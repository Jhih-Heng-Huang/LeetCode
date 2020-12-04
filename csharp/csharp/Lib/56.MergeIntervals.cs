using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Lib
{
	public class LeetCode56MergeIntervals
	{
		public int[][] Merge(int[][] intervals)
		{
			var list = new List<int[]>();
			if (intervals == null || intervals.Length == 0)
				return list.ToArray();

			var orderIntervals = intervals.OrderBy(interval => interval[0]).ToArray();
			
			var newInterval = (int[]) orderIntervals[0].Clone();
			for (int i = 1; i < orderIntervals.Length; ++i) {
				if (_IsIntersect(newInterval, orderIntervals[i]))
				{
					newInterval[0] = Math.Min(newInterval[0], orderIntervals[i][0]);
					newInterval[1] = Math.Max(newInterval[1], orderIntervals[i][1]);
				} else {
					list.Add(newInterval);
					newInterval = (int[]) orderIntervals[i].Clone();
				}
			}
			list.Add(newInterval);

			return list.ToArray();
		}

		private bool _IsIntersect(int[] interval1, int[] interval2) {
			var left = Math.Max(interval1[0], interval2[0]);
			var right = Math.Min(interval1[1], interval2[1]);

			return left <= right;
		}
	}
}
