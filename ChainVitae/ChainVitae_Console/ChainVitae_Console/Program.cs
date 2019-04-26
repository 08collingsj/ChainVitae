using ChainVitae_Console.Output;
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
            Genesis();
            do
            {
                MyWriter.WriteLine("Enter Command: ");
                MyWriter.Write("(Type -h for commands list)");
                string value = Console.ReadLine();
                switch (value)
                {
                    case "-h":
                        MyWriter.WriteLine("-Run         :   To Run the Program under automatic conditions");
                        MyWriter.WriteLine("-RunPrint    :   To Run the program under automatic conditions with added data");
                        MyWriter.WriteLine("-Test        :   To Run the program under Test conditions");
                        MyWriter.WriteLine("-TestPrint   :   To Run the program under Test Conditions with added data");
                        MyWriter.WriteLine("-x           :   Close Application");
                        break;
                    case "-Run":
                        RunProgram(false);
                        break;
                    case "-RunPrint":
                        RunProgram(true);
                        break;
                    case "-Test":
                        TestProgram(false);
                        break;
                    case "-TestPrint":
                        TestProgram(true);
                        break;
                    case "-x":
                        Environment.Exit(0);
                        break;
                    default:
                        MyWriter.WriteLine("Input: " + value + " is not a recognised command ");
                        break;
                }
            }
            while (2 > 1);
            
            //Create a list of addresses to be used in the random generation of transactions
        }
        #region Genesis
        private static void Genesis()
        {
            BlockChain genesisChain = new BlockChain();
            Address genTo = new Address();
            MyWriter.WriteLine(genTo.GetAddressAsString());
            Address genFrom = new Address();
            MyWriter.WriteLine(genFrom.GetAddressAsString());
            TransactionWithDouble[] trxArray = new TransactionWithDouble[1];
            trxArray[0] = new TransactionWithDouble(genTo, genFrom, 50.0);
            BlockWithDouble GenesisBlock = new BlockWithDouble("GENESIS HASH", trxArray);
            genesisChain.AddBlock(GenesisBlock);
            NodeInstance GenesisNode = new NodeInstance(genesisChain);
            GenesisNode.PrintData();

            List<NodeInstance> NodesList = new List<NodeInstance>();
            NodesList = GenerateNodes(10, genesisChain);
            List<Address> AddressesList = new List<Address>();
            AddressesList = GenerateAddressesList(10);
        }
        #endregion

        #region RunProgram
        private static void RunProgram(bool printIsWanted)
        {
            MyWriter.WriteLine("Press p to pause program.");
            MyWriter.WriteLine("Press x to stop program.");
            MyWriter.WriteLine("Press o to save output to text file.");

            if (printIsWanted)
            {
                MyWriter.WriteLine("Program is Running");
                //Needs to simulate the operation of nodes
                //Needs to simulate the operation of transactions
                //Needs to simulate the validation of transactions
                //Needs to simulate the generation of blocks
                //Needs to simulate the addition of block to the chain 
            }
            else
            {

            }
        }
        #endregion

        #region TestProgram
        private static void TestProgram(bool printIsWanted)
        {
            MyWriter.WriteLine("Press x to stop program.");
            if (printIsWanted)
            {

            }
            else
            {

            }
        }
        #endregion
        /// <summary>
        /// Generate x Nodes in the system
        /// </summary>
        /// <returns></returns>
        private static List<NodeInstance> GenerateNodes(int instanceCount, BlockChain blockChain)
        {
            NodeInstance[] nodes = new NodeInstance[instanceCount];
            for (int count = 0; count < instanceCount; count++)
            {
                NodeInstance ni = new NodeInstance(blockChain);
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
            MyWriter.WriteLine("All wallets connect to " + node.GetId.ToString());
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
                MyWriter.WriteLine("Address Created: " + a.GetAddressAsString());
                list[count] = a;
            }
            return list.ToList(); 
        }

    }
}
