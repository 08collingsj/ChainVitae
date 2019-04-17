using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console.Output
{
    public class Debugger
    {
        private List<string> myLog;
        private int indentLevel;

        public Debugger()
        {
            myLog = new List<string>();
        }

        public void Add(string Output)
        {
            
            myLog.Add(Output);
            indentLevel++;
        }

        public void Flush()
        {
            foreach (string s in myLog) {
                Debug.Write(s);
                Console.Write(s);
            }
        }
    }
}
