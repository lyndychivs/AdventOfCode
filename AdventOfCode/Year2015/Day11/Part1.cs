namespace AdventOfCode.Year2015.Day11
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        private readonly List<char> _forbiddenChars = [ 'i', 'o', 'l' ];

        public string GetNextPassword(string input)
        {
            do
            {
                input = IncrementPassword(input);
            }
            while (!IsPasswordValid(input));

            return input;
        }

        private string IncrementPassword(string password)
        {
            char c = GetNextChar(password[^1]);

            string newPassword = string.Empty;
            if (c == 'a')
            {
                newPassword = IncrementPassword(password[..^1]);
            }

            return (string.IsNullOrWhiteSpace(newPassword) ? password[..^1] : newPassword) + c;
        }

        private bool IsPasswordValid(string password)
        {
            if (password.Length != 8)
            {
                return false;
            }

            return DoesContainTwoUniquePairs(password) && DoesContainStraight(password) && !ContainsForbiddenChars(password);
        }

        private bool ContainsForbiddenChars(string password)
        {
            foreach (char forbiddenChar in _forbiddenChars)
            {
                if (password.Contains(forbiddenChar))
                {
                    return true;
                }
            }

            return false;
        }

        private bool DoesContainTwoUniquePairs(string password)
        {
            List<char> pairs = [];

            for (int i = 0; i < password.Length - 1; i++)
            {
                if (IsPair(password[i], password[i + 1]))
                {
                    pairs.Add(password[i]);
                    i++;
                }
            }

            return pairs.Distinct().ToList().Count >= 2;
        }

        private bool IsPair(char c1, char c2)
        {
            return c1 == c2;
        }

        private bool DoesContainStraight(string password)
        {
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (IsStraight(password[i], password[i + 1], password[i + 2]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsStraight(char c1, char c2, char c3)
        {
            return c1 + 1 == c2 && c2 + 1 == c3;
        }

        private char GetNextChar(char c)
        {
            if (c == 'z')
            {
                return 'a';
            }

            char nextChar = (char)(c + 1);

            if (_forbiddenChars.Contains(nextChar))
            {
                return GetNextChar(nextChar);
            }

            return nextChar;
        }
    }
}