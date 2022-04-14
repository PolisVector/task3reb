using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace task3reb
{
    class KeyCreation
    {
        public static string GetHMAC(byte[] bytes, string input)
        {
            input += BitConverter.ToString(bytes).Replace("-", "");
            byte[] hash = Encoding.ASCII.GetBytes(input);
            var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256);
            hashAlgorithm.BlockUpdate(hash, 0, hash.Length);
            byte[] result = new byte[32];
            hashAlgorithm.DoFinal(result, 0);
            string hashString = BitConverter.ToString(result);
            hashString = hashString.Replace("-", "").ToLowerInvariant();
            return hashString;
        }

        public static byte[] GenerateKey()
        {
            byte[] random = new byte[32];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random);
            return random;
        }
    }
}

