/*
LeetCode: 283. Move Zeroes
*/

using System.Collections.Generic;

namespace LeetCode.Problem_283
{
	public class Solution
	{
		public void MoveZeroes(int[] nums) {
			if (nums.Length == 1) return;

			var zeroQueue = new Queue<int>();
			for (int i = 0; i < nums.Length; ++i)
			{
				if (nums[i] == 0)
					zeroQueue.Enqueue(i);
				else if (zeroQueue.Count > 0)
				{
					var pos = zeroQueue.Dequeue();
					nums[pos] = nums[i];
					nums[i] = 0;
					zeroQueue.Enqueue(i);
				}
			}
		}
	}
}