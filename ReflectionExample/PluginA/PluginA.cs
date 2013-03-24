using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReflectionExample;

namespace PluginA
{
    public class PluginA : IExamplePlugin
    {

        #region IExamplePlugin Members

        string IExamplePlugin.GetPluginName()
        {
            return "Plugin A";
        }

        string IExamplePlugin.GenerateLuckyMessage()
        {
            return "Best wishes from A";
        }

        #endregion
    }
}
