/*
787. Cheapest Flights Within K Stops
*/

using System;

public class CheapestFlightsWithinKStops {
	public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
		if (n == 0 || flights == null) return -1;

		var oldTable = _GenTable(n, src);
		var newTable = (int[]) oldTable.Clone();

		for (int i = 0; i < K+1; ++i) {
			foreach (var flight in flights) {
				var start = flight[0];
				var end = flight[1];
				var weight = flight[2];

				if (oldTable[start] == int.MaxValue)
					continue;
				
				newTable[end] = Math.Min(newTable[end], oldTable[start] + weight);
			}

			for (int j = 0; j < newTable.Length; ++j)
				oldTable[j] = newTable[j];
		}

		return oldTable[dst] == int.MaxValue? -1 : oldTable[dst];
	}

	private int[] _GenTable(int n, int src) {
		var list = new int[n];

		for (int i = 0; i < list.Length; ++i)
			list[i] = int.MaxValue;

		list[src] = 0;

		return list;
	}
}