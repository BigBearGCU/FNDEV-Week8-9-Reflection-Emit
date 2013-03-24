using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttribute
{
    class Employee
    {
        private string _name;
        private string _address;

        public Employee()
        {
            _name = String.Empty;
        }

        [DatabaseField(75, IsUnicode = false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public void RaisePay( decimal amountToRaiseBy )
        {
            // ...
        }
    }
}
