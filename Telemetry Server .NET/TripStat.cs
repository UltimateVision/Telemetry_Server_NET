using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry_Server.NET
{
    /// <summary>
    /// Class used to count driven distance, collect information about fuel tank state and generating average fuel consumption rate
    /// </summary>
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

        /// <summary>
        /// Increases distance driven during active session
        /// </summary>
        /// <param name="odometer">Value of truck's odometer</param>
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

        /// <summary>
        /// Increases amount of fuel burned during active session
        /// </summary>
        /// <param name="fuelState">Value of amount of fuel in truck's tank</param>
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

        /// <summary>
        /// Starts new session
        /// </summary>
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

