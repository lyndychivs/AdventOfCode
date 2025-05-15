namespace AdventOfCode.Year2016.Day06
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Part1
    {
        public string DecodeMessages(List<string> inputs)
        {
            var characters = new Dictionary<char, int>();
            var message = new StringBuilder();

            for (int x = 0; x < inputs[0].Length; x++)
            {
                foreach (string input in inputs)
                {
                    char character = input[x];
                    if (characters.TryGetValue(character, out int value))
                    {
                        characters[character] = ++value;
                    }
                    else
                    {
                        characters.Add(character, 1);
                    }
                }

                var charactersSortedByCount = characters.OrderByDescending(x => x.Value).ToList();

                _ = message.Append(charactersSortedByCount[0].Key);

                characters.Clear();
            }

            return message.ToString();
        }
    }
}