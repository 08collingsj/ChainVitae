using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class Transaction
    {
        /*
         * TODO: Replace int with actual Addresses
         */ 
        private string ToAddress;
        private string FromAddress;
        private string _Data;

        public Transaction(string To, string From, string Data)
        {
            this.ToAddress = To;
            this.FromAddress = From;
            this._Data = Data;
        }

        #region Getters
        public string getToAddress()
        {
            return ToAddress;
        }

        public string getFromAddress()
        {
            return FromAddress;
        }

        public string getData()
        {
            return _Data;
        }
        #endregion

        public void printTransaction()
        {
            Console.WriteLine("***************");
            Console.WriteLine("\tTo: " + getToAddress());
            Console.WriteLine("\tFrom: " + getFromAddress());
            Console.WriteLine("\tData: " + getData());
            Console.WriteLine("***************");
        }
        
    }
}
