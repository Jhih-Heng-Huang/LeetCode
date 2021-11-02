/*
LeetCode: 45. Jump Game II
*/

using System;

namespace LeetCode.Problem_45
{
	public class Solution {
		public int Jump(int[] nums) {
			// get min steps
			var index = 0;
			var farCanReach = 0;
			var endIndex = 0;
			var minSteps = 0;
			while (endIndex < nums.Length-1)
			{
				while (index <= endIndex && index < nums.Length)
				{
					farCanReach = Math.Max(farCanReach, nums[index] + index);
					++index;
				}
				endIndex = farCanReach;
				++minSteps;
			}
			return minSteps;
		}
	}
}