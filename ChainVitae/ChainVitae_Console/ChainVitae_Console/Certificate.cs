using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae_Console
{
    public class Certificate
    {
        private Address To; //Address
        private Address From; //Address
        private DateTime Started;
        private DateTime Finished;
        private string SerialNo;
        private string Title;
        private string Grade;
        private string Description;

        public Certificate()
        {
            //Default for testing purposes can not be left in final version!
            To = new Address();
            From = new Address();
            Started = new DateTime();
            Finished = new DateTime();
            Started = DateTime.Now.AddYears(-3);
            Finished = DateTime.Now.AddDays(-30);
            SerialNo = "ABV163897493";
            Title = "Bsc Computer Science";
            Grade = "Second class honours";
            Description = "[Description]";
        }

        public Certificate(Address _to, Address _from, DateTime _started, DateTime _finished, string _serialNo, string _title, string _grade, string _description)
        {
            if ( !_to.IsValid() || !_from.IsValid() || _started != null || _finished != null)
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

        public void PrintCertificate()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\tToAddress: " + To.GetAddressAsString());
            Console.WriteLine("\tFromAddress: " + From.GetAddressAsString());
            Console.WriteLine("\tStarted: " + Started.ToLongDateString());
            Console.WriteLine("\tFinished: " + Finished.ToLongDateString());
            Console.WriteLine("\tSerialNo: " + SerialNo);
            Console.WriteLine("\tTitle: " + Title);
            Console.WriteLine("\tGrade: " + Grade);
            Console.WriteLine("\tDescription: " + Description);
            Console.WriteLine("--------------------------------");
        }
        
        public bool IsValid()
        {
            if (!this.To.IsValid() || !this.From.IsValid() || this.SerialNo != "" || this.Title != "" || this.Grade != "" || this.Description != "")
            {
                return true;
            }
            return false;
        }

        #region Validators
        private bool AddressIsValid()
        {
            throw new NotImplementedException();
        }

        private bool DateTimeIsValid()
        {
            throw new NotImplementedException();
        }

        private bool SerialNoIsValid()
        {
            //Might be difficult to validate due to multiple providers of official certificate would benefit
            //the solution if a custom SerialNo was generated for the purposes of the blockchain 
            throw new NotImplementedException();
        }

        private bool TitleIsValid()
        {
            //Just needs to check for profanity and check 
            throw new NotImplementedException();
        }

        private bool GradeIsValid()
        {
            throw new NotImplementedException();
        }

        private bool DescriptionIsValid()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
