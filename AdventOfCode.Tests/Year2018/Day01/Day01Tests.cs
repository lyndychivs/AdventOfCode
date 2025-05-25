namespace AdventOfCode.Tests.Year2018.Day01
{
    using AdventOfCode.Year2018.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string InputFilePath = "Year2018/Day01/input.txt";

        [Test]
        public void Day01_Part1()
        {
            string[] example1 = ["+1", "+1", "+1"];
            string[] example2 = ["+1", "+1", "-2"];
            string[] example3 = ["-1", "-2", "-3"];

            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetFrequency(example1), Is.EqualTo(3));
                Assert.That(new Part1().GetFrequency(example2), Is.EqualTo(0));
                Assert.That(new Part1().GetFrequency(example3), Is.EqualTo(-6));

                Assert.That(new Part1().GetFrequency(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(433));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            Assert.That(new Part2().GetFrequency(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(256));
        }
    }
}