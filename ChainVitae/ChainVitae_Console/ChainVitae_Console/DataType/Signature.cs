using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console.DataType
{
    public class Signature
    {
        //Contains a timestamp and a guid
        private DateTime TimeStamp;
        private Guid NodeId;
       
        public DateTime GetTimeStamp { get { return TimeStamp; } }
        public Guid GetId { get { return NodeId; } }

        public Signature(Guid id)
        {
            TimeStamp = DateTime.Now;
            NodeId = id;
        } 
    }
}
