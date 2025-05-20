namespace AdventOfCode.Year2015.Day13
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        public int GetTotalChangeInHappiness(IEnumerable<string> inputs)
        {
            Dictionary<string, Person> _people = [];

            foreach (string input in inputs)
            {
                string[] parts = input.Split(' ');
                string person1 = parts[0];
                string person2 = parts[10].TrimEnd('.');

                int change = int.Parse(parts[3]);
                if (parts[2] == "lose")
                {
                    change = -change;
                }

                if (!_people.ContainsKey(person1))
                {
                    _people[person1] = new Person(person1);
                }

                if (!_people.ContainsKey(person2))
                {
                    _people[person2] = new Person(person2);
                }

                _people[person1].AddHappinessChange(person2, change);
            }

            foreach (string person in _people.Keys.ToList())
            {
                _people["Me"] = new Person("Me");

                _people["Me"].AddHappinessChange(person, 0);
                _people[person].AddHappinessChange("Me", 0);
            }

            IEnumerable<string[]> sittingArrangements = GetPermutations([.. _people.Keys]);

            int maxHappiness = 0;
            foreach (string[] arrangement in sittingArrangements)
            {
                int arrgementHappiness = 0;
                for (int i = 0; i < arrangement.Length; i++)
                {
                    string person1 = arrangement[i];
                    string person2 = arrangement[(i + 1) % arrangement.Length];

                    arrgementHappiness += _people[person1].GetHappinessChange(person2);
                    arrgementHappiness += _people[person2].GetHappinessChange(person1);
                }

                if (arrgementHappiness > maxHappiness)
                {
                    Console.WriteLine(string.Join(" -> ", arrangement));
                    maxHappiness = arrgementHappiness;
                }
            }

            return maxHappiness;
        }

        private IEnumerable<string[]> GetPermutations(IEnumerable<string> names)
        {
            if (names.Count() == 1)
            {
                return [[.. names]];
            }

            return names.SelectMany(x => GetPermutations([.. names.Except([x])]),
                (x, y) => new[] { x }.Concat(y).ToArray());
        }

        private class Person(string name)
        {
            public string Name { get; } = name;

            private Dictionary<string, int> _happinessChanges { get; } = [];

            public void AddHappinessChange(string person, int change)
            {
                _happinessChanges[person] = change;
            }

            public int GetHappinessChange(string name)
            {
                return _happinessChanges.TryGetValue(name, out int value) ? value : 0;
            }
        }
    }
}