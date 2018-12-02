extern alias OZ;

using utils;
using odm.core;
using EasyModbus;
using video.player;
using CTI_Controller;
using onvif.services;
using Microsoft.Win32;
using System;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Winform
{

    public partial class MyForm : Form, IPlaybackController
    {
        
        #region Settings and Variable Initialize
        IPlaybackSession playbackSession;
        INvtSession _session;
        NetworkCredential account = null;
        CTI_Joystick _joystick = new CTI_Joystick();
        HostedPlayer player;
        VideoBuffer videoBuff;
        CompositeDisposable disposables = new CompositeDisposable();
        CompositeDisposable playerDisposables = new CompositeDisposable();
        Dispatcher disp;
        Image img;
        Ping pingToLink = new Ping();
        PingReply reply = null;
        Thread pingThread;
        Thread zoomThread;
        ModbusClient crevisModbusClient;
        Profile _selectedProfile;
        TimeSpan _span;
        object _lockCrevis = new object();
        System.Threading.Timer _timer = null;
        System.DateTime _emergencyTimer;
        System.DateTime _crevisLastCommand;
        System.DateTime _LocalModemLastPing;
        System.DateTime _CrevisLastPing;
        private System.DateTime _cameraConnectTime;
        OZ::Ozeki.Camera.IIPCamera _camera;

        //Variables that are saved after closing
        public static int _numOfStepsUpDown;
        public static int _numOfStepsCart;
        public static int _numOfStepsZoom;
        public static int _sensitivityUpDown;
        public static int _sensitivityCart;
        public static int _axisUpDown;
        public static int _axisCart;
        public static int _axisZoom;
        public static int _safetyButtonUpDown;
        public static int _safetyButtonCart;
        public static int _buttonZoom;
        public static int CREVIS_RELAY_ESTOP_ADDR;
        public static int CREVIS_RELAY_START_ADDR;
        public static int CREVIS_RELAY_CART_ADDR;
        public static int CREVIS_RELAY_HORN_ADDR;
        public static int CREVIS_RELAY_UPDOWN_ADDR;
        public static int _joystickType;
        public static int _crevisTimeout;      
        public static bool _isUpDownInvert;
        public static bool _isCartInvert;
        public static bool _isZoomInvert;

        //Flags 
        private object ModbusLock = new object();
        private int[] _steps = new int[6] { 0, 0, 0, 0, 0, 0 };
        private int[] _currentSteps = new int[] { 0, 0, 0, 0, 0, 0 };
        private int[] _cartAxisLog;
        private int[] _upDownAxisLog;
        private int[] _resetLogUpDown;
        private int[] _resetLogCart;
        private int[] _upDownAddresses;
        private int[] _cartAddresses;
        private int _cartAnalogChannel = 1;
        private int _upDownAnalogChannel = 0;
        private int _cartAxisTrack = 0;
        private int _upDownAxisTrack = 0;
        private int _countConn = 0;
        private int _CrevisKeepAliveCnt = 0;
        private int _centerJoystick;
        private readonly int[] CREVIS_AO_ADDR = new int[] { 2048, 2049, 2050, 2051 };
        private bool[] _joystickAquire = new bool[6];           //True if joystick axis [i] is assigned
        private bool[] _joystickAquireContinous = new bool[6];  //True if sample joystick axis [i] state continously
        private bool _singleJoystick = true;    //True for block one joystick while the other one is moving
        private bool _startUpRunning = false;   //True during start sequence
        private bool _cameraConn = false;       //True if camera is connected
        private bool _crevisConn = false;       //True if Crevis is connected
        private bool _emergency = false;        //True - working mode, false - standby mode
        private bool _startSystem = false;      //True if in working mode
        private bool _safeLblFlag = false;      //True if there is no connection to the camera and the crevis
        private bool _isZooming = false;        //True while camera is zooming
        private bool _showMenu = false;         //True if menu is showed
        private bool _zoomDirection = false;        //True - next zoom is narrow, false - next zoom is wide
        private bool _safetyUpDownCondition = false;    //True if up/down safety button is pressed
        private bool _safetyCartCondition = false;      //True if cart safety button is pressed
        private bool _emergencyPressWhileButton = false;    //True if "Stop" is pressed while one of the safety buttons is hold
        private bool _initCrevisFlag = true;        //False after Crevis is connected
        private bool _sleepMode = false;            //True if tablet goes to sleep mode
        private bool _modemAvilable = false;        //True if the local modem is connected
        private bool _isEstopPressed = false;       //True during start sequence
        private bool _remoteStop = false;           //True if Crevis is disconnected from the Crevis side
        private bool _hornOn = false;               //True if horn is on

        //Constants
        const string USER = "admin";
        const string PASSWORD = "12345";
        const string CREVIS_IP = "192.168.100.32";
        const string CAMERA_IP = "192.168.100.160";
        const string LOCAL_LINK_IP = "192.168.100.242";
        const string CAMERA_ADDRESS = @"http://" + CAMERA_IP + ":8000/0";
        const int PING_CYCLE = 100;
        const int PING_TIMEOUT = 50;
        const int CREVIS_KEEP_ALIVE_RETRY = 3;
        const int CAMERA_KEEP_ALIVE_RETRY = 5;
        const int MODBUS_TCP_PORT = 502;
        const int CREVIS_IDLE_STATE = 0;
        const int JOYSTICK_ZERO_RANGE = 500;
        const int CREVIS_TIMEOUT_ADDR = 4128;
        const int CREVIS_KEEP_ALIVE_ADDR = 4096;
        const int CREVIS_TIMEOUT_VALUE_ADDR = 8209;
        const int MAX_SENSITIVITY = 5;
        const int MIN_SENSITIVITY = 2;
        const int CREVIS_FIRST_RELAY_ADDR = 4160;
        const int CREVIS_LAST_RELAY_ADDR = 4179;
        const int CAMERA_PING_LOOP = 5000;
        const int LOCAL_MODEM_PING_LOOP = 800;
        const int MAX_VAL_APEM = 65000;
        const int MIN_VAL_APEM = 128;
        const int CENTER_VALUE_APEM = 32575;
        const int MAX_VAL_AUTO = 59500;
        const int MIN_VAL_AUTO = 12000;
        const int CENTER_VALUE_AUTO = 35500;
        #endregion

        #region UI Methods 
        public MyForm()
        {
            InitializeComponent();
            disp = Dispatcher.CurrentDispatcher;
        }
        private void Form_Load(object sender, EventArgs e)
        {

            CirclePictureBox(new PictureBox[] { HornPicBox, ConnectionPicBox, NoConnectionPicBox});
            TransparentLabelOnPictureBox(new Label[] { ConnectionLbl, NoConnectionLbl }, new PictureBox[] { ConnectionPicBox, NoConnectionPicBox });

            pingThread = new Thread(PingTimer);

            try
            {
                reply = pingToLink.Send(LOCAL_LINK_IP, PING_TIMEOUT);
                if (reply.Status.ToString().Equals("Success"))
                    _modemAvilable = true;
            }
            catch
            {
                _modemAvilable = false;
            }

            _cameraConnectTime = System.DateTime.Now;
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            #region Read From Text
            _numOfStepsUpDown = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\numOfStepsUpDown.txt"));
            _numOfStepsCart = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\numOfStepsCart.txt"));
            _numOfStepsZoom = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\numOfStepsZoom.txt"));
            _axisUpDown = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\axisUpDown.txt"));
            _axisCart = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\axisCart.txt"));
            _axisZoom = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\axisZoom.txt"));
            _safetyButtonUpDown = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\safetyButtonUpDown.txt"));
            _safetyButtonCart = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\safetyButtonCart.txt"));
            _buttonZoom = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\buttonZoom.txt"));
            _sensitivityUpDown = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\sensitivityUpDown.txt"));
            _sensitivityCart = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\sensitivityCart.txt"));
            CREVIS_RELAY_CART_ADDR = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\CREVIS_RELAY_CART_ADDR.txt"));
            CREVIS_RELAY_ESTOP_ADDR = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\CREVIS_RELAY_ESTOP_ADDR.txt"));
            CREVIS_RELAY_HORN_ADDR = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\CREVIS_RELAY_HORN_ADDR.txt"));
            CREVIS_RELAY_START_ADDR = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\CREVIS_RELAY_START_ADDR.txt"));
            CREVIS_RELAY_UPDOWN_ADDR = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\CREVIS_RELAY_UPDOWN_ADDR.txt"));
            _joystickType = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\joystickType.txt"));
            _isUpDownInvert = Convert.ToBoolean(System.IO.File.ReadAllText(@"C:\Texts\isUpDownInvert.txt"));
            _isCartInvert = Convert.ToBoolean(System.IO.File.ReadAllText(@"C:\Texts\isCartInvert.txt"));
            _isZoomInvert = Convert.ToBoolean(System.IO.File.ReadAllText(@"C:\Texts\isZoomInvert.txt"));
            _crevisTimeout = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\Texts\CREVIS_TIMEOUT.txt"));
            #endregion

            _upDownAxisLog = new int[_sensitivityUpDown];
            _resetLogUpDown = new int[_sensitivityUpDown];
            _cartAxisLog = new int[_sensitivityCart];
            _resetLogCart = new int[_sensitivityCart];

            for (int i = 0; i < _sensitivityUpDown; i++)
            {
                _upDownAxisLog[i] = 0;
                _resetLogUpDown[i] = 0;
            }

            for (int i = 0; i < _sensitivityCart; i++)
            {
                _cartAxisLog[i] = 0;
                _resetLogCart[i] = 0;
            }

            _steps[_axisUpDown] = _numOfStepsUpDown;
            _steps[_axisCart] = _numOfStepsCart;
            _steps[_axisZoom] = _numOfStepsZoom;

            _upDownAddresses = new int[_steps[_axisUpDown] + 1];
            _cartAddresses = new int[_steps[_axisCart] + 1];

            _joystickAquire[_axisCart] = true;
            _joystickAquire[_axisUpDown] = true;
            _joystickAquire[_axisZoom] = true;
            _joystickAquireContinous[_axisCart] = true;
            _joystickAquireContinous[_axisUpDown] = true;
            _joystickAquireContinous[_axisZoom] = true;

            _joystick.Steps = _steps;
            _joystick.AddSafeAxis(_axisUpDown, _safetyButtonUpDown);
            _joystick.AddSafeAxis(_axisCart, _safetyButtonCart);
            _joystick.Acquire(true, _joystickAquire[0], _joystickAquire[1], _joystickAquire[2], _joystickAquire[3], _joystickAquire[4], _joystickAquire[5],
                                    _joystickAquireContinous[0], _joystickAquireContinous[1], _joystickAquireContinous[2], _joystickAquireContinous[3], _joystickAquireContinous[4], _joystickAquireContinous[5]);
            _joystick.ButtonChanged += _joystick_ButtonChanged;
            _joystick.JoystickChanged += _joystick_JoystickChanged;
            _joystick.enableButton(_safetyButtonUpDown, true);
            _joystick.enableButton(_safetyButtonCart, true);
            _joystick.enableButton(_buttonZoom, true);
            _joystick.invert(_axisUpDown, _isUpDownInvert);
            _joystick.invert(_axisCart, _isCartInvert);
            _joystick.invert(_axisZoom, _isZoomInvert);

            if (_joystickType == 1)
            {
                _joystick.MaxValue = MAX_VAL_APEM;
                _joystick.MinValue = MIN_VAL_APEM;
                _joystick.CenterValue = CENTER_VALUE_APEM;
                _centerJoystick = CENTER_VALUE_APEM;
            }
            else
            {
                _joystick.MaxValue = MAX_VAL_AUTO;
                _joystick.MinValue = MIN_VAL_AUTO;
                _joystick.CenterValue = CENTER_VALUE_AUTO;
                _centerJoystick = CENTER_VALUE_AUTO;
            }

            _upDownAddresses[0] = CREVIS_RELAY_UPDOWN_ADDR;
            for (int i = 1; i <= _steps[_axisUpDown]; i++)
            {
                _upDownAddresses[i] = FindAddress(_upDownAddresses[0] + i);
            }
            _cartAddresses[0] = CREVIS_RELAY_CART_ADDR;
            for (int i = 1; i <= _steps[_axisCart]; i++)
            {
                _cartAddresses[i] = FindAddress(_cartAddresses[0] + i);
            }
            
            pingThread.Start();
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)      //Tablet goes to sleep
        {
            if (e.Mode == PowerModes.Suspend)
            {
                _sleepMode = true;
                if (_crevisConn)
                {
                    WriteToCrevis(CREVIS_FIRST_RELAY_ADDR, new int[] { }, new bool[20], 2, 2);
                }
                ChangeControlText(new Control[] { StepXLbl, StepZLbl }, new string[] { "0", "0" });
                _camera.Stop();
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (_crevisConn)
                    {
                        WriteToCrevis(CREVIS_FIRST_RELAY_ADDR, new int[] { }, new bool[20], 2, 2);
                    }
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_showMenu)
            {
                if (e.KeyCode == Keys.Space && e.Alt)
                {
                    ControlVisibility(new Control[] { menuStrip1 }, new bool[] { true });
                    _showMenu = true;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Space && e.Alt)
                {
                    ControlVisibility(new Control[] { menuStrip1 }, new bool[] { false });
                    _showMenu = false;
                }
            }
        }
        private void UpdateUIConnectionButtons(Button[] btn, bool[] redOrGreen)     //Show Status of Connection (Red for OFF, Green for ON)
        {
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < btn.Length; i++)
                {
                    if (redOrGreen[i])
                        btn[i].BackColor = System.Drawing.Color.LawnGreen;
                    else
                        btn[i].BackColor = System.Drawing.Color.Red;
                }
            });
        }
        private void ChangeControlSize(Control[] ctrl, int[] sizeX, int[] sizeY)
        {
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < ctrl.Length; i++)
                {
                    ctrl[i].Width = sizeX[i];
                    ctrl[i].Height= sizeY[i];
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
        private void ChangeControlText(Control[] ctrl, string[] str)
        {
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < ctrl.Length; i++)
                {
                    ctrl[i].Text = str[i];
                }
            });
        }
        private void EstopBtn_Click(object sender, EventArgs e)
        {
            if (_startUpRunning) return;

            try
            {
                if (_emergency)
                {
                    _startUpRunning = true;
                    if (_crevisConn)
                    {
                        try
                        {
                            WriteToCrevis(CREVIS_FIRST_RELAY_ADDR, new int[] { 0 }, new bool[20], 2, 2);
                        }
                        catch { crevisModbusClient.Connect(); };
                    }

                    var cancellationTokenSource = new CancellationTokenSource();
                    var cancellationToken = cancellationTokenSource.Token;

                    var startTask = Task.Factory.StartNew(delegate
                    {
                        ControlVisibility(new Control[] { EstopBtn }, new bool[] { false });
                        Thread.Sleep(2000);
                        _startUpRunning = false;
                        ControlVisibility(new Control[] { startBtn }, new bool[] { true });
                    }, cancellationToken);

                    _emergency = false;
                    _startSystem = false;
                    ChangeControlText(new Control[] { StepXLbl, StepZLbl }, new string[] { "0", "0" });
                }
                else
                {
                    if (_crevisConn)
                    {
                        try
                        {
                            WriteToCrevis(CREVIS_FIRST_RELAY_ADDR, new int[] { 0 }, new bool[20], 2, 2);
                            WriteToCrevis(CREVIS_TIMEOUT_ADDR, new int[] { 100 }, new bool[] { false }, 1, 1);
                        }
                        catch { crevisModbusClient.Connect(); };
                    }
                    _startUpRunning = true;
                    _emergency = true;
                    _emergencyTimer = System.DateTime.Now;

                    var cancellationTokenSource = new CancellationTokenSource();
                    var cancellationToken = cancellationTokenSource.Token;

                    var startTask = Task.Factory.StartNew(delegate
                    {
                        _isEstopPressed = true;
                        ControlVisibility(new Control[] { startBtn }, new bool[] { false });
                        if (_crevisConn)
                        {
                            WriteToCrevis(CREVIS_RELAY_ESTOP_ADDR, new int[] { 0 }, new bool[] { true }, 1, 2);
                            WriteToCrevis(CREVIS_RELAY_HORN_ADDR, new int[] { 0 }, new bool[] { true }, 1, 2);

                            Thread.Sleep(2000);

                            WriteToCrevis(CREVIS_RELAY_START_ADDR, new int[] { 0 }, new bool[] { true }, 1, 2);

                            Thread.Sleep(1500);


                            WriteToCrevis(CREVIS_RELAY_START_ADDR, new int[] { 0 }, new bool[] { false }, 1, 2);
                            WriteToCrevis(CREVIS_RELAY_HORN_ADDR, new int[] { 0 }, new bool[] { false }, 1, 2);

                            _startSystem = true;
                            _startUpRunning = false;
                            ControlVisibility(new Control[] { EstopBtn }, new bool[] { true });
                            _isEstopPressed = false;

                            WriteToCrevis(CREVIS_TIMEOUT_ADDR, new int[] { (_crevisTimeout / 100) }, new bool[] { false }, 1, 1);
                        }
                    }, cancellationToken);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void CirclePictureBox(PictureBox[] pics)
        {
            for (int i = 0; i < pics.Length; i++)
            {
                pics[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                GraphicsPath gp = new GraphicsPath();
                //gp.AddEllipse(pics[i].DisplayRectangle);
                gp.AddEllipse(0, 0, pics[i].Width - 1, pics[i].Height - 1);
                pics[i].Region = new Region(gp);
            }
        }

        private void TransparentLabelOnPictureBox(Label[] lbls, PictureBox[] pics)
        {
            for (int i = 0; i< lbls.Length; i++)
            {
                var pos = this.PointToScreen(lbls[i].Location);
                pos = pics[i].PointToClient(pos);
                lbls[i].Parent = pics[i];
                lbls[i].Location = pos;
                lbls[i].BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void HornPicBox_Click(object sender, EventArgs e)
        {
            if (!_emergency || _hornOn) return;

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var startTask = Task.Factory.StartNew(delegate
            {
                _hornOn = true;
                WriteToCrevis(CREVIS_RELAY_HORN_ADDR, new int[] { }, new bool[] { true }, 1, 2);
                Thread.Sleep(3000);
                WriteToCrevis(CREVIS_RELAY_HORN_ADDR, new int[] { }, new bool[] { false }, 1, 2);
                _hornOn = false;
            }, cancellationToken);
   
        }

        private void JoystickConfBtn_Click(object sender, EventArgs e)
        {
            if (_emergency)
            {
                DialogResult result = MessageBox.Show("Turn off the system for configurations", "Error", MessageBoxButtons.OK);
                return;
            }

            JoystickConfForm jcf = new JoystickConfForm();
            jcf.ShowDialog();
            if (_numOfStepsUpDown != JoystickConfForm.numOfStepsUp)
            {
                _numOfStepsUpDown = JoystickConfForm.numOfStepsUp;
                _steps[_axisUpDown] = _numOfStepsUpDown;
                System.IO.File.WriteAllText(@"C:\Texts\numOfStepsUpDown.txt", _numOfStepsUpDown.ToString());
            }
            if (_numOfStepsCart != JoystickConfForm.numOfStepsCart)
            {
                _numOfStepsCart = JoystickConfForm.numOfStepsCart;
                _steps[_axisCart] = _numOfStepsCart;
                System.IO.File.WriteAllText(@"C:\Texts\numOfStepsCart.txt", _numOfStepsCart.ToString());
            }

            if (_sensitivityUpDown != (MAX_SENSITIVITY + MIN_SENSITIVITY) - JoystickConfForm.sensitivityUp)
            {
                _sensitivityUpDown = (MAX_SENSITIVITY + MIN_SENSITIVITY) - JoystickConfForm.sensitivityUp;
                int sensLvl = (MAX_SENSITIVITY + MIN_SENSITIVITY) - _sensitivityUpDown;
                _upDownAxisLog = new int[sensLvl];
                _resetLogUpDown = new int[sensLvl];
                for (int i = 0; i < sensLvl; i++)
                {
                    _upDownAxisLog[i] = 0;
                    _resetLogUpDown[i] = 0;
                }
                System.IO.File.WriteAllText(@"C:\Texts\sensitivityUpDown.txt", _sensitivityUpDown.ToString());
            }

            if (_sensitivityCart != (MAX_SENSITIVITY + MIN_SENSITIVITY) - JoystickConfForm.sensitivityCart)
            {
                _sensitivityCart = (MAX_SENSITIVITY + MIN_SENSITIVITY) - JoystickConfForm.sensitivityCart;
                int sensLvl = (MAX_SENSITIVITY + MIN_SENSITIVITY) - _sensitivityCart;
                _cartAxisLog = new int[sensLvl];
                _resetLogCart = new int[sensLvl];
                for (int i = 0; i < sensLvl; i++)
                {
                    _cartAxisLog[i] = 0;
                    _resetLogCart[i] = 0;
                }
                System.IO.File.WriteAllText(@"C:\Texts\sensitivityCart.txt", _sensitivityCart.ToString());
            }

            if (_axisUpDown == JoystickConfForm.cartAxis && _axisCart == JoystickConfForm.upDownAxis)
            {
                _joystick.RemoveSafeAxis(_axisUpDown);
                _joystick.RemoveSafeAxis(_axisCart);
                _axisUpDown = JoystickConfForm.upDownAxis;
                _axisCart = JoystickConfForm.cartAxis;
                _steps[_axisUpDown] = _numOfStepsUpDown;
                _steps[_axisCart] = _numOfStepsCart;
                _joystick.AddSafeAxis(_axisUpDown, _safetyButtonUpDown);
                _joystick.AddSafeAxis(_axisCart, _safetyButtonCart);
                System.IO.File.WriteAllText(@"C:\Texts\axisUpDown.txt", _axisUpDown.ToString());
                System.IO.File.WriteAllText(@"C:\Texts\axisCart.txt", _axisCart.ToString());
            }
            else
            {
                if (_axisUpDown != JoystickConfForm.upDownAxis)
                {
                    _joystick.RemoveSafeAxis(_axisUpDown);
                    _joystick.RemoveSafeAxis(JoystickConfForm.upDownAxis);
                    _joystickAquire[_axisUpDown] = false;
                    _steps[_axisUpDown] = 0;
                    _axisUpDown = JoystickConfForm.upDownAxis;
                    _joystickAquire[_axisUpDown] = true;
                    _steps[_axisUpDown] = _numOfStepsUpDown;
                    _joystick.AddSafeAxis(_axisUpDown, _safetyButtonUpDown);

                    System.IO.File.WriteAllText(@"C:\Texts\axisUpDown.txt", _axisUpDown.ToString());
                }
                if (_axisCart != JoystickConfForm.cartAxis)
                {
                    _joystick.RemoveSafeAxis(_axisCart);
                    _joystick.RemoveSafeAxis(JoystickConfForm.cartAxis);
                    _joystickAquire[_axisCart] = false;
                    _steps[_axisCart] = 0;
                    _axisCart = JoystickConfForm.cartAxis;
                    _joystickAquire[_axisCart] = true;
                    _steps[_axisCart] = _numOfStepsCart;
                    _joystick.AddSafeAxis(_axisCart, _safetyButtonCart);
                    System.IO.File.WriteAllText(@"C:\Texts\axisCart.txt", _axisCart.ToString());
                }
            }
            if (_axisZoom != JoystickConfForm.zoomAxis)
            {
                _joystickAquire[_axisZoom] = false;
                _joystickAquireContinous[_axisZoom] = false;
                _steps[_axisZoom] = 0;
                _axisZoom = JoystickConfForm.zoomAxis;
                _joystickAquire[_axisZoom] = true;
                _joystickAquireContinous[_axisZoom] = true;
                _steps[_axisZoom] = _numOfStepsZoom;
                _joystick.Steps = _steps;
                System.IO.File.WriteAllText(@"C:\Texts\axisZoom.txt", _axisZoom.ToString());
            }

            if (_joystickType != JoystickConfForm.type)
            {
                _joystickType = JoystickConfForm.type;
                if (_joystickType == 1)
                {
                    _joystick.MaxValue = MAX_VAL_APEM;
                    _joystick.MinValue = MIN_VAL_APEM;
                    _joystick.CenterValue = CENTER_VALUE_APEM;
                    _centerJoystick = CENTER_VALUE_APEM;
                }
                else
                {
                    _joystick.MaxValue = MAX_VAL_AUTO;
                    _joystick.MinValue = MIN_VAL_AUTO;
                    _joystick.CenterValue = CENTER_VALUE_AUTO;
                    _centerJoystick = CENTER_VALUE_AUTO;
                }
                System.IO.File.WriteAllText(@"C:\Texts\joystickType.txt", _joystickType.ToString());
            }

            System.IO.File.WriteAllText(@"C:\Texts\numOfStepsZoom.txt", _numOfStepsZoom.ToString());

            _joystick.Steps = _steps;

            _joystick.Acquire(true, _joystickAquire[0], _joystickAquire[1], _joystickAquire[2], _joystickAquire[3], _joystickAquire[4], _joystickAquire[5],
                        _joystickAquire[0], _joystickAquire[1], _joystickAquire[2], _joystickAquire[3], _joystickAquire[4], _joystickAquire[5]);

            _isUpDownInvert = JoystickConfForm.isUpDownInvert;
            _isCartInvert = JoystickConfForm.isCartInvert;
            _isZoomInvert = JoystickConfForm.isZoomInvert;
            _joystick.invert(_axisUpDown, _isUpDownInvert);
            _joystick.invert(_axisCart, _isCartInvert);
            _joystick.invert(_axisZoom, _isZoomInvert);

            if (_isUpDownInvert) System.IO.File.WriteAllText(@"C:\Texts\isUpDownInvert.txt", "true");
            else System.IO.File.WriteAllText(@"C:\Texts\isUpDownInvert.txt", "false");

            if (_isCartInvert) System.IO.File.WriteAllText(@"C:\Texts\isCartInvert.txt", "true");
            else System.IO.File.WriteAllText(@"C:\Texts\isCartInvert.txt", "false");

            if (_isZoomInvert) System.IO.File.WriteAllText(@"C:\Texts\isZoomInvert.txt", "true");
            else System.IO.File.WriteAllText(@"C:\Texts\isZoomInvert.txt", "false");

            jcf.Close();
        }

        private void ButtonConfBtn_Click(object sender, EventArgs e)
        {
            if (_emergency)
            {
                DialogResult result = MessageBox.Show("Turn off the system for configurations", "Error", MessageBoxButtons.OK);
                return;
            }

            ButtonConfForm bcf = new ButtonConfForm();
            bcf.ShowDialog();
            if (_safetyButtonUpDown != ButtonConfForm.upDownSafety)
            {
                _joystick.RemoveSafeAxis(_axisUpDown);
                _safetyButtonUpDown = ButtonConfForm.upDownSafety;
                _joystick.enableButton(_safetyButtonUpDown, true);
                _joystick.AddSafeAxis(_axisUpDown, _safetyButtonUpDown);
                System.IO.File.WriteAllText(@"C:\Texts\safetyButtonUpDown.txt", _safetyButtonUpDown.ToString());
            }
            if (_safetyButtonCart != ButtonConfForm.cartSafety)
            {
                _joystick.RemoveSafeAxis(_axisCart);
                _safetyButtonCart = ButtonConfForm.cartSafety;
                _joystick.enableButton(_safetyButtonCart, true);
                _joystick.AddSafeAxis(_axisCart, _safetyButtonCart);
                System.IO.File.WriteAllText(@"C:\Texts\safetyButtonCart.txt", _safetyButtonCart.ToString());
            }
            if (_buttonZoom != ButtonConfForm.zoomBtn)
            {
                _joystick.enableButton(_buttonZoom, false);
                _buttonZoom = ButtonConfForm.zoomBtn;
                _joystick.enableButton(_buttonZoom, true);
                System.IO.File.WriteAllText(@"C:\Texts\buttonZoom.txt", _buttonZoom.ToString());
            }
            bcf.Close();
        }

        private void RelayConfBtn_Click(object sender, EventArgs e)
        {
            if (_emergency)
            {
                DialogResult result = MessageBox.Show("Turn off the system for configurations", "Error", MessageBoxButtons.OK);
                return;
            }

            RelayConfForm rcf = new RelayConfForm();
            rcf.ShowDialog();

            CREVIS_RELAY_UPDOWN_ADDR = RelayConfForm.upDownStartAddr;
            CREVIS_RELAY_CART_ADDR = RelayConfForm.cartStartAddr;
            CREVIS_RELAY_ESTOP_ADDR = RelayConfForm.estopAddr;
            CREVIS_RELAY_START_ADDR = RelayConfForm.startAddr;
            CREVIS_RELAY_HORN_ADDR = RelayConfForm.hornAddr;
            System.IO.File.WriteAllText(@"C:\Texts\CREVIS_RELAY_UPDOWN_ADDR.txt", CREVIS_RELAY_UPDOWN_ADDR.ToString());
            System.IO.File.WriteAllText(@"C:\Texts\CREVIS_RELAY_CART_ADDR.txt", CREVIS_RELAY_CART_ADDR.ToString());
            System.IO.File.WriteAllText(@"C:\Texts\CREVIS_RELAY_ESTOP_ADDR.txt", CREVIS_RELAY_ESTOP_ADDR.ToString());
            System.IO.File.WriteAllText(@"C:\Texts\CREVIS_RELAY_START_ADDR.txt", CREVIS_RELAY_START_ADDR.ToString());
            System.IO.File.WriteAllText(@"C:\Texts\CREVIS_RELAY_HORN_ADDR.txt", CREVIS_RELAY_HORN_ADDR.ToString());


            _upDownAddresses[0] = CREVIS_RELAY_UPDOWN_ADDR;
            for (int i = 1; i <= _steps[_axisUpDown]; i++)
            {
                _upDownAddresses[i] = FindAddress(_upDownAddresses[0] + i);
            }
            _cartAddresses[0] = CREVIS_RELAY_CART_ADDR;
            for (int i = 1; i <= _steps[_axisCart]; i++)
            {
                _cartAddresses[i] = FindAddress(_cartAddresses[0] + i);
            }
			
			rcf.Close();

        }

        private void crevisConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_emergency)
            {
                DialogResult result = MessageBox.Show("Turn off the system for configurations", "Error", MessageBoxButtons.OK);
                return;
            }

            CrevisConfForm ccf = new CrevisConfForm();
            ccf.ShowDialog();

            _crevisTimeout = Convert.ToInt32(CrevisConfForm.timeout);
            WriteToCrevis(CREVIS_TIMEOUT_ADDR, new int[] { (_crevisTimeout / 100) }, new bool[] { false }, 1, 1);
            System.IO.File.WriteAllText(@"C:\Texts\CREVIS_TIMEOUT.txt", _crevisTimeout.ToString());

            ccf.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string text = String.Format("Application Version: {0}", version);

            MessageBox.Show(text, "Version", MessageBoxButtons.OK);
            return;
        }

        #endregion

        #region Camera Methods
        private void StartCameraStream()
        {
            _session = null;

            account = new System.Net.NetworkCredential(USER, PASSWORD);

            NvtSessionFactory factory = new NvtSessionFactory(account);

            Debug.WriteLine("--------Create Session---------------");
            disposables.Add(factory.CreateSession(new Uri[] { new Uri(CAMERA_ADDRESS) })
               .ObserveOnCurrentDispatcher()
               .Subscribe(
               session =>
               {
                   GetProfiles(session);
               }, err =>
               {
                   errBox.Text = err.Message + "\r\n" + "Try Number: " + _countConn.ToString();
                   _countConn += 1;
               }));

            _camera = new OZ::Ozeki.Camera.IPCamera(CAMERA_IP + ":8000", USER, PASSWORD);
            _camera.Start();

        }

        void GetProfiles(INvtSession session)
        {
            Debug.WriteLine("--------Create Profile---------------");
            Release();
            _session = session;

            //Every video source can have it's own profiles
            disposables.Add(session.GetProfiles()
                .ObserveOnCurrentDispatcher()
                .Subscribe(
                profs =>
                {
                    _selectedProfile = profs.FirstOrDefault();
                    
                    if (_selectedProfile == null)
                    {
                        //Device vave not any profiles
                        errBox.Text = "Profile is Empty" + "\r\n" + "Try Number: " + _countConn.ToString();
                        _countConn += 1;
                    }
                    else
                    {
                        GetStreamUri(session, _selectedProfile);
                    }
                }, err =>
                {
                    errBox.Text = err.Message + "\r\n" + "Try Number: " + _countConn.ToString();
                    _countConn += 1;
                }));
        }
        void GetStreamUri(INvtSession session, onvif.services.Profile prof)
        {
            Debug.WriteLine("--------GetStreamUri--------------");
            var srtSetup = new StreamSetup()
            {
                stream = StreamType.rtpUnicast,
                transport = new Transport()
                {
                    protocol = TransportProtocol.udp
                }
            };

            

            //Get stream uri for selected profile
            disposables.Add(session.GetStreamUri(srtSetup, prof.token)
                .ObserveOnCurrentDispatcher()
                .Subscribe(
                muri =>
                {
                    Size videosize = new Size(980, 552);
                    Debug.WriteLine("------------InitPlayer--------------");
                    InitPlayer(muri.uri.ToString(), account, videosize);
                }, err =>
                {
                    errBox.Text = err.Message + "\r\n" + "Try Number: " + _countConn.ToString();
                    _countConn += 1;
                }));
        }
        public void InitPlayer(string videoUri, NetworkCredential account, Size sz = default(Size))
        {
            player = new HostedPlayer();
            playerDisposables.Add(player);

            if (sz != default(Size))
                videoBuff = new VideoBuffer((int)sz.Width, (int)sz.Height, PixFrmt.bgra32);
            else
            {
                videoBuff = new VideoBuffer(720, 576, PixFrmt.bgra32);
            }
            player.SetVideoBuffer(videoBuff);

            MediaStreamInfo.Transport transp = MediaStreamInfo.Transport.Udp;
            MediaStreamInfo mstrInfo = null;
            if (account != null)
            {
                mstrInfo = new MediaStreamInfo(videoUri, transp, new UserNameToken(account.UserName, account.Password));//, transp, null);
            }
            else
            {
                mstrInfo = new MediaStreamInfo(videoUri, transp);
            }

            playerDisposables.Add(
                player.Play(mstrInfo, this)
            );
            InitPlayback(videoBuff, true);

        }


        void SignalPresent()
        {
            _cameraConn = true;
        }

        void Restart()
        {
            _cameraConn = false;
            Debug.WriteLine("-------------------------Restart");
        }


        void InitPlayback(VideoBuffer videoBuffer, bool isInitial)
        {
            if (videoBuffer == null)
            {
                dbg.Break();
                log.WriteError("video buffer is null");
            }

            TimeSpan renderinterval;
            try
            {
                int fps = 20;

                fps = (fps <= 0 || fps > 100) ? 100 : fps;
                renderinterval = TimeSpan.FromMilliseconds(1000 / fps);
            }
            catch
            {
                renderinterval = TimeSpan.FromMilliseconds(1000 / 10);
            }

            var cancellationTokenSource = new CancellationTokenSource();
            playerDisposables.Add(Disposable.Create(() =>
            {
                cancellationTokenSource.Cancel();
            }));

            //var bitmap = PrepareForRendering(videoBuffer);
            img = new Bitmap(videoBuffer.width, videoBuffer.height);
            imageBox.Image = img;

            var cancellationToken = cancellationTokenSource.Token;

            var renderingTask = Task.Factory.StartNew(delegate
            {
                var statistics = PlaybackStatistics.Start(Restart, isInitial, SignalPresent);
                using (videoBuffer.Lock())
                {
                    try
                    {
                        //start rendering loop
                        while (!cancellationToken.IsCancellationRequested)
                        {

                            using (var processingEvent = new ManualResetEventSlim(false))
                            {
                                var dispOp = disp.BeginInvoke(delegate
                                {
                                    using (Disposable.Create(() => processingEvent.Set()))
                                    {

                                        if (!cancellationToken.IsCancellationRequested)
                                        {
                                            //update statisitc info
                                            statistics.Update(videoBuffer);

                                            //render farme to screen
                                            DrawFrame(videoBuffer, statistics);

                                        }
                                    }
                                });

                                processingEvent.Wait(cancellationToken);
                            }
                            cancellationToken.WaitHandle.WaitOne(renderinterval);

                        }

                    }
                    catch (OperationCanceledException)
                    {
                        //swallow exception
                    }
                    catch (Exception error)
                    {
                        dbg.Break();
                        log.WriteError(error);
                    }
                    finally
                    {
                    }
                }
            }, cancellationToken);
        }
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, int count);
        private void DrawFrame(VideoBuffer videoBuffer, PlaybackStatistics statistics)
        {
            Bitmap bmp = img as Bitmap;
            BitmapData bd = null;

            try
            {
                bd = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);//bgra32

                using (var md = videoBuffer.Lock())
                {

                    CopyMemory(bd.Scan0, md.value.scan0Ptr, videoBuff.stride * videoBuff.height);
                }

            }
            catch 
            {
                //errBox.Text = err.Message + "\r\n" + "Try Number: " + _countConn.ToString();
                _countConn += 1;
                Debug.WriteLine("ERROR IN DRAWFRAME FUNCTION");
            }
            finally
            {
                
                bmp.UnlockBits(bd);
            }
            imageBox.Image = bmp;
        }
        void Release()
        {
            disposables.Dispose();
            disposables = new CompositeDisposable();

            playerDisposables.Dispose();
            playerDisposables = new CompositeDisposable();
        }
        public bool Initialized(IPlaybackSession playbackSession)
        {
            this.playbackSession = playbackSession;
            return true;
        }
        public void Shutdown()
        {
        }
        private class PlaybackStatistics
        {
            private PlaybackStatistics(Action Restart, bool isInitial, Action SignalPresent)
            {
                signal = 0;
                this.Restart = Restart;
                this.SignalPresent = SignalPresent;
                this.isInitial = isInitial;

                noSignalProcessor = NoSignalProcessor().GetEnumerator();
                UpdateNoSignal();
            }

            Action Restart;
            Action SignalPresent;

            static public PlaybackStatistics Start(Action Restart, bool isInitial, Action SignalPresent)
            {
                return new PlaybackStatistics(Restart, isInitial, SignalPresent);
            }

            public const long noSignalDelay = 200;
            public const long noSignalTimeout = 500;
            public const long noSignalTimeoutInitial = 500;
            public const long noSignalRestartTimout = 2000;

            public bool isInitial { get; private set; }
            public bool isNoSignal { get; private set; }
            public byte signal { get; private set; }
            public double avgRenderingFps { get; private set; }

            CircularBuffer<long> renderTimes = new CircularBuffer<long>(128);
            CircularBuffer<long> decodeTimes = new CircularBuffer<long>(128);
            IEnumerator<bool> noSignalProcessor;

            private static double SecondsFromTicks(long ticks)
            {
                return (double)ticks / (double)Stopwatch.Frequency;
            }

            private void UpdateNoSignal()
            {
                noSignalProcessor.MoveNext();
                isNoSignal = noSignalProcessor.Current;
            }

            /// <summary>state machine for no signal</summary>
            /// <returns>true if no signal detected</returns>
            private IEnumerable<bool> NoSignalProcessor()
            {
                var timer = Stopwatch.StartNew();
                while (true)
                {
                    if (signal != 0)
                    {
                        decodeTimes.Enqueue(Stopwatch.GetTimestamp());
                        isNoSignal = false;
                        SignalPresent();
                        timer.Restart();
                    }
                    else
                    {
                        if (timer.ElapsedMilliseconds > noSignalTimeout)
                        {
                            isNoSignal = true;
                            //Debug.WriteLine("--------------------------------------------isNoSignal = true");
                            if (timer.ElapsedMilliseconds > noSignalRestartTimout)
                            {
                                if (Restart != null)
                                {
                                    timer.Restart();
                                    Restart();
                                }
                            }
                        }
                    }
                    yield return isNoSignal;
                }
            }

            public void Update(VideoBuffer videoBuffer)
            {
                //update rendering times history
                renderTimes.Enqueue(Stopwatch.GetTimestamp());

                //evaluate averange rendering fps
                avgRenderingFps = renderTimes.length / SecondsFromTicks(renderTimes.last - renderTimes.first);

                //update no signal indicator
                using (var md = videoBuffer.Lock())
                {
                    signal = md.value.signal;
                    md.value.signal = 0;
                }
                UpdateNoSignal();

            }
        }

        private void ZoomThreadFunc()
        {

            int speed = 20;
            float zSpeed = (float)1;
            double t = 0.5;

            _isZooming = true;

            if (!_zoomDirection)
            {
                for (int x = 0; x < speed; x++)
                {
                    _camera.CameraMovement.ZoomSpeed = zSpeed;
                    _camera.CameraMovement.Zoom(OZ::Ozeki.Camera.MoveDirection.Out, true, t);
                    Thread.Sleep(100);
                }
            }
            else
            {
                for (int x = 0; x < speed; x++)
                {
                    _camera.CameraMovement.ZoomSpeed = zSpeed;
                    _camera.CameraMovement.Zoom(OZ::Ozeki.Camera.MoveDirection.In, true, t);
                    Thread.Sleep(100);
                }
            }
            _zoomDirection = !_zoomDirection;
            _isZooming = false;
            zoomThread.Abort();
        }
        #endregion

        #region Joystick and Buttons Methods
        private void _joystick_ButtonChanged(object sender, ButtonsEventArgs e) //Button changed event method
        {
            
            try
            {
                //Zoom Button
                if (e.ID == _buttonZoom && !_isZooming && e.value)
                {
                    zoomThread = null;
                    zoomThread = new Thread(ZoomThreadFunc);
                    zoomThread.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (!_emergency || !_startSystem) return;

            try
            {

                //Safe Buttons
                if (e.ID == _safetyButtonCart)
                {
                    if (e.value == false)
                    {
                        _safetyCartCondition = false;
                        _emergencyPressWhileButton = false;
                        if (_crevisConn)
                        {
                            WriteToCrevis(CREVIS_AO_ADDR[_cartAnalogChannel], new int[] { CREVIS_IDLE_STATE }, new bool[] { false }, 1, 1);
                            WriteToCrevis(CREVIS_RELAY_CART_ADDR, new int[] { }, new bool[8], 2, 2);
                        }
                        _currentSteps[_axisCart] = 0;
                        ChangeControlText(new Control[] { StepZLbl }, new string[] { "0" });
                        _cartAxisLog = _resetLogUpDown;
                        _cartAxisTrack = 0;
                    }
                    else
                    {
                        _safetyCartCondition = true;
                    }
                }
                if (e.ID == _safetyButtonUpDown)
                {
                    if (e.value == false)
                    {
                        _safetyUpDownCondition = false;
                        _emergencyPressWhileButton = false;
                        if (_crevisConn)
                        {
                            WriteToCrevis(CREVIS_AO_ADDR[_upDownAnalogChannel], new int[] { CREVIS_IDLE_STATE }, new bool[] { false }, 1, 1);
                            WriteToCrevis(CREVIS_RELAY_UPDOWN_ADDR, new int[] { }, new bool[9], 2, 2);
                        }
                        _currentSteps[_safetyButtonUpDown] = 0;
                        ChangeControlText(new Control[] { StepXLbl }, new string[] { "0" });
                        _upDownAxisLog = _resetLogUpDown;
                        _upDownAxisTrack = 0;
                    }
                    else
                    {
                        _safetyUpDownCondition = true;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void _joystick_JoystickChanged(object sender, JoystickEventArgs e)  //Joystick changed event method
        {
            int signUpDown, signCart, newValUpDown, newValCart, counterCart = 0, counterUpDown = 0;
            bool cont = false;

            try
            {
                if ((e.ID == _axisZoom) && (!_safetyCartCondition) && (!_safetyUpDownCondition))
                {
                    if (e.step < -2) 
                    {
                        _camera.CameraMovement.ZoomSpeed = (float)0.15 * Math.Abs(e.step);
                        _camera.CameraMovement.Zoom(OZ::Ozeki.Camera.MoveDirection.Out, false, 0.1);
                    }
                    else if (e.step > 2)
                    {
                        _camera.CameraMovement.ZoomSpeed = (float)0.15 * Math.Abs(e.step);
                        _camera.CameraMovement.Zoom(OZ::Ozeki.Camera.MoveDirection.In, false, 0.1);
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (_singleJoystick == false) cont = true;
            else
            {
                if (e.ID == _axisUpDown && _safetyCartCondition == false) cont = true;
                if (e.ID == _axisCart && _safetyUpDownCondition == false) cont = true;
            }

            if (!_emergency || !_startSystem || _emergencyPressWhileButton) return;

            _span = System.DateTime.Now - _emergencyTimer;
            int ms = Math.Abs((int)_span.TotalMilliseconds);
            if (ms < 1000)
            {
                _emergencyPressWhileButton = true;
                return;
            }

            try
            {
                
                if (e.ID == _axisCart && cont && _safetyCartCondition)
                {
                    _currentSteps[_axisCart] = e.step;

                    if (_crevisConn)
                    {
                        if ((e.value > _centerJoystick + JOYSTICK_ZERO_RANGE) || ((e.value < _centerJoystick - JOYSTICK_ZERO_RANGE)))
                        {
                            if (e.value < _centerJoystick) newValCart = Convert.ToInt32(Math.Round(-(e.value - _centerJoystick) / 8.0));
                            else newValCart = Convert.ToInt32(Math.Round((e.value - _centerJoystick) / 8.0));

                            WriteToCrevis(CREVIS_AO_ADDR[_cartAnalogChannel], new int[] { newValCart }, new bool[] { false }, 1, 1);
                        }
                        else
                        {
                            WriteToCrevis(CREVIS_AO_ADDR[_cartAnalogChannel], new int[] { 0 }, new bool[] { false }, 1, 1);
                        }
                    }

                    _cartAxisLog[_cartAxisTrack % _cartAxisLog.Length] = e.step;
                    _cartAxisTrack += 1;

                    for (int i = 0; i < _cartAxisLog.Length; i++)
                        if (_cartAxisLog[i] == e.step) counterCart += 1;

                    if (counterCart == _cartAxisLog.Length - 1)
                    {
                        ChangeControlText(new Control[] { StepZLbl }, new string[] { e.step.ToString() });

                        if (e.step > 0) signCart = 1;
                        else signCart = -1;

                        if (_crevisConn)
                        {
                            CommandToRelay(_axisCart, Math.Abs(e.step), signCart);
                        }
                    }
                }
                if (e.ID == _axisUpDown && cont && _safetyUpDownCondition)
                {
                    Debug.WriteLine(e.value);

                    _currentSteps[_axisUpDown] = e.step;

                    if (_crevisConn)
                    {
                        if ((e.value > _centerJoystick + JOYSTICK_ZERO_RANGE) || ((e.value < _centerJoystick - JOYSTICK_ZERO_RANGE)))
                        {
                            if (e.value < _centerJoystick) newValUpDown = Convert.ToInt32(Math.Round(-(e.value - _centerJoystick) / 8.0));
                            else newValUpDown = Convert.ToInt32(Math.Round((e.value - _centerJoystick) / 8.0));
                            WriteToCrevis(CREVIS_AO_ADDR[_upDownAnalogChannel], new int[] { newValUpDown }, new bool[] { false }, 1, 1);
                        }
                        else
                        {
                            WriteToCrevis(CREVIS_AO_ADDR[_upDownAnalogChannel], new int[] { 0 }, new bool[] { false }, 1, 1);
                        }
                    }

                    _upDownAxisLog[_upDownAxisTrack % _upDownAxisLog.Length] = e.step;
                    _upDownAxisTrack += 1;

                    for (int i = 0; i < _upDownAxisLog.Length; i++)
                        if (_upDownAxisLog[i] == e.step) counterUpDown += 1;

                    if (counterUpDown == _upDownAxisLog.Length - 1)
                    {
                        ChangeControlText(new Control[] { StepXLbl }, new string[] { e.step.ToString() });

                        if (e.step > 0) signUpDown = 1;
                        else signUpDown = -1;

                        if (_crevisConn)
                        {
                            CommandToRelay(_axisUpDown, Math.Abs(e.step), signUpDown);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("1: " + ex);
            }
        }
        #endregion

        #region Relay Control Methods
        private void CommandToRelay(int axis, int step, int sign)        //Choose Crevis relays to turn on or off by command
        {

            bool[] relays =  new bool[100];
            int register, numOfRelays;
            
            // Sets the sign
            if (sign < 0 && step != 0) { relays[0] = false; relays[1] = true; }
            else if (sign > 0 && step != 0) { relays[0] = true; relays[1] = false; }

            // handles case of "0"
            if (step == 0) { for (int i = 0; i <= 5; i++) relays[i] = false; }

            // Sets the rest of the values
            else
            {
                for (int i = 2; i < step + 1; i++)
                {
                    relays[i] = true;
                }
            } 

            //if (step == 1)
            //{
            //    relays[2] = false; relays[3] = false; relays[4] = false; relays[5] = false;
            //}
            //else if (step == 2)
            //{
            //    relays[2] = true; relays[3] = false; relays[4] = false; relays[5] = false;
            //}
            //else if (step == 3)
            //{
            //    relays[2] = true; relays[3] = true; relays[4] = false; relays[5] = false;
            //}
            //else if (step == 4)
            //{
            //    relays[2] = true; relays[3] = true; relays[4] = true; relays[5] = false;
            //}
            //else if (step == 5)
            //{
            //    relays[2] = true; relays[3] = true; relays[4] = true; relays[5] = true;
            //}

            if (axis == _axisUpDown)
            {
                register = CREVIS_RELAY_UPDOWN_ADDR;
                numOfRelays = _numOfStepsUpDown + 1;
            }
            else
            {
                register = CREVIS_RELAY_CART_ADDR;
                numOfRelays = _numOfStepsCart + 1;
            }

            Relays(register, relays, numOfRelays);
        }

        private int FindAddress(int address)
        {
            if ((address >= 4164 && address <= 4167) || (address >= 4172 && address <= 4175))
                return address + 4;
            else return address;
        }

        private void WriteToCrevis(int register, int[] intVal, bool[] boolVal, int singleOrMul, int regOrCoil)
        {
            //singleOrMul: 1 - single
            //             2 - multiple

            //regOrCoil: 1 - register
            //           2 - coil

            lock (_lockCrevis)
            {
                var t = System.DateTime.Now;
                try
                {
                    if (singleOrMul == 1 && regOrCoil == 1)
                        crevisModbusClient.WriteSingleRegister(register, intVal[0]);
                    else if (singleOrMul == 1 && regOrCoil == 2)
                        crevisModbusClient.WriteSingleCoil(register, boolVal[0]);
                    else if (singleOrMul == 2 && regOrCoil == 1)
                        crevisModbusClient.WriteMultipleRegisters(register, intVal);
                    else if (singleOrMul == 2 && regOrCoil == 2)
                        crevisModbusClient.WriteMultipleCoils(register, boolVal);

                    double delta = (System.DateTime.Now - t).TotalMilliseconds;
                    Debug.WriteLine("Send Crevis: " + delta);
                    _crevisLastCommand = System.DateTime.Now;
                }
                catch
                {
                    Debug.WriteLine("WriteToCrevis Error");
                }
            }
        }

        private void Relays(int register, bool[] relays, int numOfRegisterToWrite)
        {
            int moduleSize = 4;
            int numOfValues;
            int requiredModules = 1;
            int relayInternalIndex = register % moduleSize;
            int i = 0;
            int n = 0;
            int currModule = 0;

            // calc the num of value including spacing
            int valueLeft = numOfRegisterToWrite - (moduleSize - relayInternalIndex);

            // Have enough space on on module
            if (valueLeft == 0) numOfValues = numOfRegisterToWrite;
            if (valueLeft > 0)
            {
                if (valueLeft <= moduleSize) requiredModules++;
                else requiredModules += (valueLeft % moduleSize) + 1;
            }

            // Value to be written
            bool[] values = new bool[((requiredModules-1) * moduleSize) + numOfRegisterToWrite];

            while (n < values.Length)
            {
                values[n] = relays[i];

                if (relayInternalIndex == 3)
                {
                    n += 5;
                    currModule++;
                    relayInternalIndex = -1;
                }
                else
                {
                    n++;
                }

                i++;
                relayInternalIndex++;
            }

            WriteToCrevis(register, new int[] { }, values, 2, 2);
        }
        #endregion



        #region Link Methods
        private void PingTimer()        //Start timer - send ping every PING_CYCLE
        {

            _LocalModemLastPing = System.DateTime.Now;
            _CrevisLastPing = System.DateTime.Now;

            _timer = new System.Threading.Timer(PingSender, null, 0, PING_CYCLE);
        }

        
        private void PingSender(object sender)      //Send pings to devices (Camera and Crevis)
        {
            if (_sleepMode)
            {
                _camera.Start();
                _sleepMode = false;
            }

            if ((System.DateTime.Now - _LocalModemLastPing).TotalMilliseconds >= LOCAL_MODEM_PING_LOOP)
            {
                try
                {
                    reply = pingToLink.Send(LOCAL_LINK_IP, PING_TIMEOUT);
                    if (reply.Status.ToString().Equals("Success"))
                    {
                        _modemAvilable = true;
                    }
                    else
                    {
                        _modemAvilable = false;
                    }
                }
                catch
                {
                    _modemAvilable = false;
                }

                _LocalModemLastPing = System.DateTime.Now;

            }

            //Crevis check

            double crevisDelta = (_crevisTimeout)/ CREVIS_KEEP_ALIVE_RETRY;
            if (((System.DateTime.Now - _CrevisLastPing).TotalMilliseconds >= crevisDelta) && !_crevisConn)
            {
                    _startSystem = false;
                    _emergency = false;
                
                try
                {
                    if (_initCrevisFlag)
                    {
                        Debug.WriteLine("******* INIT CREVIS ********");
                        crevisModbusClient = null;
                        crevisModbusClient = new ModbusClient(CREVIS_IP, MODBUS_TCP_PORT);
                        crevisModbusClient.ConnectionTimeout = 500;
                        _initCrevisFlag = false;
                    }
                    crevisModbusClient.Disconnect();
                    crevisModbusClient.Connect();
                    Debug.WriteLine("^^^^^^^^^^^^ CREVIS CONNECTED ^^^^^^^^^^^^");
                    Thread.Sleep(300);
                    WriteToCrevis(CREVIS_TIMEOUT_ADDR, new int[] { (_crevisTimeout / 100) }, new bool[] { false }, 1, 1);
                    WriteToCrevis(CREVIS_TIMEOUT_VALUE_ADDR, new int[] { 0, CREVIS_IDLE_STATE }, new bool[] { false }, 2, 1);
                    WriteToCrevis(CREVIS_AO_ADDR[_upDownAnalogChannel], new int[] { CREVIS_IDLE_STATE, CREVIS_IDLE_STATE, CREVIS_IDLE_STATE, CREVIS_IDLE_STATE }, new bool[] { false }, 2, 1);
                    WriteToCrevis(CREVIS_FIRST_RELAY_ADDR, new int[] { }, new bool[20], 2, 2);
                    _crevisConn = true;
                    Debug.WriteLine("^^^^^^^^^^^^ connection done ^^^^^^^^^^^^");
                }
                catch 
                {
                    Debug.WriteLine("Could not connect to Crevis!" + crevisModbusClient.Connected);
                }

                _CrevisLastPing = System.DateTime.Now;
            }

            if (((System.DateTime.Now - _CrevisLastPing).TotalMilliseconds >= crevisDelta) && _crevisConn)
            {
                System.DateTime t = System.DateTime.Now;
                int[] version;
                bool[] e_stop_val;
                
                try
                {
                    if ((System.DateTime.Now - _crevisLastCommand).TotalMilliseconds > crevisDelta)
                    {
                        if (!_isEstopPressed)
                        {
                            WriteToCrevis(CREVIS_RELAY_UPDOWN_ADDR, new int[] { }, new bool[] { false, false, false, false, false, false, false, false, false }, 2, 2);
                            WriteToCrevis(CREVIS_RELAY_CART_ADDR, new int[] { }, new bool[] { false }, 1, 2);
                            WriteToCrevis(FindAddress(CREVIS_RELAY_CART_ADDR + 1), new int[] { }, new bool[] { false }, 1, 2);
                        }

                        // Check Version & E-stop value
                        t = System.DateTime.Now;
                        lock (_lockCrevis)
                        {
                            version = crevisModbusClient.ReadHoldingRegisters(CREVIS_KEEP_ALIVE_ADDR, 1);
                            e_stop_val = crevisModbusClient.ReadCoils(CREVIS_RELAY_ESTOP_ADDR, 1);
                        }

                        // Version
                        if (version != null)
                        {
                            if (version[0] != 741) _CrevisKeepAliveCnt++;
                            else
                            {
                                if ((System.DateTime.Now - t).TotalMilliseconds > 250)
                                {
                                    _CrevisKeepAliveCnt++;
                                }
                                else
                                {
                                    //Crevis Connected!
                                    _CrevisKeepAliveCnt = 0;
                                    _crevisConn = true;
                                }
                            }
                        }
                        else
                        {
                            _CrevisKeepAliveCnt++;
                        }


                        
                        if ((e_stop_val[0] == false) && (_startSystem == true))
                        {
                            _crevisConn = false;
                            _remoteStop = true;
                        }
                        Debug.WriteLine("E-STOP: " + e_stop_val[0]);
                    }
                }
                catch 
                {
                    _CrevisKeepAliveCnt++;
                }

                if (_CrevisKeepAliveCnt >= CREVIS_KEEP_ALIVE_RETRY)
                {
                    _crevisConn = false;
                    _CrevisKeepAliveCnt = 0;
                    ChangeControlText(new Control[] { StepXLbl, StepZLbl }, new string[] { "0", "0" });
                }

                Debug.WriteLine("Crevis KA: " + _CrevisKeepAliveCnt + " , " + (System.DateTime.Now - t).TotalMilliseconds);

                _CrevisLastPing = System.DateTime.Now;
            }

            ControlVisibility(new Control[] { CameraConnectionBtn }, new bool[] { !_cameraConn });
            
            // Restart Camera
            if (((!_cameraConn) && (_crevisConn)) &&
                ((System.DateTime.Now - _cameraConnectTime).TotalMilliseconds > CAMERA_PING_LOOP))

            {
                _cameraConnectTime = System.DateTime.Now;
                Debug.WriteLine("-----------------------------Start Cam");
                StartCameraStream();
            }

            if (_crevisConn)
            {
                if (!_startUpRunning)
                {
                    if (_emergency)
                        ControlVisibility(new Control[] { startBtn, EstopBtn }, new bool[] { false, true });
                    else
                        ControlVisibility(new Control[] { startBtn, EstopBtn }, new bool[] { true, false });
                }

                //ControlVisibility(new Control[] { ConnectionBtn, NoConnectionBtn, ConnectionPicBox, NoConnectionPicBox, ConnectionLbl, NoConnectionLbl }, new bool[] { _crevisConn, !_crevisConn, _crevisConn, !_crevisConn, _crevisConn, !_crevisConn });
            }
            else
            {               
                ChangeControlText(new Control[] { StepXLbl, StepZLbl }, new string[] { "0", "0" });
                ControlVisibility(new Control[] { startBtn, EstopBtn }, new bool[] { false, false });
                //ControlVisibility(new Control[] { startBtn, EstopBtn, ConnectionBtn, NoConnectionBtn, ConnectionPicBox, NoConnectionPicBox, ConnectionLbl, NoConnectionLbl }, new bool[] { false, false, _crevisConn, !_crevisConn, _crevisConn, !_crevisConn, _crevisConn, !_crevisConn });
            }

            ControlVisibility(new Control[] { ConnectionPicBox, NoConnectionPicBox, ConnectionLbl, NoConnectionLbl }, new bool[] { _crevisConn, !_crevisConn, _crevisConn, !_crevisConn });

            if (!_cameraConn || !_crevisConn)
                Debug.WriteLine("Cam: " + _cameraConn + " Crevis: " + _crevisConn);

            if (!_cameraConn && !_crevisConn) _safeLblFlag = true;
            else _safeLblFlag = false;

            ControlVisibility(new Control[] { SafeLbl }, new bool[] { _safeLblFlag });
            ControlVisibility(new Control[] { noModemLbl }, new bool[] { !_modemAvilable });

            if (!_crevisConn)
                ChangeControlText(new Control[] { StepXLbl, StepZLbl }, new string[] { "0", "0" });

            if (_remoteStop)
            {
                _remoteStop = false;
            }

        }
        #endregion

    }

}