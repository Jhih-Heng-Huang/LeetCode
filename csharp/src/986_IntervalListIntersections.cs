/*
LeetCode: 986. Interval List Intersections
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class IntervalListIntersections {
	private class Interval {
		public int Start;
		public int End;
	}
    public int[][] IntervalIntersection(int[][] A, int[][] B) {
		List<int[]> results = new List<int[]>();

		if (A == null || A.Length == 0 ||
			B == null || B.Length == 0)
			return results.ToArray();

		var list1 = A.Select(a => new Interval{Start = a[0], End = a[1]}).ToArray();
		var list2 = B.Select(b => new Interval{Start = b[0], End = b[1]}).ToArray();
		var i = 0;
		var j = 0;
		while (i < list1.Length && j < list2.Length) {
			var interval = _Intersect(list1[i], list2[j]);

			if (interval != null)
				results.Add(new int[] {interval.Start, interval.End});
			
			if (list1[i].End <= list2[j].End) ++i;
			else ++j;
		}

		return results.ToArray();
    }

	private Interval _Intersect(Interval interval1, Interval interval2)
	{
		var left = Math.Max(interval1.Start, interval2.Start);
		var right = Math.Min(interval1.End, interval2.End);
		if (left > right) return null;
		return new Interval{Start = left, End = right};
	}

}