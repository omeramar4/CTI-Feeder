using System;

namespace Winform {
    partial class MyForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
            this.StepXLbl = new System.Windows.Forms.Label();
            this.StepZLbl = new System.Windows.Forms.Label();
            this.ZoomLbl = new System.Windows.Forms.Label();
            this.errBox = new System.Windows.Forms.RichTextBox();
            this.CameraConnectionBtn = new System.Windows.Forms.Button();
            this.UpDownLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SafeLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.EstopBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joysticksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crevisConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noModemLbl = new System.Windows.Forms.Label();
            this.NoConnectionLbl = new System.Windows.Forms.Label();
            this.ConnectionLbl = new System.Windows.Forms.Label();
            this.ConnectionPicBox = new System.Windows.Forms.PictureBox();
            this.NoConnectionPicBox = new System.Windows.Forms.PictureBox();
            this.HornPicBox = new System.Windows.Forms.PictureBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoConnectionPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HornPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StepXLbl
            // 
            this.StepXLbl.BackColor = System.Drawing.Color.Yellow;
            this.StepXLbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.StepXLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StepXLbl.Location = new System.Drawing.Point(930, 70);
            this.StepXLbl.Name = "StepXLbl";
            this.StepXLbl.Size = new System.Drawing.Size(70, 46);
            this.StepXLbl.TabIndex = 7;
            this.StepXLbl.Text = "0";
            this.StepXLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StepZLbl
            // 
            this.StepZLbl.AllowDrop = true;
            this.StepZLbl.BackColor = System.Drawing.Color.Yellow;
            this.StepZLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StepZLbl.Location = new System.Drawing.Point(25, 70);
            this.StepZLbl.Name = "StepZLbl";
            this.StepZLbl.Size = new System.Drawing.Size(70, 46);
            this.StepZLbl.TabIndex = 8;
            this.StepZLbl.Text = "0";
            this.StepZLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZoomLbl
            // 
            this.ZoomLbl.AutoSize = true;
            this.ZoomLbl.BackColor = System.Drawing.Color.Yellow;
            this.ZoomLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ZoomLbl.Location = new System.Drawing.Point(458, 55);
            this.ZoomLbl.Name = "ZoomLbl";
            this.ZoomLbl.Size = new System.Drawing.Size(0, 20);
            this.ZoomLbl.TabIndex = 9;
            // 
            // errBox
            // 
            this.errBox.Location = new System.Drawing.Point(12, 291);
            this.errBox.Name = "errBox";
            this.errBox.Size = new System.Drawing.Size(358, 78);
            this.errBox.TabIndex = 11;
            this.errBox.Text = "";
            this.errBox.Visible = false;
            // 
            // CameraConnectionBtn
            // 
            this.CameraConnectionBtn.BackColor = System.Drawing.Color.Red;
            this.CameraConnectionBtn.Enabled = false;
            this.CameraConnectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraConnectionBtn.Location = new System.Drawing.Point(248, 110);
            this.CameraConnectionBtn.Name = "CameraConnectionBtn";
            this.CameraConnectionBtn.Size = new System.Drawing.Size(556, 266);
            this.CameraConnectionBtn.TabIndex = 13;
            this.CameraConnectionBtn.Text = "אין תמונה, נהג במשנה זהירות";
            this.CameraConnectionBtn.UseVisualStyleBackColor = false;
            this.CameraConnectionBtn.Visible = false;
            // 
            // UpDownLbl
            // 
            this.UpDownLbl.BackColor = System.Drawing.Color.Yellow;
            this.UpDownLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UpDownLbl.Location = new System.Drawing.Point(929, 44);
            this.UpDownLbl.Name = "UpDownLbl";
            this.UpDownLbl.Size = new System.Drawing.Size(70, 20);
            this.UpDownLbl.TabIndex = 15;
            this.UpDownLbl.Text = "הרמה";
            this.UpDownLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "עגלה";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SafeLbl
            // 
            this.SafeLbl.AutoSize = true;
            this.SafeLbl.BackColor = System.Drawing.Color.Orange;
            this.SafeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SafeLbl.Location = new System.Drawing.Point(415, 44);
            this.SafeLbl.Name = "SafeLbl";
            this.SafeLbl.Size = new System.Drawing.Size(194, 39);
            this.SafeLbl.TabIndex = 18;
            this.SafeLbl.Text = "אין תקשורת";
            this.SafeLbl.Visible = false;
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Lime;
            this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(16, 409);
            this.startBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(192, 208);
            this.startBtn.TabIndex = 20;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Visible = false;
            this.startBtn.Click += new System.EventHandler(this.EstopBtn_Click);
            // 
            // EstopBtn
            // 
            this.EstopBtn.BackColor = System.Drawing.Color.Red;
            this.EstopBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EstopBtn.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstopBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EstopBtn.Location = new System.Drawing.Point(16, 502);
            this.EstopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.EstopBtn.Name = "EstopBtn";
            this.EstopBtn.Size = new System.Drawing.Size(154, 115);
            this.EstopBtn.TabIndex = 21;
            this.EstopBtn.Text = "Stop";
            this.EstopBtn.UseVisualStyleBackColor = false;
            this.EstopBtn.Visible = false;
            this.EstopBtn.Click += new System.EventHandler(this.EstopBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configurationsToolStripMenuItem
            // 
            this.configurationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joysticksToolStripMenuItem,
            this.buttonsToolStripMenuItem,
            this.relaysToolStripMenuItem,
            this.crevisConfigurationToolStripMenuItem});
            this.configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
            this.configurationsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.configurationsToolStripMenuItem.Text = "Settings";
            // 
            // joysticksToolStripMenuItem
            // 
            this.joysticksToolStripMenuItem.Name = "joysticksToolStripMenuItem";
            this.joysticksToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.joysticksToolStripMenuItem.Text = "Joystick Configuration";
            this.joysticksToolStripMenuItem.Click += new System.EventHandler(this.JoystickConfBtn_Click);
            // 
            // buttonsToolStripMenuItem
            // 
            this.buttonsToolStripMenuItem.Name = "buttonsToolStripMenuItem";
            this.buttonsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.buttonsToolStripMenuItem.Text = "Button Configuration";
            this.buttonsToolStripMenuItem.Click += new System.EventHandler(this.ButtonConfBtn_Click);
            // 
            // relaysToolStripMenuItem
            // 
            this.relaysToolStripMenuItem.Name = "relaysToolStripMenuItem";
            this.relaysToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.relaysToolStripMenuItem.Text = "Relay Configuration";
            this.relaysToolStripMenuItem.Click += new System.EventHandler(this.RelayConfBtn_Click);
            // 
            // crevisConfigurationToolStripMenuItem
            // 
            this.crevisConfigurationToolStripMenuItem.Name = "crevisConfigurationToolStripMenuItem";
            this.crevisConfigurationToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.crevisConfigurationToolStripMenuItem.Text = "Crevis Configuration";
            this.crevisConfigurationToolStripMenuItem.Click += new System.EventHandler(this.crevisConfigurationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // noModemLbl
            // 
            this.noModemLbl.BackColor = System.Drawing.Color.Orange;
            this.noModemLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noModemLbl.Location = new System.Drawing.Point(146, 110);
            this.noModemLbl.Name = "noModemLbl";
            this.noModemLbl.Size = new System.Drawing.Size(706, 323);
            this.noModemLbl.TabIndex = 28;
            this.noModemLbl.Text = "נצרה סגורה";
            this.noModemLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noModemLbl.Visible = false;
            // 
            // NoConnectionLbl
            // 
            this.NoConnectionLbl.AutoSize = true;
            this.NoConnectionLbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoConnectionLbl.Location = new System.Drawing.Point(917, 533);
            this.NoConnectionLbl.Name = "NoConnectionLbl";
            this.NoConnectionLbl.Size = new System.Drawing.Size(75, 29);
            this.NoConnectionLbl.TabIndex = 32;
            this.NoConnectionLbl.Text = "לא זמין";
            // 
            // ConnectionLbl
            // 
            this.ConnectionLbl.AutoSize = true;
            this.ConnectionLbl.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionLbl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLbl.Location = new System.Drawing.Point(929, 551);
            this.ConnectionLbl.Name = "ConnectionLbl";
            this.ConnectionLbl.Size = new System.Drawing.Size(46, 29);
            this.ConnectionLbl.TabIndex = 33;
            this.ConnectionLbl.Text = "זמין";
            // 
            // ConnectionPicBox
            // 
            this.ConnectionPicBox.BackColor = System.Drawing.Color.Black;
            this.ConnectionPicBox.Image = global::Winform.Properties.Resources.On;
            this.ConnectionPicBox.Location = new System.Drawing.Point(903, 521);
            this.ConnectionPicBox.Name = "ConnectionPicBox";
            this.ConnectionPicBox.Size = new System.Drawing.Size(97, 96);
            this.ConnectionPicBox.TabIndex = 30;
            this.ConnectionPicBox.TabStop = false;
            this.ConnectionPicBox.Visible = false;
            // 
            // NoConnectionPicBox
            // 
            this.NoConnectionPicBox.BackColor = System.Drawing.Color.Black;
            this.NoConnectionPicBox.Image = global::Winform.Properties.Resources.Off;
            this.NoConnectionPicBox.Location = new System.Drawing.Point(890, 489);
            this.NoConnectionPicBox.Name = "NoConnectionPicBox";
            this.NoConnectionPicBox.Size = new System.Drawing.Size(129, 128);
            this.NoConnectionPicBox.TabIndex = 31;
            this.NoConnectionPicBox.TabStop = false;
            this.NoConnectionPicBox.Visible = false;
            // 
            // HornPicBox
            // 
            this.HornPicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HornPicBox.Image = global::Winform.Properties.Resources.Horn3;
            this.HornPicBox.ImageLocation = "";
            this.HornPicBox.Location = new System.Drawing.Point(921, 410);
            this.HornPicBox.Name = "HornPicBox";
            this.HornPicBox.Size = new System.Drawing.Size(64, 63);
            this.HornPicBox.TabIndex = 29;
            this.HornPicBox.TabStop = false;
            this.HornPicBox.Click += new System.EventHandler(this.HornPicBox_Click);
            // 
            // imageBox
            // 
            this.imageBox.BackColor = System.Drawing.SystemColors.Window;
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(8, 5);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(1013, 690);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 8;
            this.imageBox.TabStop = false;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 705);
            this.Controls.Add(this.ConnectionLbl);
            this.Controls.Add(this.NoConnectionLbl);
            this.Controls.Add(this.ConnectionPicBox);
            this.Controls.Add(this.NoConnectionPicBox);
            this.Controls.Add(this.HornPicBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.noModemLbl);
            this.Controls.Add(this.EstopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.SafeLbl);
            this.Controls.Add(this.ZoomLbl);
            this.Controls.Add(this.CameraConnectionBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpDownLbl);
            this.Controls.Add(this.StepZLbl);
            this.Controls.Add(this.StepXLbl);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.errBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FEEDER";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoConnectionPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HornPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Label StepXLbl;
        private System.Windows.Forms.Label StepZLbl;
        private System.Windows.Forms.Label ZoomLbl;
        private System.Windows.Forms.RichTextBox errBox;
        private System.Windows.Forms.Button CameraConnectionBtn;
        private System.Windows.Forms.Label UpDownLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SafeLbl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button EstopBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configurationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label noModemLbl;
        private System.Windows.Forms.ToolStripMenuItem joysticksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crevisConfigurationToolStripMenuItem;
        private System.Windows.Forms.PictureBox HornPicBox;
        private System.Windows.Forms.PictureBox ConnectionPicBox;
        private System.Windows.Forms.PictureBox NoConnectionPicBox;
        private System.Windows.Forms.Label NoConnectionLbl;
        private System.Windows.Forms.Label ConnectionLbl;
    }
}

