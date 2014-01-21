using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using DataPacket;
using TelemetryPlugin;

namespace Telemetry_Server.NET
{
    public partial class Form1 : Form
    {
        SocketServer server;
        WebSender webSender;
        Thread readingThread;

        int clientCount = 0;

        public delegate void IncrementClient();
        public IncrementClient incrementClient;

        public delegate void DecrementClient();
        public DecrementClient decrementClient;

        public delegate void ChangeWebServerStatus(string status);
        public ChangeWebServerStatus changeWebStatus;

        bool serverRunning = false;
        bool webTransferRunning = false;
        bool testingVisible = false;

        public Form1()
        {
            InitializeComponent();
            readingThread = new Thread(new ThreadStart(DataReader.ReadData));
            Config.ReadConfig();
            openFileDialog1 = new OpenFileDialog();
            DataReader.dataPacket = new TelemetryPacket();
            server = new SocketServer(this);
            webSender = new WebSender(this);
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            Config.readInterval = 500;
            Config.sendInterval = 500;
            clientCountLabel.Text = clientCount.ToString();
            incrementClient = new IncrementClient(incrementClientCount);
            decrementClient = new DecrementClient(decrementClientCount);
            changeWebStatus = new ChangeWebServerStatus(changeWebStatusText);
            ipLabel.Text += ' ' + SocketServer.GetLocalIP();

            PluginLoader.LoadPlugins();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(readingThread.IsAlive)
                readingThread.Abort();

            if(serverRunning)
                server.Stop();

            if(webTransferRunning)
                webSender.StopTransmission();
        }

        private void incrementClientCount()
        {
            clientCount++;
            clientCountLabel.Text = clientCount.ToString();
        }

        private void decrementClientCount()
        {
            clientCount--;
            clientCountLabel.Text = clientCount.ToString();
        }

        private void changeWebStatusText(string status)
        {
            webStatusLabel.Text = "Status: " + status;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (readingThread.IsAlive)
            {
                if (!serverRunning)
                {
                    server.Start();
                    serverRunning = true;
                    button2.Text = "Stop";
                }
                else
                {
                    server.Stop();
                    serverRunning = false;
                    button2.Text = "Start";
                }
            }
            else
                MessageBox.Show("Start data read first!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            TelemetryPacket t;
            lock (this)
            {
                t = (TelemetryPacket)DataReader.dataPacket;
            }
            try
            {
                for (int i = 0; i < 53; i++)
                {
                    Channel c = (Channel)i;
                    listBox1.Items.Add(c.ToString() + " : " + t.GetChannelValue(c).ToString());
                }
            }
            catch
            { }
        }

        private void toolStripShowSetup_Click(object sender, EventArgs e)
        {
            if (readingThread.IsAlive || serverRunning || webTransferRunning)
                MessageBox.Show("One of services is running. Please stop it before changing config");
            else
            {
                ServerSetup ss = new ServerSetup();
                ss.ShowDialog();
            }
        }

        private void websiteTransferButton_Click(object sender, EventArgs e)
        {
            if (readingThread.IsAlive)
            {
                if (!webTransferRunning)
                {
                    if (PluginLoader.plugins.Count > 0)
                    {
                        ITelemetryPlugin plugin;
                        try
                        {
                            plugin = PluginLoader.GetPlugin(PluginType.WebLogHelper);
                            if (plugin.isActive)
                            {
                                IWebLogPlugin p = (IWebLogPlugin)plugin;
                                if (p.Initialize() == ActionResult.Success)
                                {
                                    Config.websiteAddress = p.url;
                                    Config.urlFormat = p.dataFormat;
                                    if (p.usePOST)
                                        Config.usePost = true;
                                    else
                                        Config.useGet = true;
                                    p.Dispose();
                                }
                                else
                                    return;
                            }
                        }
                        catch (PluginTypeNotFoundException)
                        { }
                    }

                    webSender.StartTransmission();
                    webTransferRunning = true;
                    websiteTransferButton.Text = "Stop";
                }
                else
                {
                    webSender.StopTransmission();
                    webTransferRunning = false;
                    websiteTransferButton.Text = "Start";
                }
            }
            else
                MessageBox.Show("Start data read first!");
        }

        private void toolStripTestChannel_Click(object sender, EventArgs e)
        {
            if (!testingVisible)
            {
                TestChannels testChannelsForm = new TestChannels();
                testChannelsForm.Show();
            }
        }

        private void readDataButton_Click(object sender, EventArgs e)
        {
            if (!readingThread.IsAlive)
            {
                readingThread = new Thread(new ThreadStart(DataReader.ReadData));
                readingThread.Start();
                readDataButton.Text = "Stop";
            }
            else
            {
                DataReader.StopReader();
                readDataButton.Text = "Read";
            }
        }

        private void toolStripStatistics_Click(object sender, EventArgs e)
        {
            Statistics stats = new Statistics();
            stats.Show();
        }

        private void toolStripButtonPlugins_Click(object sender, EventArgs e)
        {
            PluginManager pm = new PluginManager();
            pm.ShowDialog();
        }
    }
}
