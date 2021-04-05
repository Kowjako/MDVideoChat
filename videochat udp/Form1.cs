using System;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using System.Threading.Tasks;
using NAudio.Wave;

namespace videochat_udp
{
    public partial class Form1 : Form
    {
        private Bitmap actualFrame;

        /* Filter lustrzany oraz rozmiaru*/
        private Mirror filter = new Mirror(false, true);
        private ResizeNearestNeighbor filterSize = new ResizeNearestNeighbor(481, 451);

        /* Watek do odbierania wiadomosci */
        private Thread receiveThread;

        /* Zmienne opisujace wideo urzadzenia */
        public FilterInfoCollection recordingDevices = null;
        public VideoCaptureDevice videoSource = null;

        /* Adres na ktory wysylamy dane */
        static IPAddress remoteAddress;
        /* Port na ktory wysylamy dane */
        static int remotePort;
        /* Port na ktorym odbieramy dane */
        int localPort; 

        /* UDP klient do odbierania wiadomosci */
        UdpClient client;
        /* Adres IP odbiorcy naszych wiadomosci */
        IPEndPoint endPoint;

        #region Program variables
        bool isMenuActivated = false, isMicrophoneEnabled = true, isCameraEnabled = true;
        private System.Drawing.Point lastPoint;
        #endregion

        /* INICJALIZACJA DLA AUDIO */
        Socket audioClient, listenAudioSocket;
        WaveIn inputAudio;
        WaveOut outputAudio;
        BufferedWaveProvider bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
        Thread listeningAudioThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyles();
            /* Tworzenie kolekcji dostepnych wideo urzadzen */
            recordingDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo f in recordingDevices)
            {
                /* tworzenie listy dostepnych wideo urzadzen */
                comboBox1.Items.Add(f.Name); 
            }
            /* Domyslnie wybierane pierwsze urzadzenie */ 
            comboBox1.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
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
            if (myVideoPictureBox.Image != null) this.Invoke(new MethodInvoker(delegate () { myVideoPictureBox.Image.Dispose(); }));
            /* Zaladowanie nowego obrazka */
            myVideoPictureBox.Image = filterSize.Apply(actualFrame);
            /*Wyslanie obecnego obrazka do partnera*/
            SendVideo(endPoint, actualFrame);
        }

        private void ReceiveMessage()
        {
                /* Tworzenie UDP Clienta do odebrania wiadomosci na swoim porcie */
                client = new UdpClient(localPort);
                while (true)
                {
                    /* Usuniecie odebranego obrazka poprzedniego */
                    if(myVideoPictureBox.Image!= null) myVideoPictureBox.Image.Dispose();
                    /* Pobranie nowego obrazka */
                    GetFile();
                }
        }

        public void SendVideo(IPEndPoint endPoint, Image img)
        {
            /* socket do wyslania wiadomosci */
            Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            /* Zapisanie obrazka w strumieniu pamiecowym */
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            /* Konwertowanie obrazka na tablice bajtow */
            Byte[] arrImage = ms.ToArray();
            /* Funkcja wykonujaca segmentacje datagramow UDP */
            if (arrImage.Length < 60000)
                listeningSocket.SendTo(arrImage, endPoint);
            else
            {
                int parts = arrImage.Length / 60000;
                int fixedLength = arrImage.Length;
                int drift = 0;
                for (int i = 0; i < parts + 1; i++)
                {
                    if (fixedLength - 60000 >= 0)
                    {
                        listeningSocket.SendTo(arrImage, drift, 60000, SocketFlags.None, endPoint);
                        fixedLength -= 60000;
                        drift += 60000;
                    }
                    else
                    {
                        listeningSocket.SendTo(arrImage, drift, fixedLength, SocketFlags.None, endPoint);
                    }
                }
            }
        }

        public void GetFile()
        {
            try
            {
                
                IPEndPoint endP = new IPEndPoint(IPAddress.Any, 0);
                while(true)
                {
                    MemoryStream ms = new MemoryStream();
                    for (int i=0;i<3;i++)
                    {
                        /* Pobranie kolejnych danych */
                        Byte[] arrImage = client.Receive(ref endP);
                        /* Dopisanie danych do strumienia */
                        ms.Write(arrImage, 0, arrImage.Length);
                        /* Jezeli odebrany datagram <60000 to znaczy ze jest koncowy datagram wiec konczymy */
                        if (arrImage.Length < 60000) break;
                    }
                    /* Konwertowanie tablicy bajtow na obrazek */
                    Image rcvdImage = (Bitmap)((new ImageConverter()).ConvertFrom(ms.ToArray()));
                    /* Aktualizacja odebranego obrazka */
                    friendVideoPictureBox.Image = filterSize.Apply((Bitmap)rcvdImage);
                }
            }
            catch (Exception eR)
            {
                MessageBox.Show("Get file error: "+eR.ToString());
            }
        }

        private void SetStyles()
        {
            label1.Visible = false;
            localLbl.Visible = false;
            remoteLbl.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            connectBtn.Visible = false;
            disconnectBtn.Visible = false;
            comboBox1.Visible = false;
            audioLbl.Visible = false;
            remoteAudioLbl.Visible = false;
            localAudio.Visible = false;
            remoteAudio.Visible = false;
            optionPanel.Size = new Size(42, 467);
            headerPanel.BackColor = Color.FromArgb(1, 46, 103);
            optionPanel.BackColor = Color.FromArgb(156, 172, 191);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!isMenuActivated)
            {
                optionPanel.Size = new Size(266, 467);
                label1.Visible = true;
                localLbl.Visible = true;
                remoteLbl.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                connectBtn.Visible = true;
                disconnectBtn.Visible = true;
                comboBox1.Visible = true;
                isMenuActivated = true;
                audioLbl.Visible = true;
                remoteAudioLbl.Visible = true;
                localAudio.Visible = true;
                remoteAudio.Visible = true;
            }
            else
            {
                label1.Visible = false;
                localLbl.Visible = false;
                remoteLbl.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                connectBtn.Visible = false;
                disconnectBtn.Visible = false;
                comboBox1.Visible = false;
                audioLbl.Visible = false;
                remoteAudioLbl.Visible = false;
                localAudio.Visible = false;
                remoteAudio.Visible = false;
                optionPanel.Size = new Size(42, 467);
                isMenuActivated = false;
            }
        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y);
        }


        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Top += e.Y - lastPoint.Y;
                this.Left += e.X - lastPoint.X;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            /* Inicjalizacja portow oraz adresu */
            remoteAddress = IPAddress.Parse(textBox1.Text);
            remotePort = Convert.ToInt32(textBox3.Text);
            localPort = Convert.ToInt32(textBox2.Text);

            endPoint = new IPEndPoint(remoteAddress, remotePort);

            /* Tworzenia watka do odbierania wiadomosci */
            receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start();

            /* Uruchomienie nagrywania kamerki */
            videoSource = new VideoCaptureDevice(recordingDevices[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();

            inputAudio = new WaveIn();
            outputAudio = new WaveOut();
            outputAudio.Init(bufferStream);
            /* PRACA Z DZWIEKIEM */
            inputAudio.DataAvailable += Voice_Input;
            inputAudio.WaveFormat = new WaveFormat(8000, 16, 1);
            audioClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            listenAudioSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            listeningAudioThread = new Thread(new ThreadStart(GetAudio));
            listeningAudioThread.Start();
            inputAudio.StartRecording();
        }

        private void GetAudio()
        {
            IPEndPoint localIP = new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(localAudio.Text));
            listenAudioSocket.Bind(localIP);
            outputAudio.Play();
            EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] data = new byte[65535];
                int receivedBytes = listenAudioSocket.ReceiveFrom(data, ref remoteIp);
                bufferStream.AddSamples(data, 0, receivedBytes);
            }
        }

        private void Voice_Input(object sender, WaveInEventArgs e)
        {
            try
            {
                IPEndPoint remotePoint = new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(remoteAudio.Text));
                audioClient.SendTo(e.Buffer, remotePoint);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            /* Zatrzymanie nagrywania kamerki */
            videoSource.Stop();
        }

        private void microphoneBox_Click(object sender, EventArgs e)
        {
            if(isMicrophoneEnabled)
            {
                isMicrophoneEnabled = false;
                microphoneBox.Image = Properties.Resources.offmicrophone;
            }
            else
            {
                isMicrophoneEnabled = true;
                microphoneBox.Image = Properties.Resources.microphone;
            }
        }

        private void cameraBox_Click(object sender, EventArgs e)
        {
            if (isCameraEnabled)
            {
                isCameraEnabled = false;
                cameraBox.Image = Properties.Resources.offcamera;
            }
            else
            {
                isCameraEnabled = true;
                cameraBox.Image = Properties.Resources.camera;
            }
        }
    }
}

