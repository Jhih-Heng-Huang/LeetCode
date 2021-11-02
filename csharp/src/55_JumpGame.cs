/*
LeetCode: 55. Jump Game
*/

namespace LeetCode.Problem_55
{
	public class Solution {
		public bool CanJump(int[] nums)
		{
			if (nums.Length == 1) return true;

			var maxIndex = 0;
			for (int i = 0; i <= maxIndex && i < nums.Length; ++i)
			{
				if (nums[i] + i > maxIndex)
					maxIndex = nums[i] + i;
				
				if (maxIndex >= nums.Length - 1)
					return true;
			}
			return false;
		}
	}
}