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
        //Treat Program as Master 
       
        static void Main(string[] args)
        {
            //Create a basic blockchain solution
            //With some genesis data
            Console.WriteLine(Process.GetCurrentProcess().ProcessName + ": " + DateTime.Now.ToString());
            BlockChain.CreateGenesis();
            //BlockChain.AutoAddToBlockchain();

            //Initialise nodes and wallets
            List<Node> AllNodes = GenerateNodes(10);
            List<Wallet> Wallets = GenerateWallets(10, AllNodes.First());
            //Leave these Nodes and Wallets to interact with the original [b/c]



            Console.Read();
        }
        /// <summary>
        /// Generate x Nodes in the system
        /// </summary>
        /// <returns></returns>
        private static List<Node> GenerateNodes(int count)
        {
            Node[] nodes = new Node[count];
            for (int inc = 0; inc < count; inc++)
            {
                nodes[inc] = new Node();
            }
            return nodes.ToList();
        }
        /// <summary>
        /// Generate x Wallets in the system amd attach to one specific node
        /// </summary>
        /// <param name="count"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private static List<Wallet> GenerateWallets(int count, Node node)
        {
            Console.WriteLine("All wallets connect to {0}", node.GetId);
            Wallet[] wallets = new Wallet[count];
            for (int inc = 0; inc < count; inc++)
            {
                wallets[inc] = new Wallet(node);
            }
            return wallets.ToList();
        }

    }
}
