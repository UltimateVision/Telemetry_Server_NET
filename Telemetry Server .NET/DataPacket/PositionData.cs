using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataPacket
{
    class PositionData : IDataPacket
    {
        private readonly object sync = new object();
        Object[] _dataArray;
        bool _isValid;

        public double positionX
        {
            get { return (double)_dataArray[0]; }
            set { _dataArray[0] = value; }
        }

        public double positionY
        {
            get { return (double)_dataArray[1]; }
            set { _dataArray[1] = value; }
        }

        public double positionZ
        {
            get { return (double)_dataArray[2]; }
            set { _dataArray[2] = value; }
        }

        public PositionData()
        {
            _dataArray = new Object[3];
            _isValid = false;
        }

        public PositionData(string data)
        {
            _dataArray = new Object[3];
            Update(data);
        }

        public void Update(string data)
        {
            lock (sync)
            {
                string[] split = data.Split('|');
                try
                {
                    for (int i = 0; i < split.Length; i++)
                    {
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
            if(obj.GetType() != typeof(double))
                throw new ArgumentException("Data type mismatch - double expected");

            int startingChannel = (int)Channel.PlayerPosX;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 2)
                throw new ArgumentException("Unknown channel!");

            lock(sync)
                _dataArray[destination] = obj;
        }

        public object GetChannelValue(Channel dataChannel)
        {
            int startingChannel = (int)Channel.PlayerPosX;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 2)
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
            begin = Channel.PlayerPosX;
            end = Channel.PlayerPosZ;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Object o in _dataArray)
            {
                double d = (double)o;
                sb.Append(d.ToString(new CultureInfo("en-US")));
                sb.Append('|');
            }
            sb.Remove(sb.Length - 1,1);

            return sb.ToString();
        }

        public Type GetChannelType(Channel dataChannel)
        {
            return typeof(double);
        }
    }
}
