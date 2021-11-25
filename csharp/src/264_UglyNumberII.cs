// LeetCode: 264.Ugly Number II

using System;
using System.Linq;

namespace LeetCode.Problem_264
{
	public class Solution
	{
		private class PrimePointer
		{
			public int Val;
			public int Pos;
		}
		public int NthUglyNumber(int n)
		{
			var primes = new PrimePointer[]
			{
				new PrimePointer
				{
					Val = 2,
					Pos = 0,
				},
				new PrimePointer
				{
					Val = 3,
					Pos = 0,
				},
				new PrimePointer
				{
					Val = 5,
					Pos = 0,
				},
			};

			var table = new int[n];
			table[0] = 1;
			for (int i = 1; i < table.Length; ++i)
			{
				var minVal = int.MaxValue;
				foreach (var prime in primes)
					minVal = Math.Min(minVal, prime.Val * table[prime.Pos]);
				foreach (var prime in primes)
					if (minVal == prime.Val * table[prime.Pos])
						++prime.Pos;
				table[i] = minVal;
			}
			return table[n-1];
		}
	}
}
