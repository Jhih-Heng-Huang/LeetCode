/*
525. Contiguous Array
*/

using System;
using System.Collections.Generic;


public class ContiguousArray {
	private class DiffLen2IndexDic {
		private Dictionary<int, int> _dic = new Dictionary<int, int>();

		public void Set(int diffLen, int index) {
			_dic[diffLen] = index;
		}
		public bool TryGetIndex(int diffLen, out int index) {
			index = -10;
			if (!_dic.ContainsKey(diffLen)) return false;

			index = _dic[diffLen];
			return true;
		}
	}

    public int FindMaxLength(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

		var maxLen = 0;
		var dic = new DiffLen2IndexDic();
		dic.Set(0, -1);

		var diff = 0;
		for (int i = 0; i < nums.Length; ++i) {
			diff += (nums[i] == 0)? 1 : -1;
			if (dic.TryGetIndex(diff, out var preIndex))
				maxLen = Math.Max(maxLen, i - preIndex);
			else
				dic.Set(diff, i);
		}
		return maxLen;
    }
}