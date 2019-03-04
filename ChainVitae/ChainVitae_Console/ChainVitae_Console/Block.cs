using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChainVitae_Console
{
    public class Block
    {

        //private string[] transactions;
        private string previousHash;
        private Transaction[] transactions;
        private string blockHash;

        //public Block(int previousHash, string[] transactions)
        //{
        //    this.previousHash = previousHash;
        //    this.transactions = transactions;

        //    object[] content = { transactions.GetHashCode(), previousHash };
        //    this.blockHash = content.GetHashCode();
        //}
        //Need to hash: Content and transactions
        public Block(string previousHash, Transaction[] transactions)
        {
            this.previousHash = previousHash;
            this.transactions = transactions;

            object[] content = { transactions.GetHashCode(), previousHash };
            this.blockHash = content.GetHashCode().ToString();
        }

        public string getPreviousHash()
        {
            return previousHash;
        }

        //public string[] getTransaction()
        //{
        //    return transactions;
        //}
        public Transaction[] getTransactions()
        {
            return transactions;
        }

        public string getBlockHash()
        {
            return blockHash;
        }

        public void printBlock()
        {
            Console.WriteLine("++++++++++++++++++++++++++++");
            Console.WriteLine("Previous Hash: " + getPreviousHash());
            // Console.WriteLine("TRX: " + string.Join("", getTransaction()));
            Console.WriteLine("TRX: ");
            printTransactions();
            Console.WriteLine("Block Hash: " + getBlockHash());
            Console.WriteLine("++++++++++++++++++++++++++++");
        }

        public void printTransactions()
        {
            Transaction[] localTRX = getTransactions();
            foreach (Transaction trx in localTRX)
            {
                trx.printTransaction();
            }
        }

        
    }
}
