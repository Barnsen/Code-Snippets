/*
  _   _    ____    _______     _______   ______    _____   _______   ______   _____    _ 
 | \ | |  / __ \  |__   __|   |__   __| |  ____|  / ____| |__   __| |  ____| |  __ \  | |
 |  \| | | |  | |    | |         | |    | |__    | (___      | |    | |__    | |  | | | |
 | . ` | | |  | |    | |         | |    |  __|    \___ \     | |    |  __|   | |  | | | |
 | |\  | | |__| |    | |         | |    | |____   ____) |    | |    | |____  | |__| | |_|
 |_| \_|  \____/     |_|         |_|    |______| |_____/     |_|    |______| |_____/  (_)
                                                                                                                                                                                                          
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ets2SdkClient;

namespace ETS2_CSharp
{
    public class ETS2API
    {
        #region new
        new float x;
        new float y;
        new float z;
        new int speed;
        new int gear;
        new bool pause;
        new string companyname;
        new float jobdistance;
        new string jobcity;
        #endregion
        public Ets2SdkTelemetry Telemetry;
        public void Initialize()
        {
            Telemetry = new Ets2SdkTelemetry();
            Telemetry.Data += Telemetry_Data;
        }
        private void Telemetry_Data(Ets2Telemetry data, bool updated)
        {
            try
            {
                x = data.Physics.CoordinateX;
                y = data.Physics.CoordinateY;
                z = data.Physics.CoordinateZ;
                speed = (int)data.Drivetrain.SpeedKmh;
                gear = data.Drivetrain.Gear;
                pause = data.Paused;
                companyname = data.Job.CompanySource;
                jobdistance = data.Job.NavigationDistanceLeft;
                jobcity = data.Job.CompanyDestination;
            }
            catch { }
        }

        public float getCoordinateX()
        {
            return x;
        }
        public float getCoordinateY()
        {
            return y;
        }
        public float getCoordinateZ()
        {
            return z;
        }
        public int getTruckSpeed()
        {
            return speed;
        }
        public int getTruckGear()
        {
            return gear;
        }
        public bool isPaused()
        {
            return pause;
        }
        public string getCompanyName()
        {
            return companyname;
        }
        public float getJobDistance()
        {
            return jobdistance;
        }
        public string getJobCity()
        {
            return jobcity;
        }
        public bool isJobActive()
        {
            if (getJobDistance().ToString() == "0")
                return false;
            else
                return true;
        }
    }
}
