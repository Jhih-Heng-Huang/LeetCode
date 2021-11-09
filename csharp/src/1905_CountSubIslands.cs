/*
LeetCode 1905. Count Sub Islands
*/

namespace LeetCode.Problem_1905
{
	public class LeetCode1905_CountSubIslands
	{
		private const int Water = 0;
		private const int Island = 1;
		private const int Color = 2;

		public int CountSubIslands(int[][] grid1, int[][] grid2)
		{
			for (int row = 0; row < grid1.Length; ++row)
				for (int col = 0; col < grid1[row].Length; ++col)
					if (_IsIslandInWater(row, col, grid1, grid2))
						_TravelAndRemoveIslandsInWater(row, col, grid1, grid2);


			var count = 0;
			for (int row = 0; row < grid1.Length; ++row)
				for (int col = 0; col < grid1[row].Length; ++col)
					if (_IsSubIsland(row, col, grid1, grid2))
					{
						_TravelAndPaintSubIslands(row, col, grid1, grid2);
						++count;
					}
			return count;
		}


		private void _TravelAndRemoveIslandsInWater(int row, int col, int[][] grid1, int[][] grid2)
		{
			grid2[row][col] = Water;
			
			if (row-1 >=0 &&
				grid2[row - 1][col] == Island)
				_TravelAndRemoveIslandsInWater(row-1, col, grid1, grid2);
			if (col-1 >= 0 &&
				grid2[row][col-1] == Island)
				_TravelAndRemoveIslandsInWater(row, col-1, grid1, grid2);
			if (row+1 < grid1.Length &&
				grid2[row+1][col] == Island)
				_TravelAndRemoveIslandsInWater(row+1, col, grid1, grid2);
			if (col+1 < grid1[row].Length &&
				grid2[row][col+1] == Island)
				_TravelAndRemoveIslandsInWater(row, col+1, grid1, grid2);
		}

		private bool _IsIslandInWater(int row, int col, int[][] grid1, int[][] grid2)
		=> grid1[row][col] == Water && grid2[row][col] == Island;

		private void _TravelAndPaintSubIslands(
			int row, int col,
			int[][] grid1, int[][] grid2)
		{
			grid2[row][col] = Color;

			if (row-1 >=0 &&
				_IsSubIsland(row - 1, col, grid1, grid2))
				_TravelAndPaintSubIslands(row-1, col, grid1, grid2);
			if (col-1 >= 0 &&
				_IsSubIsland(row, col-1, grid1, grid2))
				_TravelAndPaintSubIslands(row, col-1, grid1, grid2);
			if (row+1 < grid1.Length &&
				_IsSubIsland(row+1, col, grid1, grid2))
				_TravelAndPaintSubIslands(row+1, col, grid1, grid2);
			if (col+1 < grid1[row].Length &&
				_IsSubIsland(row, col+1, grid1, grid2))
				_TravelAndPaintSubIslands(row, col+1, grid1, grid2);
		}

		private bool _IsSubIsland(int row, int col, int[][] grid1, int[][] grid2)
		=> grid1[row][col] == grid2[row][col] && grid1[row][col] == Island;
	}
}