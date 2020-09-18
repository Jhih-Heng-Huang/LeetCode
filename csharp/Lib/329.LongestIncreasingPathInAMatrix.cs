/*
329. Longest Increasing Path in a Matrix
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class LongestIncreasingPathInAMatrix {
    public int LongestIncreasingPath(int[][] matrix) 
    {
		if (matrix == null || matrix.Length == 0)
			return 0;
		
		return _FindLongestPath(matrix);
    }

	private int _FindLongestPath(int[][] matrix) {
		var dp = _GenTable(matrix.Length, matrix[0].Length);

		var max = 0;
		for (int i = 0; i < dp.Length; ++i)
			for (int j = 0; j < dp[i].Length; ++j)
				if (dp[i][j] == -1)
					max = Math.Max(max, _FindLongestPath(i, j, matrix, dp));
		return max;
	}

	private int _FindLongestPath(int i, int j,
		int[][] matrix, int[][] dp)
	{
		if (dp[i][j] != -1)
			return dp[i][j];

		var len = 1;
		var paths = _FindPath(i, j, matrix);

		foreach (var path in paths) {
			var x = path[0];
			var y = path[1];

			var subLen = _FindLongestPath(x, y, matrix, dp);
			len = Math.Max(len, 1+subLen);
		}

		dp[i][j] = len;
		return len;
	}

	private int[][] _GenTable(int numRows, int numCols) {
		var table = new int[numRows][];

		for (int i = 0; i < numRows; ++i) {
			table[i] = new int[numCols];
			for (int j = 0; j < numCols; ++j)
				table[i][j] = -1;
		}

		return table;
	}

	private int[][] _FindPath(int i, int j, int[][] matrix) {
		var paths = new List<int[]>();
		var val = matrix[i][j];

		if (i > 0 && val < matrix[i-1][j])
			paths.Add(new int[]{i-1, j});

		if (j > 0 && val < matrix[i][j-1])
			paths.Add(new int[]{i, j-1});

		if (i < matrix.Length-1 && val < matrix[i+1][j])
			paths.Add(new int[]{i+1, j});

		if (j < matrix[i].Length-1 && val < matrix[i][j+1])
			paths.Add(new int[]{i, j+1});

		return paths.ToArray();
	}
}