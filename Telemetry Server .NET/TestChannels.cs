using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Telemetry_Server.NET
{
    public partial class TestChannels : Form
    {
        Thread tester;

        Object sV = new object();
        Object eV = new object();

        Channel selectedChannel;
        Type dataType;

        bool lockUI
        {
            get
            {
                return lockUI;
            }
            set
            {
                lockUI = value;
                if (lockUI == true)
                    testStartButton.Enabled = false;
                else
                    testStartButton.Enabled = true;
            }
        }

        public TestChannels()
        {
            InitializeComponent();
            var values = Enum.GetValues(typeof(Channel));
            foreach (Enum channel in values)
                channelComboBox.Items.Add(channel.ToString());
        }

        private void testStartButton_Click(object sender, EventArgs e)
        {
            DataReader.overrideData = true;
            //lockUI = true;
            selectedChannel = (Channel)channelComboBox.SelectedIndex;
            dataType = DataReader.dataPacket.GetChannelType(selectedChannel);
            if (dataType != typeof(string))
            {
                string range = rangeTextBox.Text;
                int index = range.IndexOf('-');
                string startVal = range.Substring(0, index);
                startVal = startVal.Replace(" ", string.Empty);
                string endVal = range.Substring(index + 1, range.Length - index - 1);
                endVal = endVal.Replace(" ", string.Empty);
                sV = Convert.ChangeType(startVal, dataType);
                eV = Convert.ChangeType(endVal, dataType);
                tester = new Thread(new ThreadStart(StartTesting));
                tester.Start();
            }
        }

        private void StartTesting()
        {
            Object state = sV;
            int changes = 0;

            while (true)
            {
                DataReader.dataPacket.SetChannelValue(selectedChannel, state);
                if (dataType == typeof(double))
                {
                    double t = (double)state;
                    t++;
                    state = t;

                    if (t > (double)eV)
                        break;
                }
                else if (dataType == typeof(int))
                {
                    int t = (int)state;
                    t++;
                    state = t;

                    if (t > (int)eV)
                        break;
                }
                else if (dataType == typeof(uint))
                {
                    uint t = (uint)state;
                    t++;
                    state = t;

                    if (t > (uint)eV)
                        break;
                }
                else if (dataType == typeof(bool))
                {
                    bool t = (bool)state;
                    t = !t;
                    changes++;
                    state = t;
                    if (changes == 4)
                        break;
                }

                Thread.Sleep(Config.readInterval);
            }

            DataReader.overrideData = false;
            //lockUI = false;
        }
    }
}
