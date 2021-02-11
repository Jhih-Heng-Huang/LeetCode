using System;

namespace LeetCode.Extensions
{
    public static class MathExtensions {
        public static int Min(params int[] values) {
            int min = int.MaxValue;
            for (int i = 0; i < values.Length; ++i)
            {
                min = Math.Min(values[i], min);
            }

            return min;
        }
    }
}