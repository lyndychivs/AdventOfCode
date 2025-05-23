﻿namespace AdventOfCode.Tests
{
    using System.Collections.Generic;
    using System.IO;

    internal class FileOperations
    {
        private static readonly object _lock = new();

        public static string GetInputFileContent(string path)
        {
            lock (_lock)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), path);

                if (File.Exists(filePath) == false)
                {
                    throw new FileNotFoundException($"File not found: {filePath}");
                }

                return File.ReadAllText(filePath).Trim();
            }
        }

        public static IEnumerable<string> GetInputFileLines(string path)
        {
            lock (_lock)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), path);

                if (File.Exists(filePath) == false)
                {
                    throw new FileNotFoundException($"File not found: {filePath}");
                }

                return File.ReadLines(filePath);
            }
        }
    }
}