// LeetCode: 240. Search a 2D Matrix II

using System;

namespace LeetCode.Problem_240
{
	public class Solution
	{
		public bool SearchMatrix(int[][] matrix, int target)
		{
			if (matrix == null) return false;

			var row = 0;
			var col = matrix[row].Length - 1;
			while (row < matrix.Length && col >= 0)
			{
				var value = matrix[row][col];
				if (target == value) return true;
				else if (target < value) --col;
				else ++row;
			}
			return false;
		}
	}
}
