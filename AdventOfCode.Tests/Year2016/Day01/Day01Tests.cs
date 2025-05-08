namespace AdventOfCode.Tests.Year2016.Day01
{
    using AdventOfCode.Year2016.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string InputFilePath = "Year2016/Day01/input.txt";

        [Test]
        public void Day01_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.GetDistanceFromPosition("R2, L3"), Is.EqualTo(5));
                Assert.That(part1.GetDistanceFromPosition("R2, R2, R2"), Is.EqualTo(2));
                Assert.That(part1.GetDistanceFromPosition("R5, L5, R5, R3"), Is.EqualTo(12));

                Assert.That(part1.GetDistanceFromPosition(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo(278));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            var part2 = new Part2();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part2.GetDistanceFromFirstPositionVisitedTwice("R8, R4, R4, R8"), Is.EqualTo(4));

                Assert.That(part2.GetDistanceFromFirstPositionVisitedTwice(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo(161));
            }
        }
    }
}