namespace AdventOfCode.Year2015.Day09
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        private readonly List<Route> _knownRoutes = [];

        private readonly List<string> _knownDestinations = [];

        public int CalculateLongestRouteDistance(IEnumerable<string> inputs)
        {
            foreach (string input in inputs)
            {
                MapInputToRoute(input);
            }

            IEnumerable<string[]> routePermutations = GetRoutePermutations(_knownDestinations);

            List<List<Route>> routes = [];
            foreach (string[] permutation in routePermutations)
            {
                List<Route> journey = [];
                for (int i = 0; i < permutation.Length - 1; i++)
                {
                    journey.Add(GetKnownRoute(permutation[i], permutation[i + 1]));
                }

                routes.Add(journey);
            }

            return GetLongestRouteDistance(routes);
        }

        private int GetLongestRouteDistance(List<List<Route>> allJourneys)
        {
            int longestDistance = int.MinValue;

            foreach (List<Route> journey in allJourneys)
            {
                int journeyDistance = 0;

                foreach (Route route in journey)
                {
                    journeyDistance += route.Distance;
                }

                if (journeyDistance > longestDistance)
                {
                    longestDistance = journeyDistance;
                }
            }

            return longestDistance;
        }

        private Route GetKnownRoute(string source, string destination)
        {
            return _knownRoutes.First(r => r.Source == source && r.Destination == destination);
        }

        private IEnumerable<string[]> GetRoutePermutations(List<string> destinations)
        {
            if (destinations.Count == 1)
            {
                return [[.. destinations]];
            }

            return destinations.SelectMany(x => GetRoutePermutations([.. destinations.Except([x])]),
                (x, y) => new[] { x }.Concat(y).ToArray());
        }

        private void MapInputToRoute(string input)
        {
            string[] parts = input.Split([" to ", " = "], StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
            {
                throw new ArgumentException($"Invalid input format: {input}");
            }

            _knownRoutes.Add(new Route(parts[0], parts[1], int.Parse(parts[2])));
            _knownRoutes.Add(new Route(parts[1], parts[0], int.Parse(parts[2])));

            if (_knownDestinations.Contains(parts[0]) == false)
            {
                _knownDestinations.Add(parts[0]);
            }

            if (_knownDestinations.Contains(parts[1]) == false)
            {
                _knownDestinations.Add(parts[1]);
            }
        }

        private class Route(string source, string destination, int distance)
        {
            public string Source { get; } = source;

            public string Destination { get; } = destination;

            public int Distance { get; } = distance;
        }
    }
}