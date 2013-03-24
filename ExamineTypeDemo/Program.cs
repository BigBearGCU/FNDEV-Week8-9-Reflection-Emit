using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ExamineTypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(string);

            MemberInfo[] typeMembers = type.GetMembers(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance);

            foreach (MemberInfo member in typeMembers)
            {
                Console.WriteLine("{0} ({1})", member.Name, member.MemberType);
            }

            Console.ReadLine();
        }
    }
}
