// LeetCode: 279. Perfect Squares

using System;

namespace LeetCode.Problem_279 {
	public class LeetCode279PerfectSquares {
		public int NumSquares(int n) {
			if (n < 1) return 0;

			var list = _InitList(n);
			
			for (int i = 1; i < list.Length; ++i)
			{
				list[i] = _FindMinSquareNum(i, list);
			}
			return list[n];
		}

		private static int[] _InitList(int num)
		{
			var list = new int[num+1];
			list[0] = 0;
			return list;
		}

		private static int _FindMinSquareNum(int i, int[] list)
		{
			var sqrtI = Math.Sqrt(i);
			int minNum = int.MaxValue;
			for (int v = 1; v <= sqrtI; ++v)
			{
				if ((i - v * v) < 0) break;
				minNum = Math.Min(minNum, list[i - v * v] + 1);
			}
			return minNum;
		}
	}
}