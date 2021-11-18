/*
LeetCode: 986. Interval List Intersections
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class IntervalListIntersections {
	private const int left = 0;
	private const int right = 1;

    public int[][] IntervalIntersection(int[][] A, int[][] B)
	{
		if (A.Length == 0 ||
			B.Length == 0)
			return new int[][]{};
		
		var intervals = new List<int[]>();

		int intervalA = 0;
		int intervalB = 0;
		while (intervalA < A.Length && intervalB < B.Length)
		{
			var leftBound = Math.Max(A[intervalA][left], B[intervalB][left]);
			var rightBound = Math.Min(A[intervalA][right], B[intervalB][right]);
			// get intersection
			if (leftBound <= rightBound)
				intervals.Add(new int[]{leftBound, rightBound});

			// go next
			if (A[intervalA][right] <= B[intervalB][right])
				++intervalA;
			else
				++intervalB;
		}

		return intervals.ToArray();
    }
}