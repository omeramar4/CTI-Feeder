namespace Winform
{
    partial class RelayConfForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Relay1Btn = new System.Windows.Forms.Button();
            this.Relay2Btn = new System.Windows.Forms.Button();
            this.Relay3Btn = new System.Windows.Forms.Button();
            this.Relay4Btn = new System.Windows.Forms.Button();
            this.Relay5Btn = new System.Windows.Forms.Button();
            this.Relay6Btn = new System.Windows.Forms.Button();
            this.Relay7Btn = new System.Windows.Forms.Button();
            this.Relay8Btn = new System.Windows.Forms.Button();
            this.Relay12Btn = new System.Windows.Forms.Button();
            this.Relay11Btn = new System.Windows.Forms.Button();
            this.Relay10Btn = new System.Windows.Forms.Button();
            this.Relay9Btn = new System.Windows.Forms.Button();
            this.SetBtn = new System.Windows.Forms.Button();
            this.ClearRelayBtn = new System.Windows.Forms.Button();
            this.CollLbl = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Estop Relay",
            "Start Relay",
            "Up/Down Relays",
            "Cart Relays",
            "Horn Relay"});
            this.comboBox1.Location = new System.Drawing.Point(16, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Choose...";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Relay1Btn
            // 
            this.Relay1Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay1Btn.Location = new System.Drawing.Point(16, 154);
            this.Relay1Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay1Btn.Name = "Relay1Btn";
            this.Relay1Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay1Btn.TabIndex = 1;
            this.Relay1Btn.Text = "Relay 1";
            this.Relay1Btn.UseVisualStyleBackColor = true;
            this.Relay1Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay2Btn
            // 
            this.Relay2Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay2Btn.Location = new System.Drawing.Point(184, 154);
            this.Relay2Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay2Btn.Name = "Relay2Btn";
            this.Relay2Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay2Btn.TabIndex = 2;
            this.Relay2Btn.Text = "Relay 2";
            this.Relay2Btn.UseVisualStyleBackColor = true;
            this.Relay2Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay3Btn
            // 
            this.Relay3Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay3Btn.Location = new System.Drawing.Point(352, 154);
            this.Relay3Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay3Btn.Name = "Relay3Btn";
            this.Relay3Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay3Btn.TabIndex = 3;
            this.Relay3Btn.Text = "Relay 3";
            this.Relay3Btn.UseVisualStyleBackColor = true;
            this.Relay3Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay4Btn
            // 
            this.Relay4Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay4Btn.Location = new System.Drawing.Point(516, 154);
            this.Relay4Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay4Btn.Name = "Relay4Btn";
            this.Relay4Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay4Btn.TabIndex = 4;
            this.Relay4Btn.Text = "Relay 4";
            this.Relay4Btn.UseVisualStyleBackColor = true;
            this.Relay4Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay5Btn
            // 
            this.Relay5Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay5Btn.Location = new System.Drawing.Point(16, 241);
            this.Relay5Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay5Btn.Name = "Relay5Btn";
            this.Relay5Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay5Btn.TabIndex = 5;
            this.Relay5Btn.Text = "Relay 5";
            this.Relay5Btn.UseVisualStyleBackColor = true;
            this.Relay5Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay6Btn
            // 
            this.Relay6Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay6Btn.Location = new System.Drawing.Point(184, 241);
            this.Relay6Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay6Btn.Name = "Relay6Btn";
            this.Relay6Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay6Btn.TabIndex = 6;
            this.Relay6Btn.Text = "Relay 6";
            this.Relay6Btn.UseVisualStyleBackColor = true;
            this.Relay6Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay7Btn
            // 
            this.Relay7Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay7Btn.Location = new System.Drawing.Point(352, 241);
            this.Relay7Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay7Btn.Name = "Relay7Btn";
            this.Relay7Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay7Btn.TabIndex = 7;
            this.Relay7Btn.Text = "Relay 7";
            this.Relay7Btn.UseVisualStyleBackColor = true;
            this.Relay7Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay8Btn
            // 
            this.Relay8Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay8Btn.Location = new System.Drawing.Point(516, 241);
            this.Relay8Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay8Btn.Name = "Relay8Btn";
            this.Relay8Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay8Btn.TabIndex = 8;
            this.Relay8Btn.Text = "Relay 8";
            this.Relay8Btn.UseVisualStyleBackColor = true;
            this.Relay8Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay12Btn
            // 
            this.Relay12Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay12Btn.Location = new System.Drawing.Point(516, 329);
            this.Relay12Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay12Btn.Name = "Relay12Btn";
            this.Relay12Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay12Btn.TabIndex = 12;
            this.Relay12Btn.Text = "Relay 12";
            this.Relay12Btn.UseVisualStyleBackColor = true;
            this.Relay12Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay11Btn
            // 
            this.Relay11Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay11Btn.Location = new System.Drawing.Point(352, 329);
            this.Relay11Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay11Btn.Name = "Relay11Btn";
            this.Relay11Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay11Btn.TabIndex = 11;
            this.Relay11Btn.Text = "Relay 11";
            this.Relay11Btn.UseVisualStyleBackColor = true;
            this.Relay11Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay10Btn
            // 
            this.Relay10Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay10Btn.Location = new System.Drawing.Point(184, 329);
            this.Relay10Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay10Btn.Name = "Relay10Btn";
            this.Relay10Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay10Btn.TabIndex = 10;
            this.Relay10Btn.Text = "Relay 10";
            this.Relay10Btn.UseVisualStyleBackColor = true;
            this.Relay10Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // Relay9Btn
            // 
            this.Relay9Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relay9Btn.Location = new System.Drawing.Point(16, 329);
            this.Relay9Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Relay9Btn.Name = "Relay9Btn";
            this.Relay9Btn.Size = new System.Drawing.Size(160, 49);
            this.Relay9Btn.TabIndex = 9;
            this.Relay9Btn.Text = "Relay 9";
            this.Relay9Btn.UseVisualStyleBackColor = true;
            this.Relay9Btn.Click += new System.EventHandler(this.RelayBtn_Click);
            // 
            // SetBtn
            // 
            this.SetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetBtn.Location = new System.Drawing.Point(576, 15);
            this.SetBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetBtn.Name = "SetBtn";
            this.SetBtn.Size = new System.Drawing.Size(100, 28);
            this.SetBtn.TabIndex = 13;
            this.SetBtn.Text = "Set";
            this.SetBtn.UseVisualStyleBackColor = true;
            this.SetBtn.Click += new System.EventHandler(this.SetBtn_Click);
            // 
            // ClearRelayBtn
            // 
            this.ClearRelayBtn.Location = new System.Drawing.Point(252, 16);
            this.ClearRelayBtn.Name = "ClearRelayBtn";
            this.ClearRelayBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearRelayBtn.TabIndex = 14;
            this.ClearRelayBtn.Text = "Clear";
            this.ClearRelayBtn.UseVisualStyleBackColor = true;
            this.ClearRelayBtn.Click += new System.EventHandler(this.ClearRelayBtn_Click);
            // 
            // CollLbl
            // 
            this.CollLbl.AutoSize = true;
            this.CollLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollLbl.ForeColor = System.Drawing.Color.Red;
            this.CollLbl.Location = new System.Drawing.Point(11, 419);
            this.CollLbl.Name = "CollLbl";
            this.CollLbl.Size = new System.Drawing.Size(187, 25);
            this.CollLbl.TabIndex = 15;
            this.CollLbl.Text = "Collision Detected";
            this.CollLbl.Visible = false;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.Location = new System.Drawing.Point(516, 489);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(164, 48);
            this.CloseBtn.TabIndex = 16;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // RelayConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 549);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.CollLbl);
            this.Controls.Add(this.ClearRelayBtn);
            this.Controls.Add(this.SetBtn);
            this.Controls.Add(this.Relay12Btn);
            this.Controls.Add(this.Relay11Btn);
            this.Controls.Add(this.Relay10Btn);
            this.Controls.Add(this.Relay9Btn);
            this.Controls.Add(this.Relay8Btn);
            this.Controls.Add(this.Relay7Btn);
            this.Controls.Add(this.Relay6Btn);
            this.Controls.Add(this.Relay5Btn);
            this.Controls.Add(this.Relay4Btn);
            this.Controls.Add(this.Relay3Btn);
            this.Controls.Add(this.Relay2Btn);
            this.Controls.Add(this.Relay1Btn);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RelayConfForm";
            this.Text = "RelayConfForm";
            this.Load += new System.EventHandler(this.Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Relay1Btn;
        private System.Windows.Forms.Button Relay2Btn;
        private System.Windows.Forms.Button Relay3Btn;
        private System.Windows.Forms.Button Relay4Btn;
        private System.Windows.Forms.Button Relay5Btn;
        private System.Windows.Forms.Button Relay6Btn;
        private System.Windows.Forms.Button Relay7Btn;
        private System.Windows.Forms.Button Relay8Btn;
        private System.Windows.Forms.Button Relay12Btn;
        private System.Windows.Forms.Button Relay11Btn;
        private System.Windows.Forms.Button Relay10Btn;
        private System.Windows.Forms.Button Relay9Btn;
        private System.Windows.Forms.Button SetBtn;
        private System.Windows.Forms.Button ClearRelayBtn;
        private System.Windows.Forms.Label CollLbl;
        private System.Windows.Forms.Button CloseBtn;
    }
}