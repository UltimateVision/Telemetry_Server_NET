using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Telemetry_Server.NET
{
    class DiagnosticData : DataPacket
    {
        Object[] _dataArray;

        public double chassis
        {
            get { return (double)_dataArray[0]; }
            set { _dataArray[0] = value; }
        }

        public double cabin
        {
            get { return (double)_dataArray[1]; }
            set { _dataArray[1] = value; }
        }

        public double engine
        {
            get { return (double)_dataArray[2]; }
            set { _dataArray[2] = value; }
        }

        public double transmission
        {
            get { return (double)_dataArray[3]; }
            set { _dataArray[3] = value; }
        }

        public double tires
        {
            get { return (double)_dataArray[4]; }
            set { _dataArray[4] = value; }
        }

        bool _isValid;

        public DiagnosticData()
        {
            _dataArray = new Object[5];
            _isValid = false;
        }

        public DiagnosticData(string data)
        {
            _dataArray = new Object[5];
            Update(data);
        }

        public void Update(string data)
        {
            string[] split = data.Split('|');
            try
            {
                for(int i = 0; i < _dataArray.Length; i++)
                    _dataArray[i] = Convert.ToDouble(split[i], new CultureInfo("en-US"));
                _isValid = true;
            }
            catch (IndexOutOfRangeException)
            {
                _isValid = false;
            }
        }

        public void SetChannelValue(Channel dataChannel, object obj)
        {
            if(obj.GetType() != typeof(double))
                throw new ArgumentException("Data type mismatch - double expected");

            int startingChannel = (int)Channel.CabinDiag;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 4)
                throw new ArgumentException("Unknown channel!");

            _dataArray[destination] = obj;
        }

        public object GetChannelValue(Channel dataChannel)
        {
            int startingChannel = (int)Channel.CabinDiag;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 4)
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
            begin = Channel.CabinDiag;
            end = Channel.TiresDiag;
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
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public Type GetChannelType(Channel dataChannel)
        {
            return typeof(double);
        }
    }
}
