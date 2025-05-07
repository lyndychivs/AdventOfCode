namespace AdventOfCode.Tests.Year2015.Day04
{
    using AdventOfCode.Year2015.Day04;

    using NUnit.Framework;

    [TestFixture]
    public class Day04Tests
    {
        private const string InputFile = "Year2015\\Day04\\input.txt";

        [Test]
        public void Day04_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.GetSecretKeyOfHashStartingWithFiveZeros("abcdef"), Is.EqualTo("609043"));
                Assert.That(part1.GetSecretKeyOfHashStartingWithFiveZeros("pqrstuv"), Is.EqualTo("1048970"));

                Assert.That(part1.GetSecretKeyOfHashStartingWithFiveZeros(FileOperations.GetInputFileContent(InputFile)), Is.EqualTo("117946"));
            }
        }

        [Test]
        public void Day04_Part2()
        {
            Assert.That(new Part2().GetSecretKeyOfHashStartingWithSixZeros(FileOperations.GetInputFileContent(InputFile)), Is.EqualTo("3938038"));
        }
    }
}