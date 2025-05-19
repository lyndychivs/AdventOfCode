namespace AdventOfCode.Year2016.Day10
{
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        private readonly Dictionary<int, Robot> _robots = [];

        private readonly Dictionary<int, int> _outputs = [];

        public int GetValuesOfFirstThreeOutputsMultipled(IEnumerable<string> inputs)
        {
            SetUpBotRouting(inputs);
            SetUpBotValues(inputs);

            while (_robots.Any(r => r.Value.HasTwoValues()))
            {
                foreach (KeyValuePair<int, Robot> robot in _robots)
                {
                    if (robot.Value.HasTwoValues())
                    {
                        int lowValue = robot.Value.GetLowValue();

                        int highValue = robot.Value.GetHighValue();

                        if (robot.Value.IsLowValueOutput)
                        {
                            _outputs[robot.Value.LowValueTo] = lowValue;
                        }
                        else
                        {
                            _robots[robot.Value.LowValueTo].AddValue(lowValue);
                        }

                        if (robot.Value.IsHighValueOutput)
                        {
                            _outputs[robot.Value.HighValueTo] = highValue;
                        }
                        else
                        {
                            _robots[robot.Value.HighValueTo].AddValue(highValue);
                        }

                        if (_outputs.ContainsKey(0) && _outputs.ContainsKey(1) && _outputs.ContainsKey(2))
                        {
                            return _outputs[0] * _outputs[1] * _outputs[2];
                        }
                    }
                }
            }

            return 0;
        }

        private void SetUpBotValues(IEnumerable<string> inputs)
        {
            foreach (string input in inputs)
            {
                if (input.StartsWith("value "))
                {
                    string inputClean = input.Replace("value ", string.Empty)
                        .Replace(" goes to bot", string.Empty)
                        .Trim();

                    string[] valueParts = inputClean.Split(' ');

                    int value = int.Parse(valueParts[0]);

                    int botId = int.Parse(valueParts[1]);

                    _robots[botId].AddValue(value);
                }
            }
        }

        private void SetUpBotRouting(IEnumerable<string> inputs)
        {
            foreach (string input in inputs)
            {
                if (input.StartsWith("bot "))
                {
                    string inputClean = input.Replace(" gives low to", string.Empty)
                        .Replace(" and high to", string.Empty)
                        .Trim();

                    string[] routeParts = inputClean.Split(' ');

                    int botId = int.Parse(routeParts[1]);

                    if (!_robots.ContainsKey(botId))
                    {
                        _robots.Add(botId, new Robot(botId));
                    }

                    if (routeParts[2] == "output")
                    {
                        _robots[botId].IsLowValueOutput = true;
                        _robots[botId].LowValueTo = int.Parse(routeParts[3]);
                    }
                    else
                    {
                        _robots[botId].IsLowValueOutput = false;
                        _robots[botId].LowValueTo = int.Parse(routeParts[3]);
                    }

                    if (routeParts[4] == "output")
                    {
                        _robots[botId].IsHighValueOutput = true;
                        _robots[botId].HighValueTo = int.Parse(routeParts[5]);
                    }
                    else
                    {
                        _robots[botId].IsHighValueOutput = false;
                        _robots[botId].HighValueTo = int.Parse(routeParts[5]);
                    }
                }
            }
        }

        private class Robot(int id)
        {
            private readonly List<int> _values = [];

            public int Id { get; set; } = id;

            public int LowValueTo { get; set; }

            public bool IsLowValueOutput { get; set; } = false;

            public int HighValueTo { get; set; }

            public bool IsHighValueOutput { get; set; } = false;

            public void AddValue(int value)
            {
                if (_values.Count == 2)
                {
                    return;
                }

                if (_values.Contains(value))
                {
                    return;
                }

                _values.Add(value);
            }

            public bool HasTwoValues()
            {
                return _values.Count == 2;
            }

            public int GetLowValue()
            {
                int value = _values.OrderDescending().ToList()[1];

                _ = _values.Remove(value);

                return value;
            }

            public int GetHighValue()
            {
                int value = _values.OrderDescending().ToList()[0];

                _ = _values.Remove(value);

                return value;
            }
        }
    }
}