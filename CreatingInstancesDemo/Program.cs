using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Remoting;

namespace CreatingInstancesDemo
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
            Console.WriteLine("instance created using activator");
            
            // create instance using Type
            Assembly a1 = Assembly.Load(assemblyName);
            Type myType1 = a1.GetType(typeName);
            object[] typeArgs1 = new object[]{ "Hello World! "};
            object myTypeObj1 = myType1.InvokeMember(null, BindingFlags.Public | BindingFlags.DeclaredOnly |
                BindingFlags.Instance | BindingFlags.CreateInstance,
                null, null, typeArgs1);
            Console.WriteLine("instance created using Type");

            // create instance using ConstructorInfo
            Assembly a2 = Assembly.Load(assemblyName);
            Type myType2 = a2.GetType(typeName);
            Type[] argTypes2 = new Type[] { typeof(string)};
            // locate a matching constructor
            ConstructorInfo ctor = myType2.GetConstructor(argTypes2);
            // create an array of parameters for the constructor
            object[] typeArgs2 = new object[] { "Hello Again! " };
            // invoke the constructor
            object myTypeObj2 = ctor.Invoke(typeArgs2);
            Console.WriteLine("instance created using ConstructorInfo");


            // create instance of Dictionary<string, typeName>
            Assembly a3 = Assembly.Load(assemblyName);
            Type myType3 = a3.GetType(typeName);
            // create generic open type
            Type openCollectionType = typeof(Dictionary<,>);
            // prepare the type arguments
            Type[] argTypes3 = new Type[] { typeof(string), myType3 };
            // create the closed constructed type
            Type closedCollectionType = openCollectionType.MakeGenericType(argTypes3);
            // create the collection by invoking the constructore
            object myCollectionObj = closedCollectionType.InvokeMember(null, 
                BindingFlags.Public | BindingFlags.DeclaredOnly |
                BindingFlags.Instance | BindingFlags.CreateInstance,
                null, null, null);
            Console.WriteLine("generic collection created");

            // add an object to the dictionary by invoking Add method
            object[] methodArgs = new object[] { "first key", myTypeObj1 };
            // invoke the method on the object myCOllectionObj (target)
            closedCollectionType.InvokeMember("Add", BindingFlags.Public | 
                BindingFlags.Instance | BindingFlags.InvokeMethod,
                null, myCollectionObj, methodArgs);
            Console.WriteLine("first object added to collection");

            // add an object to the dictionary by invoking Add method using MethodInfo
            Type[] argTypes = new Type[] { typeof(string), myType2 };
            // locate the Add method
            MethodInfo addMethod = closedCollectionType.GetMethod("Add", argTypes);
            // invoke the method on the object myCOllectionObj
            addMethod.Invoke(myCollectionObj, new object[] { "second key", myTypeObj2 });
            Console.WriteLine("second object added to collection");

        }

        public static object Dictionary { get; set; }
    }


}
