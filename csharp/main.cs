using System;

namespace LeetCode
{
    using DynamicProgramming;
    public class main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#.");
            Console.WriteLine("Edit Distance: " + EditDistance.GetMinDistance(string.Empty, string.Empty));
        }
    }
}