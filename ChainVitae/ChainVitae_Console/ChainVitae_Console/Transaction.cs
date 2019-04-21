using ChainVitae_Console.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class Transaction
    {
        private Address ToAddress;
        private Address FromAddress;
        private Certificate _Certificate;
        private DateTime _TimeStamp = DateTime.Now.ToUniversalTime();
        private List<Signature> _SignatureLog;
        //Consider Complexity, Data access patterns, dependencies and size

        public Transaction(Address To, Address From, Certificate Data)
        {
            _SignatureLog = new List<Signature>();
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

        public string GetTimeStamp()
        {
            return _TimeStamp.ToLongDateString();
        }
        #endregion

        /// <summary>
        /// Important to ensure that this instance reaches minimum concensus prior to approval 
        /// </summary>
        /// <param name="MinConsensusCount"></param>
        /// <returns></returns>
        public bool HasTransactionReachedConcensus(int MinConsensusCount)
        {
            if (_SignatureLog.Count >= MinConsensusCount)
                return true;
            else
                return false;
        }
        public void PrintTransaction()
        {
            Console.WriteLine("***************");
            Console.WriteLine("\tTo: " + ToAddress.GetAddressAsString());
            Console.WriteLine("\tFrom: " + FromAddress.GetAddressAsString());
            Console.WriteLine("\tCertificate: " );
            _Certificate.PrintCertificate();
            Console.WriteLine("***************");
        }

       
        
    }
}
