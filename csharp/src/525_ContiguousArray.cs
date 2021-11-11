/*
LeetCode: 525. Contiguous Array
*/

using System;
using System.Collections.Generic;


public class ContiguousArray {
    public int FindMaxLength(int[] nums) {
		var maxLength = 0;
		var currentIndex = -1;
		var sum = 0;

		var startIndexDic = new Dictionary<int, int>();
		startIndexDic[sum] = currentIndex;
		++currentIndex;

		for (;currentIndex < nums.Length; ++currentIndex)
		{
			if (nums[currentIndex] == 1) ++sum;
			else --sum;

			if (startIndexDic.ContainsKey(sum))
				maxLength = Math.Max(maxLength, currentIndex - startIndexDic[sum]);
			else
				startIndexDic[sum] = currentIndex;
		}

		return maxLength;
    }
}