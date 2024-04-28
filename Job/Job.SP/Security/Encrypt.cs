using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Job.SP.Security
{
    public static class Encrypt
    {
        public static string EncryptPassword(string password)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(password));
                foreach (byte item in result)
                {
                    sb.Append(item.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
