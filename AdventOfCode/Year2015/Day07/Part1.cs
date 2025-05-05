namespace AdventOfCode.Year2015.Day07
{
    using System;
    using System.Collections.Generic;

    public class Part1
    {
        private readonly List<CircuitAction> _circuitActions = [];

        private readonly Dictionary<string, ushort> _wires = [];

        public ushort GetWireValue(string circuit, string wireKey)
        {
            string[] circuitActions = circuit.Split([ Environment.NewLine ], StringSplitOptions.RemoveEmptyEntries);

            foreach (string action in circuitActions)
            {
                _circuitActions.Add(new CircuitAction(action));
            }

            while (!IsWireReady(wireKey))
            {
                foreach (CircuitAction action in _circuitActions)
                {
                    ExecuteCircuitAction(action);
                }
            }

            return _wires[wireKey];
        }

        private bool IsWireReady(string wireKey)
        {
            return _wires.ContainsKey(wireKey) && _wires[wireKey] != 0;
        }

        private void ExecuteCircuitAction(CircuitAction action)
        {
            if (action.Command.Contains(" AND "))
            {
                string[] parts = action.Command.Split(" AND ");

                bool isLeftReady = TryGetValue(parts[0].Trim(), out ushort leftValue);
                bool isRightReady = TryGetValue(parts[1].Trim(), out ushort rightValue);

                if (isLeftReady && isRightReady)
                {
                    _wires[action.Wire] = (ushort)(leftValue & rightValue);
                }

                return;
            }

            if (action.Command.Contains(" OR "))
            {
                string[] parts = action.Command.Split(" OR ");

                bool isLeftReady = TryGetValue(parts[0].Trim(), out ushort leftValue);
                bool isRightReady = TryGetValue(parts[1].Trim(), out ushort rightValue);

                if (isLeftReady && isRightReady)
                {
                    _wires[action.Wire] = (ushort)(leftValue | rightValue);
                }

                return;
            }

            if (action.Command.Contains(" LSHIFT "))
            {
                string[] parts = action.Command.Split(" LSHIFT ");

                bool isLeftReady = TryGetValue(parts[0].Trim(), out ushort leftValue);
                bool isRightReady = TryGetValue(parts[1].Trim(), out ushort rightValue);

                if (isLeftReady && isRightReady)
                {
                    _wires[action.Wire] = (ushort)(leftValue << rightValue);
                }

                return;
            }

            if (action.Command.Contains(" RSHIFT "))
            {
                string[] parts = action.Command.Split(" RSHIFT ");

                bool isLeftReady = TryGetValue(parts[0].Trim(), out ushort leftValue);
                bool isRightReady = TryGetValue(parts[1].Trim(), out ushort rightValue);

                if (isLeftReady && isRightReady)
                {
                    _wires[action.Wire] = (ushort)(leftValue >> rightValue);
                }

                return;
            }

            if (action.Command.Contains("NOT"))
            {
                bool isReady = TryGetValue(action.Command.Replace("NOT ", string.Empty), out ushort notValue);

                if (isReady)
                {
                    _wires[action.Wire] = (ushort)~notValue;
                }

                return;
            }

            if (TryGetValue(action.Command, out ushort value))
            {
                _wires[action.Wire] = value;
            }
        }

        private bool TryGetValue(string input, out ushort output)
        {
            if (ushort.TryParse(input, out output))
            {
                return true;
            }

            if (_wires.TryGetValue(input, out output))
            {
                return true;
            }

            return false;
        }

        private class CircuitAction
        {
            public string Wire { get; private set; }

            public string Command { get; private set; }

            public CircuitAction(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new ArgumentException("CircuitAction cannot be null or whitespace.", nameof(input));
                }

                Wire = input.Split(" -> ")[1].Trim();
                Command = input.Replace($" -> {Wire}", string.Empty).Trim();
            }
        }
    }
}