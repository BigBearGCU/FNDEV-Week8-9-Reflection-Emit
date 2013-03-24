using System;
using System.Reflection.Emit;

//Generating Code at Run Time With Reflection.Emit
//http://drdobbs.com/windows/184416570

//Emitting Dynamic Methods & Assemblies
//http://msdn.microsoft.com/en-us/library/8ffc3x75.aspx
namespace DynamicMethodDemo
{
    // 1. define a delegate that has a signature that matches the dynamic method
    public delegate Int64 Squared(Int32 value);

    class Program
    {
        static void Main(string[] args)
        {
            // 2. create an instance of DynamicMethod and specify the method signature
            Type returnType = typeof(Int64);
            Type[] parameterTypes = new Type[] { typeof(Int32) };
            DynamicMethod numberSquaredMethod =
                new DynamicMethod("NumberSquared", returnType, parameterTypes);

            // 3. get the ILGenerator instance
            ILGenerator il = numberSquaredMethod.GetILGenerator();

            //return (Int64)(x*x);

            // 4. emit code using the ILGenerator
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Conv_I8);
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Mul);
            il.Emit(OpCodes.Ret);

            // 5. create a delegate to call the dynamic method
            Squared numberSquared = (Squared)numberSquaredMethod.CreateDelegate(typeof(Squared));

            Console.WriteLine("Result is: {0}", numberSquared(4));
        }
    }
}
