using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ViewingTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyId = "System.Drawing, version=2.0.0.0, " +
                "culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
            Assembly a = Assembly.Load(assemblyId);
            

            foreach (Type type in a.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }

            Console.ReadKey();
        }
    }
}
