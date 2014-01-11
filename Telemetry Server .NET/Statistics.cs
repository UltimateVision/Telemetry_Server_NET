using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Telemetry_Server.NET
{
    public partial class Statistics : Form
    {
        List<DataPacket> telemetry;

        public Statistics()
        {
            InitializeComponent();
            telemetry = new List<DataPacket>();
            toolStripStatusLabel1.Text = "Status: No data";
            var values = Enum.GetValues(typeof(Channel));
            foreach (Enum channel in values)
                channelToolStripComboBox.Items.Add(channel.ToString());
            openFileDialog1 = new OpenFileDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = "Status: Reading data";
                int lineCount = File.ReadLines(openFileDialog1.FileName).Count();
                toolStripProgressBar1.Maximum = lineCount;
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        telemetry.Add(new TelemetryPacket(sr.ReadLine()));
                        toolStripProgressBar1.Increment(1);
                    }
                }
                toolStripStatusLabel1.Text = "Status: Ready";
                toolStripProgressBar1.Value = 0;
            }
        }

        private void channelToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int blockSize = 20;

            Channel selectedChannel = (Channel)channelToolStripComboBox.SelectedIndex;
            chart1.Series.Clear();
            var series = chart1.Series.Add(selectedChannel.ToString());
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.Double;
            int i = 0;
            foreach (TelemetryPacket t in telemetry)
            {
                double val = (double)t.GetChannelValue(selectedChannel);
                if (val == double.NaN)
                    series.Points.AddXY(i, 0);
                else
                    series.Points.AddXY(i, val);
                i++;
            }
            var chartArea = chart1.ChartAreas[series.ChartArea];

            // set view range to [0,max]
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = telemetry.Count;

            // enable autoscroll
            chartArea.CursorX.AutoScroll = true;

            // let's zoom to [0,blockSize] (e.g. [0,100])
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            int position = 0;
            int size = 100;
            chartArea.AxisX.ScaleView.Zoom(position, size);

            // disable zoom-reset button (only scrollbar's arrows are available)
            chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            // set scrollbar small change to blockSize (e.g. 100)
            chartArea.AxisX.ScaleView.SmallScrollSize = blockSize;
        }
    }
}
