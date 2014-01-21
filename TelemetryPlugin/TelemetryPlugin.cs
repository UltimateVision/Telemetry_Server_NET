using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelemetryPlugin
{
    public enum PluginType
    {
        Other = 0,
        WebLogHelper
    }

    public interface ITelemetryPlugin
    {
        PluginType type { get; }
        string name { get; }
        string author { get; }
        bool isActive { get; set; }
        void Initialize();
        void Dispose();
    }

    public interface IWebLogPlugin : ITelemetryPlugin
    {
        string url { get; }
        string dataFormat { get; }
        bool usePOST { get; }
    }
}
