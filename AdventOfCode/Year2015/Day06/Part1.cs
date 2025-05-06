namespace AdventOfCode.Year2015.Day06
{
    using System.Collections.Generic;

    public class Part1
    {
        private readonly Light[,] _lights = new Light[1000, 1000];

        public int GetTotalLightsOnFromInstructions(IEnumerable<string> inputs)
        {
            foreach (string s in inputs)
            {
                ActionInstruction(s);
            }

            return GetCountOfLightsOn();
        }

        private void ActionInstruction(string input)
        {
            if (input.StartsWith("turn on "))
            {
                string gridValues = input.Replace("turn on ", string.Empty);
                ExecuteAction(Action.TurnOn, GetListofLights(gridValues));
            }

            if (input.StartsWith("turn off "))
            {
                string gridValues = input.Replace("turn off ", string.Empty);
                ExecuteAction(Action.TurnOff, GetListofLights(gridValues));
            }

            if (input.StartsWith("toggle "))
            {
                string gridValues = input.Replace("toggle ", string.Empty);
                ExecuteAction(Action.Invert, GetListofLights(gridValues));
            }
        }

        private List<Light> GetListofLights(string input)
        {
            List<Light> lights = [];

            string[] inputs = input.Split(' ');
            string[] start = inputs[0].Split(',');
            string[] end = inputs[2].Split(',');

            int startX = int.Parse(start[0]);
            int startY = int.Parse(start[1]);

            int endX = int.Parse(end[0]);
            int endY = int.Parse(end[1]);

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    lights.Add(new Light(x, y));
                }
            }

            return lights;
        }

        private void ExecuteAction(Action action, List<Light> lights)
        {
            foreach (Light light in lights)
            {
                if (_lights[light.X, light.Y] == null)
                {
                    _lights[light.X, light.Y] = new Light(light.X, light.Y);
                }

                switch (action)
                {
                    case Action.TurnOn:
                        _lights[light.X, light.Y].IsOn = true;
                        break;
                    case Action.TurnOff:
                        _lights[light.X, light.Y].IsOn = false;
                        break;
                    case Action.Invert:
                        _lights[light.X, light.Y].IsOn = !_lights[light.X, light.Y].IsOn;
                        break;
                }
            }
        }

        private int GetCountOfLightsOn()
        {
            int count = 0;

            for (int x = 0; x < _lights.GetLength(0); x++)
            {
                for (int y = 0; y < _lights.GetLength(1); y++)
                {
                    if (_lights[x, y] == null)
                    {
                        continue;
                    }

                    if (_lights[x, y].IsOn)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private enum Action
        {
            TurnOn,
            TurnOff,
            Invert,
        }

        private class Light(int x, int y)
        {
            public int X { get; private set; } = x;

            public int Y { get; private set; } = y;

            public bool IsOn { get; set; } = false;
        }
    }
}