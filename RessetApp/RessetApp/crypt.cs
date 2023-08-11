using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime;
using System.Security.Cryptography;
namespace RessetApp
{
    public static class crypt
    {
        public static string hash(string inp)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inp);
            var hashofinp = SHA256.Create ();
            byte[] s =hashofinp.ComputeHash(bytes);
            

            string hex =   BitConverter.ToString(s).Replace("-", "");
            return hex;
        }
    }
}
