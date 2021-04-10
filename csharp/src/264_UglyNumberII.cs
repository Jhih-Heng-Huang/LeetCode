// LeetCode: 264.Ugly Number II

using System;
using System.Linq;

namespace LeetCode.Problem_264
{
	public class Solution
	{
		private class PrimePointer
		{
			public int Value;
			public int Position;
		}

		public int NthUglyNumber(int n)
		{
			if (n <= 1) return 1;

			var primePointers = _GenPrimePointers();

			var table = new int[n];
			table[0] = 1;
			for (int i = 1; i < table.Length; ++i)
			{
				var min = int.MaxValue;
				foreach (var primePointer in primePointers)
					min = Math.Min(min, primePointer.Value * table[primePointer.Position]);
				table[i] = min;

				foreach (var primePointer in primePointers)
					if (primePointer.Value * table[primePointer.Position] == min)
						++primePointer.Position;
			}

			return table[n-1];
		}

		private PrimePointer[] _GenPrimePointers()
		{
			return new PrimePointer[]
			{
				new PrimePointer
				{
					Value = 2,
					Position = 0,
				},
				new PrimePointer
				{
					Value = 3,
					Position = 0,
				},
				new PrimePointer
				{
					Value = 5,
					Position = 0,
				},
			};
		}
	}
}
