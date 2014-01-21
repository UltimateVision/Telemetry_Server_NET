using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataPacket
{
    class ConfigurationData : IDataPacket
    {
        private readonly object sync = new object();
        Object[] _dataArray;
        bool _isValid;

        public string truckBrand
        {
            get { return (string)_dataArray[0]; }
            set { _dataArray[0] = value; }
        }

        public string truckModel
        {
            get { return (string)_dataArray[1]; }
            set { _dataArray[1] = value; }
        }

        public double fuelCapacity
        {
            get { return (double)_dataArray[3]; }
            set { _dataArray[2] = value; }
        }

        public double adblueCapacity
        {
            get { return (double)_dataArray[3]; }
            set { _dataArray[3] = value; }
        }

        public double rpmRedline
        {
            get { return (double)_dataArray[4]; }
            set { _dataArray[4] = value; }
        }

        public uint gearsForward
        {
            get { return (uint)_dataArray[5]; }
            set { _dataArray[5] = value; }
        }

        public uint gearsBackward
        {
            get { return (uint)_dataArray[6]; }
            set { _dataArray[6] = value; }
        }

        public uint retarderSteps
        {
            get { return (uint)_dataArray[7]; }
            set { _dataArray[7] = value; }
        }

        public double criticalFuelAmount
        {
            get { return (double)_dataArray[8]; }
            set { _dataArray[8] = value; }
        }

        public double criticalAirPressure
        {
            get { return (double)_dataArray[9]; }
            set { _dataArray[9] = value; }
        }

        public double emergencyBrakeActivationPressure
        {
            get { return (double)_dataArray[10]; }
            set { _dataArray[10] = value; }
        }

        public double criticalOilPressure
        {
            get { return (double)_dataArray[11]; }
            set { _dataArray[11] = value; }
        }

        public double criticalWaterTemp
        {
            get { return (double)_dataArray[12]; }
            set { _dataArray[12] = value; }
        }

        public double criticalBatteryVoltage
        {
            get { return (double)_dataArray[13]; }
            set { _dataArray[13] = value; }
        }

        public uint wheelsCount
        {
            get { return (uint)_dataArray[14]; }
            set { _dataArray[14] = value; }
        }

        public ConfigurationData()
        {
            _dataArray = new Object[15];
            _isValid = false;
        }

        public ConfigurationData(string data)
        {
            _dataArray = new Object[15];
            Update(data);
        }

        public void Update(string data)
        {
            lock (sync)
            {
                string[] split = data.Split('|');
                try
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (i == 0 || i == 1)
                            _dataArray[i] = split[i];
                        else if ((i >= 5 && i <= 7) || i == 14)
                            _dataArray[i] = Convert.ToUInt32(split[i]);
                        else
                            _dataArray[i] = Convert.ToDouble(split[i], new CultureInfo("en-US"));
                    }
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
            int startingChannel = (int)Channel.TruckBrand;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 14)
                throw new ArgumentException("Unknown channel!");
            if ((destination == 0 || destination == 1) && obj.GetType() != typeof(string))
                throw new ArgumentException("Data type mismatch - string expected!");
            else if (((destination >= 5 && destination <= 7) || destination == 14) && obj.GetType() != typeof(uint))
                throw new ArgumentException("Data type mismatch - unsigned integer expected!");
            else if(obj.GetType() != typeof(double))
                throw new ArgumentException("Data type mismatch - double expected!");

            lock(sync)
                _dataArray[destination] = obj;
        }

        public object GetChannelValue(Channel dataChannel)
        {
            int startingChannel = (int)Channel.TruckBrand;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 14)
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
            begin = Channel.TruckBrand;
            end = Channel.WheelsCount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Object o in _dataArray)
            {
                if(o.GetType() == typeof(double))
                {
                    double d = (double)o;
                    sb.Append(d.ToString(new CultureInfo("en-US")));
                }
                else
                    sb.Append(o.ToString());
                sb.Append('|');
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public Type GetChannelType(Channel dataChannel)
        {
            int startingChannel = (int)Channel.TruckBrand;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 14)
                throw new ArgumentException("Unknown channel!");
            if (destination == 0 || destination == 1)
                return typeof(string);
            else if ((destination >= 5 && destination <= 7) || destination == 14)
                return typeof(uint);
            else
                return typeof(double);
        }
    }
}
