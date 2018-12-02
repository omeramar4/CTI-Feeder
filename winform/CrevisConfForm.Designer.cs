namespace Winform
{
    partial class CrevisConfForm
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
            this.TimeoutLbl = new System.Windows.Forms.Label();
            this.TimeoutTextBox = new System.Windows.Forms.TextBox();
            this.SecLbl = new System.Windows.Forms.Label();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.TimeoutIsSetImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutIsSetImg)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeoutLbl
            // 
            this.TimeoutLbl.AutoSize = true;
            this.TimeoutLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeoutLbl.Location = new System.Drawing.Point(12, 17);
            this.TimeoutLbl.Name = "TimeoutLbl";
            this.TimeoutLbl.Size = new System.Drawing.Size(78, 20);
            this.TimeoutLbl.TabIndex = 0;
            this.TimeoutLbl.Text = "Timeout:";
            // 
            // TimeoutTextBox
            // 
            this.TimeoutTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeoutTextBox.Location = new System.Drawing.Point(96, 16);
            this.TimeoutTextBox.Name = "TimeoutTextBox";
            this.TimeoutTextBox.Size = new System.Drawing.Size(71, 23);
            this.TimeoutTextBox.TabIndex = 1;
            // 
            // SecLbl
            // 
            this.SecLbl.AutoSize = true;
            this.SecLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecLbl.Location = new System.Drawing.Point(170, 20);
            this.SecLbl.Name = "SecLbl";
            this.SecLbl.Size = new System.Drawing.Size(32, 15);
            this.SecLbl.TabIndex = 2;
            this.SecLbl.Text = "(ms)";
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyBtn.Location = new System.Drawing.Point(141, 265);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(87, 29);
            this.ApplyBtn.TabIndex = 3;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.Location = new System.Drawing.Point(234, 265);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(87, 29);
            this.CloseBtn.TabIndex = 4;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // TimeoutIsSetImg
            // 
            this.TimeoutIsSetImg.Image = global::Winform.Properties.Resources.Check2;
            this.TimeoutIsSetImg.Location = new System.Drawing.Point(208, 12);
            this.TimeoutIsSetImg.Name = "TimeoutIsSetImg";
            this.TimeoutIsSetImg.Size = new System.Drawing.Size(33, 34);
            this.TimeoutIsSetImg.TabIndex = 24;
            this.TimeoutIsSetImg.TabStop = false;
            this.TimeoutIsSetImg.Visible = false;
            // 
            // CrevisConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 306);
            this.Controls.Add(this.TimeoutIsSetImg);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.SecLbl);
            this.Controls.Add(this.TimeoutTextBox);
            this.Controls.Add(this.TimeoutLbl);
            this.Name = "CrevisConfForm";
            this.Text = "CrevisConfForm";
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutIsSetImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TimeoutLbl;
        private System.Windows.Forms.TextBox TimeoutTextBox;
        private System.Windows.Forms.Label SecLbl;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.PictureBox TimeoutIsSetImg;
    }
}