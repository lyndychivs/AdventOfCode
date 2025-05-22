namespace AdventOfCode.Year2015.Day15
{
    using System.Collections.Generic;

    public class Part1
    {
        public int GetHighestScoringCookieNumber(IEnumerable<string> inputs)
        {
            List<Ingredient> ingredients = GetIngredients(inputs);

            return CalculateHighestScore(ingredients);
        }

        private List<Ingredient> GetIngredients(IEnumerable<string> inputs)
        {
            var ingredients = new List<Ingredient>();

            foreach (string input in inputs)
            {
                string[] parts = input.Replace(",", string.Empty)
                    .Split(' ');

                ingredients.Add(new Ingredient(
                    parts[0],
                    int.Parse(parts[2]),
                    int.Parse(parts[4]),
                    int.Parse(parts[6]),
                    int.Parse(parts[8]),
                    int.Parse(parts[10])));
            }

            return ingredients;
        }

        private int CalculateHighestScore(List<Ingredient> ingredients)
        {
            int highestScore = 0;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100 - i; j++)
                {
                    for (int k = 0; k < 100 - i - j; k++)
                    {
                        int l = 100 - i - j - k;

                        int totalScore = GetTotalScore(ingredients, i, j, k, l);
                        if (totalScore > highestScore)
                        {
                            highestScore = totalScore;
                        }
                    }
                }
            }

            return highestScore;
        }

        private int GetTotalScore(List<Ingredient> ingredients, int i, int j, int k, int l)
        {
            int totalCapacity = 0;
            int totalDurability = 0;
            int totalFlavor = 0;
            int totalTexture = 0;

            for (int m = 0; m < ingredients.Count; m++)
            {
                IngredientScore score = ingredients[m].GetScore(GetSpoons(m, i, j, k, l, ingredients.Count));
                totalCapacity += score.Capacity;
                totalDurability += score.Durability;
                totalFlavor += score.Flavor;
                totalTexture += score.Texture;
            }

            return GetMultiplyPropertiesResult(totalCapacity, totalDurability, totalFlavor, totalTexture);
        }

        private int GetSpoons(int m, int i, int j, int k, int l, int ingredientsCount)
        {
            if (ingredientsCount == 2)
            {
                if (m == 0)
                {
                    return i + k;
                }

                return j + l;
            }

            if (m == 0)
            {
                return i;
            }

            if (m == 1)
            {
                return j;
            }

            if (m == 2)
            {
                return k;
            }

            if (m == 3)
            {
                return l;
            }

            return 0;
        }

        private int GetMultiplyPropertiesResult(int totalCapacity, int totalDurability, int totalFlavor, int totalTexture)
        {
            if (totalCapacity < 0)
            {
                totalCapacity = 0;
            }

            if (totalDurability < 0)
            {
                totalDurability = 0;
            }

            if (totalFlavor < 0)
            {
                totalFlavor = 0;
            }

            if (totalTexture < 0)
            {
                totalTexture = 0;
            }

            return totalCapacity * totalDurability * totalFlavor * totalTexture;
        }

        private class Ingredient(
            string name,
            int capacity,
            int durability,
            int flavor,
            int texture,
            int calories)
        {
            public string Name = name;

            private readonly int _capacity = capacity;
            private readonly int _durability = durability;
            private readonly int _flavor = flavor;
            private readonly int _texture = texture;
            private readonly int _calories = calories;

            public IngredientScore GetScore(int teaspoons)
            {
                return new IngredientScore()
                {
                    Capacity = _capacity * teaspoons,
                    Durability = _durability * teaspoons,
                    Flavor = _flavor * teaspoons,
                    Texture = _texture * teaspoons
                };
            }
        }

        private class IngredientScore
        {
            public int Capacity { get; set; }
            public int Durability { get; set; }
            public int Flavor { get; set; }
            public int Texture { get; set; }
        }
    }
}