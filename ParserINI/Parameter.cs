using System;
using System.Collections.Generic;
using System.Text;

namespace ParserINI
{
    public class Parameter
    {
        public string Name;
        public string Value;
        public Parameter(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
