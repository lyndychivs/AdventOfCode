namespace AdventOfCode.Tests.Year2015.Day02
{
    using AdventOfCode.Year2015.Day02;

    using NUnit.Framework;

    [TestFixture]
    public class Day2Tests
    {
        private const string InputFile = "Year2015\\Day02\\input.txt";

        [Test]
        public void Day02_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.GetBoxPerDimensions("2x3x4").RequiredWrappingPaperInSquareFeet, Is.EqualTo(58));
                Assert.That(part1.GetBoxPerDimensions("1x1x10").RequiredWrappingPaperInSquareFeet, Is.EqualTo(43));

                Assert.That(part1.CalculateWrappingPaperForAllBoxes(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(1598415));
            }
        }

        [Test]
        public void Day02_Part2()
        {
            var part2 = new Part2();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part2.GetBoxPerDimensions("2x3x4").RequiredRibbonInFeet, Is.EqualTo(34));
                Assert.That(part2.GetBoxPerDimensions("1x1x10").RequiredRibbonInFeet, Is.EqualTo(14));

                Assert.That(part2.CalculateRibbonForAllBoxes(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(3812909));
            }
        }
    }
}