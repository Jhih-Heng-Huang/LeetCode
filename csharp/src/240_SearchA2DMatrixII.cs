// LeetCode: 240. Search a 2D Matrix II

using System;

namespace LeetCode.Problem_240
{
	public class Solution
	{
		public bool SearchMatrix(int[][] matrix, int target)
		{
			var row = 0;
			var col = matrix[0].Length - 1;
			while (col >= 0 && row < matrix.Length)
			{
				if (matrix[row][col] == target)
					return true;
				if (matrix[row][col] > target)
					--col;
				else
					++row;
			}
			return false;
		}
	}
}
