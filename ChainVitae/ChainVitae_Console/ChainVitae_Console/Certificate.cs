using ChainVitae_Console.Output;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if ( !Address.IsValid(_to) || !Address.IsValid(_from) || _started != null || _finished != null)
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
                MyWriter.WriteLine("Certificate contains a null or 0 value and cant be added to the blockchain");
            }
        }

        public void PrintCertificate()
        {
            MyWriter.WriteLine("--------------------------------");
            MyWriter.WriteLine("\tToAddress: " + To.GetAddressAsString());
            MyWriter.WriteLine("\tFromAddress: " + From.GetAddressAsString());
            MyWriter.WriteLine("\tStarted: " + Started.ToLongDateString());
            MyWriter.WriteLine("\tFinished: " + Finished.ToLongDateString());
            MyWriter.WriteLine("\tSerialNo: " + SerialNo);
            MyWriter.WriteLine("\tTitle: " + Title);
            MyWriter.WriteLine("\tGrade: " + Grade);
            MyWriter.WriteLine("\tDescription: " + Description);
            MyWriter.WriteLine("--------------------------------");
        }
        
        public bool IsValid()
        {
            if (Address.IsValid(To) && Address.IsValid(From) && this.SerialNo != "" && this.Title != "" && this.Grade != "" && this.Description != "" && DateTimeIsValid(Started) && DateTimeIsValid(Finished))
                return true;
            else
                return false;
        }

        #region Validators

        private bool DateTimeIsValid(DateTime dateTime)
        {
            DateTime creationTime = new DateTime(2019,4,26);
            int timeDifference = DateTime.Compare(creationTime, dateTime);
           if (dateTime >= DateTime.Now || DateTime.Compare(creationTime, dateTime) >= 0)
               return true;
           else
               return false;
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
