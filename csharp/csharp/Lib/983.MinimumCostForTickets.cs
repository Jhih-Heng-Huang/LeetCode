using System;
using System.Linq;

public class Solution {
	private class Ticket {
		public int Price = 0;
		public int Period = 0;
	}

	public int MincostTickets(int[] days, int[] costs) {
		if (days == null || days.Length == 0 ||
			costs == null || costs.Length == 0)
			return 0;
		var tickets = _GenTickets(costs);
		return _MinCost(days, tickets);
	}

	private Ticket[] _GenTickets(int[] costs) {
		return new Ticket[]
		{
			new Ticket {Price = costs[0], Period = 1},
			new Ticket {Price = costs[1], Period = 7},
			new Ticket {Price = costs[2], Period = 30},
		};
	}

	private int _MinCost(int[] days, Ticket[] tickets) {

		var dp = new int[days.Length];

		for (int i = 0; i < dp.Length; ++i) {
			var date = days[i];
			dp[i] = _MinCost(date, days, tickets, dp);
		}
		return dp.Last();
	}

	private int _MinCost(int date, int[] days, Ticket[] tickets, int[] dp) {
		var minPrice = int.MaxValue;
		foreach (var ticket in tickets) {
			var price = ticket.Price;
			var lastDateIndex = _GetLastDateIndex(date - ticket.Period, days);
			
			if (lastDateIndex != -1)
				price += dp[lastDateIndex];
			
			minPrice = Math.Min(minPrice, price);
		}

		return minPrice;
	}

	private int _GetLastDateIndex(int date, int[] days) {
		var lastIndex = -1;
		for (int i = 0; i < days.Length; ++i) {
			if (days[i] > date) return lastIndex;
			else lastIndex = i;
		}
		return lastIndex;
	}
}