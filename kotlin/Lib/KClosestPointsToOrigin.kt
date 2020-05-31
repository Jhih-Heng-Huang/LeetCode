package LeetCode.KClosestPointsToOrigin


/*
973. K Closest Points to Origin
Test cases:
[[1,3],[-2,2]]
1
 */

private data class Point(val x: Int, val y: Int)
{
    val distance = Math.hypot(x.toDouble(), y.toDouble())
    fun toIntArray() = intArrayOf(x, y)
}

fun kClosest(points: Array<IntArray>, K: Int): Array<IntArray>
{
    if (K == 0)
        return arrayOf<IntArray>()
    if (K == points.size)
        return points
    
    return points.map { Point(it[0], it[1]) }
        .sortedBy { it.distance }
        .slice(0..K-1)
        .map { it.toIntArray() }
        .toTypedArray()
}