/*
313. Super Ugly Number
*/

using System.Linq;

public class SuperUglyNumber {
	private class PrimePointer {
		public int Value;
		public int Pointer;
	}

    public int NthSuperUglyNumber(int n, int[] primes) {
		if (n == 1)
			return 1;
		
		var pps = _GenPrimePointers(primes);
		var dp = new int[n];
		dp[0] = 1;

		for (int i = 1; i < dp.Length; ++i) {
			dp[i] = pps.Min(p => p.Value * dp[p.Pointer]);

			foreach (var p in pps)
				if (dp[i] == p.Value * dp[p.Pointer])
					++p.Pointer;
		}

		return dp[n-1];
    }

	private PrimePointer[] _GenPrimePointers(int[] primes) {
		return primes.Select(p =>
			new PrimePointer {
				Value = p,
				Pointer = 0,
			}).ToArray();
	}
}