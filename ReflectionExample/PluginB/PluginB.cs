using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PluginB
{
    public class PluginB : ReflectionExample.IExamplePlugin
    {

        #region IExamplePlugin Members

        public string GetPluginName()
        {
            return "Plugin B";
        }

        public string GenerateLuckyMessage()
        {
            return "Good Luck from B";
        }

        #endregion
    }
}
