// 264. Ugly Number II


class LeetCode264UglyNumberII {
    private data class PrimePointer(val `val`: Int, var pos: Int)
    fun nthUglyNumber(n: Int): Int {
        if (n == 1) return 1

        val dp = IntArray(n)
        dp[0] = 1

        val pps = arrayOf(
            PrimePointer(2, 0),
            PrimePointer(3, 0),
            PrimePointer(5, 0))

        for (i in 1 until n) {
            dp[i] = pps.map { p -> p.`val` * dp[p.pos] }.min()!!

            for (p in pps)
                if (dp[i] == p.`val` * dp[p.pos])
                    ++p.pos
        }

        return dp[n-1]
    }
}