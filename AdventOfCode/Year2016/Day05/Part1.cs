namespace AdventOfCode.Year2016.Day05
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class Part1
    {
        public string CalculatePassword(string input)
        {
            int i = 0;
            var hashes = new List<string>();
            while (hashes.Count < 8)
            {
                string hash = GetHash(input, i);

                if (hash.StartsWith(new string('0', 5)))
                {
                    hashes.Add(hash);
                }

                i++;
            }

            return GetPassword(hashes);
        }

        private string GetPassword(List<string> hashes)
        {
            var password = new StringBuilder();

            foreach (string hash in hashes)
            {
                _ = password.Append(hash[5]);
            }

            return password.ToString();
        }

        private string GetHash(string input, int i)
        {
            return Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(input + i)));
        }
    }
}