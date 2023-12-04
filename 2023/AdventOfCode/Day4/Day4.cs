namespace AdventOfCode.Day4
{
    using System.IO;

    public class Day4
    {
        private readonly string[] _input;

        public Day4()
        {
            _input = File.ReadAllLines("Day4/input.txt");
        }

        public int GetScratchCardsTotalPoints()
        {
            var scratchCards = new ScratchCards(_input);
            return scratchCards.GetTotalPoints();
        }

        public int GetTotalCardsLeftAfterWinning()
        {
            var scratchCards = new ScratchCards(_input);
            return scratchCards.GetTotalCardsLeftAfterWinning();
        }
    }
}