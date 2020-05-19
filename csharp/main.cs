using System;
using System.Diagnostics;

namespace LeetCode
{
    using DynamicProgramming;
    using Test;
    public class main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#.");
            Console.WriteLine("Test value: " + TestClass.Test());
            
            Console.WriteLine("Edit Distance Algorithms Test`s Result is: " + TestEditDistanceAlgorithm());
        }

        private static bool TestEditDistanceAlgorithm()
        {
            if (EditDistance.GetMinDistance(string.Empty, string.Empty) != 0)
            {
                Console.WriteLine("EditDistance.GetMinDistance(string.Empty, string.Empty) is failed");
                return false;
            }
            
            if (EditDistance.GetMinDistance("word1", "wor1d") != 2)
            {
                Console.WriteLine("EditDistance.GetMinDistance(\"word1\", \"wor1d\") is failed");
                return false;
            }
            
            if (EditDistance.GetMinDistance("abcd", "efg") != 4)
            {
                Console.WriteLine("EditDistance.GetMinDistance(\"abcd\", \"efg\") is failed");
                return false;
            }

            return true;
        }
    }
}