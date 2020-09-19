#!/usr/bin/env python3
# 983. Minimum Cost For Tickets

import sys

from typing import List
from dataclasses import dataclass

@dataclass
class _Ticket:
	Cost: int
	Period: int

class Solution:

	def mincostTickets(self, days: List[int], costs: List[int]) -> int:
		periods = [1, 7, 30]
		tickets = self.__genTickets(costs, periods)
		
		return self.__getMinTickets(days, tickets)

	def __genTickets(self, costs: List[int], periods: List[int]) -> List[_Ticket]:
		return [_Ticket(costs[i], periods[i]) for i in range(len(costs))]
	
	def __getMinTickets(self, days: List[int], tickets: List[_Ticket]) -> int:
		dp = []
		for i in range(len(days)):
			minCost = sys.maxsize
			for ticket in tickets:
				newCost = ticket.Cost
				lastDay = days[i] - ticket.Period
				newList = [d for d in days if d <= lastDay]
				last = len(newList) - 1

				if last >= 0:
					newCost = newCost + dp[last]

				minCost = min(minCost, newCost)
			dp.append(minCost)
		return dp[-1]


if __name__ == "__main__":
	sol = Solution()
	print (sol.mincostTickets([1,4,6,7,8,20],[2,7,15]))
	print (sol.mincostTickets([1,2,3,4,5,6,7,8,9,10,30,31],[2,7,15]))