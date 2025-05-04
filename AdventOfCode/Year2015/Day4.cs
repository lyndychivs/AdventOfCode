namespace AdventOfCode.Year2015
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class Day4
    {
        public string GetSecretKeyOfHashStartingWithFiveZeros(string input)
        {
            int i = 0;
            while (true)
            {
                string hash = GetHash(input, i);

                if (hash.StartsWith("00000"))
                {
                    return i.ToString();
                }

                i++;
            }
        }

        public string GetSecretKeyOfHashStartingWithSixZeros(string input)
        {
            int i = 0;
            while (true)
            {
                string hash = GetHash(input, i);

                if (hash.StartsWith("000000"))
                {
                    return i.ToString();
                }

                i++;
            }
        }

        private string GetHash(string input, int i)
        {
            return Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(input + i)));
        }
    }
}