using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class Certificate
    {
        private int To; //Address
        private int From; //Address
        private DateTime Started;
        private DateTime Finished;
        private string SerialNo;
        private string Title;
        private string Grade;
        private string Description;

        public Certificate()
        {
            To = 1;
            From = 2;
            Started = new DateTime();
            Finished = new DateTime();
            Started = DateTime.Now.AddYears(-3);
            Finished = DateTime.Now.AddDays(-30);
            SerialNo = "ABV163897493";
            Title = "Bsc Computer Science";
            Grade = "Second class honours";
            Description = "[Description]";
        }

        public Certificate(int _to, int _from, DateTime _started, DateTime _finished, string _serialNo, string _title, string _grade, string _description)
        {
            if (_to == 0 || _from == 0 || _started == null || _finished == null)
            {
                To = _to;
                From = _from;
                Started = _started;
                Finished = _finished;
                SerialNo = _serialNo;
                Title = _title;
                Grade = _grade;
                Description = _description;
            }
            else
            {
                Console.WriteLine("Certificate contains a null or 0 value and cant be added to the blockchain");
            }
        }

        public bool IsValid(Certificate cert)
        {
            return true;
        }
    }
}
