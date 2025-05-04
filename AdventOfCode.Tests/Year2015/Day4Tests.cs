namespace AdventOfCode.Tests.Year2015
{
    using AdventOfCode.Year2015;

    using NUnit.Framework;

    [TestFixture]
    public class Day4Tests
    {
        private const string Input = "ckczppom";

        [Test]
        public void Day4_A()
        {
            var day4 = new Day4();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(day4.GetSecretKeyOfHashStartingWithFiveZeros("abcdef"), Is.EqualTo("609043"));
                Assert.That(day4.GetSecretKeyOfHashStartingWithFiveZeros("pqrstuv"), Is.EqualTo("1048970"));

                Assert.That(day4.GetSecretKeyOfHashStartingWithFiveZeros(Input), Is.EqualTo("117946"));
            }
        }

        [Test]
        public void Day4_B()
        {
            var day4 = new Day4();

            Assert.That(day4.GetSecretKeyOfHashStartingWithSixZeros(Input), Is.EqualTo("3938038"));
        }
    }
}