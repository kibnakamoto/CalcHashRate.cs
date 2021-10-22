using System;
using System.Security.Cryptography; // only has Shake algorithms
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

/*      Hashrate isn't accurate but power does affect output a by lot        */

namespace HashAlgs
{
    public class SHAKE
    {
        public string Sha256HR(string Data) // sha256 hashing
        {
            /* hashrate not calculated here */
            using (SHA256 Shake256 = SHA256.Create())
            {
                // bytearray
                byte[] HashedSha256Data = Shake256.ComputeHash(Encoding.UTF8.
                                                                GetBytes(Data));
              StringBuilder BToS = new StringBuilder();
                // convert to string
                for (uint c=0;c<HashedSha256Data.Length;c++)
                {
                    BToS.Append(HashedSha256Data[c].ToString("x2"));
                }
                return BToS.ToString();
            }
        }
    }
    public class Output
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            SHAKE shaHash = new SHAKE();
            
            List<string>HashList = new List<string>();

            DateTime timePlus1 = DateTime.Now.AddSeconds(1);
            while (DateTime.Now < timePlus1)
            {

                var crypt = new RNGCryptoServiceProvider(); // random string
                
                /* no limit to 255. Type not byte. */
                var RandomByteArray = new byte[100]; // 100 bytes
                crypt.GetBytes(RandomByteArray);

                string hashRand = shaHash.Sha256HR(Convert.ToBase64String(RandomByteArray));
                HashList.Add(hashRand);
                
                Console.Write(hashRand);
            }
            
            Console.WriteLine(); // Empty line. Equivalent to "\n"
            Console.WriteLine($"Hashrate = {HashList.Count}");
        }
    }
}
