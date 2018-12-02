using System;
using System.Threading;
using System.Collections.Generic;
using SharpDX.DirectInput;
using System.Diagnostics;

namespace CTI_Controller
{
    public class CTI_Joystick
    {

        public event EventHandler<ButtonsEventArgs> ButtonChanged;
        public event EventHandler<JoystickEventArgs> JoystickChanged;

        Timer _timer = null;
        DirectInput directInput = null;
        Joystick _joystick = null;

        private int[] _steps;
        private Dictionary<int, int> _safeAxis;
        private bool[] _buttons;
        private int[] _prevValue = new int[] { 0, 0, 0, 0, 0, 0 };
        private bool[] _inverseJoystick = new bool[6];
        private bool[] _enableAxis = new bool[6];
        private bool[] _enableBtn = new bool[32];
        private bool[] _enableContCapture = new bool[6];

        private int MAX_VAL;      //Maximum joystick value
        private int MIN_VAL;        //Minimum joystick value
        private int CENTER;       //Middle joystick value
        private const int CYCLE_TIME = 150;
        private const int FILTER = 200;
        private const string PRODUCT_GUID = "{00c5068e-0000-0000-0000-504944564944}";   //The product GUID of the joysticks and buttons


        public CTI_Joystick()
        {
            try
            {
                _buttons = new bool[32];
                _steps = new int[6];
                _safeAxis = new Dictionary<int, int>();
                directInput = new DirectInput();

                //Find Joystick and Buttons by product GUID
                foreach (var deviceInstance in directInput.GetDevices())
                {
                    Debug.WriteLine(deviceInstance.ProductGuid + ", " +  deviceInstance.ProductName);
                    Guid required = new Guid(PRODUCT_GUID);
                    Guid joystickGuid = deviceInstance.ProductGuid;

                    if (joystickGuid == required)
                        {
                        _joystick = new Joystick(directInput, joystickGuid);
                        return;
                    }
                }
            }
            catch (Exception e)     //If joystick and buttons not found
            {
                _joystick = null;
                throw (new Exception("Internal Error - " + e.ToString()));
            }

            _joystick = null;
            Debug.WriteLine("Joystick not found");
        }

        public bool isConnected
        {
            get
            {
                return (_joystick != null);
            }
        }

        public void enableButton(int num, bool ena)
        {
            _enableBtn[num] = ena;
        }

        public void invert(int num, bool inv)
        {
            _inverseJoystick[num] = inv;
        }

        public bool Acquire(bool state, bool rX = true, bool X = true, bool rY = true, bool Y = true, bool rZ = true, bool Z = true,
                            bool CrX = false, bool CX = false, bool CrY = false, bool CY = false, bool CrZ = false, bool CZ = false)
        {
            if (_joystick == null) return false;

            _enableAxis[0] = rX;
            _enableAxis[1] = X;
            _enableAxis[2] = rY;
            _enableAxis[3] = Y;
            _enableAxis[4] = rZ;
            _enableAxis[5] = Z;


            _enableContCapture[0] = CrX;
            _enableContCapture[1] = CX;
            _enableContCapture[2] = CrY;
            _enableContCapture[3] = CY;
            _enableContCapture[4] = CrZ;
            _enableContCapture[5] = CZ;

            if (state == true)
            {
                _timer = new Timer(AcquireJoystickInformation, null, 0, CYCLE_TIME);
                
            }
            else
            {
                _timer.Dispose();
            }

            return true;
        }

        /// <summary>
        /// Receives 6 item array of steps per axis.where the id of the axis is the index of the array.
        /// Axes:
        /// 0 => Rotation X
        /// 1 => X
        /// 2 => Rotation Y
        /// 3 => Y
        /// 4 => Rotation Z
        /// 5 => Z
        /// </summary>
        public int[] Steps
        {
            get
            {
                return _steps;
            }
            set
            {
                if (value.Length != 6) return;
                Array.Copy(value, _steps, 6);
            }
        }

        public int MaxValue
        {
            get
            {
                return MAX_VAL;
            }
            set
            {
                MAX_VAL = value;
            }
        }

        public int MinValue
        {
            get
            {
                return MIN_VAL;
            }
            set
            {
                MIN_VAL = value;
            }
        }

        public int CenterValue
        {
            get
            {
                return CENTER;
            }
            set
            {
                CENTER = value;
            }
        }

        /// <summary>
        /// Attach button btnID as a safe for joystick axisID
        /// </summary>
        public bool AddSafeAxis(int axisID, int btnID)
        {
            if ((btnID >= 32) || (btnID < 0)) return false;

            _safeAxis.Add(axisID, btnID);
            return true;
        }

        /// <summary>
        /// Remove safe from joystick axisID
        /// </summary>
        public bool RemoveSafeAxis(int axisID)
        {
            if (_safeAxis.ContainsKey(axisID) == true)
                _safeAxis.Remove(axisID);
            else
                return false;

            return true;
        }

        public bool CleanSafeAxis(int axisID, int btnID)
        {
            _safeAxis.Clear();

            return true;
        }

        private void AcquireJoystickInformation(object sender)
        {
            int[] currentSteps = new int[6];

            if (_joystick == null) return;

            _joystick.Acquire();
            JoystickState joystickState = new JoystickState();
            _joystick.GetCurrentState(ref joystickState);


            if(_enableAxis[0])
            {
                currentSteps[0] = GetStepbyValueLinear(joystickState.RotationX, _steps[0], 0);     //X axis

                if (Math.Abs(_prevValue[0] - joystickState.RotationX) > FILTER)
                    OnJoystickChanged(0, joystickState.RotationX, currentSteps[0]);
                else if((_enableContCapture[0]) && 
                    ((joystickState.RotationX > CENTER + FILTER) || (joystickState.RotationX <= CENTER - FILTER)))
                    OnJoystickChanged(0, joystickState.RotationX, currentSteps[0]);


                _prevValue[0] = joystickState.RotationX;
            }

            if (_enableAxis[1])
            {
                currentSteps[1] = GetStepbyValueLinear(joystickState.X, _steps[1], 1);

                if (Math.Abs(_prevValue[1] - joystickState.X) > FILTER)
                    OnJoystickChanged(1, joystickState.X, currentSteps[1]);
                else if ((_enableContCapture[1]) &&
                     ((joystickState.X > CENTER + FILTER) || (joystickState.X <= CENTER - FILTER)))
                    OnJoystickChanged(1, joystickState.X, currentSteps[1]);

                _prevValue[1] = joystickState.X;
            }

            if (_enableAxis[2])
            {
                currentSteps[2] = GetStepbyValueLinear(joystickState.RotationY, _steps[2], 2);

                if (Math.Abs(_prevValue[2] - joystickState.RotationY) > FILTER)
                    OnJoystickChanged(2, joystickState.RotationY, currentSteps[2]);
                else if ((_enableContCapture[2]) &&
                    ((joystickState.RotationY > CENTER + FILTER) || (joystickState.RotationY <= CENTER - FILTER)))
                    OnJoystickChanged(2, joystickState.RotationY, currentSteps[2]);

                _prevValue[2] = joystickState.RotationY;
            }

            if (_enableAxis[3])
            {
                currentSteps[3] = GetStepbyValueLinear(joystickState.Y, _steps[3], 3);

                if (Math.Abs(_prevValue[3] - joystickState.Y) > FILTER)
                    OnJoystickChanged(3, joystickState.Y, currentSteps[3]);
                else if ((_enableContCapture[3]) &&
                    ((joystickState.Y > CENTER + FILTER) || (joystickState.Y <= CENTER - FILTER)))
                    OnJoystickChanged(3, joystickState.Y, currentSteps[3]);

                _prevValue[3] = joystickState.Y;
            }

            if (_enableAxis[4])
            {
                currentSteps[4] = GetStepbyValueLinear(joystickState.RotationZ, _steps[4], 4);

                if (Math.Abs(_prevValue[4] - joystickState.RotationZ) > FILTER)
                    OnJoystickChanged(4, joystickState.RotationZ, currentSteps[4]);
                else if ((_enableContCapture[4]) &&
                    ((joystickState.RotationZ > CENTER + FILTER) || (joystickState.RotationZ <= CENTER - FILTER)))
                    OnJoystickChanged(4, joystickState.RotationZ, currentSteps[4]);

                _prevValue[4] = joystickState.RotationZ;
            }

            if (_enableAxis[5])
            {
                currentSteps[5] = GetStepbyValueLinear(joystickState.Z, _steps[5], 5);

                if (Math.Abs(_prevValue[5] - joystickState.Z) > FILTER)
                    OnJoystickChanged(5, joystickState.Z, currentSteps[5]);
                else if ((_enableContCapture[5]) &&
                    ((joystickState.Z > CENTER + FILTER) || (joystickState.Z <= CENTER - FILTER)))
                    OnJoystickChanged(5, joystickState.Z, currentSteps[5]);

                _prevValue[5] = joystickState.Z;
            }

            // Handle Buttons
            for (int i = 0; i < 32; i++)
            {
                if (_buttons[i] != joystickState.Buttons[i])
                {
                    OnButtonChanged(i, joystickState.Buttons[i]);
                }
                _buttons[i] = joystickState.Buttons[i];
            } 
           
        }

        /// <summary>
        /// Convert joystick value to step linearly
        /// </summary>
        private int GetStepbyValueLinear(int CurrentValue, int numOfSteps, int index)
        {
            if (numOfSteps == 0) return 0;

            int i, Neg = 0, result;
            int intervalSize = Convert.ToInt32(Math.Round((double)((MAX_VAL - CENTER) / numOfSteps)));
            if (CurrentValue < (CENTER + 1500) && CurrentValue > (CENTER - 1500)) return 0;
            if (CurrentValue < CENTER)
            {
                Neg = 1;
                CurrentValue = MAX_VAL - CurrentValue;
            }
            for (i = 0; i < numOfSteps; i++)
            {
                if (CurrentValue > (CENTER + (i * intervalSize)) && CurrentValue <= (CENTER + (i + 1) * intervalSize))
                {
                    if (Neg == 0)
                    {
                        if (_inverseJoystick[index])
                            result = -(i + 1);
                        else
                            result = i + 1;
                    }
                    else
                    {
                        if (_inverseJoystick[index])
                            result = i + 1;
                        else
                            result = -(i + 1);
                    }
                    return result;
                }
            }
            if (Neg == 0)
            {
                if (_inverseJoystick[index])
                    result = -i;
                else
                    result = i;
            }
            else
            {
                if (_inverseJoystick[index])
                    result = i;
                else
                    result = -i;
            }
            return result;

        }

        /// <summary>
        /// Convert joystick value to step manually
        /// </summary>
        private int GetStepsbyValueManually(int currentValue, int[] stepsValues, int numOfSteps)
        {
            int i;
            for (i = 0; i < 2*numOfSteps + 2; i++)
            {
                if (currentValue>stepsValues[i] && currentValue <= stepsValues[i + 1])
                {
                    return (i - numOfSteps);
                }
            }

            return (i - numOfSteps);
        }

        /// <summary>
        /// Button pushed
        /// </summary>
        private void OnButtonChanged(int id, bool val)
        {
            if (_enableBtn[id] == false) return;
            Debug.Write("btn: " + id + val);
            if (ButtonChanged != null)
                ButtonChanged(this, new ButtonsEventArgs() { ID = id, value = val });
        }

        /// <summary>
        /// Joystick moved
        /// </summary>
        private void OnJoystickChanged(int id, int val, int step)
        {
            if (JoystickChanged == null) return;

            if (_safeAxis.ContainsKey(id))
            {
                int btn = _safeAxis[id];
                if (_buttons[btn] == true)
                    JoystickChanged(this, new JoystickEventArgs() { ID = id, value = val, step = step });
            }
            else
            {
                JoystickChanged(this, new JoystickEventArgs() { ID = id, value = val, step = step });
            }
        }
    }

    public class ButtonsEventArgs : EventArgs
    {
        public int ID { get; set; }
        public bool value { get; set; }
    }

    public class JoystickEventArgs : EventArgs
    {
        public int ID { get; set; }
        public int value { get; set; }
        public int step { get; set; }
    }
}