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
    public partial class MainWindow : Form
    {
        /* Obiekt klasy uzytkownika */
        Client newUser = null;

        /* Zmienne opisujace wideo urzadzenia */
        public FilterInfoCollection recordingDevices = null;
        public VideoCaptureDevice videoSource = null;

        #region Program variables
        bool isMenuActivated = false, isMicrophoneEnabled = true, isCameraEnabled = true;
        private System.Drawing.Point lastPoint;
        #endregion


        public MainWindow()
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
            headerPanel.BackColor = Color.FromArgb(0,0,0);
            optionPanel.BackColor = Color.FromArgb(112, 128, 144);
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
            newUser?.Disconnect();
            this.Close();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            /* Inicjalizacja portow oraz adresu */
            string remoteAddress = textBox1.Text;
            string remoteVideoPort = textBox3.Text;
            string localVideoPort = textBox2.Text;
            string remoteAudioPort = remoteAudio.Text;
            string localAudioPort = localAudio.Text;
            newUser = new Client(remoteAddress, localAudioPort, remoteAudioPort, localVideoPort, remoteVideoPort, this, recordingDevices[comboBox1.SelectedIndex].MonikerString);
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            newUser.Disconnect();
            newUser = null;
        }

        private void microphoneBox_Click(object sender, EventArgs e)
        {
            if(isMicrophoneEnabled)
            {
                isMicrophoneEnabled = false;
                microphoneBox.Image = Properties.Resources.offmicrophone;
                newUser.ChangeMicrophoneStatus(true);
            }
            else
            {
                isMicrophoneEnabled = true;
                microphoneBox.Image = Properties.Resources.microphone;
                newUser.ChangeMicrophoneStatus(false);
            }
        }

        private void cameraBox_Click(object sender, EventArgs e)
        {
            if (isCameraEnabled)
            {
                isCameraEnabled = false;
                cameraBox.Image = Properties.Resources.offcamera;
                this.Invoke(new MethodInvoker(delegate () { newUser.ChangeCameraStatus(true); }));
                if (myVideoPictureBox.Image != null) this.Invoke(new MethodInvoker(delegate () {
                    myVideoPictureBox.Image.Dispose();
                    myVideoPictureBox.Invalidate();
                }));
                myVideoPictureBox.Image = Properties.Resources.cameraOff;
            }
            else
            {
                isCameraEnabled = true;
                cameraBox.Image = Properties.Resources.camera;
                newUser.ChangeCameraStatus(false);
            }
        }
    }
}

