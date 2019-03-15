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
         * TODO: Replace string with actual Addresses
         */ 
        private Address ToAddress;
        private Address FromAddress;
        private Certificate _Certificate;

        public Transaction(Address To, Address From, Certificate Data)
        {
            this.ToAddress = To;
            this.FromAddress = From;
            this._Certificate = Data;
        }

        #region Getters
        public Address GetToAddress()
        {
            return ToAddress;
        }

        public Address GetFromAddress()
        {
            return FromAddress;
        }

        public Certificate GetCertificate()
        {
            return _Certificate;
        }
        #endregion

        public void PrintTransaction()
        {
            Console.WriteLine("***************");
            Console.WriteLine("\tTo: " + ToAddress.GetAddress());
            Console.WriteLine("\tFrom: " + FromAddress.GetAddress());
            Console.WriteLine("\tCertificate: " );
            _Certificate.PrintCertificate();
            Console.WriteLine("***************");
        }
        
    }
}
