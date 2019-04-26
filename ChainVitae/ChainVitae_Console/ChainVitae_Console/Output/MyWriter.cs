using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console.Output
{
    public static class MyWriter
    {
        private static List<string> writerList = new List<string>();
        public static void Write(string value)
        {
            string myString = "CV v1.0.0: " + DateTime.Now.ToLongDateString() + "   " + value;
            Console.WriteLine(myString);
            writerList.Add(myString);
        }
        public static void WriteLine(string value)
        {
            string myString = "CV v1.0.0: " + DateTime.Now.ToLongDateString() + "   " + value;
            Console.WriteLine(myString);
            writerList.Add(myString);
        }
        
        public static void ClearWriter()
        {
            writerList.Clear();
        }

        public static void SaveWriter()
        {
            TextWriter tw = new StreamWriter("ChainVitae" + DateTime.Now + "OutputLog.txt");
            foreach (string s in writerList)
                tw.WriteLine(s);
            tw.Close();
        }
    }
}
