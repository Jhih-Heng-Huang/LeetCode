// LeetCode: 827. Making A Large Island

using System;
using System.Collections.Generic;
using System.Linq;

public class LeetCode827MakingALargeIsland {
	private const int WATER = 0;
	private const int ISLAND = 1;
	public int LargestIsland(int[][] grid)
	{
		var islandSizeTable = new Dictionary<int, int>();
		// paint island & record the island size of each color
		int color = 2;
		int maxIslandSize = 0;
		for (int row = 0; row < grid.Length; ++row)
			for (int col = 0; col < grid.Length; ++col)
				if (grid[row][col] == ISLAND)
				{
					islandSizeTable[color] = _CountIslandSize(row, col, color, grid);
					maxIslandSize = Math.Max(maxIslandSize, islandSizeTable[color]);
					++color;
				}

		// find the largest connected island size
		for (int row = 0; row < grid.Length; ++row)
			for (int col = 0; col < grid.Length; ++col)
				if (grid[row][col] == WATER)
					maxIslandSize = Math.Max(maxIslandSize, _GetConnectedIslandSize(row, col, grid, islandSizeTable));
		return maxIslandSize;
	}

	private int _CountIslandSize(int row, int col, int color, int[][] grid)
	{
		grid[row][col] = color;

		int islandSize = 1;
		if (row-1 >= 0 && grid[row-1][col] == ISLAND)
			islandSize += _CountIslandSize(row-1, col, color, grid);
		if (col-1 >= 0 && grid[row][col-1] == ISLAND)
			islandSize += _CountIslandSize(row, col-1, color, grid);
		if (row+1 < grid.Length && grid[row+1][col] == ISLAND)
			islandSize += _CountIslandSize(row+1, col, color, grid);
		if (col+1 < grid.Length && grid[row][col+1] == ISLAND)
			islandSize += _CountIslandSize(row, col+1, color, grid);

		return islandSize;
	}

	private int _GetConnectedIslandSize(
		int row, int col,
		int[][] grid,
		Dictionary<int, int> islandSizeTable)
	{
		var colorSet = new HashSet<int>();
		
		int size = 1;
		if (row-1 >= 0 && grid[row-1][col] != WATER)
			colorSet.Add(grid[row-1][col]);
		if (col-1 >= 0 && grid[row][col-1] != WATER)
			colorSet.Add(grid[row][col-1]);
		if (row+1 < grid.Length && grid[row+1][col] != WATER)
			colorSet.Add(grid[row+1][col]);
		if (col+1 < grid.Length && grid[row][col+1] != WATER)
			colorSet.Add(grid[row][col+1]);
		
		foreach (var color in colorSet)
		{
			size += islandSizeTable[color];
		}
		return size;
	}
}