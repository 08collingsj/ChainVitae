using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class Wallet
    {
        private Guid _InstanceID { get; set; }
        private Address _Address;
        private string _PrivateKey;
        private string _PublicKey;
        private double _Balance = 0.00;
        private Node _MyNode;

        public Address GetAddress { get { return _Address; } }
        public string GetPublicKey { get {return _PublicKey; } }

        public double GetBalance { get { return _Balance; } }

        public Guid GetId { get { return _InstanceID; } }

        public List<Transaction> transactions;

        //For now Id and Address are not the same but eventually they should be
        public Wallet(Node node)
        {
            this._InstanceID = Guid.NewGuid();
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
    }
}
