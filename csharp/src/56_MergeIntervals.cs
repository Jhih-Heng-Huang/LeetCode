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
		private const int LEFT = 0;
		private const int RIGHT = 1;
		public int[][] Merge(int[][] intervals)
		{
			intervals = intervals.OrderBy(interval => interval[LEFT]).ToArray();

			var list = new List<int[]>();
			list.Add(intervals[0]);
			for (int i = 1; i < intervals.Length; ++i)
			{
				if (!_IsIntersect(list.Last(), intervals[i]))
				{
					list.Add(intervals[i]);
					continue;
				}

				list.Last()[RIGHT] = Math.Max(list.Last()[RIGHT], intervals[i][RIGHT]);
			}
			
			return list.ToArray();
		}
		private bool _IsIntersect(int[] interval1, int[] interval2)
		{
			return interval1[RIGHT] >= interval2[LEFT];
		}
	}
}
