using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Remoting;
using MyNameSpace;    // need this for interface type

namespace PolymorphismDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyName = args[0];
            string typeName = args[1];

            // create instance using activator
            ObjectHandle handle = Activator.CreateInstance(assemblyName,
                typeName);
            object myTypeObj = handle.Unwrap();

            // cast to interface and invoke method
            IMyInterface im = myTypeObj as IMyInterface;
            Console.WriteLine("The method returned: {0}", im.MyStringMethod());

        }
    }
}
