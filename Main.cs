using System;
using System.Security.Cryptography; // only has Shake algorithms
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

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
                string hashRand = shaHash.Sha256HR(random.Next(100000,1000000000).ToString());
                HashList.Add(hashRand);
                Console.WriteLine(hashRand);
            }
            
            Console.WriteLine($"Hashrate = {HashList.Count}");
        }
    }
}
