using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Telemetry_Server.NET
{
    class TelemetryData : DataPacket
    {
        private readonly object sync = new object();
        Object[] _dataArray;

        TripStat _fuelStat;

        public double adblue
        {
            get { return (double)_dataArray[0]; }
            set { _dataArray[0] = value; }
        }

        public double adblueAvgConsumption
        {
            get { return (double)_dataArray[1]; }
            set { _dataArray[1] = value; }
        }

        public double batteryVoltage
        {
            get { return (double)_dataArray[2]; }
            set { _dataArray[2] = value; }
        }

        public double brakeAirPressure
        {
            get { return (double)_dataArray[3]; }
            set { _dataArray[3] = value; }
        }

        public double brakeTemp
        {
            get { return (double)_dataArray[4]; }
            set { _dataArray[4] = value; }
        }

        public double cruiseControl
        {
            get { return (double)_dataArray[5]; }
            set { _dataArray[5] = value; }
        }

        public double rpm
        {
            get { return (double)_dataArray[6]; }
            set { _dataArray[6] = value; }
        }

        public int gear
        {
            get { return (int)_dataArray[7]; }
            set { _dataArray[7] = value; }
        }

        public double fuel
        {
            get { return (double)_dataArray[8]; }
            set { _dataArray[8] = value; }
        }

        public double fuelAvgConsumption
        {
            get { return (double)_dataArray[9]; }
            set { _dataArray[9] = value; }
        }

        public double odometer
        {
            get { return (double)_dataArray[10]; }
            set { _dataArray[10] = value; }
        }

        public double oilPressure
        {
            get { return (double)_dataArray[11]; }
            set { _dataArray[11] = value; }
        }

        public double oilTemp
        {
            get { return (double)_dataArray[12]; }
            set { _dataArray[12] = value; }
        }

        public uint retarderStep
        {
            get { return (uint)_dataArray[13]; }
            set { _dataArray[13] = value; }
        }

        public double speed
        {
            get { return (double)_dataArray[14]; }
            set { _dataArray[14] = value; }
        }

        public double waterTemp
        {
            get { return (double)_dataArray[15]; }
            set { _dataArray[15] = value; }
        }

        bool _isValid;
        PacketMode _mode;

        //For live-updated data
        public TelemetryData()
        {
            _fuelStat = new TripStat();
            _dataArray = new Object[16];
            _isValid = false;
            _mode = PacketMode.Live;
        }

        //For static data
        public TelemetryData(string data)
        {
            _fuelStat = new TripStat();
            _dataArray = new Object[16];
            _mode = PacketMode.Static;
            Update(data);
        }

        public bool isValid()
        {
            return _isValid;
        }

        public void Update(string data)
        {
            lock (sync)
            {
                try
                {
                    string[] splits = data.Split('|');
                    for (int i = 0; i < splits.Length; i++)
                    {
                        if (i == 7)
                            _dataArray[i] = Convert.ToInt32(splits[i]);
                        if (i == 13)
                            _dataArray[i] = Convert.ToUInt32(splits[i]);
                        else
                            _dataArray[i] = Convert.ToDouble(splits[i], new CultureInfo("en-US"));
                    }

                    //If this is live-updated packet, calculate average fuel consumption
                    if (_mode == PacketMode.Live)
                    {
                        _fuelStat.increaseDistance(odometer);
                        _fuelStat.increaseFuel(fuel);
                        fuelAvgConsumption = _fuelStat.avgFuelConsumption;
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
            if(dataChannel == Channel.Gear)
            {
                if(obj.GetType() != typeof(int))
                    throw new ArgumentException("dataChannel - data type mismatch. Integer expected");
            }
            else if(dataChannel == Channel.Retarder)
            {
                if(obj.GetType() != typeof(uint))
                    throw new ArgumentException("dataChannel - data type mismatch. Unsigned integer expected");
            }
            else
            {
                if(obj.GetType() != typeof(double))
                    throw new ArgumentException("dataChannel - data type mismatch. Double expected");
            }

            int startingChannel = (int)Channel.Adblue;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 15)
                throw new ArgumentException("Unknown channel!");
            
            lock(sync)
                _dataArray[destination] = obj;
        }

        public Object GetChannelValue(Channel dataChannel)
        {
            int startingChannel = (int)Channel.Adblue;
            int destination = (int)dataChannel - startingChannel;
            if (destination > 15)
                throw new ArgumentException("Unknown channel!");

            return _dataArray[destination];
        }

        public string CustomDataOutput(byte[] byteArray)
        {
            return "";
        }

        public void GetChannelRange(out Channel begin, out Channel end)
        {
            begin = Channel.Adblue;
            end = Channel.WaterTemp;
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
            if (dataChannel == Channel.Gear)
                return typeof(int);
            else if (dataChannel == Channel.Retarder)
                return typeof(uint);
            else
                return typeof(double);
        }

        public void SetPacketMode(PacketMode mode)
        {
            _mode = mode;
        }

        public PacketMode GetPacketMode()
        {
            return _mode;
        }
    }
}
