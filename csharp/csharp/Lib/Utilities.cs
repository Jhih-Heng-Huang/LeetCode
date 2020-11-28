using System;

namespace LeetCode.Extensions
{
    public static class Utilities
    {
        public static void Show(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); ++i)
            {
                for (int j = 0; j < table.GetLength(1); ++j)
                {
                    Console.Write("\t {0}", table[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}