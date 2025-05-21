namespace AdventOfCode.Tests.Year2015.Day14
{
    using AdventOfCode.Year2015.Day14;

    using NUnit.Framework;

    [TestFixture]
    public class Day14Tests
    {
        private const string InputFilePath = "Year2015/Day14/input.txt";

        private const string ExampleFilePath = "Year2015/Day14/example.txt";

        [Test]
        public void Day14_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetWinningReindeerDistance(FileOperations.GetInputFileLines(ExampleFilePath), 1000), Is.EqualTo(1120));

                Assert.That(new Part1().GetWinningReindeerDistance(FileOperations.GetInputFileLines(InputFilePath), 2503), Is.EqualTo(2640));
            }
        }

        [Test]
        public void Day14_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetWinningReindeerPoints(FileOperations.GetInputFileLines(ExampleFilePath), 1000), Is.EqualTo(689));

                Assert.That(new Part2().GetWinningReindeerPoints(FileOperations.GetInputFileLines(InputFilePath), 2503), Is.EqualTo(1102));
            }
        }
    }
}