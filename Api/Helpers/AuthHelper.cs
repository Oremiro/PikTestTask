﻿using System.Security.Cryptography;
using System.Text;

namespace Api.Helpers
{
    public class AuthHelper
    {
        # region public
        public static byte[] GetHash(string input)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
        }

        public static string GetHashString(string input)
        {
            StringBuilder
                sb = new StringBuilder();
            foreach (byte b in GetHash(input))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        # endregion
    }
}