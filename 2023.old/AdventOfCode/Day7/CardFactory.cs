namespace AdventOfCode.Day7
{
    using System.Collections.Generic;

    internal class CardFactory
    {
        public List<ICard> CreateStandardCards(string input)
        {
            var cards = new List<ICard>();
            foreach (var card in input)
            {
                cards.Add(new StandardCard(card));
            }

            return cards;
        }

        public List<ICard> CreateJokerCards(string input)
        {
            var cards = new List<ICard>();
            foreach (var card in input)
            {
                cards.Add(new JokerCard(card));
            }

            return cards;
        }
    }
}