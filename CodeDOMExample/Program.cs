using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;

//This example will generate some C# code and an assembly
namespace CodeDOMExample
{
    class Program
    {
        //Save a source file tp 
        static void SaveSourceFile(CSharpCodeProvider csProvider,CodeCompileUnit cUnit)
        {
            // Create a TextWriter to a StreamWriter to the output file. 
            using (StreamWriter sw = new StreamWriter("Program.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");

                // Generate source code using the code provider.
                csProvider.GenerateCodeFromCompileUnit(cUnit, tw,
                    new CodeGeneratorOptions());

                // Close the output file.
                tw.Close();
            }
        }

        static void GenerateAssembly(CSharpCodeProvider csProvider, CodeCompileUnit cUnit)
        {
            // Build the parameters for source compilation.
            CompilerParameters cp = new CompilerParameters();

            // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");

            // Generate an executable instead of 
            // a class library.
            cp.GenerateExecutable = true;

            // Set the assembly file name to generate.
            cp.OutputAssembly = "DomGenerate.exe";

            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;

            // Invoke compilation.
            
            CompilerResults cr = csProvider.CompileAssemblyFromFile(cp, "Program.cs");

            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}",
                    "Program.cs", cp.OutputAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.",
                    "Program.cs", cr.PathToAssembly);
            }
        }

        static void Main(string[] args)
        {
            //Create a provider
            CSharpCodeProvider provider = new CSharpCodeProvider();

            //Create a compile unit, root of object graph
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            //The namespace we are goin
            CodeNamespace nameSpace = new CodeNamespace("CodeDOMExample");
            //Import system
            nameSpace.Imports.Add(new CodeNamespaceImport("System"));
            //add the namespace to the root graph
            compileUnit.Namespaces.Add(nameSpace);

            //program class
            CodeTypeDeclaration programClass = new CodeTypeDeclaration("Program");
            nameSpace.Types.Add(programClass);

            //Create an entry point for the application
            CodeEntryPointMethod entryPoint = new CodeEntryPointMethod();
            //Create expressions to first write a line and read a key
            CodeMethodInvokeExpression writeLnExpression = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"),
                "WriteLine", new CodePrimitiveExpression("Hello World!!! Press any key to exit"));
            
            CodeMethodInvokeExpression readKeyExpression = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"),
                "ReadKey",new CodePrimitiveExpression(false));
            
            //add these expressions to the method
            entryPoint.Statements.Add(writeLnExpression);
            entryPoint.Statements.Add(readKeyExpression);

            //Add the entry point
            programClass.Members.Add(entryPoint);

            //Save source file
            SaveSourceFile(provider, compileUnit);

            //Compile source file
            GenerateAssembly(provider, compileUnit);


            Console.ReadKey();

        }
    }
}
