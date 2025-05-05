namespace AdventOfCode.Tests.Year2015.Day04
{
    using AdventOfCode.Year2015.Day04;

    using NUnit.Framework;

    [TestFixture]
    public class Day4Tests
    {
        [Test]
        public void Day4_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.GetSecretKeyOfHashStartingWithFiveZeros("abcdef"), Is.EqualTo("609043"));
                Assert.That(part1.GetSecretKeyOfHashStartingWithFiveZeros("pqrstuv"), Is.EqualTo("1048970"));

                Assert.That(part1.GetSecretKeyOfHashStartingWithFiveZeros(FileOperations.GetInputFileContent("Year2015\\Day04\\input.txt")), Is.EqualTo("117946"));
            }
        }

        [Test]
        public void Day4_Part2()
        {
            var part2 = new Part2();

            Assert.That(part2.GetSecretKeyOfHashStartingWithSixZeros(FileOperations.GetInputFileContent("Year2015\\Day04\\input.txt")), Is.EqualTo("3938038"));
        }
    }
}