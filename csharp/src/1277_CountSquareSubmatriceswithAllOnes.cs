/*
LeetCode: 1277. Count Square Submatrices with All Ones
*/

using System;
using System.Linq;

public class CountSquareSubmatriceswithAllOnes {
    public int CountSquares(int[][] matrix) {
		if (matrix == null ||
			matrix.Length == 0 ||
			matrix[0].Length == 0)
			return 0;
		
		return _CountSquares(matrix);
    }

	private int _CountSquares(int[][] matrix)
	{
		var table = _GenTable(matrix.Length, matrix[0].Length);

		for (int row = 0; row < matrix.Length; ++row)
			for (int col = 0; col < matrix[row].Length; ++col)
			{
				if (row == 0 || col == 0)
					table[row][col] = matrix[row][col];
				else if (matrix[row][col] == 0)
					table[row][col] = 0;
				else
					table[row][col] = 1 + new int[] {
						table[row-1][col],
						table[row][col-1],
						table[row-1][col-1]}.Min();
			}
		
		var count = 0;
		foreach (var row in table)
			foreach (var ele in row)
				count += ele;
		
		return count;
	}

	private int[][] _GenTable(int numRows, int numCols) {
		var table = new int[numRows][];

		for (int row = 0; row < numRows; ++row) {
			table[row] = new int[numCols];
			for (int col = 0; col < numCols; ++col)
				table[row][col] = 0;
		}

		return table;
	}
}