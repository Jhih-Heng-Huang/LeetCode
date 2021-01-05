// LeetCode: 279. Perfect Squares

using System;

namespace csharp.Lib {
	public class LeetCode279PerfectSquares {
		public int NumSquares(int n) {
			if (n <= 0) return -1;

			var table = _GenTable(n);

			for (int i = 1; i < table.Length; ++i) {
				table[i] = _CalculateMinSquareNum(i, table);
			}

			return table[n];
		}

		public int[] _GenTable(int n) {
			var table = new int[n+1];
			table[0] = 0;
			return table;
		}

		public int _CalculateMinSquareNum(int num, int[] table) {
			var upperBound = Math.Sqrt(num);

			var min = int.MaxValue;
			for (int i = 1; i <= upperBound; ++i) {
				min = Math.Min(min, 1 + table[num - i*i]);
			}

			return min;
		}
	}
}