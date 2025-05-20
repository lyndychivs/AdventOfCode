namespace AdventOfCode.Tests.Year2015.Day11
{
    using AdventOfCode.Year2015.Day11;

    using NUnit.Framework;

    [TestFixture]
    public class Day11Tests
    {
        private const string Input = "hxbxwxba";

        [Test]
        public void Day11_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetNextPassword("abcdefgh"), Is.EqualTo("abcdffaa"));

                Assert.That(new Part1().GetNextPassword("ghijklmn"), Is.EqualTo("ghjaabcc"));

                Assert.That(new Part1().GetNextPassword(Input), Is.EqualTo("hxbxxyzz"));
            }
        }

        [Test]
        public void Day11_Part2()
        {
            Assert.That(new Part1().GetNextPassword("hxbxxyzz"), Is.EqualTo("hxcaabcc"));
        }
    }
}