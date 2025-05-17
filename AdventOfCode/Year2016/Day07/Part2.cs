namespace AdventOfCode.Year2016.Day07
{
    using System;
    using System.Collections.Generic;

    public class Part2
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

            var palindromesInternal = new List<string>();
            var palindromesExternal = new List<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (i % 2 == 0)
                {
                    palindromesExternal.AddRange(GetPalindromes(parts[i]));
                }
                else
                {
                    palindromesInternal.AddRange(GetPalindromes(parts[i]));
                }
            }

            foreach (string palindrome in palindromesInternal)
            {
                if (palindromesExternal.Contains($"{palindrome[1]}{palindrome[0]}{palindrome[1]}"))
                {
                    return true;
                }
            }

            return false;
        }

        private List<string> GetPalindromes(string part)
        {
            var response = new List<string>();
            for (int i = 0; i < part.Length - 2; i++)
            {
                if (part[i] == part[i + 2])
                {
                    if (part[i] == part[i + 1])
                    {
                        continue;
                    }

                    response.Add($"{part[i]}{part[i + 1]}{part[i + 2]}");
                }
            }

            return response;
        }
    }
}