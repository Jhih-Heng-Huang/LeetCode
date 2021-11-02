/*
448. Find All Numbers Disappeared in an Array
*/

using System.Collections.Generic;

namespace LeetCode.Problem_448
{
	public class Solution {
		public IList<int> FindDisappearedNumbers(int[] nums) {
			if (nums.Length == 1) return new List<int>();

			var record = new bool[nums.Length+1];
			foreach (var num in nums)
			{
				record[num] = true;
			}

			var result = new List<int>();
			for (int i = 1; i <= nums.Length; ++i)
			{
				if (!record[i]) result.Add(i);
			}

			return result;
		}
	}
}