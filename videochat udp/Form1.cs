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

namespace videochat_udp
{
    public partial class Form1 : Form
    {
        [Serializable]
        public class FileDetails
        {
            public string FILESIZE = "";
        }

        private Bitmap actualFrame;

        private Mirror filter = new Mirror(false, true);
        private ResizeNearestNeighbor filterSize = new ResizeNearestNeighbor(454, 346);

        private FileDetails fileDet = new FileDetails();
        private FileDetails fileDet2 = new FileDetails();
        private Thread receiveThread, sendThread;

        private byte[] sendedBytes;
        private byte[] receivedBytes;

        private Random random = new Random();
        EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
        private MemoryStream memStr = null;

        public FilterInfoCollection recordingDevices = null;
        public VideoCaptureDevice videoSource = null;
        static IPAddress remoteAddress; // хост для отправки данных
        static int remotePort; // порт для отправки данных
        int localPort; // локальный порт для прослушивания входящих подключений

        //UdpClient sender = null;
        static Socket receiveSocket;
        IPEndPoint endPoint;

        public Form1()
        {
            InitializeComponent();
            try
            {
                //remoteAddress = IPAddress.Parse("127.0.0.1");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recordingDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo f in recordingDevices)
            {
                comboBox1.Items.Add(f.Name);
            }
            comboBox1.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
            /* Event which will be invoked when new frame is arrived */

            
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (actualFrame != null) actualFrame.Dispose();
            actualFrame = (Bitmap)eventArgs.Frame.Clone();
            filter.ApplyInPlace(actualFrame);
            if (myVideoPictureBox.Image != null) this.Invoke(new MethodInvoker(delegate () { myVideoPictureBox.Image.Dispose(); }));
            myVideoPictureBox.Image = filterSize.Apply(actualFrame);
            /*Every new frame will be sended to another user */
            if(remoteAddress.ToString() != "0.0.0.0" && remoteAddress != null)
            {
               // MessageBox.Show("Start Frame sended");
                SendVideo(endPoint, actualFrame);
               
            }
        }
        UdpClient client;
        private void ReceiveMessage()
        {
                client = new UdpClient(localPort);
                while (true)
                {
                    if(friendVideoPictureBox.Image!= null) friendVideoPictureBox.Image.Dispose();
                    GetFile();
                }
        }

        public void SendVideo(IPEndPoint endPoint, Image img)
        {
            ImageConverter _imageConverter = new ImageConverter();
            Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Byte[] arrImage = ms.ToArray();
            //MessageBox.Show("Rozmiar arrImage = ", arrImage.Length.ToString());
            if (arrImage.Length < 60000)
            {
                listeningSocket.SendTo(arrImage, endPoint);
            }
            else
            {

                int parts = arrImage.Length / 60000;
                int fixedLength = arrImage.Length;
                int drift = 0;
                FileStream fs = new FileStream("temp.jpeg", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
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
               // MessageBox.Show("Completed!");
            }
        }

        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            remoteAddress = IPAddress.Parse(textBox1.Text);
            remotePort = Convert.ToInt32(textBox3.Text);
            localPort = Convert.ToInt32(textBox2.Text);

            endPoint = new IPEndPoint(remoteAddress, remotePort);
            

            if (remoteAddress.ToString() == "0.0.0.0")
            {
               // //receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), localPort);
               // receiveSocket.Bind(localIP);

                receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
            }

            if (remoteAddress.ToString() != "0.0.0.0" && remoteAddress != null)
            {
                //sendThread = new Thread(new ThreadStart(SendMessage));
                //sendThread.Start();
            }
            videoSource = new VideoCaptureDevice(recordingDevices[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            videoSource.Stop();
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
                        Byte[] arrImage = client.Receive(ref endP);
                        ms.Write(arrImage, 0, arrImage.Length);
                        if (arrImage.Length < 60000) break;
                    }
                    Image rcvdImage = (Bitmap)((new ImageConverter()).ConvertFrom(ms.ToArray()));
                    friendVideoPictureBox.Image = filterSize.Apply((Bitmap)rcvdImage);
                  //  MessageBox.Show("FILE GETTED!");
                }
            }
            catch (Exception eR)
            {
                MessageBox.Show("GET FILE: " + eR.ToString() + "STACK TRACE: " + eR.StackTrace);
            }
        } 
    }
}

