//Class used to count driven distance, collect information about fuel tank state and generating average fuel consumption rate

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry_Server.NET
{
    class TripStat
    {
        double _distanceDriven = 0;
        public double distanceDriven
        {
            get
            {
                return _distanceDriven;
            }
        }
        public string distanceDrivenStr
        {
            get
            {
                return _distanceDriven.ToString("0.00");
            }
        }

        double _avgFuelConsumption = 0;
        public double avgFuelConsumption
        {
            get
            {
                return _avgFuelConsumption;
            }
        }
        public string avgFuelConsumptionStr
        {
            get
            {
                return _avgFuelConsumption.ToString("0.00");
            }
        }

        double lastOdometerState = 0;
        double lastFuelState = 0;
        double fuelUsed = 0;

        public TripStat()
        {
        }

        public void increaseDistance(double odometer)
        {
            if (lastOdometerState != 0)
            {
                lock (this)
                {
                    _distanceDriven += odometer - lastOdometerState;
                    lastOdometerState = odometer;
                    _avgFuelConsumption = fuelUsed / _distanceDriven;
                }
            }
            else
            {
                lock (this)
                {
                    lastOdometerState = odometer;
                }
            }
        }

        public void increaseFuel(double fuelState)
        {
            if (lastFuelState != 0)
            {
                lock (this)
                {
                    if(fuelState < lastFuelState) //??
                        fuelUsed += lastFuelState - fuelState;
                    lastFuelState = fuelState;
                }
            }
            else
            {
                lock (this)
                {
                    lastFuelState = fuelState;
                }
            }
        }

        public void resetData()
        {
            lock (this)
            {
                _distanceDriven = 0;
                _avgFuelConsumption = 0;
                lastFuelState = 0;
                lastOdometerState = 0;
                fuelUsed = 0;
            }
        }
    }
}

