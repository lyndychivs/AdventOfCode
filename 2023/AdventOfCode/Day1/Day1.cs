namespace AdventOfCode.Day1
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Day1
    {
        private readonly string[] _input;

        private readonly List<int> _calibrationValues;

        private readonly Dictionary<string, int> _numberTransactionTable = new()
        {
            { "zero" , 0 },
            { "one" , 1 },
            { "two" , 2 },
            { "three" , 3 },
            { "four" , 4 },
            { "five" , 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        private readonly List<string> _wordsToFind =
        [
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"
        ];

        public Day1()
        {
            _calibrationValues = [];
            _input = File.ReadAllLines(@"Day1/input.txt");
        }

        public int GetSumOfCalibrationValues()
        {
            foreach (var line in _input)
            {
                var firstWord = GetFirstCalibrationWord(line);
                var lastWord = GetLastCalibrationWord(line);

                if (string.IsNullOrWhiteSpace(firstWord) && string.IsNullOrWhiteSpace(lastWord))
                {
                    continue;
                }

                var didParseFirstSuccessfully = int.TryParse(firstWord, out int firstNumber);
                var didParseLastSuccessfully = int.TryParse(lastWord, out int lastNumber);

                if (!didParseFirstSuccessfully)
                {
                    firstNumber = _numberTransactionTable[firstWord];
                }

                if (!didParseLastSuccessfully)
                {
                    lastNumber = _numberTransactionTable[lastWord];
                }

                _calibrationValues.Add(int.Parse($"{firstNumber}{lastNumber}"));
            }

            return _calibrationValues.Sum();
        }

        private string GetFirstCalibrationWord(string input)
        {
            var word = string.Empty;
            for (int i = 0; i <= input.Length; i++)
            {
                var calibrationValue = input.Substring(0, i);

                word = TryExtractWordFromInput(calibrationValue);
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }

                return word;
            }

            return word;
        }

        private string GetLastCalibrationWord(string input)
        {
            var word = string.Empty;
            for (int i = input.Length; i >= 0; i--)
            {
                int subLength = input.Length - i;
                var calibrationValue = input.Substring(i, subLength);

                word = TryExtractWordFromInput(calibrationValue);
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }

                return word;
            }

            return word;
        }

        private string TryExtractWordFromInput(string input)
        {
            foreach (var wordToFind in _wordsToFind)
            {
                if (input.Contains(wordToFind))
                {
                    return wordToFind;
                }
            }

            return string.Empty;
        }
    }
}