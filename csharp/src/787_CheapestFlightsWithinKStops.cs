/*
LeetCode: 787. Cheapest Flights Within K Stops
*/

using System;

namespace LeetCode.Problem_787
{
	public class CheapestFlightsWithinKStops {
		public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
			if (n <= 0 || flights == null ||
				flights.Length == 0)
				return -1;
			if (src == dst) return 0;

			var table = _GenTable(n, src);
			for (int count = 0; count < K + 1; ++count)
			{
				var newTable = (int[])table.Clone();
				foreach (var flight in flights)
				{
					var from = flight[0];
					var to = flight[1];
					var price = flight[2];

					if (table[from] == -1) continue;

					var len = newTable[to];
					newTable[to] = (len == -1)?
						table[from] + price :
						Math.Min(newTable[to], table[from] + price);
				}
				table = newTable;
			}
			return table[dst];
		}

		private int[] _GenTable(int n, int src)
		{
			var table = new int[n];
			for (int i = 0; i < table.Length; ++i)
				table[i] = -1;
			table[src] = 0;
			return table;
		}
	}
}