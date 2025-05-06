namespace AdventOfCode.Tests.Year2015.Day08
{
    using AdventOfCode.Year2015.Day08;

    using NUnit.Framework;

    [TestFixture]
    public class Day8Tests
    {
        private const string ExampleFile = "Year2015\\Day08\\example.txt";

        private const string InputFile = "Year2015\\Day08\\input.txt";

        [Test]
        public void Day8_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.CalculateDifferenceBetweenStrings(FileOperations.GetInputFileLines(ExampleFile)), Is.EqualTo(12));
                Assert.That(part1.CalculateDifferenceBetweenStrings(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(1333));
            }
        }

        [Test]
        public void Day8_Part2()
        {
            var part2 = new Part2();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part2.CalculateDifferenceBetweenStrings(FileOperations.GetInputFileLines(ExampleFile)), Is.EqualTo(19));
                Assert.That(part2.CalculateDifferenceBetweenStrings(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(2046));
            }
        }
    }
}