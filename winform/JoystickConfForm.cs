using System;
using System.Drawing;
using System.Windows.Forms;
using CTI_Controller;
using System.Drawing.Drawing2D;

namespace Winform
{
    public partial class JoystickConfForm : Form
    {
        CTI_Joystick joystick = new CTI_Joystick();
        DateTime[] chooseAxis = new DateTime[6];
        private bool[] timerStart = new bool[6];
        private bool[] upDownAxisFlags = new bool[6];
        private bool[] cartAxisFlags = new bool[6];
        private bool[] zoomAxisFlags = new bool[6];
        private bool closeWindow = false;
        const int MAX_STEP = 8;
        const int MIN_STEP = 1;
        const int MAX_SENSITIVITY = 5;
        const int MIN_SENSITIVITY = 2;
        const int CENTER = 32575;       //Middle joystick value
        const int FILTER = 2500;
        public static bool isUpDownInvert = MyForm._isUpDownInvert;
        public static bool isCartInvert = MyForm._isCartInvert;
        public static bool isZoomInvert = MyForm._isZoomInvert;
        public static int upDownAxis = MyForm._axisUpDown;
        public static int cartAxis = MyForm._axisCart;
        public static int zoomAxis = MyForm._axisZoom;
        public static int numOfStepsUp = MyForm._numOfStepsUpDown;
        public static int numOfStepsCart = MyForm._numOfStepsCart;
        public static int type = MyForm._joystickType;
        public static int sensitivityUp = (MAX_SENSITIVITY + MIN_SENSITIVITY) - MyForm._sensitivityUpDown;
        public static int sensitivityCart = (MAX_SENSITIVITY + MIN_SENSITIVITY) - MyForm._sensitivityCart;
        Color[] clr = new Color[3] { Color.Orange, Color.Turquoise, Color.Crimson };

        public JoystickConfForm()
        {
            InitializeComponent();
            NumOfStepsUpTxtBx.Text = MyForm._numOfStepsUpDown.ToString();
            NumOfStepsCartTxtBx.Text = MyForm._numOfStepsCart.ToString();
            IsInvertUpDownCheckBox.Checked = isUpDownInvert;
            IsInvertCartCheckBox.Checked = isCartInvert;
            isInvertZoomCheckBox.Checked = isZoomInvert;
            if (type == 1) ApemCheckBox.Checked = true;
            if (type == 2) AutoCheckBox.Checked = true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            joystick.Acquire(true, true, true, true, true, true, true,
                                    true, true, true, true, true, true);
            
            upDownAxisFlags[upDownAxis] = true;
            cartAxisFlags[cartAxis] = true;
            zoomAxisFlags[zoomAxis] = true;

            joystick.JoystickChanged += Joystick_JoystickChanged;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (upDownAxis == -1 || cartAxis == -1 || zoomAxis == -1)
                {
                    DialogResult result = MessageBox.Show("Configuration not complete", "Error", MessageBoxButtons.OK);
                    e.Cancel = true;
                }
                else
                {
                    joystick = null;
                    closeWindow = true;
                }
            });
    
        }

        private void CirclePictureBox(PictureBox[] pics)
        {
            for (int i = 0; i < pics.Length; i++)
            {
                pics[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0, 0, pics[i].Width - 1, pics[i].Height - 1);
                pics[i].Region = new Region(gp);
            }
        }

        private void ControlVisibility(Control[] ctrl, bool[] visOrNon)     //Change Control's Visibility
        {
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < ctrl.Length; i++)
                {
                    if (visOrNon[i])
                        ctrl[i].Visible = true;
                    else
                        ctrl[i].Visible = false;
                }
            });
        }

        private void Joystick_JoystickChanged(object sender, JoystickEventArgs e)
        {
            ProgressBar prog = new ProgressBar();
            if (closeWindow) return;

            this.Invoke((MethodInvoker)delegate
            {

                if (e.ID == 0) prog = ProgRotX;
                if (e.ID == 1) prog = ProgX;
                if (e.ID == 2) prog = ProgRotY;
                if (e.ID == 3) prog = ProgY;
                if (e.ID == 4) prog = ProgRotZ;
                if (e.ID == 5) prog = ProgZ;

               prog.Value = e.value;
                
                if (e.value >= CENTER - FILTER && e.value <= CENTER + FILTER) return;

                if (comboBox1.Text == "Choose Axis") return;
                
                if (e.value > 64000 && !timerStart[e.ID])
                {
                    timerStart[e.ID] = true;
                    chooseAxis[e.ID] = DateTime.Now;
                }
                else
                {
                    if (e.value < 64000)
                    {
                        chooseAxis[e.ID] = new DateTime();
                        timerStart[e.ID] = false;
                    }
                    else
                    {
                        if ((DateTime.Now - chooseAxis[e.ID]).TotalSeconds > 3 && timerStart[e.ID])
                        {
                            if (comboBox1.Text == "Up/Down")
                            {
                                if (upDownAxis != -1) upDownAxisFlags[upDownAxis] = false;
                                upDownAxisFlags[e.ID] = true;
                                upDownAxis = e.ID;

                                if (upDownAxis == cartAxis)
                                {
                                    cartAxisFlags[cartAxis] = false;
                                    cartAxis = -1;
                                    ControlVisibility(new Control[] { CartUnassignedLbl }, new bool[] { true });
                                }
                                else if (upDownAxis != cartAxis && cartAxis != -1 && upDownAxis != -1)
                                    ControlVisibility(new Control[] { CartUnassignedLbl, UpDownUnassignedLbl }, new bool[] { false, false });

                                if (upDownAxis == zoomAxis)
                                {
                                    zoomAxisFlags[zoomAxis] = false;
                                    zoomAxis = -1;
                                    ControlVisibility(new Control[] { ZoomUnassignedLbl }, new bool[] { true });
                                }
                                else if (upDownAxis != zoomAxis && zoomAxis != -1 && upDownAxis != -1)
                                    ControlVisibility(new Control[] { ZoomUnassignedLbl, UpDownUnassignedLbl }, new bool[] { false, false });

                                ControlVisibility(new Control[] { RotXChosen, XChosen, RotYChosen, YChosen, RotZChosen, ZChosen }, upDownAxisFlags);
                            }
                            else if (comboBox1.Text == "Cart")
                            {
                                if (cartAxis != -1) cartAxisFlags[cartAxis] = false;
                                cartAxisFlags[e.ID] = true;
                                cartAxis = e.ID;

                                if (cartAxis == upDownAxis)
                                {
                                    upDownAxisFlags[upDownAxis] = false;
                                    upDownAxis = -1;
                                    ControlVisibility(new Control[] { UpDownUnassignedLbl }, new bool[] { true });
                                }
                                else if (upDownAxis != cartAxis && cartAxis != -1 && upDownAxis != -1)
                                    ControlVisibility(new Control[] { CartUnassignedLbl, UpDownUnassignedLbl }, new bool[] { false, false });

                                if (cartAxis == zoomAxis)
                                {
                                    zoomAxisFlags[zoomAxis] = false;
                                    zoomAxis = -1;
                                    ControlVisibility(new Control[] { ZoomUnassignedLbl }, new bool[] { true });
                                }
                                else if (cartAxis != zoomAxis && zoomAxis != -1 && cartAxis != -1)
                                    ControlVisibility(new Control[] { ZoomUnassignedLbl, CartUnassignedLbl }, new bool[] { false, false });

                                ControlVisibility(new Control[] { RotXChosen, XChosen, RotYChosen, YChosen, RotZChosen, ZChosen }, cartAxisFlags);
                            }
                            else if (comboBox1.Text == "Zoom")
                            {
                                if (zoomAxis != -1) zoomAxisFlags[zoomAxis] = false;
                                zoomAxisFlags[e.ID] = true;
                                zoomAxis = e.ID;

                                if (zoomAxis == upDownAxis)
                                {
                                    upDownAxisFlags[upDownAxis] = false;
                                    upDownAxis = -1;
                                    ControlVisibility(new Control[] { UpDownUnassignedLbl }, new bool[] { true });
                                }
                                else if (upDownAxis != zoomAxis && zoomAxis != -1 && upDownAxis != -1)
                                    ControlVisibility(new Control[] { ZoomUnassignedLbl, UpDownUnassignedLbl }, new bool[] { false, false });

                                if (cartAxis == zoomAxis)
                                {
                                    cartAxisFlags[cartAxis] = false;
                                    cartAxis = -1;
                                    ControlVisibility(new Control[] { CartUnassignedLbl }, new bool[] { true });
                                }
                                else if (cartAxis != zoomAxis && zoomAxis != -1 && cartAxis != -1)
                                    ControlVisibility(new Control[] { ZoomUnassignedLbl, CartUnassignedLbl }, new bool[] { false, false });

                                ControlVisibility(new Control[] { RotXChosen, XChosen, RotYChosen, YChosen, RotZChosen, ZChosen }, zoomAxisFlags);
                            }
                            chooseAxis[e.ID] = new DateTime();
                            timerStart[e.ID] = false;
                        }
                    }
                }
            });
        }

        private void CloseConfBtn_Click(object sender, EventArgs e)
        {
            if (ApemCheckBox.Checked && !AutoCheckBox.Checked) type = 1;
            if (!ApemCheckBox.Checked && AutoCheckBox.Checked) type = 2;
            this.Close();
        }

        private void ApplyChangesUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int conv = Convert.ToInt32(NumOfStepsUpTxtBx.Text);
                if (NumOfStepsUpTxtBx.Text == "" || conv < MIN_STEP || conv > MAX_STEP)
                {
                    ControlVisibility(new Control[] { OkUpDownSensImg, OkUpDownStepImg, OkUpDownInvImg }, new bool[] { false, false, false });
                    ErrorUpStepLbl.Text = "Invalid Step Value";
                }
                else
                {
                    ErrorUpStepLbl.Text = "";
                    ControlVisibility(new Control[] { OkUpDownSensImg, OkUpDownStepImg, OkUpDownInvImg }, new bool[] { true, true, true });
                    sensitivityUp = SensUpBar.Value;
                    numOfStepsUp = conv;
                }
            }
            catch
            {
                ErrorUpStepLbl.Text = "Invalid Step Value";
            }
        }

        private void ApplyChangesCartLbl_Click(object sender, EventArgs e)
        {
            string str = NumOfStepsCartTxtBx.Text;
            try
            {
                int conv = Convert.ToInt32(str);
                if (str == "" || conv < MIN_STEP || conv > MAX_STEP)
                {
                    ControlVisibility(new Control[] { OkCartSensImg, OkCartStepImg, OkCartInvImg }, new bool[] { false, false, false });
                    ErrorCartStepLbl.Text = "Invalid Step Value";
                }
                else
                {
                    ErrorCartStepLbl.Text = "";
                    ControlVisibility(new Control[] { OkCartSensImg, OkCartStepImg, OkCartInvImg }, new bool[] { true, true, true });
                    sensitivityCart = SensCartBar.Value;
                    numOfStepsCart = conv;
                }
            }
            catch
            {
                ErrorCartStepLbl.Text = "Invalid Step Value";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Up/Down")
            {
                ControlVisibility(new Control[] { RotXChosen, XChosen, RotYChosen, YChosen, RotZChosen, ZChosen }, upDownAxisFlags);
                ControlVisibility(new Control[] { InstructionLbl }, new bool[] { true });
            }
            else if (comboBox1.Text == "Cart")
            {
                ControlVisibility(new Control[] { RotXChosen, XChosen, RotYChosen, YChosen, RotZChosen, ZChosen }, cartAxisFlags);
                ControlVisibility(new Control[] { InstructionLbl }, new bool[] { true });
            }
            else if (comboBox1.Text == "Zoom")
            {
                ControlVisibility(new Control[] { RotXChosen, XChosen, RotYChosen, YChosen, RotZChosen, ZChosen }, zoomAxisFlags);
                ControlVisibility(new Control[] { InstructionLbl }, new bool[] { true });
            }
            else
            {
                ControlVisibility(new Control[] { InstructionLbl }, new bool[] { false });
            }
        }

        private ProgressBar AxisToProg(int axis)
        {
            if (axis == 0) return ProgRotX;
            else if (axis == 1) return ProgX;
            else if (axis == 2) return ProgRotY;
            else if (axis == 3) return ProgY;
            else if (axis == 4) return ProgRotZ;
            else if (axis == 5) return ProgZ;
            else return new ProgressBar();
        }

        private void IsInvertUpDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isUpDownInvert = IsInvertUpDownCheckBox.Checked;
        }

        private void IsInvertCartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isCartInvert = IsInvertCartCheckBox.Checked;
        }

        private void isInvertZoomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isZoomInvert = isInvertZoomCheckBox.Checked;
        }

        private void ApemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckBox.Checked = !ApemCheckBox.Checked;
        }

        private void AutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ApemCheckBox.Checked = !AutoCheckBox.Checked;
        }

        private void ApplyChangesZoomLbl_Click(object sender, EventArgs e)
        {
            ControlVisibility(new Control[] { OkZoomInvImg }, new bool[] { true });
        }
    }
}