using System;
using System.Collections.Generic;
using ChainVitae_Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class NodeInstanceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void CreateNodeNoParams()
        {
            NodeInstance n = new NodeInstance();
            Assert.IsNotNull(n);
        
        }
        [TestMethod]
        public void CreateGenesisNode()
        {
            NodeInstance n = new NodeInstance();
            Assert.IsNotNull(n);
        }
        [TestMethod]
        public void CreateNodeWithBlockchain()
        {
            BlockChain test = new BlockChain();
            List<NodeInstance> allNodes = new List<NodeInstance>();
            NodeInstance m = new NodeInstance(test, allNodes);
            Assert.IsNotNull(m);
            Assert.IsNotNull(m.GetId);
            Assert.IsTrue(m.GetState);
            Assert.IsNotNull(m.GetChain);
        }

        [TestMethod]
        public void CommunicateBetweenTwoNodes()
        {
            NodeInstance nodeInstance1 = new NodeInstance();
            NodeInstance nodeInstance2 = new NodeInstance();
            nodeInstance1.SendWhisper();
            List<string> mempool = nodeInstance2.GetMemoryPool;
            Assert.IsTrue(mempool.Contains("Basic Whisper"));
            Assert.IsTrue(mempool.Count > 1);
        }

        [TestMethod]
        public void TransactionWhisper()
        {
            Address a = new Address();
            Address b = new Address();
            NodeInstance nodeInstance1 = new NodeInstance();
            NodeInstance nodeInstance2 = new NodeInstance();
            TransactionWithDouble transactionWithDouble = new TransactionWithDouble(a, b, 20.0);
            nodeInstance1.SendWhisper(transactionWithDouble);
            List<string> mempool = nodeInstance2.GetMemoryPool;
            Assert.IsTrue(mempool.Contains("Basic Whisper"));
            Assert.IsTrue(mempool.Count > 1);
        }
        [TestMethod]
        public void NodeListWhisper()
        {

        }
        [TestMethod]
        public void NewBlockWhisper()
        {

        }
    }
}
