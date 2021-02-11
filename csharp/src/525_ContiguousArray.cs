/*
LeetCode: 525. Contiguous Array
*/

using System;
using System.Collections.Generic;


public class ContiguousArray {
	private class Mapping {
		private Dictionary<int, int> _dic = new Dictionary<int, int>();

		public bool TryMap(int diffLen, out int index) {
			if (!_dic.ContainsKey(diffLen)) {
				index = int.MinValue;
				return false;
			}

			index = _dic[diffLen];
			return true;
		}

		public bool Add(int diffLen, int index) {
			_dic[diffLen] = index;
			return true;
		}
	}
    public int FindMaxLength(int[] nums) {
    	if (nums == null || nums.Length == 0) return 0;

		Mapping dic = new Mapping();
		dic.Add(0, -1);

		var maxLen = 0;
		var diffLen = 0;
		for (int i = 0; i < nums.Length; ++i) {
			diffLen += (nums[i] == 0)? 1 : -1;

			var index = 0;
			if (dic.TryMap(diffLen, out index)) {
				maxLen = Math.Max(i - index, maxLen);
			} else {
				dic.Add(diffLen, i);
			}
		}

		return maxLen;
    }
}