namespace AdventOfCode.Year2015.Day06
{
    using System;
    using System.Collections.Generic;

    public class Part2
    {
        private readonly Light[,] _lights = new Light[1000, 1000];

        public void ActionInstruction(string input)
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

        public int GetTotalLightsBrightnessCountFromInstructions(string input)
        {
            string[] inputs = input.Split([ Environment.NewLine ], StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in inputs)
            {
                ActionInstruction(s);
            }

            return GetCountOfLightsBrightness();
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
                        _lights[light.X, light.Y].Brightness++;
                        break;
                    case Action.TurnOff:
                        _lights[light.X, light.Y].Brightness--;
                        break;
                    case Action.Invert:
                        _lights[light.X, light.Y].Brightness += 2;
                        break;
                }
            }
        }

        private int GetCountOfLightsBrightness()
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

                    count += _lights[x, y].Brightness;
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
            private int _brightness = 0;

            public int X { get; private set; } = x;

            public int Y { get; private set; } = y;

            public int Brightness
            {
                get => _brightness;

                set => SetBrightness(value);
            }

            private void SetBrightness(int value)
            {
                if (value < 0)
                {
                    _brightness = 0;
                }
                else
                {
                    _brightness = value;
                }
            }
        }
    }
}