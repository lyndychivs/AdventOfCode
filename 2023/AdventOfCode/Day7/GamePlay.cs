namespace AdventOfCode.Day7
{
    using System;
    using System.Collections.Generic;

    internal class GamePlay(Hand hand, Bid bid) : IComparable<GamePlay>
    {
        private Hand _hand { get; set; } = hand;
        private Bid _bid { get; set; } = bid;

        public int Bid { get => _bid.Value; }

        public int CompareTo(GamePlay? other)
        {
            if (other == null)
            {
                return -1;
            }

            var handStrength = GetHandStrength();
            var otherHandStrength = other.GetHandStrength();

            if (handStrength > otherHandStrength)
            {
                return -1;
            }
            else if(handStrength == otherHandStrength)
            {
                var cardPoints = GetCardPointsForCard();
                var otherCardPoints = other.GetCardPointsForCard();

                if (cardPoints.Count != otherCardPoints.Count)
                {
                    throw new ArgumentException("Hands are not the same length.");
                }

                for (int i = 0; i < cardPoints.Count; i++)
                {
                    if (cardPoints[i] == otherCardPoints[i])
                    {
                        continue;
                    }

                    if (cardPoints[i] > otherCardPoints[i])
                    {
                        return -1;
                    }

                    return 1;
                }
            }

            return 1;
        }

        public override string ToString()
        {
            return $"{_hand} {_bid}";
        }

        private int GetHandStrength()
        {
            return (int)_hand.GetHandType();
        }

        private List<int> GetCardPointsForCard()
        {
            return _hand.GetPointsForCards();
        }
    }
}