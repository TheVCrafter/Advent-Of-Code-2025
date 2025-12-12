using System;
using System.IO;

namespace AdventOfCode_2025
{
    internal class Part2
    {
        public void Solve()
        {
            long count = 0;

            string[] ranges = File.ReadAllText("C:\\Users\\User\\Downloads\\input.txt")
                                  .Split(",");

            foreach (string s in ranges)
            {
                string[] values = s.Split("-");
                long firstNumber = long.Parse(values[0]);
                long lastNumber = long.Parse(values[1]);

                for (long id = firstNumber; id <= lastNumber; id++)
                {
                    if (IsInvalid(id))
                    {
                        count += id;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private bool IsInvalid(long id)
        {
            string s = id.ToString();
            int len = s.Length;
            for (int parts = 2; parts <= len; parts++)
            {
                if (len % parts != 0)
                    continue;

                int chunkSize = len / parts;

                string chunk = s.Substring(0, chunkSize);

                bool allMatch = true;

                for (int i = 1; i < parts; i++)
                {
                    if (s.Substring(i * chunkSize, chunkSize) != chunk)
                    {
                        allMatch = false;
                        break;
                    }
                }

                if (allMatch)
                    return true;
            }

            return false;
        }
    }
}
