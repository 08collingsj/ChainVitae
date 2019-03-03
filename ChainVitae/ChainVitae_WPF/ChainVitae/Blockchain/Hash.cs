using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChainVitae.Blockchain
{
    public class Hash
    {
        public Hash()
        {

        }

        public string ComputeSha256Hash(string data)
        {
            using (SHA256 localHash = SHA256.Create())
            {
                byte[] bytes = localHash.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }


    
}
