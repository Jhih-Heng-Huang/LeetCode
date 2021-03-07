/*
LeetCode: 329. Longest Increasing Path in a Matrix
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class LongestIncreasingPathInAMatrix {
	private class Position {
		public int row;
		public int col;
	}

	public int LongestIncreasingPath(int[][] matrix) 
	{
		if (matrix == null ||
			matrix.Length == 0 ||
			matrix[0].Length == 0)
			return 0;
		
		var table = new int[matrix.Length][];
		for (int row = 0; row < table.Length; ++row)
		{
			table[row] = new int[matrix[row].Length];
			for (int col = 0; col < table[row].Length; ++col)
				table[row][col] = 0;
		}

		int result = 0;
		for (int row = 0; row < table.Length; ++row)
			for (int col = 0; col < table[row].Length; ++col)
				result = Math.Max(result,
				_FindLongestIncreasingPath(row, col, matrix, table));
		
		return result;
    }

	private int _FindLongestIncreasingPath(
		int row, int col,
		int[][] matrix, int[][] table)
	{
		if (table[row][col] != 0) return table[row][col];

		var result = 1;
		var paths = _FindPaths(row, col, matrix);
		foreach (var path in paths) {
			if (matrix[row][col] < matrix[path.row][path.col])
				result = Math.Max(result,
				1 + _FindLongestIncreasingPath(path.row, path.col, matrix, table));
		}
		table[row][col] = result;
		return result;
	}

	private Position[] _FindPaths(int row, int col, int[][] matrix) {
		var list = new List<Position>();

		if (row - 1 >= 0)
			list.Add(new Position
			{
				row = row-1,
				col = col,
			});
		if (col - 1 >= 0)
			list.Add(new Position
			{
				row = row,
				col = col-1,
			});
		if (row + 1 < matrix.Length)
			list.Add(new Position
			{
				row = row+1,
				col = col,
			});
		if (col + 1 < matrix[row].Length)
			list.Add(new Position
			{
				row = row,
				col = col+1,
			});
		return list.ToArray();
	}
}