using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace AdventOfCode_2025
{
    internal class Part2
    {
        public void Solve()
        {
            BigInteger totalJolts = 0;
            int k = 12;

            string[] batteryBanks = File.ReadAllLines("C:\\Users\\User\\Downloads\\input2.txt");

            foreach (string bank in batteryBanks)
            {
                int n = bank.Length;
                Stack<char> stack = new Stack<char>();

                for (int i = 0; i < n; i++)
                {
                    char digit = bank[i];

                    while (stack.Count > 0 &&
                           stack.Peek() < digit &&
                           stack.Count + (n - i - 1) >= k)
                    {
                        stack.Pop();
                    }

                    if (stack.Count < k)
                        stack.Push(digit);
                }
                char[] largestDigits = stack.ToArray();
                Array.Reverse(largestDigits);
                BigInteger maxJolt = BigInteger.Parse(new string(largestDigits));

                totalJolts += maxJolt;
            }

            Console.WriteLine($"Total output joltage: {totalJolts}");
        }
    }
}