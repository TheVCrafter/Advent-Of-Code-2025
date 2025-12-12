using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode_2025
{
    internal class Part1
    {
        public void Solve()
        {
            long count = 0;
            string[] ranges = File.ReadAllText("C:\\Users\\User\\Downloads\\input.txt").Split(",");
            foreach (string s in ranges)
            {
                string[] values = s.Split("-");
                long firstNumber = long.Parse(values[0]);
                long lastNumber = long.Parse(values[1]);
                for (long i = firstNumber; i <= lastNumber; i++)
                {
                    string iString = i.ToString();
                    int lengthOfI = iString.Length;
                    string firstPart = iString.Substring(0, lengthOfI / 2);
                    string secondPart = iString.Substring(lengthOfI / 2);
                    if (firstPart == secondPart)
                    {
                        count += i;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
