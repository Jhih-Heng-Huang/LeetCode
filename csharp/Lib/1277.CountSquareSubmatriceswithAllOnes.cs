/*
1277. Count Square Submatrices with All Ones
*/

using System;
using System.Linq;

public class CountSquareSubmatriceswithAllOnes {
    public int CountSquares(int[][] matrix) {
		if (matrix == null || matrix.Length == 0)
			return 0;
		

		return _CountSquare(matrix);
    }

	private int _CountSquare(int[][] matrix) {
		var dp = _GenTable(matrix.Length, matrix[0].Length);

		var count = 0;
		for (int i = 0; i < dp.Length; ++i)
			for (int j = 0; j < dp[i].Length; ++j) {
				if (i == 0 || j == 0) dp[i][j] = matrix[i][j];
				else if (matrix[i][j] == 0) dp[i][j] = 0;
				else dp[i][j] = 1 + new int[] {
					dp[i-1][j],
					dp[i-1][j-1],
					dp[i][j-1],
				}.Min();
				count += dp[i][j];
			}

		return count;
	}

	private int[][] _GenTable(int numRows, int numCols) {
		var table = new int[numRows][];

		for (int i = 0; i < numRows; ++i) {
			table[i] = new int[numCols];
			for (int j = 0; j < numCols; ++j)
				table[i][j] = 0;
		}

		return table;
	}
}