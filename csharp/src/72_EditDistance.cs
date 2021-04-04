/*
LeetCode 72. Edit Distance
*/

using System;

namespace LeetCode.Problem_72
{
	public class EditDistance {
		public int MinDistance(string word1, string word2)
		{
			if (string.IsNullOrEmpty(word1) &&
				string.IsNullOrEmpty(word2)) return 0;
			if (string.IsNullOrEmpty(word1)) return word2.Length;
			if (string.IsNullOrEmpty(word2)) return word1.Length;

			return _GetMinEditDistance(word1, word2);
		}

		private int _GetMinEditDistance(string word1, string word2)
		{
			var table = _GenTable(
				rowNum: word1.Length + 1,
				colNum: word2.Length + 1);

			for (int row = 0; row < table.Length; ++row)
				for (int col = 0; col < table[row].Length; ++col)
					if (row == 0)
						table[row][col] = col;
					else if (col == 0)
						table[row][col] = row;
					else if (word1[row-1] == word2[col-1])
						table[row][col] = table[row-1][col-1];
					else
						table[row][col] = 1 + Math.Min(table[row-1][col-1],
							Math.Min(table[row-1][col], table[row][col-1]));
			return table[word1.Length][word2.Length];
		}

		private int[][] _GenTable(int rowNum, int colNum)
		{
			var table = new int[rowNum][];

			for (int row = 0; row < table.Length; ++row)
				table[row] = new int[colNum];
			
			return table;
		}
	}
}