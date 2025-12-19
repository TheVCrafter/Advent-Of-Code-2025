using System;

namespace AdventOfCode_2025
{
    internal class Part1
    {
        public void Solve()
        {
            string[] input = File.ReadAllLines("C:\\Users\\User\\Downloads\\input4.txt");

            List<(long start, long end)> ranges = new List<(long, long)>();
            List<long> ingredientIDs = new List<long>();

            bool parsingRanges = true;
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    parsingRanges = false;
                    continue;
                }

                if (parsingRanges)
                {
                    var parts = line.Split('-');
                    long start = long.Parse(parts[0]);
                    long end = long.Parse(parts[1]);
                    ranges.Add((start, end));
                }
                else
                {
                    ingredientIDs.Add(long.Parse(line));
                }
            }

            int freshCount = 0;
            foreach (var id in ingredientIDs)
            {
                foreach (var range in ranges)
                {
                    if (id >= range.start && id <= range.end)
                    {
                        freshCount++;
                        break;
                    }
                }
            }

            Console.WriteLine($"Number of fresh ingredients: {freshCount}");
        }
    }
}
