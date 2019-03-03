using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a basic blockchain solution
            ArrayList blockchain = new ArrayList();
            string[] genesisTransactions = { "To: my first transaction", "From: my first transaction " };
            Block genesisBlock = new Block(0, genesisTransactions);
            Console.WriteLine("Genesis Hash: ");
            Console.WriteLine(genesisBlock.getBlockHash());
            Console.Read();
        }
    }
}
