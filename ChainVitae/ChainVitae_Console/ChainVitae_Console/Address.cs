using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ChainVitae_Console.Output;

namespace ChainVitae_Console
{
    public class Address
    {
        private string HashAddress;
        private string privateKey;
        private string publicKey; 
        //To and From 
        // BCrypt.Net.BCrypt();
        public Address()
        {
            this.HashAddress = GenerateHashCode().ToString();
        }

        private int GenerateHashCode()
        {
            string n = "";
            for (int i = 0; i< 10; i++)
            {
                Random _random = new Random();
                int num = _random.Next(0, 26); // Zero to 25
                char let = (char)('a' + num);
                n = n + let;
            }
            return n.GetHashCode();
        }

        private string GenerateKeys()
        {
            // Generate a public/private key using RSA  
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    // Do something with the key...
                    // Encrypt, export, etc.
                    return "";
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }

        }
        public string GetAddressAsString()
        {
            return HashAddress;
        }

        //Ensure that HashAddress has been assigned
        public bool IsValid()
        {
            if (HashAddress != "" && HashAddress.Length != 0)
                return true;
            
            return false;
        }

    }
}
