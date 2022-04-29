using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Project1
{
    public class HashPw
    {
        public static string Hash(string password)
        {
            using var sha1 = SHA1.Create();

            byte[] pwBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedPw = sha1.ComputeHash(pwBytes);
            return Convert.ToBase64String(hashedPw);
        }
    }
}
