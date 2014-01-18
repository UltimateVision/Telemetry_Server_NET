/*
 * DataPacket.cs
 * Interface for all .*Data classes
 * Channel and PacketMode codes
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telemetry_Server.NET
{
    enum Channel
    {
        //Telemetry
        Adblue = 0,
        AdblueAvgCons,
        BatteryVoltage,
        AirPressure,
        BrakesTemp,
        CruiseControl,
        RPM,
        Gear,
        Fuel,
        FuelAvgCons,
        Odometer,
        OilPressure,
        OilTemp,
        Retarder,
        Speed,
        WaterTemp,
        //Diagnostics
        CabinDiag,
        ChassisDiag,
        EngineDiag,
        TransmissionDiag,
        TiresDiag,
        //Electrics
        LowAdblueLevelWarning,
        LowVoltageWarning,
        ActiveEmergencyBrake,
        LowAirPressureWarning,
        ElectricsOn,
        EngineOn,
        LowFuelLevelWarning,
        ActiveLeftBlinker,
        ActiveRightBlinker,
        ActiveLowBeamLights,
        ActiveHighBeamLights,
        OilPressureWarning,
        ActiveHandbrake,
        HighWaterTempWarning,
        //Player position
        PlayerPosX,
        PlayerPosY,
        PlayerPosZ,
        //Configuration data
        TruckBrand,
        TruckModel,
        FuelCapacity,
        AdblueCapacity,
        RPMRedline,
        GearsForward,
        GearsBackward,
        RetarderSteps,
        CriticalFuelAmount,
        CriticalAirPressure,
        EmergencyBrakeActivationPressure,
        CriticalOilPressure,
        CriticalWaterTemp,
        CriticalBatteryVoltage,
        WheelsCount
    }

    enum PacketMode
    {
        Static = 0,
        Live
    }

    interface DataPacket
    {
        void Update(string data);
        void SetChannelValue(Channel dataChannel, Object obj);
        Object GetChannelValue(Channel dataChannel);
        void GetChannelRange(out Channel begin, out Channel end);
        string CustomDataOutput(byte[] byteArray);
        Type GetChannelType(Channel dataChannel);
        bool isValid();
    }
}
