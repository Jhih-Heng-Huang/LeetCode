// LeetCode: 279. Perfect Squares

using System;

namespace csharp.Lib {
	public class LeetCode279PerfectSquares {
		public int NumSquares(int n) {
			if (n < 1) return 0;

			var table = new int[n+1];
			table[0] = 0;

			for (int i = 1; i < table.Length; ++i) {
				table[i] = _FindLeastNumSquares(i, table);
			}

			return table[n];
		}

		private int _FindLeastNumSquares(in int n, in int[] table) {
			var length = (int)Math.Floor(Math.Sqrt(n));

			var leastNumSquares = int.MaxValue;
			for (int i = 1; i <= length; ++i) {
				var numSquares = 1 + table[n - i*i];
				if (leastNumSquares > numSquares)
					leastNumSquares = numSquares;
			}

			return leastNumSquares;
		}
	}
}