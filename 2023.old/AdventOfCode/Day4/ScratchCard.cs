namespace AdventOfCode.Day4
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ScratchCard
    {
        public int Id { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> ScratchNumbers { get; set; }
        public List<int> MatchedNumbers { get; set; }

        public ScratchCard(string input)
        {
            Id = GetCardIdFromInput(input);
            WinningNumbers = GetWinningNumbersFromInput(input);
            ScratchNumbers = GetScratchNumbersFromInput(input);
            MatchedNumbers = GetMatchedNumbers();
        }

        public int GetPoints()
        {
            var points = 0;
            var nextPoint = 1;

            foreach (var matchedNumber in MatchedNumbers)
            {
                points = nextPoint;
                nextPoint *= 2;
            }

            return points;
        }

        private List<int> GetMatchedNumbers()
        {
            var matchedNumbers = new List<int>();
            foreach (var scratchNumber in ScratchNumbers)
            {
                if (WinningNumbers.Contains(scratchNumber))
                {
                    matchedNumbers.Add(scratchNumber);
                }
            }

            return matchedNumbers;
        }

        private List<int> GetScratchNumbersFromInput(string input)
        {
            var scratchNumbers = new List<int>();

            var splitCardNameFromNumbers = input.Split(':');
            var splitWinningNumbersFromScratched = splitCardNameFromNumbers[1].Split('|');
            var scratchedNumbersAsString = splitWinningNumbersFromScratched[1];

            var scratchedMatches = Regex.Matches(scratchedNumbersAsString, @"\d+");
            foreach (var match in scratchedMatches)
            {
                scratchNumbers.Add(GetIntFromString(match.ToString()));
            }

            return scratchNumbers;
        }

        private List<int> GetWinningNumbersFromInput(string input)
        {
            var winningNumbers = new List<int>();

            var splitCardNameFromNumbers = input.Split(':');
            var splitWinningNumbersFromScratched = splitCardNameFromNumbers[1].Split('|');
            var winningNumbersAsString = splitWinningNumbersFromScratched[0];

            var winningMatches = Regex.Matches(winningNumbersAsString, @"\d+");
            foreach (var match in winningMatches)
            {
                winningNumbers.Add(GetIntFromString(match.ToString()));
            }

            return winningNumbers;
        }

        private int GetCardIdFromInput(string input)
        {
            var gameContext = input.Split(':')[0];
            return GetIntFromString(gameContext);
        }

        private int GetIntFromString(string input)
        {
            return int.Parse(new string(input.Where(char.IsDigit).ToArray()));
        }
    }
}