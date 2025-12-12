using System;
using System.IO;

namespace AdventOfCode_2025
{
    internal class Part1
    {
        public void Solve()
        {
            int totalJolts = 0;
            string[] batteryBanks = File.ReadAllLines("C:\\Users\\User\\Downloads\\input2.txt");

            foreach (string bank in batteryBanks)
            {
                int maxJolt = 0;
                for (int i = 0; i < bank.Length - 1; i++)
                {
                    for (int j = i + 1; j < bank.Length; j++)
                    {
                        int jolts = int.Parse(bank[i].ToString() + bank[j].ToString());
                        if (jolts > maxJolt)
                            maxJolt = jolts;
                    }
                }
                totalJolts += maxJolt;
            }

            Console.WriteLine(totalJolts);
        }
    }
}