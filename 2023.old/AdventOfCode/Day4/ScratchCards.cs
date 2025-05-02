namespace AdventOfCode.Day4
{
    using System.Collections.Generic;
    using System.Linq;

    public class ScratchCards
    {
        private readonly string[] _input;

        private readonly List<ScratchCard> _scratchCards;

        private Dictionary<int, List<ScratchCard>> _cardsWon;

        public ScratchCards(string[] input)
        {
            _input = input;
            _scratchCards = PopulateScratchCardGames();
            _cardsWon = [];
        }

        public int GetTotalCardsLeftAfterWinning()
        {
            foreach (var scratchCard in _scratchCards)
            {
                if (_cardsWon.Keys.Contains(scratchCard.Id))
                {
                    _cardsWon[scratchCard.Id].Add(scratchCard);
                }
                else
                {
                    _cardsWon.Add(scratchCard.Id, [scratchCard]);
                }

                for (var i = 1; i <= scratchCard.MatchedNumbers.Count; i++)
                {
                    if (!_cardsWon.Keys.Contains(scratchCard.Id + i))
                    {
                        _cardsWon.Add(scratchCard.Id + i, []);
                    }

                    _cardsWon[scratchCard.Id + i].Add(_scratchCards[(scratchCard.Id + i) - 1]);
                }

                if (_cardsWon[scratchCard.Id].Count == 1)
                {
                    continue;
                }

                for (var i = 1; i < _cardsWon[scratchCard.Id].Count; i++)
                {
                    for (var j = 1; j <= _cardsWon[scratchCard.Id][i].MatchedNumbers.Count; j++)
                    {
                        if (!_cardsWon.Keys.Contains(scratchCard.Id + j))
                        {
                            _cardsWon.Add(scratchCard.Id + j, []);
                        }

                        _cardsWon[scratchCard.Id + j].Add(_scratchCards[(scratchCard.Id + j) - 1]);
                    }
                }
            }

            var countOfTotalCardsWon = 0;
            foreach (var cards in _cardsWon)
            {
                countOfTotalCardsWon += cards.Value.Count;
            }

            return countOfTotalCardsWon;
        }

        public int GetTotalPoints()
        {
            var points = new List<int>();

            foreach(var scratchCard in _scratchCards)
            {
                points.Add(scratchCard.GetPoints());
            }

            return points.Sum();
        }

        private List<ScratchCard> PopulateScratchCardGames()
        {
            var scratchCards = new List<ScratchCard>();
            foreach(var line in _input)
            {
                var scratchCard = new ScratchCard(line);
                scratchCards.Add(scratchCard);
            }

            return scratchCards;
        }
    }
}