namespace AdventOfCode.Year2015.Day12
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Part2
    {
        public int CalculateSumOfJsonExcludingRed(string input)
        {
            string filtered = FilterRed(input);
            return CalculateSumOfJson(filtered);
        }

        private string FilterRed(string input)
        {
            JToken? rootJToken = JsonConvert.DeserializeObject<JToken>(input);
            List<JToken> tokensToRemove = GetTokensToRemove(rootJToken!);

            foreach (JToken token in tokensToRemove)
            {
                try
                {
                    if (token.Parent is JProperty)
                    {
                        token.Parent.Remove();
                    }
                    else
                    {
                        token.Remove();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message.Contains("The parent is missing.")
                        && tokensToRemove.Count == 1)
                    {
                        return string.Empty;
                    }
                }
            }

            return JsonConvert.SerializeObject(rootJToken);
        }

        private List<JToken> GetTokensToRemove(JToken jToken)
        {
            var tokensToRemove = new List<JToken>();

            if (jToken is JProperty property && property.Value.ToString() == "red")
            {
                tokensToRemove.Add(property.Parent!);
            }

            foreach (JToken subJToken in jToken)
            {
                tokensToRemove.AddRange(GetTokensToRemove(subJToken));
            }

            return tokensToRemove;
        }

        private int CalculateSumOfJson(string input)
        {
            int sum = 0;

            bool isNegative = false;
            string foundNumber = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' && char.IsDigit(input[i + 1]))
                {
                    isNegative = true;

                    continue;
                }

                if (char.IsDigit(input[i]))
                {
                    foundNumber += input[i];

                    continue;
                }

                if (foundNumber.Length > 0)
                {
                    if (isNegative)
                    {
                        sum -= int.Parse(foundNumber);
                    }
                    else
                    {
                        sum += int.Parse(foundNumber);
                    }

                    foundNumber = string.Empty;
                    isNegative = false;
                }
            }

            return sum;
        }
    }
}