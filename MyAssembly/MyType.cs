using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNameSpace 
{
    public class MyType : IMyInterface
    {
        private String myField;

        public String MyField
        {
            get { return myField; }
            set { myField = value; }
        }

        public MyType()
        {
            myField = "Default value";
        }

        public MyType(String value)
        {
            myField = value;
        }

        public void MyVoidMethod(string value)
        {
            Console.WriteLine(value);
        }

        public string MyStringMethod()
        {
            return "method result";
        }

        [Obsolete("Use MyStringMethod instead")]
        public string MyOldStringMethod()
        {
            return "old method result";
        }

    }
}
