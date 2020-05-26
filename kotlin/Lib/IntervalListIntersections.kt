package LeetCode.IntervalListIntersections

/*
986. Interval List Intersections
Test Cases:
[[0,2],[5,10],[13,23],[24,25]]
[[1,5],[8,12],[15,24],[25,26]]

[[0,10]]
[[0,0],[5,10]]

[[10,12],[18,19]]
[[1,6],[8,11],[13,17],[19,20]]
*/

public fun intervalIntersection(A: Array<IntArray>, B: Array<IntArray>): Array<IntArray>
{
    if (A.size == 0 || B.size == 0)
        return Array<IntArray>(0, {_ -> IntArray(0)})
    
    var result = mutableListOf<IntArray>()
    var aIndex = 0
    var bIndex = 0
    while (aIndex < A.size && bIndex < B.size)
    {
        _getIntersection(A[aIndex], B[bIndex])?.let { intersection -> result.add(intersection) }

        if (A[aIndex][1] < B[bIndex][1])
            ++aIndex
        else if (A[aIndex][1] == B[bIndex][1])
        {
            ++aIndex
            ++bIndex
        }
        else
            ++bIndex

    }
    return result.toTypedArray()
}

private fun _getIntersection(first: IntArray, second: IntArray): IntArray?
{
    val left = Math.max(first[0], second[0])
    val right = Math.min(second[1], second[1])
    if (left <= right)
        return intArrayOf(left, right)
    else
        return null
}