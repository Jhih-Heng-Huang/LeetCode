/*
72. Edit Distance
*/

using System.Linq;

public class EditDistance {
    public int MinDistance(string word1, string word2)
    {
		if (string.IsNullOrEmpty(word1) && !string.IsNullOrEmpty(word2))
			return word2.Length;
		if (!string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
			return word1.Length;
		if (string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
			return 0;
		
		return _MinDistance(word1, word2);
    }

	private int[][] _GenTable(int numRows, int numCols) {
		var table = new int[numRows][];

		for (int i = 0; i < table.Length; ++i) {
			table[i] = new int[numCols];
		}

		table[0][0] = 0;

		return table;
	}

	private int _MinDistance(string str1, string str2) {
		var dp = _GenTable(str1.Length + 1, str2.Length + 1);

		for (int i = 0; i < dp.Length; ++i)
			for (int j = 0; j < dp[i].Length; ++j)
				if (i == 0) dp[i][j] = j;
				else if (j == 0) dp[i][j] = i;
				else if (str1[i-1] == str2[j-1]) dp[i][j] = dp[i-1][j-1];
				else dp[i][j] = 1 +
					new int[] {
						dp[i-1][j],
						dp[i-1][j-1],
						dp[i][j-1],
					}.Min();
	
		return dp.Last().Last();
	}
}