// LeetCode: 279. Perfect Squares

using System;

namespace csharp.Lib {
	public class LeetCode279PerfectSquares {
		public int NumSquares(int n) {
			if (n < 0) return -1;

			var table = _GenTable(n);
			for (int i = 2; i <= n; ++i)
				table[i] = _FindLeastNumSquare(i, table);

			return table[n];
		}

		private int[] _GenTable(int n) {
			var table = new int[n+1];
			table[0] = 0;
			table[1] = 1;
			return table;
		}

		private int _FindLeastNumSquare(int num, int[] table) {
			var upperBound = Math.Floor(MathF.Sqrt(num));
			var leastNum = int.MaxValue;
			for (int i = 1; i <= upperBound; ++i)
				leastNum = Math.Min(leastNum, 1 + table[num - i*i]);
			return leastNum;
		}
	}
}