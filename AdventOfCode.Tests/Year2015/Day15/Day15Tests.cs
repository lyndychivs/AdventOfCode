namespace AdventOfCode.Tests.Year2015.Day15
{
    using AdventOfCode.Year2015.Day15;

    using NUnit.Framework;

    [TestFixture]
    public class Day15Tests
    {
        private const string InputFilePath = "Year2015/Day15/input.txt";

        private const string ExampleFilePath = "Year2015/Day15/example.txt";

        [Test]
        public void Day15_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetHighestScoringCookieNumber(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(62842880));

                Assert.That(new Part1().GetHighestScoringCookieNumber(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(21367368));
            }
        }

        [Test]
        public void Day15_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetHighestScoringCookieNumberUnder500Calories(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(57600000));

                Assert.That(new Part2().GetHighestScoringCookieNumberUnder500Calories(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(1766400));
            }
        }
    }
}