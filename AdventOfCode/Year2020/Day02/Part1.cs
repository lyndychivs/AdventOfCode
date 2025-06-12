namespace AdventOfCode.Year2020.Day02
{
    using System.Collections.Generic;

    public class Part1
    {
        public int CountValidPasswords(IEnumerable<string> inputs)
        {
            int validPasswordCount = 0;
            foreach (string input in inputs)
            {
                var passwordPolicy = new PasswordPolicy(input);
                if (passwordPolicy.IsValid())
                {
                    validPasswordCount++;
                }
            }

            return validPasswordCount;
        }

        private class PasswordPolicy
        {
            public PasswordPolicy(string input)
            {
                string[] parts = input.Split(' ');
                string[] range = parts[0].Split('-');

                Min = int.Parse(range[0]);
                Max = int.Parse(range[1]);
                Character = parts[1][0];
                Password = parts[2];
            }

            public int Min { get; init; }

            public int Max { get; init; }

            public char Character { get; init; }

            public string Password { get; init; }

            public bool IsValid()
            {
                int characterCount = 0;
                foreach (char c in Password)
                {
                    if (c == Character)
                    {
                        characterCount++;
                    }
                }

                return characterCount >= Min && characterCount <= Max;
            }
        }
    }
}