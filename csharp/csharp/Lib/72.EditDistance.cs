/*
72. Edit Distance
*/

using System;
using System.Linq;

public class EditDistance {
    public int MinDistance(string word1, string word2)
    {
        if (string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
            return 0;
        if (string.IsNullOrEmpty(word1)) return word2.Length;
        if (string.IsNullOrEmpty(word2)) return word1.Length;


        return _GetMinDistance(word1, word2);
    }

    private int _GetMinDistance(string word1, string word2)
    {
        var table = _GenTable(word1.Length, word2.Length);

        for (int i = 0; i < table.Length; ++i)
            for (int j = 0; j < table[i].Length; ++j)
            {
                int dist = 0;
                if (i == 0) dist = j;
                else if (j == 0) dist = i;
                else if (word1[i - 1] == word2[j - 1])
                    dist = table[i - 1][j - 1];
                else
                    dist = 1 + new int[]
                    {
                        table[i-1][j],
                        table[i-1][j-1],
                        table[i][j-1],
                    }.Min();
                table[i][j] = dist;
            }

        return table[word1.Length][word2.Length];
    }

    private int[][] _GenTable(int word1Length, int word2Length)
    {
        var table = new int[word1Length + 1][];
        for (int i = 0; i < table.Length; ++i)
            table[i] = new int[word2Length + 1];

        return table;
    }
}