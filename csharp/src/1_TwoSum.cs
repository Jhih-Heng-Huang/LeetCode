/*
LeetCode: 1.Two Sum
*/

using System.Collections.Generic;

namespace LeetCode.Problem_1
{
	public class LeetCodeTwoSum {
		public int[] TwoSum(int[] nums, int target) {
			if (nums == null || nums.Length == 0)
				return new int[]{};

			var diffToIndex = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length; ++i) {
				var num = nums[i];
				if (diffToIndex.ContainsKey(num))
					return new int[]{diffToIndex[num], i};
				
				diffToIndex[target - num] = i;
			}
			return new int[]{};
		}
	}
}