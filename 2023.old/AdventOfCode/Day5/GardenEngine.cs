namespace AdventOfCode.Day5
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GardenEngine
    {
        private readonly string[] _input;

        private readonly Seeds _seeds;

        private readonly Mapper _seedToSoilMapper;
        private readonly Mapper _soilToFertilizerMapper;
        private readonly Mapper _fertilizerToWaterMapper;
        private readonly Mapper _waterToLightMapper;
        private readonly Mapper _lightToTemperatureMapper;
        private readonly Mapper _temperatureToHumidityMapper;
        private readonly Mapper _humidityToLocationMapper;

        private readonly List<Mapper> _mappers;

        public GardenEngine(string[] input)
        {
            _input = input;

            _seeds = new Seeds(_input[0..1]);
            _seedToSoilMapper = new Mapper(_input[3..15]);
            _soilToFertilizerMapper = new Mapper(_input[17..46]);
            _fertilizerToWaterMapper = new Mapper(_input[48..76]);
            _waterToLightMapper = new Mapper(_input[78..97]);
            _lightToTemperatureMapper = new Mapper(_input[99..135]);
            _temperatureToHumidityMapper = new Mapper(_input[137..161]);
            _humidityToLocationMapper = new Mapper(_input[163..]);

            _mappers =
            [
                _seedToSoilMapper,
                _soilToFertilizerMapper,
                _fertilizerToWaterMapper,
                _waterToLightMapper,
                _lightToTemperatureMapper,
                _temperatureToHumidityMapper,
                _humidityToLocationMapper
            ];
        }

        public long GetLowestLocationNumberForSeeds()
        {
            var locations = new List<long>();
            foreach (var seed in _seeds.SeedValues)
            {
                long location = seed;
                foreach (var mapper in _mappers)
                {
                    location = mapper.GetDestinationValue(location);
                }

                locations.Add(location);
            }

            return locations.Order().First();
        }

        public long GetSeedNumberWithLowestLocationNumber()
        {
            var seedRanges = new SeedRanges(_input[0..1]);

            (long, long) lowestSeed = (0, long.MaxValue);
            var lowestSeedLock = new object();

            Parallel.ForEach(seedRanges.Seeds, seeds =>
            {
                for (int i = 0; i < seeds.RangeLength; i++)
                {
                    long location = seeds.RangeStart + i;
                    foreach (var mapper in _mappers)
                    {
                        location = mapper.GetDestinationValue(location);
                    }

                    lock (lowestSeedLock)
                    {
                        if (location < lowestSeed.Item2)
                        {
                            lowestSeed = (seeds.RangeStart + i, location);
                        }
                    }
                }
            });

            return lowestSeed.Item2;
        }
    }
}