/*
LeetCode: 56. Merge Intervals
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problem_56
{
	public class LeetCode56MergeIntervals
	{
		private class Interval
		{
			public int left;
			public int right;
		}

		public int[][] Merge(int[][] intervals)
		{
			if (intervals == null || intervals.Length == 0)
				return new int[0][];
			
			return _Merge(intervals
				.OrderBy(interval => interval[0])
				.Select(interval => new Interval
				{
					left = interval[0],
					right = interval[1],
				})
				.ToArray());
		}

		private int[][] _Merge(Interval[] intervals)
		{
			var list = new List<int[]>();

			Interval lastInterval = new Interval
			{
				left = intervals[0].left,
				right = intervals[0].right,
			};

			foreach (var interval in intervals)
			{
				if (lastInterval.right >= interval.left)
					lastInterval.right = Math.Max(lastInterval.right, interval.right);
				else
				{
					list.Add(new int[]{ lastInterval.left, lastInterval.right});
					lastInterval.left = interval.left;
					lastInterval.right = interval.right;
				}
			}
			list.Add(new int[] {lastInterval.left, lastInterval.right});

			return list.ToArray();
		}
	}
}
