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
        bool isMenuActivated = false, isMicrophoneEnabled = true, isCameraEnabled = true, isConnected = false;
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

            /* Tworzenie kolekcji dostepnych audio urzadzen */
            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                var caps = WaveIn.GetCapabilities(n);
                comboBox2.Items.Add((caps.ProductName.Substring(caps.ProductName.IndexOf('(')+1)).TrimEnd(')'));
            }
            comboBox2.SelectedIndex = 0;
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
            comboBox2.Visible = false;
            audioLbl.Visible = false;
            remoteAudioLbl.Visible = false;
            localAudio.Visible = false;
            remoteAudio.Visible = false;
            optionPanel.Size = new Size(42, 467);
            headerPanel.BackColor = Color.FromArgb(0,0,0);
            optionPanel.BackColor = Color.FromArgb(70, 130, 180);
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
                comboBox2.Visible = true;
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
                comboBox2.Visible = false;
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
            isConnected = false;
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
            /* Sprawdzenie czy wpisane adresy oraz porty są poprawne */
            if (CheckAddressAndPort(remoteAddress, remoteVideoPort, localVideoPort, remoteAudioPort, localAudioPort))
            {
                newUser = new Client(remoteAddress, localAudioPort, remoteAudioPort, localVideoPort, remoteVideoPort, this, recordingDevices[comboBox1.SelectedIndex].MonikerString);
                isConnected = true;
            }
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            newUser?.Disconnect();
            newUser = null;
        }

        private void microphoneBox_Click(object sender, EventArgs e)
        {
            if(isMicrophoneEnabled)
            {
                isMicrophoneEnabled = false;
                microphoneBox.Image = Properties.Resources.offmicrophone;
                if(isConnected) newUser.ChangeMicrophoneStatus(true);
            }
            else
            {
                isMicrophoneEnabled = true;
                microphoneBox.Image = Properties.Resources.microphone;
                if(isConnected) newUser.ChangeMicrophoneStatus(false);
            }
        }

        private void cameraBox_Click(object sender, EventArgs e)
        {
            if (isCameraEnabled)
            {
                isCameraEnabled = false;
                cameraBox.Image = Properties.Resources.offcamera;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    if (isConnected)
                    {
                        newUser.ChangeCameraStatus(true);
                        if (myVideoPictureBox.Image != null) this.Invoke(new MethodInvoker(delegate ()
                        {
                            myVideoPictureBox.Image.Dispose();
                            myVideoPictureBox.Invalidate();
                        }));
                        myVideoPictureBox.Image = Properties.Resources.cameraOff;
                    }
                })); 
            }
            else
            {
                isCameraEnabled = true;
                cameraBox.Image = Properties.Resources.camera;
                if(isConnected) newUser.ChangeCameraStatus(false);
            }
        }

        private bool CheckAddressAndPort(params string[] param)
        {
            IPAddress validateIP = null;
            if(IPAddress.TryParse(param[0], out validateIP))
            {
                if(String.IsNullOrEmpty(param[1]))
                {
                    label2.Text = "remoteVideo cannot be empty";
                    return false;
                }
                if (String.IsNullOrEmpty(param[2]))
                {
                    label2.Text = "localVideo cannot be empty";
                    return false;
                }
                if (String.IsNullOrEmpty(param[3]))
                {
                    label2.Text = "remoteAideo cannot be empty";
                    return false;
                }
                if (String.IsNullOrEmpty(param[4]))
                {
                    label2.Text = "localAideo cannot be empty";
                    return false;
                }
                int remoteVideo = Convert.ToInt32(param[1]);
                int localVideo = Convert.ToInt32(param[2]);
                int remoteAudio = Convert.ToInt32(param[3]);
                int localAudio = Convert.ToInt32(param[4]);
                if(remoteAudio>40000 || remoteAudio<1000)
                {
                    label2.Text = "Check validity of remoteAudio Port";
                    return false;
                }
                if (localVideo > 40000 || localVideo < 1000)
                {
                    label2.Text = "Check validity of localVideo Port";
                    return false;
                }
                if (localAudio > 40000 || localAudio < 1000)
                {
                    label2.Text = "Check validity of localAudio Port";
                    return false;
                }
                if (remoteVideo > 40000 || remoteVideo < 1000)
                {
                    label2.Text = "Check validity of remoteVideo Port";
                    return false;
                }
                label2.Text = "";
                return true;
            }
            else
            {
                label2.Text = "Check validity of IP Address";
                return false;
            }
        }
    }
}

