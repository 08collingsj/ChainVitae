using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;

namespace ChainVitae_Console
{
    public class Address
    {
        private string HashAddress; 
        //To and From 
        // BCrypt.Net.BCrypt();
        public Address()
        {
            this.HashAddress = generateHashCode().ToString();
        }

        private int generateHashCode()
        {
            string n = "";
            for (int i = 0; i< 10; i++)
            {
                Random _random = new Random();
                int num = _random.Next(0, 26); // Zero to 25
                char let = (char)('a' + num);
                n = n + let;
            }
            Console.Write(n);
            return n.GetHashCode();
        }

    }
}
