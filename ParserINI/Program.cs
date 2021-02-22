using System;

namespace ParserINI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ini = new Parser(@"D:\Code\OOP.Labs\ParserINI\Test2.ini");
            var dataInt = ini.GetTheIntValue("DEBUG", "PlentySockMaxSize");
            var dataDouble = ini.GetTheDoubleValue("ADC_DEV", "SampleRate");
            var dateString = ini.GetTheStringValue("ADC_DEV", "Driver");

            Console.WriteLine(dataInt);
            Console.WriteLine(dataDouble);
            Console.WriteLine(dateString);
        }
    }
}
