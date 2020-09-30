// 983. Minimum Cost For Tickets

private data class Ticket(val cost: Int, val period: Int)

class LeetCode983MinimumCostForTickets {
    fun mincostTickets(days: IntArray, costs: IntArray): Int {
        val tickets = arrayOf(
            Ticket(costs[0], 1),
            Ticket(costs[1], 7),
            Ticket(costs[2], 30))

        var dp = IntArray(days.size) {0}
        
        for (i in 0 until dp.size) {
            var minCost = Int.MAX_VALUE

            for (ticket in tickets) {
                var cost = ticket.cost
                val lastDay = days[i] - ticket.period
                val lastIndex = days.filter { day -> day <= lastDay }.size - 1

                if (lastIndex >= 0)
                    cost += dp[lastIndex];

                minCost = minOf(minCost, cost)
            }

            dp[i] = minCost
        }

        return dp.last()
    }
}