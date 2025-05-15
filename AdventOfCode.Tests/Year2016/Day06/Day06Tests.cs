namespace AdventOfCode.Tests.Year2016.Day06
{
    using AdventOfCode.Year2016.Day06;

    using NUnit.Framework;

    [TestFixture]
    public class Day06Tests
    {
        private const string ExampleFilePath = "Year2016/Day06/example.txt";

        private const string InputFilePath = "Year2016/Day06/input.txt";

        [Test]
        public void Day06_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().DecodeMessages([.. FileOperations.GetInputFileLines(ExampleFilePath)]), Is.EqualTo("easter"));

                Assert.That(new Part1().DecodeMessages([.. FileOperations.GetInputFileLines(InputFilePath)]), Is.EqualTo("agmwzecr"));
            }
        }

        [Test]
        public void Day06_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().DecodeMessages([.. FileOperations.GetInputFileLines(InputFilePath)]), Is.EqualTo("owlaxqvq"));
            }
        }
    }
}