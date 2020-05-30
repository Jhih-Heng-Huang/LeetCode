package LeetCode.CountingBits

/*
338. Counting Bits
Test cases:
2
3
4
5
6
*/

fun countBits(num: Int): IntArray
{
    val result = mutableListOf<Int>()
    if (num < 0) return IntArray(0)

    for (i in 0..num)
    {
        if (i < 2)
            result.add(i)
        else
        {
            result.add(result[i % 2] + result[i / 2])
        }
    }
    return result.toIntArray()
}