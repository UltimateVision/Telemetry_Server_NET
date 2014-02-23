using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TelemetryPlugin;

namespace Telemetry_Server.NET
{
    /// <summary>
    /// Class for handling plugin loading
    /// </summary>
    class PluginLoader
    {
        static public ICollection<ITelemetryPlugin> plugins = new List<ITelemetryPlugin>();

        public static void LoadPlugins()
        {
            //Get all *.dll's in plugins directory
            string[] dllFileNames = null;
            if (Directory.Exists("plugins"))
            {
                dllFileNames = Directory.GetFiles("plugins", "*.dll");
            }

            if (dllFileNames == null)
                return;

            //Load assemblies using System.Reflection
            ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
            foreach (string dllFile in dllFileNames)
            {
                AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                Assembly assembly = Assembly.Load(an);
                assemblies.Add(assembly);
            }

            //Search for compatible plugins
            Type pluginType = typeof(ITelemetryPlugin);
            ICollection<Type> pluginTypes = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.IsInterface || type.IsAbstract)
                        {
                            continue;
                        }
                        else
                        {
                            if (type.GetInterface(pluginType.FullName) != null)
                            {
                                pluginTypes.Add(type);
                            }
                        }
                    }
                }
            }

            //Create instances
            plugins = new List<ITelemetryPlugin>(pluginTypes.Count);
            foreach (Type type in pluginTypes)
            {
                ITelemetryPlugin plugin = (ITelemetryPlugin)Activator.CreateInstance(type);
                plugins.Add(plugin);
            }
        }

        public static ITelemetryPlugin GetPlugin(PluginType pluginType)
        {
            var items = from plugin in plugins where plugin.type == PluginType.WebLogHelper select plugin;
            foreach (ITelemetryPlugin plugin in items)
            {
                return plugin;
            }

            throw new PluginTypeNotFoundException();
        }
    }

    public class PluginTypeNotFoundException : Exception
    {
        public PluginTypeNotFoundException()
        {
        }

        public PluginTypeNotFoundException(string message)
            : base(message)
        {
        }

        public PluginTypeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
