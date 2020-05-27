package LeetCode.ContiguousArray

/*
525. Contiguous Array

Test cases:
[0,1]
[0,1,0]
[0,1,0,1]
[0,0,0,0,1,1,1]
*/

fun findMaxLength(nums: IntArray): Int
{
    var result = 0
    var count = 0
    var diffIndexMap = mutableMapOf<Int, Int?>(0 to -1)

    for (index in 0 until nums.size)
    {
        if (nums[index] == 0) ++count
        else --count

        if (diffIndexMap.containsKey(count))
            result = Math.max(result, index - diffIndexMap[count]!!)
        else
            diffIndexMap[count] = index
    }
    return result
}