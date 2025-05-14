namespace AdventOfCode.Year2016.Day05
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class Part2
    {
        public string CalculatePassword(string input)
        {
            int i = 0;

            var password = new Dictionary<int, char>();

            while (password.Count < 8)
            {
                string hash = GetHash(input, i);

                if (hash.StartsWith(new string('0', 5)))
                {
                    if (!char.IsDigit(hash[5]))
                    {
                        i++;
                        continue;
                    }

                    int key = int.Parse(hash[5].ToString());
                    if (key is < 0 or > 7)
                    {
                        i++;
                        continue;
                    }

                    if (password.ContainsKey(key))
                    {
                        i++;
                        continue;
                    }

                    password[key] = hash[6];
                }

                i++;
            }

            var passBuilder = new StringBuilder();
            for (int x = 0; x < password.Count; x++)
            {
                _ = passBuilder.Append(password[x]);
            }

            return passBuilder.ToString();
        }

        private string GetHash(string input, int i)
        {
            return Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(input + i)));
        }
    }
}