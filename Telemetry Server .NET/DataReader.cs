using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Telemetry_Server.NET
{
    class DataReader
    {
        private static object _lock = new object();
        private static object _lock2 = new object();

        public static string dataFilePath;
        public static DataPacket dataPacket;

        private static bool _overrideData = false;
        private static bool _run = true;

        public static StreamWriter writer;

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

        public static void ReadData()
        {
            _run = true;

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
                    MessageBox.Show("Data file not found!");
                    if (Config.logData)
                        writer.Close();
                    return;
                }
                Thread.Sleep(Config.readInterval);

                while(_overrideData)
                    Thread.Sleep(Config.readInterval);
            }

            if (Config.logData)
                writer.Close();
        }

        public static void StopReader()
        {
            lock (_lock2)
                _run = false;
        }
    }
}
