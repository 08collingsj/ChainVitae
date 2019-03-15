using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationInstances
{
    class Program
    {
        static void Main(string[] args)
        {
            //Need a way of creating multiple instances of the app 
            //Each implementation needs a unqiue id and a total needs to be managed by a third instance used as a sheduler 
            //
            using (var process1 = new Process())
            {
                process1.StartInfo.FileName = @"..\..\..\ConsoleApp1\bin\Debug\ConsoleApp1.exe";
                process1.Start();
            }

            using (var process2 = new Process())
            {
                process2.StartInfo.FileName = @"..\..\..\ConsoleApp2\bin\Debug\ConsoleApp2.exe";
                process2.Start();
            }

            Console.WriteLine("MainApp");
            Console.ReadKey();
        }
    }
}
