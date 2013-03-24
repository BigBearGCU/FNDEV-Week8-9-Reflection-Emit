using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    class DatabaseFieldAttribute : Attribute
    {
        private int _length;
        private bool _isUnicode = true;

        public DatabaseFieldAttribute(int length)
        {
            _length = length;
        }

        public int Length
        {
            get { return _length; }
        }

        public bool IsUnicode
        {
            get { return _isUnicode; }
            set { _isUnicode = value; }
        }


    }
}
