namespace AdventOfCode.Tests.Year2015.Day09
{
    using AdventOfCode.Year2015.Day09;

    using NUnit.Framework;

    [TestFixture]
    public class Day09Tests
    {
        private const string InputFile = "Year2015/Day09/input.txt";

        private const string ExampleFile = "Year2015/Day09/example.txt";

        [Test]
        public void Day09_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().CalculateShortestRouteDistance(FileOperations.GetInputFileLines(ExampleFile)), Is.EqualTo(0));

                Assert.That(new Part1().CalculateShortestRouteDistance(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(0));
            }
        }
    }
}