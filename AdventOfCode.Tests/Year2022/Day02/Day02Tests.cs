﻿namespace AdventOfCode.Tests.Year2022.Day02
{
    using AdventOfCode.Year2022.Day02;

    using NUnit.Framework;

    [TestFixture]
    public class Day02Tests
    {
        private const string InputFilePath = "Year2022/Day02/input.txt";

        private const string ExampleFilePath = "Year2022/Day02/example.txt";

        [Test]
        public void Day02_Part1()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part1().GetPlayerPoints(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(15));
                Assert.That(new Part1().GetPlayerPoints(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(12740));
            }
        }

        [Test]
        public void Day02_Part2()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(new Part2().GetPlayerPoints(FileOperations.GetInputFileLines(ExampleFilePath)), Is.EqualTo(12));
                Assert.That(new Part2().GetPlayerPoints(FileOperations.GetInputFileLines(InputFilePath)), Is.EqualTo(11980));
            }
        }
    }
}