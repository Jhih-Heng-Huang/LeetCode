using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class GambleProblem {
    public int solution(int N, int K) {
        if (N == 1 && K == 0)
			return 0;

		var dp = _GenTable(N, K);

		for (int i = 2; i < dp.Length; ++i) {
			for (int j = 0; j < dp[i].Length; ++j) {
				if (j == 0)
					dp[i][j] = 1 + dp[i-1][j];
				else {
					var allInCount = (i % 2 == 0)? dp[i/2][j-1] + 1: dp[i/2][j-1] + 2;
					dp[i][j] = Math.Min(1 + dp[i-1][j], allInCount);
				}
			}
		}

		return dp[N][K];
    }

	private int[][] _GenTable(int N, int K) {
		var table = new int[N+1][];

		for (int i = 0; i < table.Length; ++i) {
			table[i] = new int[K+1];

			for (int j = 0; j < table[i].Length; ++j)
				table[i][j] = 0;
		}

		return table;
	}

	public int solution1(int N, int K) {
		if (N < 2)
			return 0;
		
		if (K == 0)
			return solution1(N-1, K) + 1;
		else {
			var allInCount = (N % 2 == 0)? solution1(N/2, K-1) + 1 : solution1(N/2, K-1) + 2;
			return Math.Min(1 + solution1(N-1, K) + 1, allInCount);
		}
	}
}