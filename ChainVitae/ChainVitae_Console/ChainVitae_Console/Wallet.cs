using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class Wallet
    {
        private List<string> LocalLog;
        private Guid _InstanceID { get; set; }
        private Address _Address;
        private string _PrivateKey;
        private string _PublicKey;
        private double _Balance = 0.00;
        private Boolean _ActiveState = true;
        private DateTime _Timestamp;
        private NodeInstance _MyNode; //Shouldnt store full node instance just a static version of the data in the node to connect to the actual instance

        public Address GetAddress { get { return _Address; } }
        public string GetPublicKey { get {return _PublicKey; } }

        public double GetBalance { get { return _Balance; } }

        public Guid GetId { get { return _InstanceID; } }
        public Boolean GetActiveState { get { return _ActiveState; } }
        public DateTime GetTimeStamp { get { return _Timestamp; } }

        public List<Transaction> transactions;

        //For now Id and Address are not the same but eventually they should be
        public Wallet(NodeInstance node)
        {
            this._InstanceID = Guid.NewGuid();
            LocalLog = new List<string>();
            _Timestamp = DateTime.Now;
            Console.WriteLine("Wallet Created: ");
            Console.WriteLine("GUID: {0}   Time: {1}   Public Key: {2}   {3} ", this.GetId.ToString(), 
                                                                          this.GetTimeStamp.ToLongDateString(), 
                                                                          this.GetPublicKey, 
                                                                          this.GetActiveState.ToString());
            _MyNode = node;
            _Address = new Address();
            _PrivateKey = GeneratePrivateKey();
            _PublicKey = GeneratePublicKey();
            Console.WriteLine("Wallet created: {0} is connected to {1} ", this.GetId, node.GetId);
            GenerateTransactionsToWalletAddress(
                new Address()
                );
        }

        private string GeneratePrivateKey()
        {
            return "TempPrivateKey";
        }

        private string GeneratePublicKey()
        {
            return "TempPublicKey";
        }

        private string GenerateAddress()
        {
            return "TempAddress";
        }

        private void GenerateTransactionsToWalletAddress(Address address)
        {
            Certificate certificate = new Certificate();
            Transaction x;

            do
            {
                x = new Transaction(address, GetAddress, certificate);
                Address localAddress = GetAddress;

                Console.WriteLine("New Transaction From: {0} To: {1} ", localAddress.GetAddressAsString(), address.GetAddressAsString());
                Console.Read();    
            } while (true);
        }

        private void GenerateTransactionToWalletAddressDouble(Address address)
        {
            double d = 0.00;
            TransactionWithDouble x;
            do
            {
                x = new TransactionWithDouble(address, GetAddress, d);
                Address localAddress = GetAddress;
                Console.WriteLine("New Transaction From: {0} To: {1} ", localAddress.GetAddressAsString(), address.GetAddressAsString());
                Console.WriteLine(d);
                Console.Read();
            } while (true);
        }

        //Ask to see if the local blockchain needs updating
        private void QueryForChanges()
        {

        }
        /// <summary>
        /// Send Transaction for validation and potential approval
        /// </summary>
        private void SendTransactionToNode()
        {

        }
    }
}
