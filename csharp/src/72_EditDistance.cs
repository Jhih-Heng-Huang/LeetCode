/*
LeetCode 72. Edit Distance
*/

using System.Linq;

namespace LeetCode.Problem_72
{
	public class EditDistance {
		private const int NAN = -1;
		public int MinDistance(string word1, string word2)
		{
			if (word1.Length == 0) return word2.Length;
			if (word2.Length == 0) return word1.Length;

			var table = _GenTable(word1.Length, word2.Length);
			return _FindMinDistance(
				word1,
				word2,
				word1.Length,
				word2.Length,
				table);
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

		private int _FindMinDistance(
			string str1,
			string str2,
			int str1Length,
			int str2Length,
			int[][] table)
		{
			if (table[str1Length][str2Length] != NAN)
				return table[str1Length][str2Length];

			var word1 = str1[str1Length-1];
			var word2 = str2[str2Length-1];

			if (word1 == word2)
				table[str1Length][str2Length] = _FindMinDistance(str1, str2, str1Length-1, str2Length-1, table);
			else
				table[str1Length][str2Length] = new int[]
				{
					1 + _FindMinDistance(str1, str2, str1Length-1, str2Length, table),
					1 + _FindMinDistance(str1, str2, str1Length, str2Length-1, table),
					1 + _FindMinDistance(str1, str2, str1Length-1, str2Length-1, table),
				}.Min();
			return table[str1Length][str2Length];
		}
	}
}