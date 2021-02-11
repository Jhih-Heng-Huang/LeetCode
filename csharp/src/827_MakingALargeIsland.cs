// 827. Making A Large Island

using System;
using System.Collections.Generic;
using System.Linq;

public class LeetCode827MakingALargeIsland {
	private Dictionary<int, int> _colorSizeMap = new Dictionary<int, int>();

	public int LargestIsland(int[][] grid) {
		if (grid == null || grid.Length == 0) return 0;

		// color the island
		_PaintColorIsland(grid);
		var maxSize = _GetLargestColorIsland();
		maxSize = Math.Max(maxSize, _GetLargestConnectedIsland(grid));
		
		return maxSize;
	}

	private void _PaintColorIsland(int[][] map) {
		_colorSizeMap.Clear();

		int color = 2;
		for (int x = 0; x < map.Length; ++x) {
			for (int y = 0; y < map[x].Length; ++y) {
				if (map[x][y] != 1) continue;
				var size = _GetColorIslandSize(x, y, color, map);
				_colorSizeMap[color] = size;
				++color;
			}
		}
	}

	private int _GetColorIslandSize(int x, int y, int color, int[][] map) {
		if (map[x][y] != 1) return 0;

		map[x][y] = color;
		var paths = _GetPaths(x, y, map);
		var size = 1;

		foreach (var path in paths)
		{
			var i = path[0];
			var j = path[1];
			size += _GetColorIslandSize(i, j, color, map);
		}

		return size;
	}

	private int[][] _GetPaths(int x, int y, int[][] map) {
		var paths = new List<int[]>();

		if (x > 0) paths.Add(new int[]{x-1,y});
		if (y > 0) paths.Add(new int[]{x,y-1});
		if (x < map.Length - 1) paths.Add(new int[]{x+1,y});
		if (y < map[x].Length - 1) paths.Add(new int[]{x,y+1});

		return paths.ToArray();
	}

	private int _GetLargestColorIsland() {
		if (_colorSizeMap.Keys.Count() > 0)
			return _colorSizeMap.Values.Max();
		return 0;
	}

	private int _GetLargestConnectedIsland(int[][] map) {
		var maxSize = 0;
		for (int x = 0; x < map.Length; ++x) {
			for (int y = 0; y < map[x].Length; ++y) {
				var size = _GetLargestConnectedIsland(x, y, map);
				maxSize = Math.Max(maxSize, size);
			}
		}

		return maxSize;
	}

	private int _GetLargestConnectedIsland(int x, int y, int[][] map) {
		if (map[x][y] != 0) return 0;

		var paths = _GetPaths(x, y, map);
		var colorHashSet = new HashSet<int>();
		var size = 1;
		foreach (var path in paths)
		{
			var i = path[0];
			var j = path[1];
			var color = map[i][j];
			if (color == 0 || colorHashSet.Contains(color)) continue;
			colorHashSet.Add(color);
			size += _colorSizeMap[color];
		}

		return size;
	}
}