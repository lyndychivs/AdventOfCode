namespace AdventOfCode.Tests.Year2015.Day13
{
    using AdventOfCode.Year2015.Day13;

    using NUnit.Framework;

    [TestFixture]
    public class Day13Tests
    {
        private const string InputFilePath = "Year2015/Day13/input.txt";

        private const string ExampleFilePath = "Year2015/Day13/example.txt";

        [Test]
        public void Day13_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetTotalChangeInHappiness(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(330));

                Assert.That(new Part1().GetTotalChangeInHappiness(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(733));
            }
        }

        [Test]
        public void Day13_Part2()
        {
            Assert.That(new Part2().GetTotalChangeInHappiness(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(725));
        }
    }
}