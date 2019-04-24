using ChainVitae_Console.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console.Node
{
    /// <summary>
    /// Is the process in the node that recieves messages related to the blockchain and other nodes
    /// </summary>
    public class Listener
    {
        private static Processor myProcess;
        public Listener()
        {

        }

        public void AssignProcessor(Processor processor)
        {
            myProcess = processor;
        }

        public bool ValidateTransaction(Transaction transaction, Guid nodeid)
        {
            try
            {
                transaction.GetCertificate();
                transaction.GetFromAddress();
                transaction.GetHashCode();
                transaction.GetTimeStamp();
                transaction.GetToAddress();
                List<Signature> mylist = transaction.GetSignatures();
                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                return false;
            }
        }
    }


}
