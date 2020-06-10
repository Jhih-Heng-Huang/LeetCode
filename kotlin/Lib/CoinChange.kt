package LeetCode.CoinChange

/*
322. Coin Change
Test cases:
[1,2,5]
11
[2]
3
[]
34
[1,2,3,4]
0
[]
20
[1,2,3,4]
34
[1,2,3,4]
5000
 */

fun coinChange(coins: IntArray, amount: Int): Int
{
    val table = Array<Int> (amount + 1, {amount + 1})
    table[0] = 0

    for (coin in coins)
        for (i in coin..amount)
            table[i] = minOf(table[i], 1 + table[i-coin])

    return if (table[amount] > amount) -1 else table[amount]
}