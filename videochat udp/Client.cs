using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace videochat_udp
{
    public class Client
    {
        private Bitmap actualFrame;

        /* Filter lustrzany oraz rozmiaru*/
        private Mirror filter = new Mirror(false, true);
        private ResizeNearestNeighbor filterSize = new ResizeNearestNeighbor(481, 451);

        /* Zmienne opisujace wideo urzadzenia */
        public FilterInfoCollection recordingDevices = null;
        public VideoCaptureDevice videoSource = null;

        /* Watki do odbierania audio i wideo */
        Thread listeningAudioThread, listeningVideoThread;
        
        /* Klient do odbierania wideo */
        UdpClient videoClient;

        /* Klient do odbierania oraz wysylki audio */
        Socket audioClient, listeningAudioSocket, listeningVideoSocket;
        
        /* Strumien wejsciowego audio */
        WaveIn inputAudio;

        /* Strumien przychodzacego audio */
        WaveOut outputAudio;

        /* Bufor do przechowywania odebranego audio */
        BufferedWaveProvider bufferStream;

        /* Punkty dostarczania wideo oraz audio */
        private IPEndPoint remoteVideo, remoteAudio;
        private int localAudioPort, localVideoPort;
        private string remoteAddress;

        bool cameraOffFlag = false;

        MainWindow clientView;

        public Client(string remoteAddress, string localAudioPort, string remoteAudio, string localVideoPort, string remoteVideo, MainWindow window, string videoMoniker)
        {
            recordingDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            this.remoteVideo = new IPEndPoint(IPAddress.Parse(remoteAddress), Convert.ToInt32(remoteVideo));
            this.remoteAudio = new IPEndPoint(IPAddress.Parse(remoteAddress), Convert.ToInt32(remoteAudio));

            this.localAudioPort = Convert.ToInt32(localAudioPort);
            this.localVideoPort = Convert.ToInt32(localVideoPort);

            this.remoteAddress = remoteAddress;

            videoSource = new VideoCaptureDevice(videoMoniker);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);

            bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));

            inputAudio = new WaveIn();
            outputAudio = new WaveOut();
            outputAudio.Init(bufferStream);
            inputAudio.DataAvailable += Voice_Input;
            inputAudio.WaveFormat = new WaveFormat(8000, 16, 1);
            audioClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            listeningAudioSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            listeningVideoSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            clientView = window;

            listeningAudioThread = new Thread(new ThreadStart(GetAudio));
            listeningAudioThread.Start();
            listeningVideoThread = new Thread(new ThreadStart(GetVideo));
            listeningVideoThread.Start();

            videoSource.Start();
            inputAudio.StartRecording();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            /* Zwolnienie pamieci */
            if (actualFrame != null) actualFrame.Dispose();
            /* Kopiowanie obrazka dostarczonego przez kamere */
            actualFrame = (Bitmap)eventArgs.Frame.Clone();
            /* Zastosowanie filtra lustra */
            filter.ApplyInPlace(actualFrame);
            /* Usuniecie poprzedniego obrazka u klienta */
            if (clientView.myVideoPictureBox.Image != null) clientView.Invoke(new MethodInvoker(delegate () { clientView.myVideoPictureBox.Image.Dispose(); }));
            /* Zaladowanie nowego obrazka */
            clientView.myVideoPictureBox.Image = filterSize.Apply(actualFrame);
            /*Wyslanie obecnego obrazka do partnera*/
            SendVideo(actualFrame);
        }

        public void SendVideo(Image img)
        {
            /* socket do wyslania wiadomosci */
            /* Zapisanie obrazka w strumieniu pamiecowym */
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            /* Konwertowanie obrazka na tablice bajtow */
            Byte[] arrImage = ms.ToArray();
            /* Funkcja wykonujaca segmentacje datagramow UDP */
            if (arrImage.Length < 60000)
                listeningVideoSocket.SendTo(arrImage, remoteVideo);
            else
            {
                int parts = arrImage.Length / 60000;
                int fixedLength = arrImage.Length;
                int drift = 0;
                for (int i = 0; i < parts + 1; i++)
                {
                    if (fixedLength - 60000 >= 0)
                    {
                        listeningVideoSocket.SendTo(arrImage, drift, 60000, SocketFlags.None, remoteVideo);
                        fixedLength -= 60000;
                        drift += 60000;
                    }
                    else
                    {
                        listeningVideoSocket.SendTo(arrImage, drift, fixedLength, SocketFlags.None, remoteVideo);
                    }
                }
            }
        }

        private void Voice_Input(object sender, WaveInEventArgs e)
        {
            try
            {
                IPEndPoint remotePoint = remoteAudio;
                audioClient.SendTo(e.Buffer, remotePoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetAudio()
        {
            listeningAudioSocket.Bind(new IPEndPoint(IPAddress.Parse(remoteAddress), localAudioPort));
            outputAudio.Play();
            EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] data = new byte[65535];
                int receivedBytes = listeningAudioSocket.ReceiveFrom(data, ref remoteIp);
                bufferStream.AddSamples(data, 0, receivedBytes);
            }
        }

        public void GetVideo()
        {
            videoClient = new UdpClient(localVideoPort);
            while (true)
            {
                /* Usuniecie odebranego obrazka poprzedniego */
                if (clientView.friendVideoPictureBox.Image != null) clientView.friendVideoPictureBox.Image.Dispose();
                /* Pobranie nowego obrazka */
                try
                {
                    IPEndPoint endP = new IPEndPoint(IPAddress.Any, 0);
                    while (true)
                    {
                        MemoryStream ms = new MemoryStream();
                        for (int i = 0; i < 3; i++)
                        {
                            /* Pobranie kolejnych danych */
                            Byte[] arrImage = videoClient.Receive(ref endP);
                            if (Encoding.UTF8.GetString(arrImage) == "cameraoff")
                            {
                                clientView.friendVideoPictureBox.Image = Properties.Resources.cameraOff;
                                /* Zamykamy strumien aby Image nie odczytal niepoprawny ciag */
                                ms.Close();
                                break;
                            }
                            else
                            if (Encoding.UTF8.GetString(arrImage) == "cameraon")
                            {
                                /* Zamykamy strumien aby Image nie odczytal niepoprawny ciag */
                                ms.Close();
                                break;
                            }
                            /* Dopisanie danych do strumienia */
                            ms.Write(arrImage, 0, arrImage.Length);
                            /* Jezeli odebrany datagram <60000 to znaczy ze jest koncowy datagram wiec konczymy */
                            if (arrImage.Length < 60000) break;
                        }
                        /* Sprawdzanie czy strumien nie jest zamkniety */
                        if (ms.CanRead)
                        {
                            /* Konwertowanie tablicy bajtow na obrazek */
                            Image rcvdImage = (Bitmap)((new ImageConverter()).ConvertFrom(ms.ToArray()));
                            /* Aktualizacja odebranego obrazka */
                            clientView.friendVideoPictureBox.Image = filterSize.Apply((Bitmap)rcvdImage);
                        }
                    }
                }
                catch (Exception eR)
                {
                    MessageBox.Show("Get file error: " + eR.ToString());
                }
            }
        }

        public void Disconnect()
        {
            CloseAudio();
            CloseVideo();
            CloseClient();
        }

        private void CloseAudio()
        {
            listeningAudioSocket?.Close();
            if (outputAudio != null)
            {
                outputAudio.Stop();
                outputAudio.Dispose();
                outputAudio = null;
            }
            if (inputAudio != null)
            {
                inputAudio.StopRecording();
                inputAudio.Dispose();
                inputAudio = null;
            }
        }

        private void CloseVideo()
        {
            videoSource.Stop();
            clientView.myVideoPictureBox.Image = null;
            clientView.myVideoPictureBox.Invalidate();
            listeningVideoSocket?.Close();
        }

        private void CloseClient()
        {
            audioClient?.Close();
            videoClient?.Close();
        }

        public void ChangeMicrophoneStatus(bool isDisabled)
        {
            if (isDisabled)
            {
                inputAudio.StopRecording();
            }
            else inputAudio.StartRecording();
        }

        public void ChangeCameraStatus(bool isDisabled)
        {
            if (isDisabled && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                listeningVideoSocket.SendTo(Encoding.UTF8.GetBytes("cameraoff"), remoteVideo);
            }
            else
            {
                videoSource.Start();
                listeningVideoSocket.SendTo(Encoding.UTF8.GetBytes("cameraon"), remoteVideo);
            }
        }
    }
}
