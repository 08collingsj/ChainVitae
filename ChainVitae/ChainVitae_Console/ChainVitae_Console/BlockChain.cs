using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class BlockChain
    {
        public static List<Block> blockchain = new List<Block>();
        public static void CreateGenesis()
        {
            //A block needs transations before it can be hashed
            Transaction genesisTransaction = new Transaction("1", "2", "We swapped information");
            Transaction[] transactions = new Transaction[] { genesisTransaction };
            //It is ineffecient to have the genesis block contain only one transaction
            Block genesisBlock = new Block("0", transactions);
            Console.WriteLine("Genesis Hash: ");
            genesisBlock.printBlock();
            blockchain.Add(genesisBlock);
            Console.Read();
        }
        public static Block GetBlockByIndex(int id)
        {
            return blockchain[id];
        }
        public static Block GetLatestBlock()
        {
            return blockchain.Last();
        }

        public static void AddBlock(Block newBlock)
        {
            blockchain.Add(newBlock);
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
