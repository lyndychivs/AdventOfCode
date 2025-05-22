namespace AdventOfCode.Tests.Year2017.Day01
{
    using AdventOfCode.Year2017.Day01;

    using NUnit.Framework;

    [TestFixture]
    public class Day01Tests
    {
        private const string InputFilePath = "Year2017/Day01/Input.txt";

        [Test]
        public void Day01_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().SolveCaptcha("1122"), Is.EqualTo(3));
                Assert.That(new Part1().SolveCaptcha("1111"), Is.EqualTo(4));
                Assert.That(new Part1().SolveCaptcha("1234"), Is.EqualTo(0));
                Assert.That(new Part1().SolveCaptcha("91212129"), Is.EqualTo(9));

                Assert.That(new Part1().SolveCaptcha(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo(997));
            }
        }

        [Test]
        public void Day01_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().SolveCaptcha("1212"), Is.EqualTo(6));
                Assert.That(new Part2().SolveCaptcha("1221"), Is.EqualTo(0));
                Assert.That(new Part2().SolveCaptcha("123425"), Is.EqualTo(4));
                Assert.That(new Part2().SolveCaptcha("123123"), Is.EqualTo(12));
                Assert.That(new Part2().SolveCaptcha("12131415"), Is.EqualTo(4));

                Assert.That(new Part2().SolveCaptcha(FileOperations.GetInputFileContent(InputFilePath)), Is.EqualTo(1358));
            }
        }
    }
}