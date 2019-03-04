using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    class Program
    {
        //Create the blockchain
       
        static void Main(string[] args)
        {
            //Create a basic blockchain solution
            
            Console.WriteLine(Process.GetCurrentProcess().ProcessName + ": " + DateTime.Now.ToString());
            BlockChain.CreateGenesis();
            //BlockChain.AutoAddToBlockchain();
            
        }

        
    }
}
