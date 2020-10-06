// 313. Super Ugly Number

class LeetCode313SuperUglyNumber {
    private data class PrimePointer(val value: Int, var pos: Int)

    fun nthSuperUglyNumber(n: Int, primes: IntArray): Int {
        if (n == 1) return 1

        val pps = primes.map { PrimePointer(it, 0) }.toTypedArray()
        var dp = `_GenInitTable`(n)

        for (i in 0 until n) {
            dp[i] = _GetNextUglyNumber(dp, pps)
        }

        return dp[n-1]
    }

    private fun _GenInitTable(num: Int): IntArray {
        var dp = IntArray(num) {0}
        dp[0] = 1
        return dp
    }

    private fun _GetNextUglyNumber(dp: IntArray, pps: Array<PrimePointer>): Int {
        var uglyNumber = pps.map { it.value * dp[it.pos] }.min()!!

        for (p in pps) {
            if (uglyNumber == p.value * dp[p.pos])
                ++p.pos
        }

        return uglyNumber
    }
}