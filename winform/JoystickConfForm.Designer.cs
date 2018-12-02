namespace Winform
{
    partial class JoystickConfForm
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
            this.MainTab = new System.Windows.Forms.TabControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.ZChosen = new System.Windows.Forms.PictureBox();
            this.RotZChosen = new System.Windows.Forms.PictureBox();
            this.YChosen = new System.Windows.Forms.PictureBox();
            this.RotYChosen = new System.Windows.Forms.PictureBox();
            this.XChosen = new System.Windows.Forms.PictureBox();
            this.RotXChosen = new System.Windows.Forms.PictureBox();
            this.ZoomUnassignedLbl = new System.Windows.Forms.Label();
            this.CartUnassignedLbl = new System.Windows.Forms.Label();
            this.UpDownUnassignedLbl = new System.Windows.Forms.Label();
            this.InstructionLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RotZLbl = new System.Windows.Forms.Label();
            this.YLbl = new System.Windows.Forms.Label();
            this.RotYLbl = new System.Windows.Forms.Label();
            this.XLbl = new System.Windows.Forms.Label();
            this.RotXLbl = new System.Windows.Forms.Label();
            this.ProgZ = new System.Windows.Forms.ProgressBar();
            this.ProgRotZ = new System.Windows.Forms.ProgressBar();
            this.ProgY = new System.Windows.Forms.ProgressBar();
            this.ProgRotY = new System.Windows.Forms.ProgressBar();
            this.ProgX = new System.Windows.Forms.ProgressBar();
            this.ProgRotX = new System.Windows.Forms.ProgressBar();
            this.UpTab = new System.Windows.Forms.TabPage();
            this.OkUpDownInvImg = new System.Windows.Forms.PictureBox();
            this.OkUpDownSensImg = new System.Windows.Forms.PictureBox();
            this.OkUpDownStepImg = new System.Windows.Forms.PictureBox();
            this.InvMovUpDownLbl = new System.Windows.Forms.Label();
            this.IsInvertUpDownCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyChangesUpBtn = new System.Windows.Forms.Button();
            this.ErrorUpStepLbl = new System.Windows.Forms.Label();
            this.SensUpBar = new System.Windows.Forms.TrackBar();
            this.NumOfStepsUpTxtBx = new System.Windows.Forms.TextBox();
            this.SensUpLbl = new System.Windows.Forms.Label();
            this.NumOfstepsUpLbl = new System.Windows.Forms.Label();
            this.CartTab = new System.Windows.Forms.TabPage();
            this.OkCartInvImg = new System.Windows.Forms.PictureBox();
            this.OkCartSensImg = new System.Windows.Forms.PictureBox();
            this.OkCartStepImg = new System.Windows.Forms.PictureBox();
            this.InvMovCartLbl = new System.Windows.Forms.Label();
            this.IsInvertCartCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyChangesCartLbl = new System.Windows.Forms.Button();
            this.SensCartBar = new System.Windows.Forms.TrackBar();
            this.NumOfStepsCartTxtBx = new System.Windows.Forms.TextBox();
            this.ErrorCartStepLbl = new System.Windows.Forms.Label();
            this.SensCartLbl = new System.Windows.Forms.Label();
            this.NumOfStepsCartLbl = new System.Windows.Forms.Label();
            this.ZoomTab = new System.Windows.Forms.TabPage();
            this.ApplyChangesZoomLbl = new System.Windows.Forms.Button();
            this.OkZoomInvImg = new System.Windows.Forms.PictureBox();
            this.InvMovZoomLbl = new System.Windows.Forms.Label();
            this.isInvertZoomCheckBox = new System.Windows.Forms.CheckBox();
            this.TypeTab = new System.Windows.Forms.TabPage();
            this.AutoCheckBox = new System.Windows.Forms.CheckBox();
            this.ApemCheckBox = new System.Windows.Forms.CheckBox();
            this.ChooseLbl = new System.Windows.Forms.Label();
            this.CloseConfBtn = new System.Windows.Forms.Button();
            this.MainTab.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZChosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotZChosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YChosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotYChosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XChosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotXChosen)).BeginInit();
            this.UpTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OkUpDownInvImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkUpDownSensImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkUpDownStepImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensUpBar)).BeginInit();
            this.CartTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OkCartInvImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkCartSensImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkCartStepImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensCartBar)).BeginInit();
            this.ZoomTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OkZoomInvImg)).BeginInit();
            this.TypeTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.GeneralTab);
            this.MainTab.Controls.Add(this.UpTab);
            this.MainTab.Controls.Add(this.CartTab);
            this.MainTab.Controls.Add(this.ZoomTab);
            this.MainTab.Controls.Add(this.TypeTab);
            this.MainTab.Location = new System.Drawing.Point(12, 12);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(633, 429);
            this.MainTab.TabIndex = 0;
            // 
            // GeneralTab
            // 
            this.GeneralTab.Controls.Add(this.ZChosen);
            this.GeneralTab.Controls.Add(this.RotZChosen);
            this.GeneralTab.Controls.Add(this.YChosen);
            this.GeneralTab.Controls.Add(this.RotYChosen);
            this.GeneralTab.Controls.Add(this.XChosen);
            this.GeneralTab.Controls.Add(this.RotXChosen);
            this.GeneralTab.Controls.Add(this.ZoomUnassignedLbl);
            this.GeneralTab.Controls.Add(this.CartUnassignedLbl);
            this.GeneralTab.Controls.Add(this.UpDownUnassignedLbl);
            this.GeneralTab.Controls.Add(this.InstructionLbl);
            this.GeneralTab.Controls.Add(this.comboBox1);
            this.GeneralTab.Controls.Add(this.label1);
            this.GeneralTab.Controls.Add(this.RotZLbl);
            this.GeneralTab.Controls.Add(this.YLbl);
            this.GeneralTab.Controls.Add(this.RotYLbl);
            this.GeneralTab.Controls.Add(this.XLbl);
            this.GeneralTab.Controls.Add(this.RotXLbl);
            this.GeneralTab.Controls.Add(this.ProgZ);
            this.GeneralTab.Controls.Add(this.ProgRotZ);
            this.GeneralTab.Controls.Add(this.ProgY);
            this.GeneralTab.Controls.Add(this.ProgRotY);
            this.GeneralTab.Controls.Add(this.ProgX);
            this.GeneralTab.Controls.Add(this.ProgRotX);
            this.GeneralTab.Location = new System.Drawing.Point(4, 22);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Size = new System.Drawing.Size(625, 403);
            this.GeneralTab.TabIndex = 2;
            this.GeneralTab.Text = "General";
            this.GeneralTab.UseVisualStyleBackColor = true;
            // 
            // ZChosen
            // 
            this.ZChosen.Image = global::Winform.Properties.Resources.Check2;
            this.ZChosen.Location = new System.Drawing.Point(325, 275);
            this.ZChosen.Name = "ZChosen";
            this.ZChosen.Size = new System.Drawing.Size(33, 34);
            this.ZChosen.TabIndex = 28;
            this.ZChosen.TabStop = false;
            this.ZChosen.Visible = false;
            // 
            // RotZChosen
            // 
            this.RotZChosen.Image = global::Winform.Properties.Resources.Check2;
            this.RotZChosen.Location = new System.Drawing.Point(325, 231);
            this.RotZChosen.Name = "RotZChosen";
            this.RotZChosen.Size = new System.Drawing.Size(33, 34);
            this.RotZChosen.TabIndex = 27;
            this.RotZChosen.TabStop = false;
            this.RotZChosen.Visible = false;
            // 
            // YChosen
            // 
            this.YChosen.Image = global::Winform.Properties.Resources.Check2;
            this.YChosen.Location = new System.Drawing.Point(325, 187);
            this.YChosen.Name = "YChosen";
            this.YChosen.Size = new System.Drawing.Size(33, 34);
            this.YChosen.TabIndex = 26;
            this.YChosen.TabStop = false;
            this.YChosen.Visible = false;
            // 
            // RotYChosen
            // 
            this.RotYChosen.Image = global::Winform.Properties.Resources.Check2;
            this.RotYChosen.Location = new System.Drawing.Point(325, 143);
            this.RotYChosen.Name = "RotYChosen";
            this.RotYChosen.Size = new System.Drawing.Size(33, 34);
            this.RotYChosen.TabIndex = 25;
            this.RotYChosen.TabStop = false;
            this.RotYChosen.Visible = false;
            // 
            // XChosen
            // 
            this.XChosen.Image = global::Winform.Properties.Resources.Check2;
            this.XChosen.Location = new System.Drawing.Point(325, 99);
            this.XChosen.Name = "XChosen";
            this.XChosen.Size = new System.Drawing.Size(33, 34);
            this.XChosen.TabIndex = 24;
            this.XChosen.TabStop = false;
            this.XChosen.Visible = false;
            // 
            // RotXChosen
            // 
            this.RotXChosen.Image = global::Winform.Properties.Resources.Check2;
            this.RotXChosen.Location = new System.Drawing.Point(324, 55);
            this.RotXChosen.Name = "RotXChosen";
            this.RotXChosen.Size = new System.Drawing.Size(33, 34);
            this.RotXChosen.TabIndex = 23;
            this.RotXChosen.TabStop = false;
            this.RotXChosen.Visible = false;
            // 
            // ZoomUnassignedLbl
            // 
            this.ZoomUnassignedLbl.AutoSize = true;
            this.ZoomUnassignedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomUnassignedLbl.ForeColor = System.Drawing.Color.Red;
            this.ZoomUnassignedLbl.Location = new System.Drawing.Point(4, 371);
            this.ZoomUnassignedLbl.Name = "ZoomUnassignedLbl";
            this.ZoomUnassignedLbl.Size = new System.Drawing.Size(370, 17);
            this.ZoomUnassignedLbl.TabIndex = 22;
            this.ZoomUnassignedLbl.Text = "NOTICE: zoom axis is not assigned to any joystick";
            this.ZoomUnassignedLbl.Visible = false;
            // 
            // CartUnassignedLbl
            // 
            this.CartUnassignedLbl.AutoSize = true;
            this.CartUnassignedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CartUnassignedLbl.ForeColor = System.Drawing.Color.Red;
            this.CartUnassignedLbl.Location = new System.Drawing.Point(4, 347);
            this.CartUnassignedLbl.Name = "CartUnassignedLbl";
            this.CartUnassignedLbl.Size = new System.Drawing.Size(360, 17);
            this.CartUnassignedLbl.TabIndex = 21;
            this.CartUnassignedLbl.Text = "NOTICE: cart axis is not assigned to any joystick";
            this.CartUnassignedLbl.Visible = false;
            // 
            // UpDownUnassignedLbl
            // 
            this.UpDownUnassignedLbl.AutoSize = true;
            this.UpDownUnassignedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpDownUnassignedLbl.ForeColor = System.Drawing.Color.Red;
            this.UpDownUnassignedLbl.Location = new System.Drawing.Point(4, 322);
            this.UpDownUnassignedLbl.Name = "UpDownUnassignedLbl";
            this.UpDownUnassignedLbl.Size = new System.Drawing.Size(392, 17);
            this.UpDownUnassignedLbl.TabIndex = 20;
            this.UpDownUnassignedLbl.Text = "NOTICE: up/down axis is not assigned to any joystick";
            this.UpDownUnassignedLbl.Visible = false;
            // 
            // InstructionLbl
            // 
            this.InstructionLbl.AutoSize = true;
            this.InstructionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionLbl.Location = new System.Drawing.Point(134, 23);
            this.InstructionLbl.Name = "InstructionLbl";
            this.InstructionLbl.Size = new System.Drawing.Size(453, 13);
            this.InstructionLbl.TabIndex = 19;
            this.InstructionLbl.Text = "To set this axis hold the desired joystick to the maximum for at least 3 seconds";
            this.InstructionLbl.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Up/Down",
            "Cart",
            "Zoom"});
            this.comboBox1.Location = new System.Drawing.Point(7, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Choose Axis";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Z:";
            // 
            // RotZLbl
            // 
            this.RotZLbl.AutoSize = true;
            this.RotZLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotZLbl.Location = new System.Drawing.Point(3, 242);
            this.RotZLbl.Name = "RotZLbl";
            this.RotZLbl.Size = new System.Drawing.Size(99, 20);
            this.RotZLbl.TabIndex = 10;
            this.RotZLbl.Text = "Rotation Z:";
            // 
            // YLbl
            // 
            this.YLbl.AutoSize = true;
            this.YLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YLbl.Location = new System.Drawing.Point(3, 198);
            this.YLbl.Name = "YLbl";
            this.YLbl.Size = new System.Drawing.Size(26, 20);
            this.YLbl.TabIndex = 9;
            this.YLbl.Text = "Y:";
            // 
            // RotYLbl
            // 
            this.RotYLbl.AutoSize = true;
            this.RotYLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotYLbl.Location = new System.Drawing.Point(3, 154);
            this.RotYLbl.Name = "RotYLbl";
            this.RotYLbl.Size = new System.Drawing.Size(100, 20);
            this.RotYLbl.TabIndex = 8;
            this.RotYLbl.Text = "Rotation Y:";
            // 
            // XLbl
            // 
            this.XLbl.AutoSize = true;
            this.XLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XLbl.Location = new System.Drawing.Point(3, 110);
            this.XLbl.Name = "XLbl";
            this.XLbl.Size = new System.Drawing.Size(26, 20);
            this.XLbl.TabIndex = 7;
            this.XLbl.Text = "X:";
            // 
            // RotXLbl
            // 
            this.RotXLbl.AutoSize = true;
            this.RotXLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotXLbl.Location = new System.Drawing.Point(3, 66);
            this.RotXLbl.Name = "RotXLbl";
            this.RotXLbl.Size = new System.Drawing.Size(100, 20);
            this.RotXLbl.TabIndex = 6;
            this.RotXLbl.Text = "Rotation X:";
            // 
            // ProgZ
            // 
            this.ProgZ.Location = new System.Drawing.Point(109, 286);
            this.ProgZ.Maximum = 66000;
            this.ProgZ.Name = "ProgZ";
            this.ProgZ.Size = new System.Drawing.Size(209, 23);
            this.ProgZ.TabIndex = 5;
            // 
            // ProgRotZ
            // 
            this.ProgRotZ.Location = new System.Drawing.Point(109, 242);
            this.ProgRotZ.Maximum = 66000;
            this.ProgRotZ.Name = "ProgRotZ";
            this.ProgRotZ.Size = new System.Drawing.Size(209, 23);
            this.ProgRotZ.TabIndex = 4;
            // 
            // ProgY
            // 
            this.ProgY.Location = new System.Drawing.Point(109, 198);
            this.ProgY.Maximum = 66000;
            this.ProgY.Name = "ProgY";
            this.ProgY.Size = new System.Drawing.Size(209, 23);
            this.ProgY.TabIndex = 3;
            // 
            // ProgRotY
            // 
            this.ProgRotY.Location = new System.Drawing.Point(109, 154);
            this.ProgRotY.Maximum = 66000;
            this.ProgRotY.Name = "ProgRotY";
            this.ProgRotY.Size = new System.Drawing.Size(209, 23);
            this.ProgRotY.TabIndex = 2;
            // 
            // ProgX
            // 
            this.ProgX.Location = new System.Drawing.Point(109, 110);
            this.ProgX.Maximum = 66000;
            this.ProgX.Name = "ProgX";
            this.ProgX.Size = new System.Drawing.Size(209, 23);
            this.ProgX.TabIndex = 1;
            // 
            // ProgRotX
            // 
            this.ProgRotX.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ProgRotX.Location = new System.Drawing.Point(109, 66);
            this.ProgRotX.Maximum = 66000;
            this.ProgRotX.Name = "ProgRotX";
            this.ProgRotX.Size = new System.Drawing.Size(209, 23);
            this.ProgRotX.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgRotX.TabIndex = 0;
            // 
            // UpTab
            // 
            this.UpTab.Controls.Add(this.OkUpDownInvImg);
            this.UpTab.Controls.Add(this.OkUpDownSensImg);
            this.UpTab.Controls.Add(this.OkUpDownStepImg);
            this.UpTab.Controls.Add(this.InvMovUpDownLbl);
            this.UpTab.Controls.Add(this.IsInvertUpDownCheckBox);
            this.UpTab.Controls.Add(this.ApplyChangesUpBtn);
            this.UpTab.Controls.Add(this.ErrorUpStepLbl);
            this.UpTab.Controls.Add(this.SensUpBar);
            this.UpTab.Controls.Add(this.NumOfStepsUpTxtBx);
            this.UpTab.Controls.Add(this.SensUpLbl);
            this.UpTab.Controls.Add(this.NumOfstepsUpLbl);
            this.UpTab.Location = new System.Drawing.Point(4, 22);
            this.UpTab.Name = "UpTab";
            this.UpTab.Padding = new System.Windows.Forms.Padding(3);
            this.UpTab.Size = new System.Drawing.Size(625, 403);
            this.UpTab.TabIndex = 0;
            this.UpTab.Text = "Up/Down";
            this.UpTab.UseVisualStyleBackColor = true;
            // 
            // OkUpDownInvImg
            // 
            this.OkUpDownInvImg.Image = global::Winform.Properties.Resources.Check2;
            this.OkUpDownInvImg.Location = new System.Drawing.Point(225, 83);
            this.OkUpDownInvImg.Name = "OkUpDownInvImg";
            this.OkUpDownInvImg.Size = new System.Drawing.Size(33, 34);
            this.OkUpDownInvImg.TabIndex = 26;
            this.OkUpDownInvImg.TabStop = false;
            this.OkUpDownInvImg.Visible = false;
            // 
            // OkUpDownSensImg
            // 
            this.OkUpDownSensImg.Image = global::Winform.Properties.Resources.Check2;
            this.OkUpDownSensImg.Location = new System.Drawing.Point(225, 43);
            this.OkUpDownSensImg.Name = "OkUpDownSensImg";
            this.OkUpDownSensImg.Size = new System.Drawing.Size(33, 34);
            this.OkUpDownSensImg.TabIndex = 25;
            this.OkUpDownSensImg.TabStop = false;
            this.OkUpDownSensImg.Visible = false;
            // 
            // OkUpDownStepImg
            // 
            this.OkUpDownStepImg.Image = global::Winform.Properties.Resources.Check2;
            this.OkUpDownStepImg.Location = new System.Drawing.Point(225, 3);
            this.OkUpDownStepImg.Name = "OkUpDownStepImg";
            this.OkUpDownStepImg.Size = new System.Drawing.Size(33, 34);
            this.OkUpDownStepImg.TabIndex = 24;
            this.OkUpDownStepImg.TabStop = false;
            this.OkUpDownStepImg.Visible = false;
            // 
            // InvMovUpDownLbl
            // 
            this.InvMovUpDownLbl.AutoSize = true;
            this.InvMovUpDownLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvMovUpDownLbl.Location = new System.Drawing.Point(6, 96);
            this.InvMovUpDownLbl.Name = "InvMovUpDownLbl";
            this.InvMovUpDownLbl.Size = new System.Drawing.Size(155, 20);
            this.InvMovUpDownLbl.TabIndex = 9;
            this.InvMovUpDownLbl.Text = "Inverse Movement";
            // 
            // IsInvertUpDownCheckBox
            // 
            this.IsInvertUpDownCheckBox.AutoSize = true;
            this.IsInvertUpDownCheckBox.Location = new System.Drawing.Point(196, 101);
            this.IsInvertUpDownCheckBox.Name = "IsInvertUpDownCheckBox";
            this.IsInvertUpDownCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsInvertUpDownCheckBox.TabIndex = 8;
            this.IsInvertUpDownCheckBox.UseVisualStyleBackColor = true;
            this.IsInvertUpDownCheckBox.CheckedChanged += new System.EventHandler(this.IsInvertUpDownCheckBox_CheckedChanged);
            // 
            // ApplyChangesUpBtn
            // 
            this.ApplyChangesUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyChangesUpBtn.Location = new System.Drawing.Point(544, 370);
            this.ApplyChangesUpBtn.Name = "ApplyChangesUpBtn";
            this.ApplyChangesUpBtn.Size = new System.Drawing.Size(75, 27);
            this.ApplyChangesUpBtn.TabIndex = 5;
            this.ApplyChangesUpBtn.Text = "Apply";
            this.ApplyChangesUpBtn.UseVisualStyleBackColor = true;
            this.ApplyChangesUpBtn.Click += new System.EventHandler(this.ApplyChangesUpBtn_Click);
            // 
            // ErrorUpStepLbl
            // 
            this.ErrorUpStepLbl.AutoSize = true;
            this.ErrorUpStepLbl.Location = new System.Drawing.Point(200, 10);
            this.ErrorUpStepLbl.Name = "ErrorUpStepLbl";
            this.ErrorUpStepLbl.Size = new System.Drawing.Size(0, 13);
            this.ErrorUpStepLbl.TabIndex = 4;
            // 
            // SensUpBar
            // 
            this.SensUpBar.Location = new System.Drawing.Point(107, 37);
            this.SensUpBar.Maximum = 5;
            this.SensUpBar.Minimum = 2;
            this.SensUpBar.Name = "SensUpBar";
            this.SensUpBar.Size = new System.Drawing.Size(104, 45);
            this.SensUpBar.TabIndex = 3;
            this.SensUpBar.Value = 5;
            // 
            // NumOfStepsUpTxtBx
            // 
            this.NumOfStepsUpTxtBx.Location = new System.Drawing.Point(158, 7);
            this.NumOfStepsUpTxtBx.Name = "NumOfStepsUpTxtBx";
            this.NumOfStepsUpTxtBx.Size = new System.Drawing.Size(53, 20);
            this.NumOfStepsUpTxtBx.TabIndex = 2;
            // 
            // SensUpLbl
            // 
            this.SensUpLbl.AutoSize = true;
            this.SensUpLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensUpLbl.Location = new System.Drawing.Point(6, 51);
            this.SensUpLbl.Name = "SensUpLbl";
            this.SensUpLbl.Size = new System.Drawing.Size(95, 20);
            this.SensUpLbl.TabIndex = 1;
            this.SensUpLbl.Text = "Sensitivity:";
            // 
            // NumOfstepsUpLbl
            // 
            this.NumOfstepsUpLbl.AutoSize = true;
            this.NumOfstepsUpLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfstepsUpLbl.Location = new System.Drawing.Point(3, 7);
            this.NumOfstepsUpLbl.Name = "NumOfstepsUpLbl";
            this.NumOfstepsUpLbl.Size = new System.Drawing.Size(149, 20);
            this.NumOfstepsUpLbl.TabIndex = 0;
            this.NumOfstepsUpLbl.Text = "Number of Steps:";
            // 
            // CartTab
            // 
            this.CartTab.Controls.Add(this.OkCartInvImg);
            this.CartTab.Controls.Add(this.OkCartSensImg);
            this.CartTab.Controls.Add(this.OkCartStepImg);
            this.CartTab.Controls.Add(this.InvMovCartLbl);
            this.CartTab.Controls.Add(this.IsInvertCartCheckBox);
            this.CartTab.Controls.Add(this.ApplyChangesCartLbl);
            this.CartTab.Controls.Add(this.SensCartBar);
            this.CartTab.Controls.Add(this.NumOfStepsCartTxtBx);
            this.CartTab.Controls.Add(this.ErrorCartStepLbl);
            this.CartTab.Controls.Add(this.SensCartLbl);
            this.CartTab.Controls.Add(this.NumOfStepsCartLbl);
            this.CartTab.Location = new System.Drawing.Point(4, 22);
            this.CartTab.Name = "CartTab";
            this.CartTab.Padding = new System.Windows.Forms.Padding(3);
            this.CartTab.Size = new System.Drawing.Size(625, 403);
            this.CartTab.TabIndex = 1;
            this.CartTab.Text = "Cart";
            this.CartTab.UseVisualStyleBackColor = true;
            // 
            // OkCartInvImg
            // 
            this.OkCartInvImg.Image = global::Winform.Properties.Resources.Check2;
            this.OkCartInvImg.Location = new System.Drawing.Point(225, 83);
            this.OkCartInvImg.Name = "OkCartInvImg";
            this.OkCartInvImg.Size = new System.Drawing.Size(33, 34);
            this.OkCartInvImg.TabIndex = 27;
            this.OkCartInvImg.TabStop = false;
            this.OkCartInvImg.Visible = false;
            // 
            // OkCartSensImg
            // 
            this.OkCartSensImg.Image = global::Winform.Properties.Resources.Check2;
            this.OkCartSensImg.Location = new System.Drawing.Point(225, 43);
            this.OkCartSensImg.Name = "OkCartSensImg";
            this.OkCartSensImg.Size = new System.Drawing.Size(33, 34);
            this.OkCartSensImg.TabIndex = 26;
            this.OkCartSensImg.TabStop = false;
            this.OkCartSensImg.Visible = false;
            // 
            // OkCartStepImg
            // 
            this.OkCartStepImg.Image = global::Winform.Properties.Resources.Check2;
            this.OkCartStepImg.Location = new System.Drawing.Point(225, 3);
            this.OkCartStepImg.Name = "OkCartStepImg";
            this.OkCartStepImg.Size = new System.Drawing.Size(33, 34);
            this.OkCartStepImg.TabIndex = 25;
            this.OkCartStepImg.TabStop = false;
            this.OkCartStepImg.Visible = false;
            // 
            // InvMovCartLbl
            // 
            this.InvMovCartLbl.AutoSize = true;
            this.InvMovCartLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvMovCartLbl.Location = new System.Drawing.Point(6, 96);
            this.InvMovCartLbl.Name = "InvMovCartLbl";
            this.InvMovCartLbl.Size = new System.Drawing.Size(160, 20);
            this.InvMovCartLbl.TabIndex = 11;
            this.InvMovCartLbl.Text = "Inverse Movement:";
            // 
            // IsInvertCartCheckBox
            // 
            this.IsInvertCartCheckBox.AutoSize = true;
            this.IsInvertCartCheckBox.Location = new System.Drawing.Point(196, 101);
            this.IsInvertCartCheckBox.Name = "IsInvertCartCheckBox";
            this.IsInvertCartCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsInvertCartCheckBox.TabIndex = 10;
            this.IsInvertCartCheckBox.UseVisualStyleBackColor = true;
            this.IsInvertCartCheckBox.CheckedChanged += new System.EventHandler(this.IsInvertCartCheckBox_CheckedChanged);
            // 
            // ApplyChangesCartLbl
            // 
            this.ApplyChangesCartLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyChangesCartLbl.Location = new System.Drawing.Point(544, 370);
            this.ApplyChangesCartLbl.Name = "ApplyChangesCartLbl";
            this.ApplyChangesCartLbl.Size = new System.Drawing.Size(75, 27);
            this.ApplyChangesCartLbl.TabIndex = 5;
            this.ApplyChangesCartLbl.Text = "Apply";
            this.ApplyChangesCartLbl.UseVisualStyleBackColor = true;
            this.ApplyChangesCartLbl.Click += new System.EventHandler(this.ApplyChangesCartLbl_Click);
            // 
            // SensCartBar
            // 
            this.SensCartBar.Location = new System.Drawing.Point(107, 37);
            this.SensCartBar.Maximum = 5;
            this.SensCartBar.Minimum = 2;
            this.SensCartBar.Name = "SensCartBar";
            this.SensCartBar.Size = new System.Drawing.Size(104, 45);
            this.SensCartBar.TabIndex = 4;
            this.SensCartBar.Value = 5;
            // 
            // NumOfStepsCartTxtBx
            // 
            this.NumOfStepsCartTxtBx.Location = new System.Drawing.Point(158, 7);
            this.NumOfStepsCartTxtBx.Name = "NumOfStepsCartTxtBx";
            this.NumOfStepsCartTxtBx.Size = new System.Drawing.Size(53, 20);
            this.NumOfStepsCartTxtBx.TabIndex = 3;
            // 
            // ErrorCartStepLbl
            // 
            this.ErrorCartStepLbl.AutoSize = true;
            this.ErrorCartStepLbl.Location = new System.Drawing.Point(200, 12);
            this.ErrorCartStepLbl.Name = "ErrorCartStepLbl";
            this.ErrorCartStepLbl.Size = new System.Drawing.Size(0, 13);
            this.ErrorCartStepLbl.TabIndex = 2;
            // 
            // SensCartLbl
            // 
            this.SensCartLbl.AutoSize = true;
            this.SensCartLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensCartLbl.Location = new System.Drawing.Point(6, 51);
            this.SensCartLbl.Name = "SensCartLbl";
            this.SensCartLbl.Size = new System.Drawing.Size(95, 20);
            this.SensCartLbl.TabIndex = 1;
            this.SensCartLbl.Text = "Sensitivity:";
            // 
            // NumOfStepsCartLbl
            // 
            this.NumOfStepsCartLbl.AutoSize = true;
            this.NumOfStepsCartLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfStepsCartLbl.Location = new System.Drawing.Point(3, 7);
            this.NumOfStepsCartLbl.Name = "NumOfStepsCartLbl";
            this.NumOfStepsCartLbl.Size = new System.Drawing.Size(149, 20);
            this.NumOfStepsCartLbl.TabIndex = 0;
            this.NumOfStepsCartLbl.Text = "Number of Steps:";
            // 
            // ZoomTab
            // 
            this.ZoomTab.Controls.Add(this.ApplyChangesZoomLbl);
            this.ZoomTab.Controls.Add(this.OkZoomInvImg);
            this.ZoomTab.Controls.Add(this.InvMovZoomLbl);
            this.ZoomTab.Controls.Add(this.isInvertZoomCheckBox);
            this.ZoomTab.Location = new System.Drawing.Point(4, 22);
            this.ZoomTab.Name = "ZoomTab";
            this.ZoomTab.Size = new System.Drawing.Size(625, 403);
            this.ZoomTab.TabIndex = 3;
            this.ZoomTab.Text = "Zoom";
            this.ZoomTab.UseVisualStyleBackColor = true;
            // 
            // ApplyChangesZoomLbl
            // 
            this.ApplyChangesZoomLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyChangesZoomLbl.Location = new System.Drawing.Point(544, 363);
            this.ApplyChangesZoomLbl.Name = "ApplyChangesZoomLbl";
            this.ApplyChangesZoomLbl.Size = new System.Drawing.Size(75, 27);
            this.ApplyChangesZoomLbl.TabIndex = 27;
            this.ApplyChangesZoomLbl.Text = "Apply";
            this.ApplyChangesZoomLbl.UseVisualStyleBackColor = true;
            this.ApplyChangesZoomLbl.Click += new System.EventHandler(this.ApplyChangesZoomLbl_Click);
            // 
            // OkZoomInvImg
            // 
            this.OkZoomInvImg.Image = global::Winform.Properties.Resources.Check2;
            this.OkZoomInvImg.Location = new System.Drawing.Point(242, 14);
            this.OkZoomInvImg.Name = "OkZoomInvImg";
            this.OkZoomInvImg.Size = new System.Drawing.Size(33, 34);
            this.OkZoomInvImg.TabIndex = 26;
            this.OkZoomInvImg.TabStop = false;
            this.OkZoomInvImg.Visible = false;
            // 
            // InvMovZoomLbl
            // 
            this.InvMovZoomLbl.AutoSize = true;
            this.InvMovZoomLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvMovZoomLbl.Location = new System.Drawing.Point(15, 19);
            this.InvMovZoomLbl.Name = "InvMovZoomLbl";
            this.InvMovZoomLbl.Size = new System.Drawing.Size(160, 20);
            this.InvMovZoomLbl.TabIndex = 13;
            this.InvMovZoomLbl.Text = "Inverse Movement:";
            // 
            // isInvertZoomCheckBox
            // 
            this.isInvertZoomCheckBox.AutoSize = true;
            this.isInvertZoomCheckBox.Location = new System.Drawing.Point(205, 24);
            this.isInvertZoomCheckBox.Name = "isInvertZoomCheckBox";
            this.isInvertZoomCheckBox.Size = new System.Drawing.Size(15, 14);
            this.isInvertZoomCheckBox.TabIndex = 12;
            this.isInvertZoomCheckBox.UseVisualStyleBackColor = true;
            this.isInvertZoomCheckBox.CheckedChanged += new System.EventHandler(this.isInvertZoomCheckBox_CheckedChanged);
            // 
            // TypeTab
            // 
            this.TypeTab.Controls.Add(this.AutoCheckBox);
            this.TypeTab.Controls.Add(this.ApemCheckBox);
            this.TypeTab.Controls.Add(this.ChooseLbl);
            this.TypeTab.Location = new System.Drawing.Point(4, 22);
            this.TypeTab.Name = "TypeTab";
            this.TypeTab.Size = new System.Drawing.Size(625, 403);
            this.TypeTab.TabIndex = 4;
            this.TypeTab.Text = "Type";
            this.TypeTab.UseVisualStyleBackColor = true;
            // 
            // AutoCheckBox
            // 
            this.AutoCheckBox.AutoSize = true;
            this.AutoCheckBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoCheckBox.Location = new System.Drawing.Point(8, 82);
            this.AutoCheckBox.Name = "AutoCheckBox";
            this.AutoCheckBox.Size = new System.Drawing.Size(68, 27);
            this.AutoCheckBox.TabIndex = 4;
            this.AutoCheckBox.Text = "Auto";
            this.AutoCheckBox.UseVisualStyleBackColor = true;
            this.AutoCheckBox.CheckedChanged += new System.EventHandler(this.AutoCheckBox_CheckedChanged);
            // 
            // ApemCheckBox
            // 
            this.ApemCheckBox.AutoSize = true;
            this.ApemCheckBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApemCheckBox.Location = new System.Drawing.Point(8, 49);
            this.ApemCheckBox.Name = "ApemCheckBox";
            this.ApemCheckBox.Size = new System.Drawing.Size(76, 27);
            this.ApemCheckBox.TabIndex = 3;
            this.ApemCheckBox.Text = "Apem";
            this.ApemCheckBox.UseVisualStyleBackColor = true;
            this.ApemCheckBox.CheckedChanged += new System.EventHandler(this.ApemCheckBox_CheckedChanged);
            // 
            // ChooseLbl
            // 
            this.ChooseLbl.AutoSize = true;
            this.ChooseLbl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseLbl.Location = new System.Drawing.Point(3, 9);
            this.ChooseLbl.Name = "ChooseLbl";
            this.ChooseLbl.Size = new System.Drawing.Size(207, 27);
            this.ChooseLbl.TabIndex = 0;
            this.ChooseLbl.Text = "Choose joystick type:";
            // 
            // CloseConfBtn
            // 
            this.CloseConfBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseConfBtn.Location = new System.Drawing.Point(560, 447);
            this.CloseConfBtn.Name = "CloseConfBtn";
            this.CloseConfBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseConfBtn.TabIndex = 1;
            this.CloseConfBtn.Text = "Close";
            this.CloseConfBtn.UseVisualStyleBackColor = true;
            this.CloseConfBtn.Click += new System.EventHandler(this.CloseConfBtn_Click);
            // 
            // JoystickConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 499);
            this.Controls.Add(this.CloseConfBtn);
            this.Controls.Add(this.MainTab);
            this.Name = "JoystickConfForm";
            this.Text = "Joystick Configurations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.MainTab.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.GeneralTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZChosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotZChosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YChosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotYChosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XChosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotXChosen)).EndInit();
            this.UpTab.ResumeLayout(false);
            this.UpTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OkUpDownInvImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkUpDownSensImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkUpDownStepImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensUpBar)).EndInit();
            this.CartTab.ResumeLayout(false);
            this.CartTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OkCartInvImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkCartSensImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkCartStepImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensCartBar)).EndInit();
            this.ZoomTab.ResumeLayout(false);
            this.ZoomTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OkZoomInvImg)).EndInit();
            this.TypeTab.ResumeLayout(false);
            this.TypeTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage UpTab;
        private System.Windows.Forms.TabPage CartTab;
        private System.Windows.Forms.Button CloseConfBtn;
        private System.Windows.Forms.Button ApplyChangesUpBtn;
        private System.Windows.Forms.Label ErrorUpStepLbl;
        private System.Windows.Forms.TrackBar SensUpBar;
        private System.Windows.Forms.TextBox NumOfStepsUpTxtBx;
        private System.Windows.Forms.Label SensUpLbl;
        private System.Windows.Forms.Label NumOfstepsUpLbl;
        private System.Windows.Forms.Button ApplyChangesCartLbl;
        private System.Windows.Forms.TrackBar SensCartBar;
        private System.Windows.Forms.TextBox NumOfStepsCartTxtBx;
        private System.Windows.Forms.Label ErrorCartStepLbl;
        private System.Windows.Forms.Label SensCartLbl;
        private System.Windows.Forms.Label NumOfStepsCartLbl;
        private System.Windows.Forms.TabPage GeneralTab;
        private System.Windows.Forms.ProgressBar ProgRotX;
        private System.Windows.Forms.ProgressBar ProgZ;
        private System.Windows.Forms.ProgressBar ProgRotZ;
        private System.Windows.Forms.ProgressBar ProgY;
        private System.Windows.Forms.ProgressBar ProgRotY;
        private System.Windows.Forms.ProgressBar ProgX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RotZLbl;
        private System.Windows.Forms.Label YLbl;
        private System.Windows.Forms.Label RotYLbl;
        private System.Windows.Forms.Label XLbl;
        private System.Windows.Forms.Label RotXLbl;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label CartUnassignedLbl;
        private System.Windows.Forms.Label UpDownUnassignedLbl;
        private System.Windows.Forms.Label InstructionLbl;
        private System.Windows.Forms.Label ZoomUnassignedLbl;
        private System.Windows.Forms.Label InvMovUpDownLbl;
        private System.Windows.Forms.CheckBox IsInvertUpDownCheckBox;
        private System.Windows.Forms.Label InvMovCartLbl;
        private System.Windows.Forms.CheckBox IsInvertCartCheckBox;
        private System.Windows.Forms.TabPage ZoomTab;
        private System.Windows.Forms.Label InvMovZoomLbl;
        private System.Windows.Forms.CheckBox isInvertZoomCheckBox;
        private System.Windows.Forms.TabPage TypeTab;
        private System.Windows.Forms.CheckBox AutoCheckBox;
        private System.Windows.Forms.CheckBox ApemCheckBox;
        private System.Windows.Forms.Label ChooseLbl;
        private System.Windows.Forms.PictureBox RotXChosen;
        private System.Windows.Forms.PictureBox ZChosen;
        private System.Windows.Forms.PictureBox RotZChosen;
        private System.Windows.Forms.PictureBox YChosen;
        private System.Windows.Forms.PictureBox RotYChosen;
        private System.Windows.Forms.PictureBox XChosen;
        private System.Windows.Forms.PictureBox OkUpDownInvImg;
        private System.Windows.Forms.PictureBox OkUpDownSensImg;
        private System.Windows.Forms.PictureBox OkUpDownStepImg;
        private System.Windows.Forms.PictureBox OkCartInvImg;
        private System.Windows.Forms.PictureBox OkCartSensImg;
        private System.Windows.Forms.PictureBox OkCartStepImg;
        private System.Windows.Forms.Button ApplyChangesZoomLbl;
        private System.Windows.Forms.PictureBox OkZoomInvImg;
    }
}