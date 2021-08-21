/*
LeetCode: 45. Jump Game II
*/

namespace LeetCode.Problem_45
{
	public class Solution {
		public int Jump(int[] nums) {
			if (nums.Length == 1) return 0;

			// Declare table
			var minJumpTable = new int[nums.Length];
			for (int i = 0; i < nums.Length; ++i)
				minJumpTable[i] = int.MaxValue;
			minJumpTable[0] = 0;

			// run dynamic programming
			for (int i = 0; i < nums.Length; ++i)
			{
				var maxIndex = i + nums[i] < nums.Length-1?
					i + nums[i] : nums.Length-1;
				for (int j = i+1; j <= maxIndex; ++j)
				{
					if (minJumpTable[j] > minJumpTable[i] + 1)
						minJumpTable[j] = minJumpTable[i] + 1;
				}
			}
			return minJumpTable[minJumpTable.Length - 1];
		}
	}
}