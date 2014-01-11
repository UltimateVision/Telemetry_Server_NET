using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Telemetry_Server.NET
{
    class Config
    {
        public static string dataSharePath;
        public static string websiteAddress;
        public static string urlFormat;
        public static int readInterval;
        public static int sendInterval;
        public static bool logData;
        public static bool usePost;
        public static bool useGet;

        public static string GetURLData(string data = null)
        {
            StringBuilder sb = new StringBuilder();
            if(useGet)
                sb.Append(websiteAddress);
            StringBuilder tempData = new StringBuilder(urlFormat);
            tempData.Replace("[DATA]", data);
            sb.Append(tempData.ToString());
            return sb.ToString();
        } 

        public static void SerializeConfig()
        {
            using(StreamWriter sw = new StreamWriter("config.ini"))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(dataSharePath + '|');
                sb.Append(websiteAddress + '|');
                sb.Append(urlFormat + '|');
                sb.Append(readInterval.ToString() + '|');
                sb.Append(sendInterval.ToString() + '|');
                sb.Append(logData.ToString() + '|');
                sb.Append(usePost.ToString() + '|');
                sb.Append(useGet.ToString());
                sw.WriteLine(sb.ToString());
            }
        }

        public static void SetDefault()
        {
            readInterval = 500;
            sendInterval = 500;
            dataSharePath = "";
            websiteAddress = "";
            urlFormat = "?data=[DATA]";
        }

        public static void ReadConfig()
        {
            try
            {
                using (StreamReader sr = new StreamReader("config.ini"))
                {
                    string[] split = sr.ReadLine().Split('|');
                    try
                    {
                        dataSharePath = split[0];
                        websiteAddress = split[1];
                        urlFormat = split[2];
                        readInterval = Convert.ToInt32(split[3]);
                        sendInterval = Convert.ToInt32(split[4]);
                        logData = Convert.ToBoolean(split[5]);
                        usePost = Convert.ToBoolean(split[6]);
                        useGet = Convert.ToBoolean(split[7]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        SetDefault();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                SetDefault();
            }
        }
    }
}
