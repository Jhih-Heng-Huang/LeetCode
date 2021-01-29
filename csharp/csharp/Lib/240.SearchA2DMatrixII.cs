// LeetCode: 240. Search a 2D Matrix II

using System;

public class LeetCode240SearchA2DMatrixII
{
	public bool SearchMatrix(int[][] matrix, int target) {
		if (matrix == null ||
			matrix.Length == 0 ||
			matrix[0].Length == 0)
			return false;

		var rowIndex = 0;
		var colIndex = matrix[0].Length - 1;

		while (rowIndex < matrix.Length && colIndex >= 0) {
			var value = matrix[rowIndex][colIndex];
			if (value == target) return true;
			else if (value > target) --colIndex;
			else ++rowIndex;
		}

		return false;
	}
}
