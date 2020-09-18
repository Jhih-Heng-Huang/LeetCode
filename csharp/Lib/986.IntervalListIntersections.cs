/*
986. Interval List Intersections
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class IntervalListIntersections {
	private class Interval {
		public int left;
		public int right;
	}

    public int[][] IntervalIntersection(int[][] A, int[][] B) {
        var intervals1 = A.Select(v => new Interval {
			left = v[0],
			right = v[1],
		}).ToArray();
		var intervals2 = B.Select(v => new Interval {
			left = v[0],
			right = v[1],
		}).ToArray();

		var list = new List<Interval>();
		var i = 0;
		var j = 0;

		while (i < intervals1.Length && j < intervals2.Length) {
			var newInterval = _Intersect(intervals1[i], intervals2[j]);
			if (newInterval != null)
				list.Add(newInterval);
			
			if (intervals1[i].right <= intervals2[j].right) ++i;
			else ++j;
		}

		return list.Select(e => new int[] {e.left, e.right}).ToArray();
    }

	private Interval _Intersect(Interval interval1, Interval interval2) {
		var left = Math.Max(interval1.left, interval2.left);
		var right = Math.Min(interval1.right, interval2.right);

		if (left > right)
			return null;
		return new Interval {
			left = left,
			right = right
		};
	}
}