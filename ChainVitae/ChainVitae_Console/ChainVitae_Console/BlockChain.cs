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
        //Blockchain hash needed or version number to be able to identify the most recent version
        //public static List<Block> blockchain = new List<Block>();
        public static List<BlockWithDouble> Blockchain = new List<BlockWithDouble>();
        public static void CreateGenesis()
        {
            for (int count = 0; count < 10; count++)
            {
                Address first = new Address();
                Address snd = new Address();
                Certificate crt = new Certificate();
                //A block needs transations before it can be hashed
                Transaction genesisTransaction = new Transaction(first, snd, crt);
                genesisTransaction.PrintTransaction();
            }
        }

            //Transaction[] transactions = new Transaction[] { genesisTransaction };
            //It is ineffecient to have the genesis block contain only one transaction
         //   Block genesisBlock = new Block("0", transactions);
            //Console.WriteLine("Genesis Hash: ");
            //genesisBlock.printBlock();
            //blockchain.Add(genesisBlock);
            
        
        #region BlockWithDouble 
        public BlockWithDouble GetBlockByIndex(int id)
        {
            return Blockchain[id];
        }
        public BlockWithDouble GetLatestBlock()
        {
            return Blockchain.Last();
        }

        public void AddBlock(BlockWithDouble newBlock)
        {
            Blockchain.Add(newBlock);
        }
        #endregion
        public void AutoAddToBlockchain()
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
