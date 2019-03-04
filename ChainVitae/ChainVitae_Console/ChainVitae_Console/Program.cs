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
        public static ArrayList blockchain = new ArrayList();
        static void Main(string[] args)
        {
            //Create a basic blockchain solution
            
            Console.WriteLine(Process.GetCurrentProcess().ProcessName + ": " + DateTime.Now.ToString());
            Genesis();
            AutoAddToBlockchain();
        }

        public static void Genesis()
        {
            
            Transaction genesisTransaction = new Transaction("1", "2", "We swapped information");
            Transaction[] transactions = new Transaction[] { genesisTransaction };
            // string[] genesisTransactions = { "To: my first transaction", "From: my first transaction " };
            //for (int i = 0; i < 10; i++)
            //{
                
            //}
            Block genesisBlock = new Block("0", transactions);
            Console.WriteLine("Genesis Hash: ");
            genesisBlock.printBlock();
            blockchain.Add(genesisBlock);
            Console.Read();
        }

        public static void AutoAddToBlockchain()
        {
            while (true)
            {
              //  Transaction.gener
            }
        }
        public void printTransactions(int BlockHash)
        {
            //blockchain.IndexOf(BlockHash);
        }
    }
}
