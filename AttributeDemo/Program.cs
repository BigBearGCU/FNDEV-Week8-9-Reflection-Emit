using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MyNameSpace;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyNameSpace.MyType);
            MemberInfo[] typeMembers = type.GetMembers(
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static);
            foreach (MemberInfo member in typeMembers)
            {
                object[] attributes = member.GetCustomAttributes(false);
                if (attributes.Length > 0)
                {
                    Console.WriteLine("The attributes for member {0} are:", member.Name);
                    foreach (object attr in attributes)
                    {
                        Console.WriteLine("  Attribute type: {0}", attr);
                    }
                }
            }  
        }
    }
}
