using System;
using System.IO;

namespace AdventOfCode_2025
{
    internal class Part2
    {
        public void Solve()
        {
            string[] input = File.ReadAllLines("C:\\Users\\User\\Downloads\\input4.txt");

            List<(long start, long end)> ranges = new List<(long, long)>();

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                if (!line.Contains('-'))
                    continue;

                var parts = line.Split('-');
                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);
                ranges.Add((start, end));
            }
            ranges.Sort((a, b) => a.start.CompareTo(b.start));

            List<(long start, long end)> merged = new List<(long, long)>();
            foreach (var range in ranges)
            {
                if (merged.Count == 0 || range.start > merged[^1].end + 1)
                {
                    merged.Add(range);
                }
                else
                {
                    merged[^1] = (merged[^1].start, Math.Max(merged[^1].end, range.end));
                }
            }

            long totalFresh = 0;
            foreach (var range in merged)
            {
                totalFresh += range.end - range.start + 1;
            }

            Console.WriteLine($"Total fresh ingredient IDs: {totalFresh}");
        }
    }
}
