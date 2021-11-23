/*
LeetCode 72. Edit Distance
*/

using System;
using System.Linq;

namespace LeetCode.Problem_72
{
	public class EditDistance {
		private const int NAN = -1;
		public int MinDistance(string word1, string word2)
		{
			var table = _GenTable(word1.Length, word2.Length);

			for (int len1 = 1; len1 <= word1.Length; ++len1)
				for (int len2 = 1; len2 <= word2.Length; ++len2)
				{
					var val1 = word1[len1-1];
					var val2 = word2[len2-1];

					
					table[len1][len2] = (val1 == val2)?
						table[len1-1][len2-1] :
						1 + Math.Min(
							table[len1-1][len2],
							Math.Min(
								table[len1][len2-1],
								table[len1-1][len2-1]
							)
						);
				}

			return table[word1.Length][word2.Length];
		}

		private int[][] _GenTable(
			int str1Length,
			int str2Length)
		{
			var table = new int[str1Length+1][];
			for (int row = 0; row < table.Length; ++row)
			{
				table[row] = new int[str2Length+1];
				for (int col = 0; col < table[row].Length; ++col)
					table[row][col] = NAN;
			}

			for (int row = 0; row < table.Length; ++row)
				table[row][0] = row;
			for (int col = 0; col < table[0].Length; ++col)
				table[0][col] = col;
			return table;
		}
	}
}