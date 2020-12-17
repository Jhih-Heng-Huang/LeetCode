/*
313. Super Ugly Number
*/

using System.Linq;

public class SuperUglyNumber {
	private class PrimePointer {
		public int Value;
		public int Position;
	}

    public int NthSuperUglyNumber(int n, int[] primes) {
		if (n == 1) return 1;
		
		var primePointers = primes.Select(prime =>
			new PrimePointer{Value = prime, Position = 0})
			.ToArray();
		
		return _FindNthSuperUglyNumber(n, primePointers);
    }

	private int _FindNthSuperUglyNumber(int n, PrimePointer[] primePointers) {
		var table = new int[n];
		table[0] = 1;

		for (int i = 1; i < n; i++) {
			table[i] = primePointers.Min(primePointer => primePointer.Value * table[primePointer.Position]);

			foreach (var primePointer in primePointers) {
				if (table[i] == primePointer.Value * table[primePointer.Position])
					++primePointer.Position;
			}
		}

		return table[n-1];
	}
}