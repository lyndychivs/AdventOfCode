namespace AdventOfCode.Day7
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Day7
    {
        private readonly string[] _input;

        public Day7()
        {
            _input = File.ReadAllLines("Day7/input.txt");
        }

        public int Part1()
        {
            var cardFactory = new CardFactory();
            var gamePlays = new List<GamePlay>();
            foreach (var line in _input)
            {
                var hand = new Hand(cardFactory.CreateStandardCards(line.Split(' ')[0]));
                var bid = new Bid(line.Split(' ')[1]);

                gamePlays.Add(new GamePlay(hand, bid));
            }

            gamePlays.Sort();
            gamePlays.Reverse();

            var totalWinnings = 0;
            for (int i = 1; i <= gamePlays.Count; i++)
            {
                totalWinnings += (i * gamePlays[i - 1].Bid);
            }

            return totalWinnings;
        }

        public int Part2()
        {
            var cardFactory = new CardFactory();
            var gamePlays = new List<GamePlay>();
            foreach (var line in _input)
            {
                var hand = new Hand(cardFactory.CreateJokerCards(line.Split(' ')[0]));
                var bid = new Bid(line.Split(' ')[1]);

                gamePlays.Add(new GamePlay(hand, bid));
            }

            gamePlays.Sort();
            gamePlays.Reverse();

            var totalWinnings = 0;
            for (int i = 1; i <= gamePlays.Count; i++)
            {
                Console.WriteLine(gamePlays[i-1].ToString());
                totalWinnings += i * gamePlays[i - 1].Bid;
            }

            return totalWinnings;
        }
    }
}