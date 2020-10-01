// 56. Merge Intervals

class LeetCode56MergeIntervals {
    fun merge(intervals: Array<IntArray>): Array<IntArray> {
        if (intervals.size < 2)
            return intervals

        val list = mutableListOf<IntArray>()

        intervals.sortBy { i -> i[0] }

        var i = 0
        while (i < intervals.size) {
            var newInterval = intervals[i].clone()

            var j = i+1
            while (j < intervals.size) {
                if (!`_IsIntersect`(newInterval, intervals[j])) {
                    break
                }
                
                newInterval[0] = minOf(newInterval[0], intervals[j][0])
                newInterval[1] = maxOf(newInterval[1], intervals[j][1])
                ++j
            }
            i = j

            list.add(newInterval)
        }

        return list.toTypedArray()
    }

    private fun _IsIntersect(interval1: IntArray, interval2: IntArray): Boolean {
        val left = maxOf(interval1[0], interval2[0])
        val right = minOf(interval1[1], interval2[1])

        return left <= right
    }
}