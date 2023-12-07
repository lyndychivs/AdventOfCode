namespace AdventOfCode.Day7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Hand(List<ICard> cards)
    {
        private readonly List<char> Ordering = ['A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2'];

        private List<ICard> Cards { get; set; } = cards;

        private bool IsJokerHand => Cards[0] is JokerCard;

        private int JokerCount
        {
            get
            {
                if (IsJokerHand)
                {
                    return Cards.Count(c => c.Value == 'J');
                }

                return 0;
            }
        }

        private Dictionary<char, int> CardsCountedByStrength
        {
            get
            {
                return Cards.Select(c => c.Value)
                    .GroupBy(val => val)
                    .Select(g => new { Value = g.Key, Count = g.Count() })
                    .ToDictionary(x => x.Value, x => x.Count);
            }
        }

        private Dictionary<char, int> CardsCountedByStrengthWithJokerAddedToMostCommon
        {
            get
            {
                var cards = CardsCountedByStrength;
                cards.Remove('J');
                cards[MostCommonCardExcludingJoker] += JokerCount;
                return cards;
            }
        }

        private char MostCommonCardExcludingJoker
        {
            get
            {
                return CardsCountedByStrength
                    .Where(c => c.Key != 'J')
                    .OrderByDescending(c => c.Value)
                    .ThenByDescending(c => Ordering.IndexOf(c.Key))
                    .First()
                    .Key;
            }
        }

        public List<int> GetPointsForCards()
        {
            var points = new List<int>();

            foreach (var card in Cards)
            {
                points.Add(card.Points);
            }

            return points;
        }

        public HandType GetHandType()
        {
            if (IsFiveOfAKind())
            {
                return HandType.FiveOfAKind;
            }

            if (IsFourOfAKind())
            {
                return HandType.FourOfAKind;
            }

            if (IsFullHouse())
            {
                return HandType.FullHouse;
            }

            if (IsThreeOfAKind())
            {
                return HandType.ThreeOfAKind;
            }

            if (IsTwoPairs())
            {
                return HandType.TwoPairs;
            }

            if (IsOnePair())
            {
                return HandType.OnePair;
            }

            if (IsHighCard())
            {
                return HandType.HighCard;
            }

            return HandType.Undefined;
        }

        public override string ToString()
        {
            var cardsAsString = string.Empty;
            foreach (var card in Cards)
            {
                cardsAsString += card.Value;
            }

            return cardsAsString;
        }

        private bool IsFiveOfAKind()
        {
            if (JokerCount == 5)
            {
                return true;
            }

            if (IsJokerHand)
            {
                return CardsCountedByStrengthWithJokerAddedToMostCommon.Any(c => c.Value == 5);
            }

            return CardsCountedByStrength.Any(c => c.Value == 5);
        }

        private bool IsFourOfAKind()
        {
            if (IsJokerHand)
            {
                return CardsCountedByStrengthWithJokerAddedToMostCommon.Any(c => c.Value == 4);
            }

            return CardsCountedByStrength.Any(c => c.Value == 4);
        }

        private bool IsThreeOfAKind()
        {
            if (IsJokerHand)
            {
                return CardsCountedByStrengthWithJokerAddedToMostCommon.Any(c => c.Value == 3);
            }

            return CardsCountedByStrength.Any(c => c.Value == 3);
        }

        private bool IsFullHouse()
        {
            return IsThreeOfAKind() && IsOnePair();
        }

        private bool IsOnePair()
        {
            if (IsJokerHand)
            {
                return CardsCountedByStrengthWithJokerAddedToMostCommon.Any(c => c.Value == 2);
            }

            return CardsCountedByStrength.Any(c => c.Value == 2);
        }

        private bool IsTwoPairs()
        {
            if (IsJokerHand)
            {
                return CardsCountedByStrengthWithJokerAddedToMostCommon.Count(c => c.Value == 2) == 2;
            }

            return CardsCountedByStrength.Count(c => c.Value == 2) == 2;
        }

        private bool IsHighCard()
        {
            return CardsCountedByStrength.Count(c => c.Value == 1) == 5;
        }
    }
}