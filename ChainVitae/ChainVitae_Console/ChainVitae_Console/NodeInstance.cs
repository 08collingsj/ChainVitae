﻿using ChainVitae_Console.Node;
using ChainVitae_Console.Output;
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
        private List<NodeInstance> NeighborNodes;
        private List<string> MemoryPool; 
        private string _Name;
        private string _Location = "No Location Assigned";
        //private Listener myListener;
        private Listener myListener;
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
        
        public NodeInstance(BlockChain myChain, List<NodeInstance> allNodes)
        {
            this._InstanceID = Guid.NewGuid();
            this.NeighborNodes = allNodes;
            this.theChain = myChain;
            this.MemoryPool = new List<string>();
            SetName(_InstanceID.ToString());
            MyWriter.WriteLine("Node created: " + this._InstanceID);
            myListener = new Listener();
            SendNewNodeWhisper(allNodes, this);
        }

        public void PrintUniqueInstanceID()
        {
            MyWriter.WriteLine("Unique ID for '"+ GetName + "' is: " + GetId);
           
        }
        public void PrintData()
        {
            //InstanceId, Active, NeighorNodes, MemoryPool, Name, Location
            MyWriter.WriteLine("Node Data: ===============");
            MyWriter.WriteLine("UniqueID: " + GetId);
            MyWriter.WriteLine("State: " + Active);
            MyWriter.WriteLine("NeighborNodes: " + NeighborNodes.Count);
            MyWriter.WriteLine("MemoryPool: " + MemoryPool.Count);
            MyWriter.WriteLine("Name: " + GetName);
            MyWriter.WriteLine("Location: " + GetLocation);
            MyWriter.WriteLine("===============");
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

        public void SendAddBlockWhisper(List<NodeInstance> list, BlockWithDouble newBlock)
        {
            foreach (NodeInstance i in list)
            {
                i.AddToBlockchain(newBlock);
            }
        }
        public void SendNewNodeWhisper(List<NodeInstance> list, NodeInstance node)
        {
            foreach (NodeInstance i in list)
            {
                i.AddToNeighbors(node);
            }
        }
        public void SendNewTransactionWhisper(List<NodeInstance> list, TransactionWithDouble newTrx)
        {
            foreach (NodeInstance i in list)
            {
                i.ProcessTransaction(newTrx);
            }
        }
        private void UpdateBlockchain()
        { }
        private void AddToBlockchain(BlockWithDouble newBlock)
        {  theChain.AddBlock(newBlock); }

        private void ProcessTransaction(TransactionWithDouble newTrx)
        {
            if (newTrx != null)
            {
                if (Address.IsValid(newTrx.GetToAddress()) &&
                        Address.IsValid(newTrx.GetFromAddress()) &&
                            newTrx.GetValue() != 0 && 
                                newTrx.GetSignatureLog() != null)
                {
                    SignTransaction(newTrx);
                }
            }
        }

        private void SignTransaction(TransactionWithDouble trx)
        {
            trx.GetSignatureLog();
        }
        private void UpdateNeighbors()
        { }
        private void AddToNeighbors(NodeInstance node)
        {
            if (!NeighborNodes.Contains(node))
                this.NeighborNodes.Add(node);
        }
    }
}
