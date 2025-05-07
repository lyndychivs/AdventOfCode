namespace AdventOfCode.Tests.Year2015.Day03
{
    using AdventOfCode.Year2015.Day03;

    using NUnit.Framework;

    [TestFixture]
    public class Day03Tests
    {
        private const string InputFile = "Year2015\\Day03\\input.txt";

        [Test]
        public void Day03_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.CalulateHousesVisited(">"), Is.EqualTo(2));
                Assert.That(part1.CalulateHousesVisited("^>v<"), Is.EqualTo(4));
                Assert.That(part1.CalulateHousesVisited("^v^v^v^v^v"), Is.EqualTo(2));

                Assert.That(part1.CalulateHousesVisited(FileOperations.GetInputFileContent(InputFile)), Is.EqualTo(2592));
            }
        }

        [Test]
        public void Day03_Part2()
        {
            var part2 = new Part2();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part2.CalulateHousesVisitedBySantaAndRobot("^v"), Is.EqualTo(3));
                Assert.That(part2.CalulateHousesVisitedBySantaAndRobot("^>v<"), Is.EqualTo(3));
                Assert.That(part2.CalulateHousesVisitedBySantaAndRobot("^v^v^v^v^v"), Is.EqualTo(11));

                Assert.That(part2.CalulateHousesVisitedBySantaAndRobot(FileOperations.GetInputFileContent(InputFile)), Is.EqualTo(2360));
            }
        }
    }
}