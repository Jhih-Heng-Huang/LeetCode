/*
LeetCode 200. Number of Islands
*/

using System;

namespace LeetCode.Problem_200
{
	public class LeetCode200NumberOfIslands
	{
		public int NumIslands(char[][] grid)
		{
			var count = 0;
			for (int row = 0; row < grid.Length; ++row)
				for (int col = 0; col < grid[row].Length; ++col)
					if (grid[row][col] == '1')
					{
						var color = '2';
						_PaintIslands(row, col, color, grid);
						++count;
					}
			
			return count;
		}

		private void _PaintIslands(int row, int col, char color, char[][] grid)
		{
			grid[row][col] = color;
			if (row - 1 >= 0 && grid[row-1][col] == '1')
				_PaintIslands(row-1, col, color, grid);
			if (row + 1 < grid.Length && grid[row+1][col] == '1')
				_PaintIslands(row+1, col, color, grid);
			if (col - 1 >= 0 && grid[row][col-1] == '1')
				_PaintIslands(row, col-1, color, grid);
			if (col + 1 < grid[row].Length && grid[row][col+1] == '1')
				_PaintIslands(row, col+1, color, grid);
		}
	}
}