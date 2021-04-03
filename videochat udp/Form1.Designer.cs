namespace videochat_udp
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.localLbl = new System.Windows.Forms.Label();
            this.remoteLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.optionPanel = new System.Windows.Forms.Panel();
            this.menuLabel = new System.Windows.Forms.Label();
            this.cameraBox = new System.Windows.Forms.PictureBox();
            this.microphoneBox = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.myVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.friendVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.headerPanel.SuspendLayout();
            this.optionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.microphoneBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myVideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendVideoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connect To";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 79);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(84, 111);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(170, 20);
            this.textBox3.TabIndex = 7;
            // 
            // localLbl
            // 
            this.localLbl.AutoSize = true;
            this.localLbl.Location = new System.Drawing.Point(7, 82);
            this.localLbl.Name = "localLbl";
            this.localLbl.Size = new System.Drawing.Size(60, 13);
            this.localLbl.TabIndex = 8;
            this.localLbl.Text = "LocalVideo";
            // 
            // remoteLbl
            // 
            this.remoteLbl.AutoSize = true;
            this.remoteLbl.Location = new System.Drawing.Point(7, 114);
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
            this.comboBox1.Location = new System.Drawing.Point(6, 233);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(248, 21);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "VideoChat by @maybedot";
            // 
            // optionPanel
            // 
            this.optionPanel.Controls.Add(this.cameraBox);
            this.optionPanel.Controls.Add(this.microphoneBox);
            this.optionPanel.Controls.Add(this.menuLabel);
            this.optionPanel.Controls.Add(this.pictureBox4);
            this.optionPanel.Controls.Add(this.label1);
            this.optionPanel.Controls.Add(this.textBox1);
            this.optionPanel.Controls.Add(this.localLbl);
            this.optionPanel.Controls.Add(this.textBox2);
            this.optionPanel.Controls.Add(this.remoteLbl);
            this.optionPanel.Controls.Add(this.textBox3);
            this.optionPanel.Controls.Add(this.button1);
            this.optionPanel.Controls.Add(this.button2);
            this.optionPanel.Controls.Add(this.comboBox1);
            this.optionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.optionPanel.Location = new System.Drawing.Point(2, 48);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(291, 461);
            this.optionPanel.TabIndex = 21;
            // 
            // menuLabel
            // 
            this.menuLabel.AutoSize = true;
            this.menuLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuLabel.Location = new System.Drawing.Point(115, 13);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(48, 18);
            this.menuLabel.TabIndex = 12;
            this.menuLabel.Text = "MENU";
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
            this.pictureBox4.Location = new System.Drawing.Point(6, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
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
            // Form1
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.optionPanel.ResumeLayout(false);
            this.optionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.microphoneBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myVideoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendVideoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label localLbl;
        private System.Windows.Forms.Label remoteLbl;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox friendVideoPictureBox;
        private System.Windows.Forms.PictureBox myVideoPictureBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel optionPanel;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox cameraBox;
        private System.Windows.Forms.PictureBox microphoneBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

