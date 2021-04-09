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
			public int Cost;
			public int Period;
		}

		public int MincostTickets(int[] days, int[] costs)
		{
			if (days == null || days.Length == 0)
				return 0;
			
			var tickets = _GenTickets(costs);
			return _GetMinCost(days, tickets);
		}

		private Ticket[] _GenTickets(int[] costs)
			=> new Ticket[]
			{
				new Ticket
				{
					Cost = costs[0],
					Period = 1,
				},
				new Ticket
				{
					Cost = costs[1],
					Period = 7,
				},
				new Ticket
				{
					Cost = costs[2],
					Period = 30,
				},
			};

		private int _GetMinCost(int[] days, Ticket[] tickets)
		{
			var table = new int[days.Length];

			for (int i = 0; i < table.Length; ++i)
			{
				var minCost = int.MaxValue;
				foreach (var ticket in tickets)
				{
					var cost = ticket.Cost;
					for (int j = i-1; j >= 0; --j)
						if (days[j] <= days[i] - ticket.Period)
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