using System;
using System.Collections.Generic;
using System.Text;

namespace ParserINI
{
    public class Section
    {
        public string Name;
        public static int ID = 1;
        public Section(string name)
        {
            Name = name;
            ID++;
        }
    }
}
