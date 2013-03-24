using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CustomAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAttributes();
            ShowDatabaseFieldAttribute();
        }

        private static void ShowAttributes()
        {
            Type t = typeof(Employee);

            foreach (PropertyInfo pi in t.GetProperties())
            {
                Attribute[] propertyAttributes = Attribute.GetCustomAttributes(pi);

                if (propertyAttributes.GetLength(0) == 0)
                {
                    Console.WriteLine("Property {0} has NO attributes", pi.Name);
                }
                else
                {
                    Console.WriteLine("Property {0} has attributes:", pi.Name);
                    for (int i = 0; i < propertyAttributes.GetLength(0); i++)
                    {
                        Console.WriteLine(propertyAttributes[i].GetType().Name);
                    }
                }
            }
        }

        private static void ShowDatabaseFieldAttribute()
        {
            Type t = typeof(Employee);
            PropertyInfo pi = t.GetProperty("Name");

            if (pi.IsDefined(typeof(DatabaseFieldAttribute), false))
            {
                DatabaseFieldAttribute attribute =
                    (DatabaseFieldAttribute)Attribute.GetCustomAttribute(pi,
                                                   typeof(DatabaseFieldAttribute));
                Console.WriteLine("DatabaseFieldAttribute, Length = {0}, IsUnicode = {1}",
                    attribute.Length,
                    attribute.IsUnicode);
            }
        }


    }
}
