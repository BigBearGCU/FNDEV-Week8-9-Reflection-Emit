using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicAssemblyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new dynamic assembly
            AssemblyName assemblyName = new AssemblyName("DynamicHelloWorld");
            assemblyName.Version = new Version("1.0.0.12");
            AssemblyBuilder dynamicAssembly =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    assemblyName,
                    AssemblyBuilderAccess.RunAndSave);

            // create a module inside the assembly
            ModuleBuilder dynamicModule = dynamicAssembly.DefineDynamicModule(
                assemblyName.Name, "DynamicHelloWorld.exe");

            // create a type inside the module
            TypeBuilder programType = dynamicModule.DefineType(
                "DynamicHelloWorld.Program",
                TypeAttributes.Class | TypeAttributes.Public);

            // add a method
            MethodBuilder main = programType.DefineMethod(
                "Main",
                MethodAttributes.Public | MethodAttributes.Static,
                typeof(int),
                new Type[] { typeof(string[]) });

            // add the IL for the method
            // equivalent to Console.WriteLine("Hello World!");
            Type console = typeof(Console);
            MethodInfo writeLine = console.GetMethod(
                "WriteLine",
                new Type[] { typeof(string) });
            ILGenerator il = main.GetILGenerator();

            il.EmitWriteLine("Hello World!");
            //OR
            //il.Emit(OpCodes.Ldstr, "Hello World!");
            //il.Emit(OpCodes.Call, writeLine);

            il.Emit(OpCodes.Ldc_I4_0);   // set return value to 0

            il.Emit(OpCodes.Ret);

            // finished, now materialise the type
            programType.CreateType();

            // set program's entry point to the Main method
            dynamicAssembly.SetEntryPoint(main, PEFileKinds.ConsoleApplication);

            // save the assembly 
            dynamicAssembly.Save("DynamicHelloWorld.exe");
        }
    }
}
