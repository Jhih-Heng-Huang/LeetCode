/*
LeetCode: 313. Super Ugly Number
*/

using System.Linq;

namespace LeetCode.Problem_313
{
	public class SuperUglyNumber {
		private class PrimePointer
		{
			public int Value;
			public int Index;
		}

		public int NthSuperUglyNumber(int n, int[] primes) {
			if (n <= 1) return 1;

			var primePointers = primes.Select(prime => new PrimePointer{ Value = prime, Index = 0})
				.ToArray();
			return _FindNthSuperUglyNumber(n, primePointers);
		}

		private int _FindNthSuperUglyNumber(int n, PrimePointer[] primePointers)
		{
			var table = new int[n];
			table[0] = 1;

			for (int i = 1; i < table.Length; ++i)
			{
				table[i] = primePointers.Min(pointer => pointer.Value * table[pointer.Index]);

				foreach (var pointer in primePointers)
					if (table[i] == pointer.Value * table[pointer.Index])
						++pointer.Index;
			}
			return table[n-1];
		}
	}
}