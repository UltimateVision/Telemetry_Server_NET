using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TelemetryPlugin;

namespace Telemetry_Server.NET
{
    public partial class PluginManager : Form
    {
        public PluginManager()
        {
            InitializeComponent();

            foreach (var item in PluginLoader.plugins)
            {
                OnOffControl tmp = new OnOffControl();
                tmp.Dock = DockStyle.Left;
                tmp.SetPlugin((ITelemetryPlugin)item);
                pluginFlowLayoutPanel.Controls.Add(tmp);
            }
        }
    }
}
