namespace AdventOfCode.Tests.Year2015.Day05
{
    using AdventOfCode.Year2015.Day05;

    using NUnit.Framework;

    [TestFixture]
    public class Day5Tests
    {
        private const string InputFile = "Year2015\\Day05\\input.txt";

        [Test]
        public void Day05_Part1()
        {
            var part1 = new Part1();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part1.IsNice("ugknbfddgicrmopn"), Is.True);
                Assert.That(part1.IsNice("aaa"), Is.True);
                Assert.That(part1.IsNice("jchzalrnumimnmhp"), Is.False);
                Assert.That(part1.IsNice("haegwjzuvuyypxyu"), Is.False);
                Assert.That(part1.IsNice("dvszwmarrgswjxmb"), Is.False);

                Assert.That(part1.GetNiceCount(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(255));
            }
        }

        [Test]
        public void Day05_Part2()
        {
            var part2 = new Part2();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(part2.IsNice("qjhvhtzxzqqjkmpb"), Is.True);
                Assert.That(part2.IsNice("xxyxx"), Is.True);
                Assert.That(part2.IsNice("uurcxstgmygtbstg"), Is.False);
                Assert.That(part2.IsNice("ieodomkazucvgmuy"), Is.False);

                Assert.That(part2.GetNiceCount(FileOperations.GetInputFileLines(InputFile)), Is.EqualTo(55));
            }
        }
    }
}