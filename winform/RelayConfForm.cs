using System;
using System.Drawing;
using System.Windows.Forms;

namespace Winform
{
    public partial class RelayConfForm : Form
    {
        const string CREVIS_IP = "192.168.100.32";
        const int MODBUS_TCP_PORT = 502;
        private int upDownNumOfSteps = MyForm._numOfStepsUpDown;
        private int cartNumOfSteps = MyForm._numOfStepsCart;
        private int crevisStartRelayAddr = 4160;
        public static int upDownStartAddr = MyForm.CREVIS_RELAY_UPDOWN_ADDR;
        public static int cartStartAddr = MyForm.CREVIS_RELAY_CART_ADDR;
        public static int hornAddr = MyForm.CREVIS_RELAY_HORN_ADDR;
        public static int estopAddr = MyForm.CREVIS_RELAY_ESTOP_ADDR;  
        public static int startAddr = MyForm.CREVIS_RELAY_START_ADDR;
        private int crevisNum;
        private bool[] relays = new bool[20];
        private bool collision = false;

        public RelayConfForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            collision = CheckCollision();
            ControlVisibility(new Control[] { CollLbl }, new bool[] { collision });
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (collision)
            {
                DialogResult result = MessageBox.Show("Configuration not complete", "Error", MessageBoxButtons.OK);
                e.Cancel = true;
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

        private void RelayBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Button[] btns = new Button[12] { Relay1Btn, Relay2Btn, Relay3Btn, Relay4Btn, Relay5Btn, Relay6Btn, Relay7Btn, Relay8Btn, Relay9Btn, Relay10Btn, Relay11Btn, Relay12Btn };
            bool[] falseArr20 = new bool[20];
            bool[] falseArr12 = new bool[12];

            int currBtn = ButtonToNumber(btn);
            EnableOrDisableControl(new Control[] { SetBtn }, new bool[] { true });

            if (comboBox1.Text == "Up/Down Relays")
            {
                if (currBtn <= btns.Length - (upDownNumOfSteps + 1))
                {
                    relays = falseArr20;
                    crevisNum = RelayNumberToCrevisNumber(currBtn);
                    UpdateUIButtons(btns, falseArr12, new Color[12]);
                    for (int i = 0; i <= upDownNumOfSteps; i++)
                    {
                        UpdateUIButtons(new Button[] { btns[currBtn + i] }, new bool[] { true }, new Color[] { Color.Turquoise });
                        if ((crevisNum + i >= 4 && crevisNum + i <= 7) || (crevisNum + i >= 12 && crevisNum + i <= 15))
                            relays[crevisNum + i + 4] = true;
                        else
                            relays[crevisNum + i] = true;
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Not enough relays in a row, maximum choise is: " + (btns.Length - upDownNumOfSteps), "Dialog Title", MessageBoxButtons.OK);
                }
            }
            else if (comboBox1.Text == "Cart Relays")
            {
                if (currBtn <= btns.Length - (cartNumOfSteps + 1))
                {
                    relays = falseArr20;
                    crevisNum = RelayNumberToCrevisNumber(currBtn);
                    UpdateUIButtons(btns, falseArr12, new Color[12]);
                    for (int i = 0; i <= cartNumOfSteps; i++)
                    {
                        UpdateUIButtons(new Button[] { btns[currBtn + i] }, new bool[] { true }, new Color[] { Color.Turquoise });
                        if ((crevisNum + i >= 4 && crevisNum + i <= 7) || (crevisNum + i >= 12 && crevisNum + i <= 15))
                            relays[crevisNum + i + 4] = true;
                        else
                            relays[crevisNum + i] = true;
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Not enough relays in a row, maximum choise is: " + (btns.Length - cartNumOfSteps), "Dialog Title", MessageBoxButtons.OK);
                }
            }
            else if (comboBox1.Text == "Horn Relay" || comboBox1.Text == "Estop Relay" || comboBox1.Text == "Start Relay")
            {
                relays = falseArr20;
                crevisNum = RelayNumberToCrevisNumber(currBtn);
                UpdateUIButtons(btns, falseArr12, new Color[12]);
                UpdateUIButtons(new Button[] { btns[currBtn] }, new bool[] { true }, new Color[] { Color.Turquoise });
                relays[crevisNum] = true;
            }
        }

        private int ButtonToNumber(Button btn)
        {
            if (btn.Text == "Relay 1") return 0;
            else if (btn.Text == "Relay 2") return 1;
            else if (btn.Text == "Relay 3") return 2;
            else if (btn.Text == "Relay 4") return 3;
            else if (btn.Text == "Relay 5") return 4;
            else if (btn.Text == "Relay 6") return 5;
            else if (btn.Text == "Relay 7") return 6;
            else if (btn.Text == "Relay 8") return 7;
            else if (btn.Text == "Relay 9") return 8;
            else if (btn.Text == "Relay 10") return 9;
            else if (btn.Text == "Relay 11") return 10;
            else if (btn.Text == "Relay 12") return 11;
            else return -1;
        }

        private int RelayNumberToCrevisNumber(int relay)
        {
            if (relay == 0) return 0;
            else if (relay == 1) return 1;
            else if (relay == 2) return 2;
            else if (relay == 3) return 3;
            else if (relay == 4) return 8;
            else if (relay == 5) return 9;
            else if (relay == 6) return 10;
            else if (relay == 7) return 11;
            else if (relay == 8) return 16;
            else if (relay == 9) return 17;
            else if (relay == 10) return 18;
            else if (relay == 11) return 19;
            return -1;
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

        private void EnableOrDisableControl(Control[] ctrl, bool[] enOrDis)         //Enable or Disable Controls
        {
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < ctrl.Length; i++)
                {
                    if (enOrDis[i])
                        ctrl[i].Enabled = true;
                    else
                        ctrl[i].Enabled = false;
                }
            });
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            Button[] btns = new Button[12] { Relay1Btn, Relay2Btn, Relay3Btn, Relay4Btn, Relay5Btn, Relay6Btn, Relay7Btn, Relay8Btn, Relay9Btn, Relay10Btn, Relay11Btn, Relay12Btn };

            if (comboBox1.Text == "Up/Down Relays")
            {
                upDownStartAddr = crevisStartRelayAddr + crevisNum;
                for (int i = 0; i <= upDownNumOfSteps; i++)
                {
                    UpdateUIButtons(new Button[] { btns[AddressToNumber(upDownStartAddr) + i] }, new bool[] { true }, new Color[] { Color.LawnGreen });
                }
            }
            else if (comboBox1.Text == "Cart Relays")
            {
                cartStartAddr = crevisStartRelayAddr + crevisNum;
                for (int i = 0; i <= cartNumOfSteps; i++)
                {
                    UpdateUIButtons(new Button[] { btns[AddressToNumber(cartStartAddr) + i] }, new bool[] { true }, new Color[] { Color.LawnGreen });
                }
            }
            else if (comboBox1.Text == "Horn Relay")
            {
                hornAddr = crevisStartRelayAddr + crevisNum;
                UpdateUIButtons(new Button[] { btns[AddressToNumber(hornAddr)] }, new bool[] { true }, new Color[] { Color.LawnGreen });
            }
            else if (comboBox1.Text == "Estop Relay")
            {
                estopAddr = crevisStartRelayAddr + crevisNum;
                UpdateUIButtons(new Button[] { btns[AddressToNumber(estopAddr)] }, new bool[] { true }, new Color[] { Color.LawnGreen });
            }
            else if (comboBox1.Text == "Start Relay")
            {
                startAddr = crevisStartRelayAddr + crevisNum;
                UpdateUIButtons(new Button[] { btns[AddressToNumber(startAddr)] }, new bool[] { true }, new Color[] { Color.LawnGreen });
            }

            collision = CheckCollision();
            ControlVisibility(new Control[] { CollLbl }, new bool[] { collision });
            EnableOrDisableControl(new Control[] { SetBtn }, new bool[] { false });
        }

        private int AddressToNumber(int addr)
        {
            int num = addr - crevisStartRelayAddr;
            if (num >= 8 && num <= 11) return num - 4;
            else if (num >= 16 && num <= 19) return num - 8;
            return num;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button[] btns = new Button[12] { Relay1Btn, Relay2Btn, Relay3Btn, Relay4Btn, Relay5Btn, Relay6Btn, Relay7Btn, Relay8Btn, Relay9Btn, Relay10Btn, Relay11Btn, Relay12Btn };
            bool[] falseArr12 = new bool[12];

            EnableOrDisableControl(new Control[] { SetBtn }, new bool[] { false });
            UpdateUIButtons(btns, falseArr12, new Color[12]);

            if (comboBox1.Text == "Up/Down Relays")
            {
                for (int i = 0; i <= upDownNumOfSteps; i++)
                {
                    UpdateUIButtons(new Button[] { btns[AddressToNumber(upDownStartAddr) + i] }, new bool[] { true }, new Color[] { Color.LawnGreen });
                }
            }
            else if (comboBox1.Text == "Cart Relays")
            {
                for (int i = 0; i <= cartNumOfSteps; i++)
                {
                    UpdateUIButtons(new Button[] { btns[AddressToNumber(cartStartAddr) + i] }, new bool[] { true }, new Color[] { Color.LawnGreen });
                }
            }
            else if (comboBox1.Text == "Horn Relay")
            {
                UpdateUIButtons(new Button[] { btns[AddressToNumber(hornAddr)] }, new bool[] { true }, new Color[] { Color.LawnGreen });
            }
            else if (comboBox1.Text == "Estop Relay")
            {
                UpdateUIButtons(new Button[] { btns[AddressToNumber(estopAddr)] }, new bool[] { true }, new Color[] { Color.LawnGreen });
            }
            else if (comboBox1.Text == "Start Relay")
            {
                UpdateUIButtons(new Button[] { btns[AddressToNumber(startAddr)] }, new bool[] { true }, new Color[] { Color.LawnGreen });
            }
        }

        private void ClearRelayBtn_Click(object sender, EventArgs e)
        {
            Button[] btns = new Button[12] { Relay1Btn, Relay2Btn, Relay3Btn, Relay4Btn, Relay5Btn, Relay6Btn, Relay7Btn, Relay8Btn, Relay9Btn, Relay10Btn, Relay11Btn, Relay12Btn };

            if (comboBox1.Text == "Up/Down Relays")
            {
                for (int i = 0; i <= upDownNumOfSteps; i++)
                {
                    UpdateUIButtons(new Button[] { btns[AddressToNumber(upDownStartAddr) + i] }, new bool[] { false }, new Color[] { Color.LawnGreen });
                }
                upDownStartAddr = -1;
            }
            else if (comboBox1.Text == "Cart Relays")
            {
                for (int i = 0; i <= cartNumOfSteps; i++)
                {
                    UpdateUIButtons(new Button[] { btns[AddressToNumber(cartStartAddr) + i] }, new bool[] { false }, new Color[] { Color.LawnGreen });
                }
                cartStartAddr = -1;
            }
            else if (comboBox1.Text == "Horn Relay")
            {
                UpdateUIButtons(new Button[] { btns[AddressToNumber(hornAddr)] }, new bool[] { false }, new Color[] { Color.LawnGreen });
                hornAddr = -1;
            }
            else if (comboBox1.Text == "Estop Relay")
            {
                UpdateUIButtons(new Button[] { btns[AddressToNumber(estopAddr)] }, new bool[] { false }, new Color[] { Color.LawnGreen });
                estopAddr = -1;
            }
            else if (comboBox1.Text == "Start Relay")
            {
                UpdateUIButtons(new Button[] { btns[AddressToNumber(startAddr)] }, new bool[] { false }, new Color[] { Color.LawnGreen });
                startAddr = -1;
            }
        }

        private bool CheckCollision()
        {
            for (int i = 0; i <= upDownNumOfSteps; i++)
            {
                for (int j = 0; j <= cartNumOfSteps; j++)
                {
                    if (FindAddress(upDownStartAddr + i) == FindAddress(cartStartAddr + j))
                    {
                        return true;
                    }
                }
            }
            if (FindAddress(hornAddr) >= FindAddress(upDownStartAddr) && FindAddress(hornAddr) <= FindAddress(upDownStartAddr + upDownNumOfSteps)) return true;
            if (FindAddress(estopAddr) >= FindAddress(upDownStartAddr) && FindAddress(estopAddr) <= FindAddress(upDownStartAddr + upDownNumOfSteps)) return true;
            if (FindAddress(startAddr) >= FindAddress(upDownStartAddr) && FindAddress(startAddr) <= FindAddress(upDownStartAddr + upDownNumOfSteps)) return true;

            if (FindAddress(hornAddr) >= FindAddress(cartStartAddr) && FindAddress(hornAddr) <= FindAddress(cartStartAddr + cartNumOfSteps)) return true;
            if (FindAddress(estopAddr) >= FindAddress(cartStartAddr) && FindAddress(estopAddr) <= FindAddress(cartStartAddr + cartNumOfSteps)) return true;
            if (FindAddress(startAddr) >= FindAddress(cartStartAddr) && FindAddress(startAddr) <= FindAddress(cartStartAddr + cartNumOfSteps)) return true;

            if (FindAddress(hornAddr) == FindAddress(estopAddr)) return true;
            if (FindAddress(hornAddr) == FindAddress(startAddr)) return true;
            if (FindAddress(startAddr) == FindAddress(estopAddr)) return true;

            return false;
        }

        private int FindAddress(int address)
        {
            if ((address >= 4164 && address <= 4167) || (address >= 4172 && address <= 4175))
                return address + 4;
            else return address;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}