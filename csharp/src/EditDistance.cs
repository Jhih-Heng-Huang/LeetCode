using System;
using System.Text;

namespace LeetCode.DynamicProgramming
{
    using Extensions;
    public static class EditDistance
    {
        public static int GetMinDistance(string str1, string str2)
        {
            return GetMinDistanceByDP(new StringBuilder(str1), new StringBuilder(str2));
        }

        // DFS
        private static int GetMinDistanceByDFS(StringBuilder str1, StringBuilder str2)
        {
            var len1 = str1.Length;
            var len2 = str2.Length;
            if (len1 == 0)
                return len2;
            
            if (len2 == 0)
                return len1;

            if (str1[len1 - 1] == str2[len2 - 1])
                return GetMinDistanceByDFS(str1.Remove(len1 - 1, 1), str2.Remove(len2 - 1, 1));
            
            return 1 + MathExtensions.Min(
                GetMinDistanceByDFS(str1, str2.Remove(len2 - 1, 1)),
                GetMinDistanceByDFS(str1.Remove(len1 - 1, 1), str2),
                GetMinDistanceByDFS(str1.Remove(len1 - 1, 1), str2.Remove(len2 - 1, 1)));
        }

        private static int GetMinDistanceByDP(StringBuilder str1, StringBuilder str2)
        {
            var len1 = str1.Length;
            var len2 = str2.Length;
            if (len1 == 0)
                return len2;
            
            if (len2 == 0)
                return len1;
            
            var table = new int[len1 + 1, len2 + 1];
            for (int i = 0; i <= len1; ++i)
                for (int j = 0; j <= len2; ++j)
                    if (i == 0)
                        table[i, j] = j;
                    else if (j == 0)
                        table[i, j] = i;
                    else if (str1[i - 1] == str2[j - 1])
                        table[i, j] = table[i-1, j-1];
                    else
                        table[i, j] = 1 + MathExtensions.Min(table[i-1, j], table[i, j-1], table[i-1, j-1]);

            return table[len1, len2];
        }
    }
}