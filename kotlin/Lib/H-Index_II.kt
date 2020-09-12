package LeetCode.H_Index_II

/*
275. H-Index II
Test cases:
[0,1,3,5,6]
[3,3,3]
 */

fun hIndex(citations: IntArray): Int {
    return hIndex(citations, 0, citations.size - 1)
}

private fun hIndex(citations: IntArray, leftIndex: Int, rightIndex: Int): Int
{
    if (leftIndex > rightIndex)
        return 0

    val index = (leftIndex + rightIndex) / 2

    val N = citations.size
    val h = N - index
    
    val isHIndex =
        (index == 0 && citations[0] >= N) ||
        (citations[index] >= h && citations[index-1] <= h)
    
    if (isHIndex)
        return maxOf(h, hIndex(citations, index+1, rightIndex))
    else
        return maxOf(0,
        if (citations[index] < h) hIndex(citations, index+1, rightIndex)
        else hIndex(citations, leftIndex, index-1))
}