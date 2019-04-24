using ChainVitae_Console.Node;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class NodeInstance
    {
        private Guid _InstanceID { get; set; }
        private Boolean Active = true;
        private BlockChain theChain;
        private string HashedNeighborNodes;
        private List<NodeInstance> NeighborNodes;
        private List<Transaction> MemoryPool; 
        private string _Name;
        private string _Location = "No Location Assigned";
        //private Listener myListener;
        private BackgroundWorker myListener;
        //private Processor myProcessor;
        private BackgroundWorker myProcessor;
        //NodeSpeed
        public string GetName { get { return _Name; } }
        public string GetLocation { get { return _Location; } }
        public Guid GetId { get { return _InstanceID; } }

        public void SetName(string newName) { _Name = newName; }
        public List<Transaction> transactions;
        /*
         * Nodes contain an instance of the blockchain
         * A Mempool of pending transactions
         * 
         * The node needs to be able to run independently without other nodes 
         * It needs to be able to recieve transactions
         * ValidateTransactions
         * Approve and Deny Transactions
         * Notify other nodes of:
         *  - Finishing a block
         *  - Approving / Denying a transaction
         *  - Any changes in state 
         *  - Adding a block to the blockchain 
         *  - NotifyNodes
         *  
         *  {LISTENER}
         *  A node needs one loop that constantly listens for: A Blockchain change, A New Transaction, A processed Transaction, A change in the node list
         *  
         *  {PROCESSOR}
         *  A node needs a second loop for processing transactions from the mempool  
         */

        public NodeInstance(BlockChain myChain)
        {
            this._InstanceID = Guid.NewGuid();
            this.theChain = myChain;
            SetName(_InstanceID.ToString());
            Console.WriteLine("Node created: {0}", this._InstanceID);
            myListener = new BackgroundWorker();
            myListener.DoWork += new System.ComponentModel.DoWorkEventHandler(myListener_DoWork);
            myListener.RunWorkerAsync(2000);
           // myListener.AssignProcessor(myProcessor);
        }

        public void PrintUniqueInstanceID()
        {
            Console.WriteLine("Unique ID for '{0}' is: {1}", GetName, GetId);
           
        }
        public void PrintData()
        {
            //InstanceId, Active, NeighorNodes, MemoryPool, Name, Location
            Console.WriteLine("Node Data: ");
            Console.WriteLine("UniqueID: {0}", GetId);
            Console.WriteLine("State: {0}", Active);
            //Console.WriteLine("NeighborNodes: {0} ", NeighborNodes.ToString());
            //Console.WriteLine("MemoryPool: {0}", MemoryPool);
            Console.WriteLine("Name: {0}", GetName);
            Console.WriteLine("Location: {0}", GetLocation);
        }
        public NodeInstance(string newLocation, string newName)
        {
            this._InstanceID = Guid.NewGuid();
            this._Location = newLocation;
            SetName(newName);
        }
        

        public bool ValidateTransaction(Transaction transaction)
        {
            if (transaction != null)
                return true;
            else
                return false;
        }

        #region Listener 
        public void myListener_DoWork(object sender, DoWorkEventArgs e)
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
            Console.WriteLine("Listener is alive");
            return result;
        }
        #endregion
        private void UpdateBlockchain()
        { }
        private void AddToBlockchain(BlockWithDouble newBlock)
        { this.theChain.AddBlock(newBlock); }

        private void UpdateNeighbors()
        { }
        private void AddToNeighbors() { }
    }
}
