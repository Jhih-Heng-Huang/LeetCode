// 787. Cheapest Flights Within K Stops

data class Edge(val src: Int, val dst: Int, val weight: Int)

class LeetCode787CheapestFlightsWithinKStops {
    fun findCheapestPrice(n: Int, flights: Array<IntArray>, src: Int, dst: Int, K: Int): Int {
        return _FindCheapestPrice(n, flights.map { Edge(it[0], it[1], it[2]) }.toTypedArray(), src, dst, K)
    }

    private fun _FindCheapestPrice(n: Int, edges: Array<Edge>, src: Int, dst: Int, K:Int): Int {
        if (n < 2 || edges.isEmpty()) return 0;

        var dp = IntArray(n) { Int.MAX_VALUE }
        dp[src] = 0

        for (i in 0..K) {
            dp = `_UpdateTable`(edges, dp)
        }

        if (dp[dst] == Int.MAX_VALUE) return -1
        else return dp[dst]
    }

    private fun _UpdateTable(edges: Array<Edge>, dp: IntArray): IntArray {
        val temp = dp.clone()

        for (edge in edges) {
            if (dp[edge.src] == Int.MAX_VALUE) continue

            temp[edge.dst] = minOf(temp[edge.dst], dp[edge.src] + edge.weight)
        }
        return temp
    }
}