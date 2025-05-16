namespace AdventOfCode.Year2016.Day07
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        public int GetCountOfValidIpAddresses(IEnumerable<string> inputs)
        {
            int count = 0;
            foreach (string input in inputs)
            {
                if (IsValidIpAddress(input))
                {
                    count++;
                }
            }

            return count;
        }

        private bool IsValidIpAddress(string input)
        {
            string[] parts = input.Split(['[', ']'], StringSplitOptions.RemoveEmptyEntries);

            bool response = false;
            for (int i = 0; i < parts.Length; i++)
            {
                bool doesContainPalindrome = DoesContainPalindrome(parts[i]);

                if (doesContainPalindrome && i % 2 == 0 == false)
                {
                    return false;
                }

                if (doesContainPalindrome)
                {
                    response = true;
                }
            }

            return response;
        }

        private bool DoesContainPalindrome(string part)
        {
            for (int i = 0; i < part.Length - 3; i++)
            {
                if (part[i] == part[i + 3]
                    && part[i + 1] == part[i + 2])
                {
                    if (part[i] == part[i + 1])
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}