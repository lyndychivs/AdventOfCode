namespace AdventOfCode.Year2020.Day02
{
    using System.Collections.Generic;
    using System.Xml;

    public class Part2
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

                Postition1 = int.Parse(range[0]) - 1;
                Postition2 = int.Parse(range[1]) - 1;
                Character = parts[1][0];
                Password = parts[2];
            }

            public int Postition1 { get; init; }

            public int Postition2 { get; init; }

            public char Character { get; init; }

            public string Password { get; init; }

            public bool IsValid()
            {
                char firstChar = Password[Postition1];
                char secondChar = Password[Postition2];

                if (firstChar == secondChar)
                {
                    return false;
                }

                if (firstChar == Character || secondChar == Character)
                {
                    return true;
                }

                return false;
            }
        }
    }
}