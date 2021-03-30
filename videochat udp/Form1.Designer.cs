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
            this.myVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.friendVideoPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.localLbl = new System.Windows.Forms.Label();
            this.remoteLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.myVideoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendVideoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // myVideoPictureBox
            // 
            this.myVideoPictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.myVideoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.myVideoPictureBox.Name = "myVideoPictureBox";
            this.myVideoPictureBox.Size = new System.Drawing.Size(454, 346);
            this.myVideoPictureBox.TabIndex = 0;
            this.myVideoPictureBox.TabStop = false;
            // 
            // friendVideoPictureBox
            // 
            this.friendVideoPictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.friendVideoPictureBox.Location = new System.Drawing.Point(500, 12);
            this.friendVideoPictureBox.Name = "friendVideoPictureBox";
            this.friendVideoPictureBox.Size = new System.Drawing.Size(454, 346);
            this.friendVideoPictureBox.TabIndex = 1;
            this.friendVideoPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connect To";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(798, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(879, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 377);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(330, 379);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(520, 379);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            // 
            // localLbl
            // 
            this.localLbl.AutoSize = true;
            this.localLbl.Location = new System.Drawing.Point(272, 382);
            this.localLbl.Name = "localLbl";
            this.localLbl.Size = new System.Drawing.Size(52, 13);
            this.localLbl.TabIndex = 8;
            this.localLbl.Text = "LocalPort";
            // 
            // remoteLbl
            // 
            this.remoteLbl.AutoSize = true;
            this.remoteLbl.Location = new System.Drawing.Point(451, 382);
            this.remoteLbl.Name = "remoteLbl";
            this.remoteLbl.Size = new System.Drawing.Size(63, 13);
            this.remoteLbl.TabIndex = 9;
            this.remoteLbl.Text = "RemotePort";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(648, 376);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(966, 416);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.remoteLbl);
            this.Controls.Add(this.localLbl);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.friendVideoPictureBox);
            this.Controls.Add(this.myVideoPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myVideoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendVideoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox myVideoPictureBox;
        private System.Windows.Forms.PictureBox friendVideoPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label localLbl;
        private System.Windows.Forms.Label remoteLbl;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

