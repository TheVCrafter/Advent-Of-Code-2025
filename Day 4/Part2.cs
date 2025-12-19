using System;
using System.IO;

namespace AdventOfCode_2025
{
    internal class Part2
    {
        public void Solve()
        {
            string[] inputGrid = File.ReadAllLines("C:\\Users\\User\\Downloads\\input3.txt");

            int rows = inputGrid.Length;
            int cols = inputGrid[0].Length;

            char[,] grid = new char[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    grid[i, j] = inputGrid[i][j];

            int totalRemoved = 0;
            bool removedSomething;

            do
            {
                removedSomething = false;
                bool[,] toRemove = new bool[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == '@')
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
                                        if (grid[ni, nj] == '@')
                                            count++;
                                    }
                                }
                            }
                            if (count < 4)
                                toRemove[i, j] = true;
                        }
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (toRemove[i, j])
                        {
                            grid[i, j] = '.';
                            totalRemoved++;
                            removedSomething = true;
                        }
                    }
                }

            } while (removedSomething);

            Console.WriteLine($"Total rolls removed: {totalRemoved}");
        }
    }
}
