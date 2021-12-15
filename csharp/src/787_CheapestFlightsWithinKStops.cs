/*
LeetCode: 787. Cheapest Flights Within K Stops
*/

using System;

namespace LeetCode.Problem_787
{
	public class CheapestFlightsWithinKStops {
		private const int FROM = 0;
		private const int TO = 1;
		private const int PRICE = 2;
		public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
			var table = GenTable_(n);
			table[src] = 0;

			for (int count = 0; count <= K; ++count)
			{
				var tempTable = (int[])table.Clone();
				foreach (var flight in flights)
				{
					var from = flight[FROM];
					if (table[from] == int.MaxValue)
						continue;
					
					var to = flight[TO];
					var price = flight[PRICE];

					tempTable[to] = Math.Min(tempTable[to], table[from] + price);
				}
				table = tempTable;
			}
			return table[dst] == int.MaxValue? -1: table[dst];
		}

		private int[] GenTable_(int numPlaces)
		{
			var table = new int[numPlaces];
			for (int i = 0; i < table.Length; ++i)
				table[i] = int.MaxValue;
			return table;
		}
	}
}