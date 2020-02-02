using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Gunetberg.Helpers
{
    public class PasswordHelper
    {
        public static Guid GetHash(string password)
        {
            var stringBuilder = new StringBuilder();

            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                foreach (var b in bytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

            }

            return Guid.Parse(stringBuilder.ToString());
        }
    }
}
