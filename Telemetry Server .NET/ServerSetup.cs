using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemetry_Server.NET
{
    public partial class ServerSetup : Form
    {
        public ServerSetup()
        {
            InitializeComponent();
            dataSharePathLabel.Text = Config.dataSharePath;
            addressTextBox.Text = Config.websiteAddress;
            urlFormatTextBox.Text = Config.urlFormat;
            postRadioButton.Checked = Config.usePost;
            getRadioButton.Checked = Config.useGet;
            readIntTextBox.Text = Config.readInterval.ToString();
            sendIntTextBox.Text = Config.sendInterval.ToString();
            logCheckBox.Checked = Config.logData;
        }

        private void changeLocationButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                dataSharePathLabel.Text = openFileDialog1.FileName;
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            Config.dataSharePath = dataSharePathLabel.Text;
            Config.websiteAddress = addressTextBox.Text;
            Config.urlFormat = urlFormatTextBox.Text;
            Config.useGet = getRadioButton.Checked;
            Config.usePost = postRadioButton.Checked;
            Config.readInterval = Convert.ToInt32(readIntTextBox.Text);
            Config.sendInterval = Convert.ToInt32(sendIntTextBox.Text);
            Config.logData = logCheckBox.Checked;
            Config.SerializeConfig();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
