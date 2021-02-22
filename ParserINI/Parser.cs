using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParserINI
{
    class Parser
    {
        private string comment = ";", equals = "=";
        Dictionary<string, List<Parameter>> ParsiniFile = new Dictionary<string, List<Parameter>>();
        public Parser (string path)
        {
            if (!File.Exists(path))
                throw new Exception("Ini file not found or does not exist!");
            if (Path.GetExtension(path) != ".ini")
                throw new Exception("The found file does not have the ini extension!");
            if (new FileInfo(path).Length == 0)
                throw new Exception("The file is empty!");

            StreamReader file = new StreamReader(path);
            string Section = null, CurrSection = null, Name = null, Value = null;
            List<Parameter> parameters = new List<Parameter>();
            while (!file.EndOfStream)
            {
                string CurrentString = file.ReadLine();
                //deleting comments
                string[] str = CurrentString.Split(comment);
                if (str[0].Length != 0)
                    CurrentString = str[0];
                else
                    continue;

                //checking "section"

                if (CurrentString.StartsWith("[") && CurrentString.EndsWith("]"))
                {
                    CurrSection = CurrentString.Trim(new char[] { '[', ']' });
                }
                else
                {
                    string[] str2 = CurrentString.Split(equals);
                    if (str2.Length != 2)
                            throw new Exception("The parameter has no value!");
                    else
                    {
                        Name = str2[0].Trim();
                        Value = str2[1].Trim();

                        if (Section == null)
                            Section = CurrSection;
                        if (Section != CurrSection)
                        {
                            List<Parameter> TempParameters = new List<Parameter>();
                            TempParameters.AddRange(parameters);

                            //Console.WriteLine(Section);
                            //foreach (var item in TempParameters)
                            //{
                            //    Console.WriteLine(item.Name + " = " + item.Value);
                            //}

                            ParsiniFile.Add(Section, TempParameters);
                            parameters.Clear();
                            Section = CurrSection;
                        }
                        parameters.Add(new Parameter(Name, Value));
                    }
                    
                }


            }
            ParsiniFile.Add(CurrSection, parameters);
        }

        public int GetTheIntValue(string section, string name)
        {
            int val = 0;
            var found = ParsiniFile[section].Find(atem => atem.Name == name);
            if (found == null)
                throw new Exception("The parameter does not exist!");
            if (found.Value == null)
                throw new Exception("The value does not exist!");
            try
            {
                val = Convert.ToInt32(found.Value);
                return val;
            }
            catch
            {
                throw new Exception("Сannot convert to int!");
            }
        }

        public double GetTheDoubleValue(string section, string name)
        {
            double val = 0;
            var found = ParsiniFile[section].Find(atem => atem.Name == name);
            if (found == null)
                throw new Exception("The parameter does not exist!");
            if (found.Value == null)
                throw new Exception("The value does not exist!");
            int Index = -1;
            Index = found.Value.IndexOf(".");
            if (Index != -1)
                found.Value = found.Value.Replace('.', ',');
                try
                {
                    val = Convert.ToDouble(found.Value);
                    return val;
                }
                catch
                {
                    throw new Exception("Сannot convert to double!");
                }
        }

        public string GetTheStringValue(string section, string name)
        {
            string val = null;
            var found = ParsiniFile[section].Find(atem => atem.Name == name);
            if (found == null)
                throw new Exception("The parameter does not exist!");
            if (found.Value == null)
                return val;
            try
            {
                val = Convert.ToString(found.Value);
                return val;
            }
            catch
            {
                throw new Exception("Сannot convert to string!");
            }
        }

    }
}
