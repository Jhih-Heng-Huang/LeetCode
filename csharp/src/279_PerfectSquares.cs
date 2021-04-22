// LeetCode: 279. Perfect Squares

using System;

namespace LeetCode.Problem_279 {
	public class LeetCode279PerfectSquares {
		public int NumSquares(int n) {
			if (n < 1) return 0;

			var table = new int[n+1];
			table[0] = 0;

			for (int i = 1; i < table.Length; ++i)
				table[i] = _GetMinNumSquares(i, table);

			return table[n];
		}

		private int _GetMinNumSquares(int num, int[] table)
		{
			var min = int.MaxValue;
			for (int val = 1; num >= val * val; ++val)
				min = Math.Min(min, 1 + table[num - val * val]);
			return min;
		}
	}
}