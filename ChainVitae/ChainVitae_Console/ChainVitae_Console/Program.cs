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
        private static BlockChain genesisChain;
       
        static void Main(string[] args)
        {

            //First version
            /*
            //Create a basic blockchain solution
            //With some genesis data
            genesis = new BlockChain();
            Console.WriteLine(Process.GetCurrentProcess().ProcessName + ": " + DateTime.Now.ToString());
            BlockChain.CreateGenesis();
            //BlockChain.AutoAddToBlockchain();

            //Initialise nodes and wallets
            List<NodeInstance> AllNodes = GenerateNodes(10);
            //List<Wallet> Wallets = GenerateWallets(10, AllNodes.First());
            //Leave these Nodes and Wallets to interact with the original [b/c]
            */
            //Lists used for testing
            List<NodeInstance> NodesList = new List<NodeInstance>();
            NodesList = GenerateNodes(10);
            List<Address> AddressesList = new List<Address>();
            AddressesList = GenerateAddressesList(10);


            genesisChain = new BlockChain();
            
            Address genTo = new Address();
            Address genFrom = new Address();
            TransactionWithDouble[] trxArray = new TransactionWithDouble[1];
            trxArray[0] = new TransactionWithDouble(genTo, genFrom, 50.0);
            BlockWithDouble GenesisBlock = new BlockWithDouble("GENESIS HASH", trxArray);
            genesisChain.AddBlock(GenesisBlock);
            NodeInstance GenesisNode = new NodeInstance(genesisChain);
            GenesisNode.PrintData();

            Console.Read();
            //Create a list of addresses to be used in the random generation of transactions
            
            
            

        }
        /// <summary>
        /// Generate x Nodes in the system
        /// </summary>
        /// <returns></returns>
        private static List<NodeInstance> GenerateNodes(int instanceCount)
        {
            NodeInstance[] nodes = new NodeInstance[instanceCount];
            for (int count = 0; count < instanceCount; count++)
            {
                NodeInstance ni = new NodeInstance(genesisChain);
                nodes[count] = ni;
               // nodes[inc] = new NodeInstance(genesis);
            }
            return nodes.ToList();
        }
        /// <summary>
        /// Generate x Wallets in the system amd attach to one specific node
        /// </summary>
        /// <param name="count"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private static List<Wallet> GenerateWallets(int count, NodeInstance node)
        {
            Console.WriteLine("All wallets connect to {0}", node.GetId);
            Wallet[] wallets = new Wallet[count];
            for (int inc = 0; inc < count; inc++)
            {
                wallets[inc] = new Wallet(node);
            }
            return wallets.ToList();
        }
        /// <summary>
        /// Generate x Addresses in the system to be used for testing
        /// </summary>
        /// <param name="instanceCount"></param>
        /// <returns></returns>
        private static List<Address> GenerateAddressesList(int instanceCount)
        {
            Address[] list = new Address[instanceCount];
            for (int count = 0; count < instanceCount; count++)
            {
                Address a = new Address();
                Console.WriteLine("Address Created: {0}", a.GetAddressAsString());
                list[count] = a;
            }
            return list.ToList(); 
        }

    }
}
