using ChainVitae_Console.DataType;
using ChainVitae_Console.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChainVitae_Console.Node
{
    /// <summary>
    /// Is the process in the node that recieves messages related to the blockchain and other nodes
    /// </summary>
    public class Listener
    {
        private static BackgroundWorker myBw;
        public Listener()
        {
            myBw = new BackgroundWorker();
            myBw.DoWork += new System.ComponentModel.DoWorkEventHandler(myBw_DoWork);
            myBw.RunWorkerAsync();
        }

        #region Listener 
        public void myBw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            int arg = (int)e.Argument;
            e.Result = myListenerLogic(bw, arg);
            if (bw.CancellationPending)
                e.Cancel = true;
        }
        private int myListenerLogic(BackgroundWorker bw, int a)
        {
            int result = 0;
            Thread.Sleep(20000);
            MyWriter.WriteLine("Listener is alive");
            return result;
        }
        #endregion

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
