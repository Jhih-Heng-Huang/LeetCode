// LeetCode: 827. Making A Large Island

using System;
using System.Collections.Generic;
using System.Linq;

public class LeetCode827MakingALargeIsland {
	public int LargestIsland(int[][] grid) {
		if (grid == null ||
			grid.Length == 0 ||
			grid[0].Length == 0)
			return 0;
		
		var map = (int[][]) grid.Clone();

		var color = 2;
		var color2Size = new Dictionary<int, int>();
		for (int row = 0; row < map.Length; ++row)
			for (int col = 0; col < map[row].Length; ++col)
			{
				if (map[row][col] == 1)
				{
					color2Size.Add(color, _PaintIsland(row, col, color, map));
					++color;
				}
			}
		
		var maxSize = 0;
		foreach (var size in color2Size.Values)
			maxSize = Math.Max(maxSize, size);

		for (int row = 0; row < map.Length; ++row)
			for (int col = 0; col < map[row].Length; ++col)
			{
				if (map[row][col] == 0)
					maxSize = Math.Max(
						maxSize,
						_CombineSize(row, col, map, color2Size));
			}

		return maxSize;
	}

	private int[][] _GetPaths(int row, int col, int[][] map)
	{
		var paths = new List<int[]>();
		if (row - 1 >= 0)
			paths.Add(new int[]{row-1, col});
		if (col - 1 >= 0)
			paths.Add(new int[]{row, col-1});
		if (row + 1 < map.Length)
			paths.Add(new int[]{row+1, col});
		if (col + 1 < map[row].Length)
			paths.Add(new int[]{row, col+1});
		return paths.ToArray();
	}

	private int _PaintIsland(
		int row, int col, int color,
		int[][] map)
	{
		if (map[row][col] != 1) return 0;

		map[row][col] = color;
		var size = 1;
		var paths = _GetPaths(row, col, map);
		foreach (var path in paths)
		{
			var i = path[0];
			var j = path[1];
			size += _PaintIsland(i, j, color, map);
		}
		return size;
	}

	private int _CombineSize(int row, int col, int[][] map, Dictionary<int, int> color2Size)
	{
		if (map[row][col] != 0) return 0;

		var size = 1;
		var paths = _GetPaths(row, col, map);
		var colorCache = new HashSet<int>();
		foreach (var path in paths)
		{
			var i = path[0];
			var j = path[1];
			var color = map[i][j];
			if (color != 0 && !colorCache.Contains(color))
			{
				colorCache.Add(color);
				size += color2Size[color];
			}
		}
		return size;
	}
}