/*
LeetCode: 1277. Count Square Submatrices with All Ones
*/

using System.Linq;

public class CountSquareSubmatriceswithAllOnes {
    public int CountSquares(int[][] matrix) {
		var table = _GenTable(matrix.Length, matrix[0].Length);
		var count = 0;
		for (int row = 0; row < table.Length; ++row)
			for (int col = 0; col < table[row].Length; ++col)
			{
				if (matrix[row][col] == 0) continue;
				if (row == 0 || col == 0)
					table[row][col] = matrix[row][col];
				else
					table[row][col] = new int[]
					{
						table[row-1][col],
						table[row-1][col-1],
						table[row][col-1],
					}.Min() + 1;
				count += table[row][col];

			}
		return count;
    }

	private int[][] _GenTable(int height, int width)
	{
		var table = new int[height][];

		for (int i = 0; i < height; ++i)
			table[i] = new int[width];
		return table;
	}
}