using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using DataPacket;

namespace Telemetry_Server.NET
{
    /// <summary>
    /// Class handling reading data from dataShare.data file
    /// <para>Thread safe... probably ;)</para>
    /// </summary>
    class DataReader
    {
        private static object _lock = new object();
        private static object _lock2 = new object();

        public static IDataPacket dataPacket;

        private static bool _overrideData = false;
        private static bool _run = true;

        public static StreamWriter writer;

        /// <summary>
        /// Enables overwriting sended data by channel testing code
        /// </summary>
        public static bool overrideData
        {
            get
            {
                return _overrideData;
            }
            set
            {
                lock (_lock)
                    _overrideData = value;
            }
        }

        /// <summary>
        /// Reads telemetry data from location specified in <seealso cref="Config.dataPathShare"/>
        /// </summary>
        public static void ReadData()
        {
            _run = true;

            //Create log file if user wants to
            if (Config.logData)
            {
                StringBuilder filename = new StringBuilder(DateTime.Now.ToString());
                filename.Replace(':', '_');
                writer = new StreamWriter(filename.ToString() + ".tds");
            }

            while (_run)
            {
                try
                {
                    //A bit ugly, but working hack to obtain data form file
                    FileStream stream = null;
                    while (true)
                    {
                        try
                        {
                            stream = File.Open(Config.dataSharePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            break;
                        }
                        catch { }
                    }

                    //Update packet and log
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string data = reader.ReadLine();
                        dataPacket.Update(data);
                        if (Config.logData)
                            writer.WriteLine(dataPacket.ToString());
                        stream.Close();
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Data file not found!"); //Whoops... dataShare.data couldn't be found
                    if (Config.logData)
                        writer.Close();
                    return;
                }
                Thread.Sleep(Config.readInterval);

                //Pause reading while user is testing channels
                while(_overrideData)
                    Thread.Sleep(Config.readInterval);
            }

            if (Config.logData)
                writer.Close();
        }

        /// <summary>
        /// Safely informs reading thread to stop
        /// </summary>
        public static void StopReader()
        {
            lock (_lock2)
                _run = false;
        }
    }
}
