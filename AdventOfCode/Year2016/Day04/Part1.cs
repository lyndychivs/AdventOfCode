namespace AdventOfCode.Year2016.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part1
    {
        public int GetSumOfRealRoomSectorIds(IEnumerable<string> inputs)
        {
            int sum = 0;
            foreach (string input in inputs)
            {
                sum += GetSectorIds(input);
            }

            return sum;
        }

        private int GetSectorIds(string input)
        {
            string checksum = input.Substring(input.IndexOf('[') + 1, input.IndexOf(']') - 1 - input.IndexOf('['));

            string encryptedName = input.Replace($"[{checksum}]", string.Empty);

            string[] encryptedParts = encryptedName.Split(['-'], StringSplitOptions.RemoveEmptyEntries);

            var encryptedLetters = new SortedList<char, int>();

            int sectorId = 0;
            foreach (string encryptedPart in encryptedParts)
            {
                if (int.TryParse(encryptedPart, out sectorId))
                {
                    continue;
                }

                foreach (char letter in encryptedPart)
                {
                    if (encryptedLetters.TryGetValue(letter, out int value))
                    {
                        encryptedLetters[letter] = ++value;
                    }
                    else
                    {
                        encryptedLetters.Add(letter, 1);
                    }
                }
            }

            var lettersSortedByCount = encryptedLetters.OrderByDescending(x => x.Value).ToList();
            for (int i = 0; i < 5; i++)
            {
                if (lettersSortedByCount.Count <= i)
                {
                    return 0;
                }

                if (lettersSortedByCount[i].Key != checksum[i])
                {
                    return 0;
                }
            }

            return sectorId;
        }
    }
}