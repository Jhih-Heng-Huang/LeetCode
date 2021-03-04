/*
LeetCode: 518. Coin Change 2
*/

using System;

namespace LeetCode.Problem_518
{
	public class CoinChange2 {
		public int Change(int amount, int[] coins) {
			if (amount <= 0) return 1;

			var table = _GenTable(amount);

			foreach (var coin in coins)
				for (int i = coin; i <= amount; ++i)
					table[i] += table[i-coin];

			return table[amount];
		}

		private int[] _GenTable(int amount) {
			var table = new int[amount + 1];

			for (int i = 0; i <= amount; ++i)
				table[i] = 0;
			table[0] = 1;
			return table;
		}
	}
}