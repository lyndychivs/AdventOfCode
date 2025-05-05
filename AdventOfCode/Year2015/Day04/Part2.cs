namespace AdventOfCode.Year2015.Day04
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class Part2
    {
        public string GetSecretKeyOfHashStartingWithSixZeros(string input)
        {
            int i = 0;
            while (true)
            {
                string hash = GetHash(input, i);

                if (hash.StartsWith(new string('0', 6)))
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