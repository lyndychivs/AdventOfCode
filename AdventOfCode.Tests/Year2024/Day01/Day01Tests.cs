namespace AdventOfCode.Tests.Year2024.Day01
{
    using AdventOfCode.Year2024.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string InputFilePath = "Year2024/Day01/input.txt";

        private const string ExampleFilePath = "Year2024/Day01/example.txt";

        [Test]
        public void Day01_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetSumOfDistances(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(11));
                Assert.That(new Part1().GetSumOfDistances(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(3714264));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetDistancesSimilarityScore(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(31));
                Assert.That(new Part2().GetDistancesSimilarityScore(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(18805872));
            }
        }
    }
}