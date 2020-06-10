package LeetCode.CoinChange2

/*
Coin Change 2
Test cases:
5
[1,2,5]
3
[2]
0
[10]
50
[]
500
[1,5,10,25,40,50]
5000
[102, 89, 76, 63, 50, 37, 24, 11]
 */

fun change(amount: Int, coins: IntArray): Int
{
    val table = IntArray(amount + 1)
    table[0] = 1

    for (coin in coins)
        for (i in coin..amount)
            table[i] += table[i-coin]
    
    return table[amount]
}
