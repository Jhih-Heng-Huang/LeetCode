/*
LeetCode: 983. Minimum Cost For Tickets
*/

using System;
using System.Linq;

namespace LeetCode.Problem_983
{	
	public class Solution
	{
		private class Ticket
		{
			public int Period;
			public int Cost;
		}
		public int MincostTickets(int[] days, int[] costs)
		{
			var tickets = _GenTickets(costs);
			return _FindMinCost(days, tickets);
		}

		private Ticket[] _GenTickets(int[] costs)
		{
			return new Ticket[]
			{
				new Ticket
				{
					Period = 1,
					Cost = costs[0],
				},
				new Ticket
				{
					Period = 7,
					Cost = costs[1],
				},
				new Ticket
				{
					Period = 30,
					Cost = costs[2],
				},
			};
		}

		private int _FindMinCost(int[] days, Ticket[] tickets)
		{
			var table = new int[days.Length];

			for (int i = 0; i < table.Length; ++i)
			{
				var minCost = int.MaxValue;
				foreach (var ticket in tickets)
				{
					var cost = ticket.Cost;
					for (int j = i-1; j >= 0; --j)
						if (days[i] - days[j] >= ticket.Period)
						{
							cost += table[j];
							break;
						}
					minCost = Math.Min(minCost, cost);
				}
				table[i] = minCost;
			}
			return table.Last();
		}
	}
}