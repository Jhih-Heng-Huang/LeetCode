/*
LeetCode: 313. Super Ugly Number
*/

using System;
using System.Linq;

namespace LeetCode.Problem_313
{
	public class SuperUglyNumber {
		private class PrimePointer
		{
			public int Val;
			public int Pos = 0;
		}

		public int NthSuperUglyNumber(int n, int[] primes) {
			if (n == 1) return 1;

			var table = new int[n];
			table[0] = 1;

			var primePointers = primes
				.Select(prime => new PrimePointer{Val = prime})
				.ToArray();
			
			for (int i = 1; i < n; ++i)
			{
				var minVal = int.MaxValue;
				foreach(var primePointer in primePointers)
					minVal = Math.Min(minVal, primePointer.Val * table[primePointer.Pos]);
				foreach(var primePointer in primePointers)
					if (primePointer.Val * table[primePointer.Pos] == minVal)
						++primePointer.Pos;
				table[i] = minVal;
			}
			return table[n-1];
		}
	}
}