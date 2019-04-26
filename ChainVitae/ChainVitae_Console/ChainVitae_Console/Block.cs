using ChainVitae_Console.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChainVitae_Console
{
    public class Block
    {
        //BlockHeader Fields
        //Version - the version number of the software
        private string _VersionNumber = "0.1";
        //LastBlock - the hash of the previous block
        private string _LastBlock;
        //Merkle Root - the root hash of the Merkle tree
        private string _MerkleRoot;
        //Transactions 
        //Encrypted list of all transactions

        //Time - the time in seconds since 1970–01–01 T00: 00 UTC 
        private readonly string _Time = DateTime.Now.ToUniversalTime().ToString();
        //Target - the nonce - the goal of the current difficulty
        private int Target;

        //private string[] transactions;
        private int index;
        private int MaxBlockSize = 10;
        private string previousHash;
        private Transaction[] transactions;
        private string blockHash;

        public Block(string previousHash, Transaction[] transactions)
        {
            this.previousHash = previousHash;
            this.transactions = transactions;

            object[] content = { transactions.GetHashCode(), previousHash };
            this.blockHash = content.GetHashCode().ToString();
        }


        #region Getters 
        public string getPreviousHash()
        { return previousHash; }

        //public string[] getTransaction()
        //{
        //    return transactions;
        //}
        public Transaction[] getTransactions()
        { return transactions; }

        public string getBlockHash()
        { return blockHash; }

        public int getIndex()
        { return index; }

        
        #endregion

        public void PrintBlock()
        {
            MyWriter.WriteLine("++++++++++++++++++++++++++++");
            MyWriter.WriteLine("Previous Hash: " + getPreviousHash());
            // Console.WriteLine("TRX: " + string.Join("", getTransaction()));
            MyWriter.WriteLine("TRX: ");
            PrintTransactions();
            MyWriter.WriteLine("Block Hash: " + getBlockHash());
            MyWriter.WriteLine("++++++++++++++++++++++++++++");
        }

        public void PrintTransactions()
        {
            Transaction[] localTRX = getTransactions();
            foreach (Transaction trx in localTRX)
            {
                trx.PrintTransaction();
            }
        }

        
    }
}
