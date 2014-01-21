using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPacket
{
    class TelemetryPacket : IDataPacket
    {
        private readonly object sync = new object();

        public TelemetryData telemetryData;
        public DiagnosticData diagnosticData;
        public ElectricData electricData;
        public PositionData positionData;
        public ConfigurationData configurationData;
        bool _isValid;

        public TelemetryPacket()
        {
            telemetryData = new TelemetryData();
            diagnosticData = new DiagnosticData();
            electricData = new ElectricData();
            positionData = new PositionData();
            configurationData = new ConfigurationData();
        }

        public TelemetryPacket(string data)
        {
            lock (sync)
            {
                string[] split = data.Split('#');
                try
                {
                    telemetryData = new TelemetryData(split[0]);
                    diagnosticData = new DiagnosticData(split[1]);
                    electricData = new ElectricData(split[2]);
                    positionData = new PositionData(split[3]);
                    configurationData = new ConfigurationData(split[4]);
                    if (telemetryData.isValid() && diagnosticData.isValid() && electricData.isValid() && positionData.isValid() && configurationData.isValid())
                        _isValid = true;
                    else
                        _isValid = false;
                }
                catch (IndexOutOfRangeException)
                {
                    _isValid = false;
                }
            }
        }

        public void Update(string data)
        {
            lock (sync)
            {
                string[] split = data.Split('#');
                telemetryData.Update(split[0]);
                diagnosticData.Update(split[1]);
                electricData.Update(split[2]);
                positionData.Update(split[3]);
                configurationData.Update(split[4]);
                _isValid = true;
            }
        }

        public void SetChannelValue(Channel dataChannel, object obj)
        {
            lock (sync)
            {
                if (dataChannel >= Channel.Adblue && dataChannel <= Channel.WaterTemp)
                    telemetryData.SetChannelValue(dataChannel, obj);
                else if (dataChannel >= Channel.CabinDiag && dataChannel <= Channel.TiresDiag)
                    diagnosticData.SetChannelValue(dataChannel, obj);
                else if (dataChannel >= Channel.LowAdblueLevelWarning && dataChannel <= Channel.HighWaterTempWarning)
                    electricData.SetChannelValue(dataChannel, obj);
                else if (dataChannel >= Channel.PlayerPosX && dataChannel <= Channel.PlayerPosZ)
                    positionData.SetChannelValue(dataChannel, obj);
                else
                    configurationData.SetChannelValue(dataChannel, obj);
            }
        }

        public string CustomDataOutput(byte[] byteArray)
        {
            throw new NotImplementedException();
        }

        public Object GetChannelValue(Channel dataChannel)
        {
            if (dataChannel >= Channel.Adblue && dataChannel <= Channel.WaterTemp)
                return telemetryData.GetChannelValue(dataChannel);
            else if (dataChannel >= Channel.CabinDiag && dataChannel <= Channel.TiresDiag)
                return diagnosticData.GetChannelValue(dataChannel);
            else if (dataChannel >= Channel.LowAdblueLevelWarning && dataChannel <= Channel.HighWaterTempWarning)
                return electricData.GetChannelValue(dataChannel);
            else if (dataChannel >= Channel.PlayerPosX && dataChannel <= Channel.PlayerPosZ)
                return positionData.GetChannelValue(dataChannel);
            else
                return configurationData.GetChannelValue(dataChannel);
        }

        public bool isValid()
        {
            return _isValid;
        }


        public void GetChannelRange(out Channel begin, out Channel end)
        {
            begin = Channel.Adblue;
            end = Channel.WheelsCount;
        }

        public override string ToString()
        {
            return telemetryData.ToString() + '#' + diagnosticData.ToString() + '#' + electricData.ToString() + '#' + positionData.ToString() + '#' + configurationData.ToString();
        }

        public Type GetChannelType(Channel dataChannel)
        {
            if (dataChannel >= Channel.Adblue && dataChannel <= Channel.WaterTemp)
                return telemetryData.GetChannelType(dataChannel);
            else if (dataChannel >= Channel.CabinDiag && dataChannel <= Channel.TiresDiag)
                return diagnosticData.GetChannelType(dataChannel);
            else if (dataChannel >= Channel.LowAdblueLevelWarning && dataChannel <= Channel.HighWaterTempWarning)
                return electricData.GetChannelType(dataChannel);
            else if (dataChannel >= Channel.PlayerPosX && dataChannel <= Channel.PlayerPosZ)
                return positionData.GetChannelType(dataChannel);
            else
                return configurationData.GetChannelType(dataChannel);
        }
    }
}
