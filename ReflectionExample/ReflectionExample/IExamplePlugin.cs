using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;

namespace ReflectionExample
{
    public interface IExamplePlugin
    {
        string GetPluginName();

        string GenerateLuckyMessage();
    }
}
