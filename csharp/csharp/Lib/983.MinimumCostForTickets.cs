using System;
using System.Linq;

public class Solution {
	private class Ticket {
		public int Cost;
		public int Period;
	}

    public int MincostTickets(int[] days, int[] costs) {
		if (days == null || days.Length == 0 ||
			costs == null || costs.Length == 0)
			return 0;
		
		var tickets = _GenTickets(costs);
		return _GetMinCost(days, tickets);
    }

	private Ticket[] _GenTickets(int[] costs) {
		return new Ticket[] {
			new Ticket {
				Cost = costs[0],
				Period = 1,
			},
			new Ticket {
				Cost = costs[1],
				Period = 7,
			},
			new Ticket {
				Cost = costs[2],
				Period = 30,
			},
		};
	}

	private int _GetMinCost(int[] days, Ticket[] tickets) {
		var dp = new int[days.Length];

		for (int i = 0; i < dp.Length; ++i) {
			var minCost = int.MaxValue;

			foreach (var ticket in tickets) {
				var cost = ticket.Cost;
				var lastDay = days[i] - ticket.Period;
				var index = days.Where(d => d <= lastDay).Count()-1;

				if (index >= 0)
					cost += dp[index];

				minCost = Math.Min(minCost, cost);
			}
			dp[i] = minCost;
		}

		return dp.Last();
	}
}