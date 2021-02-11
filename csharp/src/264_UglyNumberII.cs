// LeetCode: 264.Ugly Number II

using System.Linq;

namespace csharp.Lib
{
	public class LeetCode264UglyNumberII
	{
		private class PrimePointer
		{
			public int Value;
			public int Position;
		}

		public int NthUglyNumber(int n)
		{
			if (n < 1) return 0;
			if (n == 1) return 1;

			var primePointers = _GenPrimePointers();
			var dp = new int[n];
			dp[0] = 1;

			for (int i = 1; i < n; ++i) {
				dp[i] = primePointers.Min(p => p.Value * dp[p.Position]);

				foreach (var p in primePointers) {
					if (dp[i] == p.Value * dp[p.Position])
						++p.Position;
				}
			}

			return dp.Last();
		}

		private PrimePointer[] _GenPrimePointers() {
			return new PrimePointer[]
			{
				new PrimePointer{ Value = 2, Position = 0},
				new PrimePointer{ Value = 3, Position = 0},
				new PrimePointer{ Value = 5, Position = 0},
			};
		}
	}
}
