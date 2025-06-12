namespace AdventOfCode.Tests.Year2020.Day02
{
    using AdventOfCode.Year2020.Day02;

    using NUnit.Framework;

    [TestFixture]
    public class Day02Tests
    {
        private const string InputFilePath = "Year2020/Day02/input.txt";

        private const string ExampleFilePath = "Year2020/Day02/example.txt";

        [Test]
        public void Day02_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().CountValidPasswords(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(2));
                Assert.That(new Part1().CountValidPasswords(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(416));
            }
        }

        [Test]
        public void Day02_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().CountValidPasswords(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(1));
                Assert.That(new Part2().CountValidPasswords(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(688));
            }
        }
    }
}