using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class Node
    {
        private string _Name;
        private string _Location = "No Location Assigned";
        private Guid _InstanceID { get; set; }
        //NodeSpeed

        public string GetName { get { return _Name; } }
        public string GetLocation { get { return _Location; } }
        public Guid GetId { get { return _InstanceID; } }

        public void SetName(string newName) { _Name = newName; }
        

        public List<Transaction> transactions;

        public Node()
        {
            this._InstanceID = Guid.NewGuid();
            SetName(_InstanceID.ToString());
            Console.WriteLine("Node created: {0}", this._InstanceID);
        }

        void PrintUniqueInstanceID()
        {
            Console.WriteLine("Unique ID for '{0}' is: {1}", GetName, GetId);
        }

        public Node(string newLocation, string newName)
        {
            this._InstanceID = Guid.NewGuid();
            this._Location = newLocation;
            SetName(newName);
        }
    }
}
