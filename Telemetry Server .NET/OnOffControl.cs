using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TelemetryPlugin;

namespace Telemetry_Server.NET
{
    public partial class OnOffControl : UserControl
    {
        public bool isActive = false;
        private ITelemetryPlugin _plugin;

        public OnOffControl()
        {
            InitializeComponent();
        }

        public void SetPlugin(ITelemetryPlugin plugin)
        {
            _plugin = plugin;
            PluginNameLabel.Text = plugin.name;
            AuthorNameLabel.Text = plugin.author;
            isActive = plugin.isActive;
            if(isActive)
                OnOffButton.Text = "Off";
        }

        private void OnOffButton_Click(object sender, EventArgs e)
        {
            isActive = !isActive;
            _plugin.isActive = isActive;
            if (isActive)
                OnOffButton.Text = "Off";
            else
                OnOffButton.Text = "On";
        }
    }
}
