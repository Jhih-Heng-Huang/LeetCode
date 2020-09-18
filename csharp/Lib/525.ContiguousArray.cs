/*
525. Contiguous Array
*/

using System;
using System.Collections.Generic;

public class ContiguousArray {
    public int FindMaxLength(int[] nums) {
        if (nums == null || nums.Length == 0)
			return 0;

		var dp = new Dictionary<int, int>();
		dp[0] = -1;

		var maxLen = 0;
		var sum = 0;
		for (int i = 0; i < nums.Length; ++i) {
			sum += nums[i] == 1? 1 : -1;

			if (dp.ContainsKey(sum))
				maxLen = Math.Max(maxLen, i - dp[sum]);
			else
				dp[sum] = i;
		}

		return maxLen;
    }
}