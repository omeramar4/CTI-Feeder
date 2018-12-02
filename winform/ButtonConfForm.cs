using System;
using System.Drawing;
using System.Windows.Forms;
using CTI_Controller;

namespace Winform
{
    public partial class ButtonConfForm : Form
    {
        CTI_Joystick joystick = new CTI_Joystick();
        DateTime[] chooseBtn = new DateTime[32];
        bool[] timerStart = new bool[32];
        Color[] btnsClr = new Color[] { Color.Orange, Color.Turquoise, Color.Crimson };
        bool[] btnState = new bool[32];
        public static int upDownSafety = MyForm._safetyButtonUpDown;
        public static int cartSafety = MyForm._safetyButtonCart;
        public static int zoomBtn = MyForm._buttonZoom;
        private bool closeWindow = false;

        public ButtonConfForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Button[] btns = new Button[32] { Btn0, Btn1, Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9, Btn10, Btn11, Btn12, Btn13, Btn14, Btn15,
                Btn16, Btn17, Btn18, Btn19, Btn20, Btn21, Btn22, Btn23, Btn24, Btn25, Btn26, Btn27, Btn28, Btn29, Btn30, Btn31 };
            UpdateUIButtons(new Button[] { btns[upDownSafety], btns[cartSafety], btns[zoomBtn] }, new bool[] { true, true, true }, new Color[] { btnsClr[0], btnsClr[1], btnsClr[2] });

            joystick.Acquire(true, true, true, true, true, true, true,
                                    true, true, true, true, true, true);
            for (int i = 0; i < 32; i++)
            {
                joystick.enableButton(i, true);
            }
            joystick.ButtonChanged += Joystick_ButtonChanged;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (upDownSafety == -1 || cartSafety == -1 || zoomBtn == -1)
            {
                DialogResult result = MessageBox.Show("Configuration not complete", "Error", MessageBoxButtons.OK);
                e.Cancel = true;
            }
            else
            {
                joystick = null;
                closeWindow = true;
            }
        }

        private void UpdateUIButtons(Button[] btn, bool[] clr, Color[] color)     //Show Status of Connection (Red for OFF, Green for ON)
        {
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < btn.Length; i++)
                {
                    if (clr[i])
                        btn[i].BackColor = color[i];
                    else
                        btn[i].BackColor = Color.LightGray;
                }
            });
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

        private void Joystick_ButtonChanged(object sender, ButtonsEventArgs e)
        {
            Button[] btns = new Button[32] { Btn0, Btn1, Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9, Btn10, Btn11, Btn12, Btn13, Btn14, Btn15,
                Btn16, Btn17, Btn18, Btn19, Btn20, Btn21, Btn22, Btn23, Btn24, Btn25, Btn26, Btn27, Btn28, Btn29, Btn30, Btn31 };

            if (closeWindow) return;

            UpdateUIButtons(new Button[] { btns[e.ID] }, new bool[] { e.value }, new Color[] { Color.LawnGreen });
            if (e.value && !timerStart[e.ID])
            {
                btnState[e.ID] = true;
                timerStart[e.ID] = true;
                chooseBtn[e.ID] = DateTime.Now;
            }
            else
            {
                btnState[e.ID] = false;
                if (timerStart[e.ID] && (DateTime.Now - chooseBtn[e.ID]).TotalSeconds > 3)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (comboBox1.Text == "Up/Down Safety Button")
                        {
                            if (upDownSafety != -1)
                                UpdateUIButtons(new Button[] { btns[upDownSafety], btns[e.ID] }, new bool[] { false, true }, new Color[] { Color.Black, btnsClr[0] });
                            else
                                UpdateUIButtons(new Button[] { btns[e.ID] }, new bool[] { true }, new Color[] { btnsClr[0] });

                            upDownSafety = e.ID;

                            if (upDownSafety == cartSafety)
                            {
                                cartSafety = -1;
                                ControlVisibility(new Control[] { CartUnassignedLbl }, new bool[] { true });
                            }
                            else if (upDownSafety != cartSafety && cartSafety != -1 && upDownSafety != -1)
                                ControlVisibility(new Control[] { CartUnassignedLbl, UpDownUnassignedLbl }, new bool[] { false, false });

                            if (upDownSafety == zoomBtn)
                            {
                                zoomBtn = -1;
                                ControlVisibility(new Control[] { ZoomUnassignedLbl }, new bool[] { true });
                            }
                            else if (upDownSafety != zoomBtn && zoomBtn != -1 && upDownSafety != -1)
                                ControlVisibility(new Control[] { ZoomUnassignedLbl, UpDownUnassignedLbl }, new bool[] { false, false });
                        }

                        else if (comboBox1.Text == "Cart Safety Button")
                        {
                            if (cartSafety != -1)
                                UpdateUIButtons(new Button[] { btns[cartSafety], btns[e.ID] }, new bool[] { false, true }, new Color[] { Color.Black, btnsClr[1] });
                            else
                                UpdateUIButtons(new Button[] { btns[e.ID] }, new bool[] { true }, new Color[] { btnsClr[1] });

                            cartSafety = e.ID;

                            if (cartSafety == upDownSafety)
                            {
                                upDownSafety = -1;
                                ControlVisibility(new Control[] { UpDownUnassignedLbl }, new bool[] { true });
                            }
                            else if (upDownSafety != cartSafety && cartSafety != -1 && upDownSafety != -1)
                                ControlVisibility(new Control[] { CartUnassignedLbl, UpDownUnassignedLbl }, new bool[] { false, false });

                            if (cartSafety == zoomBtn)
                            {
                                zoomBtn = -1;
                                ControlVisibility(new Control[] { ZoomUnassignedLbl }, new bool[] { true });
                            }
                            else if (cartSafety != zoomBtn && zoomBtn != -1 && cartSafety != -1)
                                ControlVisibility(new Control[] { ZoomUnassignedLbl, CartUnassignedLbl }, new bool[] { false, false });
                        }

                        else if (comboBox1.Text == "Zoom Button")
                        {
                            if (zoomBtn != -1)
                                UpdateUIButtons(new Button[] { btns[zoomBtn], btns[e.ID] }, new bool[] { false, true }, new Color[] { Color.Black, btnsClr[2] });
                            else
                                UpdateUIButtons(new Button[] { btns[e.ID] }, new bool[] { true }, new Color[] { btnsClr[2] });

                            zoomBtn = e.ID;

                            if (zoomBtn == cartSafety)
                            {
                                cartSafety = -1;
                                ControlVisibility(new Control[] { CartUnassignedLbl }, new bool[] { true });
                            }
                            else if (zoomBtn != cartSafety && cartSafety != -1 && zoomBtn != -1)
                                ControlVisibility(new Control[] { CartUnassignedLbl, ZoomUnassignedLbl }, new bool[] { false, false });

                            if (zoomBtn == upDownSafety)
                            {
                                upDownSafety = -1;
                                ControlVisibility(new Control[] { UpDownUnassignedLbl }, new bool[] { true });
                            }
                            else if (upDownSafety != zoomBtn && zoomBtn != -1 && upDownSafety != -1)
                                ControlVisibility(new Control[] { ZoomUnassignedLbl, UpDownUnassignedLbl }, new bool[] { false, false });
                        }
                    });
                }

                if (upDownSafety != -1) UpdateUIButtons(new Button[] { btns[upDownSafety] }, new bool[] { true }, new Color[] { btnsClr[0] });
                if (cartSafety != -1) UpdateUIButtons(new Button[] { btns[cartSafety] }, new bool[] { true }, new Color[] { btnsClr[1] });
                if (zoomBtn != -1) UpdateUIButtons(new Button[] { btns[zoomBtn] }, new bool[] { true }, new Color[] { btnsClr[2] });
                timerStart[e.ID] = false;
                chooseBtn[e.ID] = new DateTime();
            }

        }

        private void CloseConfBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}