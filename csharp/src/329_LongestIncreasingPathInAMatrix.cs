/*
LeetCode: 329. Longest Increasing Path in a Matrix
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class LongestIncreasingPathInAMatrix {
	private int NONE = -1;
	public int LongestIncreasingPath(int[][] matrix) 
	{
		var table = _GenTable(matrix.Length, matrix[0].Length);

		int maxLen = 0;
		for (int row = 0; row < table.Length; ++row)
			for (int col = 0; col < table[row].Length; ++col)
				if (table[row][col] == NONE)
					maxLen = Math.Max(
						maxLen,
						 _TravelAndFindLongestLength(row, col, matrix, table)
					);
					
		return maxLen;
    }

	private int[][] _GenTable(int rowNum, int colNum)
	{
		var table = new int[rowNum][];
		for (int row = 0; row < rowNum; ++row)
		{	
			table[row] = new int[colNum];
			for (int col = 0; col < colNum; ++col)
				table[row][col] = NONE;
		}

		return table;
	}

	private int _TravelAndFindLongestLength(int row, int col, int[][] matrix, int[][] table)
	{
		if (table[row][col] != NONE) return table[row][col];

		var maxLen = 1;
		var currentVal = matrix[row][col];

		if (row > 0 && matrix[row-1][col] > currentVal)
			maxLen = Math.Max(
				maxLen,
				1+_TravelAndFindLongestLength(row-1, col, matrix, table)
			);
		if (col > 0 && matrix[row][col-1] > currentVal)
			maxLen = Math.Max(
				maxLen,
				1+_TravelAndFindLongestLength(row, col-1, matrix, table)
			);
		if (row+1 < table.Length && matrix[row+1][col] > currentVal)
			maxLen = Math.Max(
				maxLen,
				1+_TravelAndFindLongestLength(row+1, col, matrix, table)
			);
		if (col+1 < table[row].Length && matrix[row][col+1] > currentVal)
			maxLen = Math.Max(
				maxLen,
				1+_TravelAndFindLongestLength(row, col+1, matrix, table)
			);
		table[row][col] = maxLen;

		return table[row][col];
	}
}