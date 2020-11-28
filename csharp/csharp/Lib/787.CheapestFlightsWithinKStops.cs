/*
787. Cheapest Flights Within K Stops
*/

using System;

public class CheapestFlightsWithinKStops {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
		if (n == 0)
			return 0;
		
		var dp = _GenTable(n);
		dp[src] = 0;

		for (int i = 0; i < K+1; ++i)
			_Update(ref dp, flights);

		return dp[dst] == int.MaxValue? -1 : dp[dst];
    }

	private int[] _GenTable(int n) {
		var list = new int[n];
		
		for (int i = 0; i < list.Length; ++i)
			list[i] = int.MaxValue;
		
		return list;
	}

	private void _Update(ref int[] dp, int[][] flights) {
		var temp = (int[]) dp.Clone();

		foreach (var f in flights) {
			var src = f[0];
			var dst = f[1];
			var price = f[2];

			if (dp[src] == int.MaxValue)
				continue;
			
			temp[dst] = Math.Min(temp[dst], dp[src] + price);
		}
		dp = temp;
	}
}