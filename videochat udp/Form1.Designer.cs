namespace videochat_udp
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.localLbl = new System.Windows.Forms.Label();
            this.remoteLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optionPanel = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.remoteAudio = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.localAudio = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.remoteAudioLbl = new System.Windows.Forms.Label();
            this.audioLbl = new System.Windows.Forms.Label();
            this.disconnectBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.connectBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textBox3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBox2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBox1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cameraBox = new System.Windows.Forms.PictureBox();
            this.microphoneBox = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.myVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.friendVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.optionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.microphoneBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myVideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendVideoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connect To";
            // 
            // localLbl
            // 
            this.localLbl.AutoSize = true;
            this.localLbl.Location = new System.Drawing.Point(7, 85);
            this.localLbl.Name = "localLbl";
            this.localLbl.Size = new System.Drawing.Size(60, 13);
            this.localLbl.TabIndex = 8;
            this.localLbl.Text = "LocalVideo";
            // 
            // remoteLbl
            // 
            this.remoteLbl.AutoSize = true;
            this.remoteLbl.Location = new System.Drawing.Point(6, 116);
            this.remoteLbl.Name = "remoteLbl";
            this.remoteLbl.Size = new System.Drawing.Size(71, 13);
            this.remoteLbl.TabIndex = 9;
            this.remoteLbl.Text = "RemoteVideo";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 306);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 2);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1024, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 509);
            this.panel2.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 509);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 2);
            this.panel3.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 507);
            this.panel4.TabIndex = 19;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Controls.Add(this.label2);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(2, 2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1022, 46);
            this.headerPanel.TabIndex = 20;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            this.headerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::videochat_udp.Properties.Resources.exit;
            this.pictureBox1.Location = new System.Drawing.Point(976, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "VideoChat by @maybedot";
            // 
            // optionPanel
            // 
            this.optionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionPanel.Controls.Add(this.materialLabel1);
            this.optionPanel.Controls.Add(this.remoteAudio);
            this.optionPanel.Controls.Add(this.localAudio);
            this.optionPanel.Controls.Add(this.remoteAudioLbl);
            this.optionPanel.Controls.Add(this.audioLbl);
            this.optionPanel.Controls.Add(this.disconnectBtn);
            this.optionPanel.Controls.Add(this.connectBtn);
            this.optionPanel.Controls.Add(this.textBox3);
            this.optionPanel.Controls.Add(this.textBox2);
            this.optionPanel.Controls.Add(this.textBox1);
            this.optionPanel.Controls.Add(this.cameraBox);
            this.optionPanel.Controls.Add(this.microphoneBox);
            this.optionPanel.Controls.Add(this.pictureBox4);
            this.optionPanel.Controls.Add(this.label1);
            this.optionPanel.Controls.Add(this.localLbl);
            this.optionPanel.Controls.Add(this.remoteLbl);
            this.optionPanel.Controls.Add(this.comboBox1);
            this.optionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.optionPanel.Location = new System.Drawing.Point(2, 48);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(262, 461);
            this.optionPanel.TabIndex = 21;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(102, 14);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(71, 19);
            this.materialLabel1.TabIndex = 24;
            this.materialLabel1.Text = "OPTIONS";
            // 
            // remoteAudio
            // 
            this.remoteAudio.Depth = 0;
            this.remoteAudio.Hint = "";
            this.remoteAudio.Location = new System.Drawing.Point(83, 170);
            this.remoteAudio.MouseState = MaterialSkin.MouseState.HOVER;
            this.remoteAudio.Name = "remoteAudio";
            this.remoteAudio.PasswordChar = '\0';
            this.remoteAudio.SelectedText = "";
            this.remoteAudio.SelectionLength = 0;
            this.remoteAudio.SelectionStart = 0;
            this.remoteAudio.Size = new System.Drawing.Size(170, 23);
            this.remoteAudio.TabIndex = 23;
            this.remoteAudio.UseSystemPasswordChar = false;
            // 
            // localAudio
            // 
            this.localAudio.Depth = 0;
            this.localAudio.Hint = "";
            this.localAudio.Location = new System.Drawing.Point(83, 140);
            this.localAudio.MouseState = MaterialSkin.MouseState.HOVER;
            this.localAudio.Name = "localAudio";
            this.localAudio.PasswordChar = '\0';
            this.localAudio.SelectedText = "";
            this.localAudio.SelectionLength = 0;
            this.localAudio.SelectionStart = 0;
            this.localAudio.Size = new System.Drawing.Size(170, 23);
            this.localAudio.TabIndex = 22;
            this.localAudio.UseSystemPasswordChar = false;
            // 
            // remoteAudioLbl
            // 
            this.remoteAudioLbl.AutoSize = true;
            this.remoteAudioLbl.Location = new System.Drawing.Point(6, 180);
            this.remoteAudioLbl.Name = "remoteAudioLbl";
            this.remoteAudioLbl.Size = new System.Drawing.Size(71, 13);
            this.remoteAudioLbl.TabIndex = 21;
            this.remoteAudioLbl.Text = "RemoteAudio";
            // 
            // audioLbl
            // 
            this.audioLbl.AutoSize = true;
            this.audioLbl.Location = new System.Drawing.Point(6, 150);
            this.audioLbl.Name = "audioLbl";
            this.audioLbl.Size = new System.Drawing.Size(60, 13);
            this.audioLbl.TabIndex = 20;
            this.audioLbl.Text = "LocalAudio";
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Depth = 0;
            this.disconnectBtn.Location = new System.Drawing.Point(9, 259);
            this.disconnectBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Primary = true;
            this.disconnectBtn.Size = new System.Drawing.Size(245, 41);
            this.disconnectBtn.TabIndex = 19;
            this.disconnectBtn.Text = "DISCONNECT";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Depth = 0;
            this.connectBtn.Location = new System.Drawing.Point(9, 212);
            this.connectBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Primary = true;
            this.connectBtn.Size = new System.Drawing.Size(245, 41);
            this.connectBtn.TabIndex = 18;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // textBox3
            // 
            this.textBox3.Depth = 0;
            this.textBox3.Hint = "";
            this.textBox3.Location = new System.Drawing.Point(84, 110);
            this.textBox3.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.SelectedText = "";
            this.textBox3.SelectionLength = 0;
            this.textBox3.SelectionStart = 0;
            this.textBox3.Size = new System.Drawing.Size(170, 23);
            this.textBox3.TabIndex = 17;
            this.textBox3.UseSystemPasswordChar = false;
            // 
            // textBox2
            // 
            this.textBox2.Depth = 0;
            this.textBox2.Hint = "";
            this.textBox2.Location = new System.Drawing.Point(84, 81);
            this.textBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.Size = new System.Drawing.Size(170, 23);
            this.textBox2.TabIndex = 16;
            this.textBox2.UseSystemPasswordChar = false;
            // 
            // textBox1
            // 
            this.textBox1.Depth = 0;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Hint = "";
            this.textBox1.Location = new System.Drawing.Point(84, 52);
            this.textBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.Size = new System.Drawing.Size(170, 23);
            this.textBox1.TabIndex = 15;
            this.textBox1.UseSystemPasswordChar = false;
            // 
            // cameraBox
            // 
            this.cameraBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cameraBox.Image = global::videochat_udp.Properties.Resources.camera;
            this.cameraBox.Location = new System.Drawing.Point(6, 427);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(30, 30);
            this.cameraBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cameraBox.TabIndex = 14;
            this.cameraBox.TabStop = false;
            this.cameraBox.Click += new System.EventHandler(this.cameraBox_Click);
            // 
            // microphoneBox
            // 
            this.microphoneBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.microphoneBox.Image = global::videochat_udp.Properties.Resources.microphone;
            this.microphoneBox.Location = new System.Drawing.Point(6, 391);
            this.microphoneBox.Name = "microphoneBox";
            this.microphoneBox.Size = new System.Drawing.Size(30, 30);
            this.microphoneBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.microphoneBox.TabIndex = 13;
            this.microphoneBox.TabStop = false;
            this.microphoneBox.Click += new System.EventHandler(this.microphoneBox_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::videochat_udp.Properties.Resources.menuicon;
            this.pictureBox4.Location = new System.Drawing.Point(5, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // myVideoPictureBox
            // 
            this.myVideoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myVideoPictureBox.Location = new System.Drawing.Point(50, 54);
            this.myVideoPictureBox.Name = "myVideoPictureBox";
            this.myVideoPictureBox.Size = new System.Drawing.Size(481, 451);
            this.myVideoPictureBox.TabIndex = 17;
            this.myVideoPictureBox.TabStop = false;
            // 
            // friendVideoPictureBox
            // 
            this.friendVideoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.friendVideoPictureBox.Location = new System.Drawing.Point(537, 54);
            this.friendVideoPictureBox.Name = "friendVideoPictureBox";
            this.friendVideoPictureBox.Size = new System.Drawing.Size(481, 451);
            this.friendVideoPictureBox.TabIndex = 16;
            this.friendVideoPictureBox.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1026, 511);
            this.Controls.Add(this.optionPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.myVideoPictureBox);
            this.Controls.Add(this.friendVideoPictureBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.optionPanel.ResumeLayout(false);
            this.optionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.microphoneBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myVideoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendVideoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label localLbl;
        private System.Windows.Forms.Label remoteLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel optionPanel;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox cameraBox;
        private System.Windows.Forms.PictureBox microphoneBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBox3;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBox2;
        private MaterialSkin.Controls.MaterialRaisedButton connectBtn;
        private MaterialSkin.Controls.MaterialRaisedButton disconnectBtn;
        private MaterialSkin.Controls.MaterialSingleLineTextField remoteAudio;
        private MaterialSkin.Controls.MaterialSingleLineTextField localAudio;
        private System.Windows.Forms.Label remoteAudioLbl;
        private System.Windows.Forms.Label audioLbl;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox friendVideoPictureBox;
        public System.Windows.Forms.PictureBox myVideoPictureBox;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}

