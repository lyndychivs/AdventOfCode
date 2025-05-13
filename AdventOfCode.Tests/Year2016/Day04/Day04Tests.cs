namespace AdventOfCode.Tests.Year2016.Day04
{
    using AdventOfCode.Year2016.Day04;

    using NUnit.Framework;

    [TestFixture]
    public class Day04Tests
    {
        private const string ExampleFilePath = "Year2016/Day04/example.txt";

        private const string InputFilePath = "Year2016/Day04/input.txt";

        [Test]
        public void Day04_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetSumOfRealRoomSectorIds(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(1514));

                Assert.That(new Part1().GetSumOfRealRoomSectorIds(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(245102));
            }
        }

        [Test]
        public void Day04_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetSectorIdOfNorthPoleRoom(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(324));
            }
        }
    }
}