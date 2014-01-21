using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPacket
{
    class ElectricData : IDataPacket
    {
        private readonly object sync = new object();
        Object[] _dataArray;

        public bool adblueLowLevelWarning
        {
            get { return (bool)_dataArray[0]; }
            set { _dataArray[0] = value; }
        }

        public bool lowBatteryVoltageWarning
        {
            get { return (bool)_dataArray[1]; }
            set { _dataArray[1] = value; }
        }

        public bool activeEmergencyBrake
        {
            get { return (bool)_dataArray[2]; }
            set { _dataArray[2] = value; }
        }

        public bool lowAirPressureWarning
        {
            get { return (bool)_dataArray[3]; }
            set { _dataArray[3] = value; }
        }

        public bool electricOn
        {
            get { return (bool)_dataArray[4]; }
            set { _dataArray[4] = value; }
        }

        public bool engineOn
        {
            get { return (bool)_dataArray[5]; }
            set { _dataArray[5] = value; }
        }

        public bool fuelLowLevelWarning
        {
            get { return (bool)_dataArray[6]; }
            set { _dataArray[6] = value; }
        }

        public bool leftBlinkerActive
        {
            get { return (bool)_dataArray[7]; }
            set { _dataArray[7] = value; }
        }

        public bool rightBlinkerActive
        {
            get { return (bool)_dataArray[8]; }
            set { _dataArray[8] = value; }
        }

        public bool lowBeamLightsActive
        {
            get { return (bool)_dataArray[9]; }
            set { _dataArray[9] = value; }
        }

        public bool highBeamLightsActive
        {
            get { return (bool)_dataArray[10]; }
            set { _dataArray[10] = value; }
        }

        public bool oilPressureWarning
        {
            get { return (bool)_dataArray[11]; }
            set { _dataArray[11] = value; }
        }

        public bool handbrakeActive
        {
            get { return (bool)_dataArray[12]; }
            set { _dataArray[12] = value; }
        }

        public bool waterTempWarning
        {
            get { return (bool)_dataArray[13]; }
            set { _dataArray[13] = value; }
        }

        bool _isValid;

        public ElectricData()
        {
            _dataArray = new Object[14];
            _isValid = false;
        }

        public ElectricData(string data)
        {
            _dataArray = new Object[14];
            Update(data);
        }

        private bool parseBoolean(char value)
        {
            return (value == '1');
        }

        private char boolToChar(bool value)
        {
            if (value)
                return '1';
            return '0';
        }

        public void Update(string data)
        {
            lock (sync)
            {
                try
                {
                    for (int i = 0; i < _dataArray.Length; i++)
                        _dataArray[i] = parseBoolean(data[i]);
                    _isValid = true;
                }
                catch (IndexOutOfRangeException)
                {
                    _isValid = false;
                }
            }
        }

        public void SetChannelValue(Channel dataChannel, object obj)
        {
            if(obj.GetType() != typeof(bool))
                throw new ArgumentException("Data type mismatch - bool expected");

            int startingChannel = (int)Channel.LowAdblueLevelWarning;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 13)
                throw new ArgumentException("Unknown channel!");

            lock(sync)
                _dataArray[destination] = obj;
        }

        public object GetChannelValue(Channel dataChannel)
        {
            int startingChannel = (int)Channel.LowAdblueLevelWarning;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 13)
                throw new ArgumentException("Unknown channel!");

            return _dataArray[destination];
        }

        public string CustomDataOutput(byte[] byteArray)
        {
            throw new NotImplementedException();
        }

        public bool isValid()
        {
            return _isValid;
        }

        public void GetChannelRange(out Channel begin, out Channel end)
        {
            begin = Channel.LowAdblueLevelWarning;
            end = Channel.HighWaterTempWarning;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Object o in _dataArray)
                sb.Append(boolToChar((bool)o));

            return sb.ToString();
        }

        public Type GetChannelType(Channel dataChannel)
        {
            return typeof(bool);
        }
    }
}
