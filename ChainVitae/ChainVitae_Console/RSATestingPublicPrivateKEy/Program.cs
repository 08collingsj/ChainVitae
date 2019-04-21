using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RSATestingPublicPrivateKEy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a public/private key using RSA  
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    //Print public key


                    
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
    }
}
