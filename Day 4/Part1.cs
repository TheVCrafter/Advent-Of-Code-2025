using System;

namespace AdventOfCode_2025
{
    internal class Part1
    {
        public void Solve()
        {
            string[] grid = File.ReadAllLines("C:\\Users\\User\\Downloads\\input3.txt");

            int rows = grid.Length;
            int cols = grid[0].Length;
            int accessibleCount = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '@')
                    {
                        int count = 0;
                        for (int di = -1; di <= 1; di++)
                        {
                            for (int dj = -1; dj <= 1; dj++)
                            {
                                if (di == 0 && dj == 0) continue;
                                int ni = i + di;
                                int nj = j + dj;
                                if (ni >= 0 && ni < rows && nj >= 0 && nj < cols)
                                {
                                    if (grid[ni][nj] == '@')
                                        count++;
                                }
                            }
                        }

                        if (count < 4)
                            accessibleCount++;
                    }
                }
            }

            Console.WriteLine($"Accessible rolls: {accessibleCount}");
        }
    }
}
