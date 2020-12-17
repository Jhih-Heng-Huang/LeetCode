// LeetCode: 279. Perfect Squares

using System;

namespace csharp.Lib {
	public class LeetCode279PerfectSquares {
		public int NumSquares(int n) {
			if (n <= 1) return n;

			var table = _GenTable(n);

			for (int i = 1; i < table.Length; ++i) {
				table[i] = _GetMinNumSquares(i, table);
			}

			return table[n];
		}

		private int[] _GenTable(int n) {
			var table = new int[1+n];
			table[0] = 0;
			return table;
		}

		private int _GetMinNumSquares(int n, int[] table)
        {
			var upperBound = Math.Sqrt(n);
			var minNum = int.MaxValue;
			for (int i = 1; i <= upperBound; ++i)
            {
				minNum = Math.Min(minNum, 1 + table[n - i * i]);
            }

			return minNum;
        }
	}
}