using ChainVitae_Console.DataType;
using ChainVitae_Console.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
        public class TransactionWithDouble
        {
            // A transaction should be validated at least 6 times but this will be all nodes if less than 6 
            private int ValidateCount;
            private int IdealValidationCount;
            private Address ToAddress;
            private Address FromAddress;
            private double Value;
            private DateTime _TimeStamp = DateTime.Now.ToUniversalTime();
            private List<Signature> _SignatureLog; 
            //Consider Complexity, Data access patterns, dependencies and size

            public TransactionWithDouble(Address To, Address From, double Data)
            {
                _SignatureLog = new List<Signature>();
                this.ToAddress = To;
                this.FromAddress = From;
                this.Value = Data;
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

            public double GetValue()
            {
                return Value;
            }

            public string GetTimeStamp()
            {
                return _TimeStamp.ToLongDateString();
            }

            public List<Signature> GetSignatureLog()
            {
                return _SignatureLog;
            }
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
            #endregion

            public void PrintTransaction()
            {
            MyWriter.WriteLine("***************");
            MyWriter.WriteLine("\tTo: " + ToAddress.GetAddressAsString());
            MyWriter.WriteLine("\tFrom: " + FromAddress.GetAddressAsString());
            MyWriter.WriteLine("\tValue: " + Value.ToString());
            MyWriter.WriteLine("***************");
            }
    }

}
