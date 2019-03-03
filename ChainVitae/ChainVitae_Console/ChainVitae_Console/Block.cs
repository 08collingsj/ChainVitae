using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class Block
    {
        private int previousHash;
        private string[] transactions;

        private int blockHash;

        public Block(int previousHash, string[] transactions)
        {
            this.previousHash = previousHash;
            this.transactions = transactions;

            object[] content = { transactions.GetHashCode(), previousHash };
            this.blockHash = content.GetHashCode();
        }

        public int getPreviousHash()
        {
            return previousHash;
        }

        public string[] getTransaction()
        {
            return transactions;
        }

        public int getBlockHash()
        {
            return blockHash;
        }
    }
}
