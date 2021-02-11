using System;

public class CoinChange2 {
    public int Change(int amount, int[] coins) {
		if (amount == 0 || coins.Length == 0)
			return 0;
		
		return _Change(amount, coins);
    }

	private int _Change(int amount, int[] coins) {
		var dp = _GenTable(amount);
		dp[0] = 1;

		foreach (var coin in coins)
			for (int i = coin; i < amount; ++i)
				dp[i] += dp[i-coin];

		return dp[amount-1];
	}

	private int[] _GenTable(int amount) {
		var table = new int[amount];
		for (int i = 0; i < amount; ++i)
			table[i] = 0;
		return table;
	}
}