// LeetCode: 5. Longest Palindromic Substring

using System;

namespace LeetCode.Problem_5
{
	public class LongestPalindromicSubstring {
		public string LongestPalindrome(string s) {
			int maxLen = 0;
			var result = string.Empty;
			for (int i = 0; i < s.Length; ++i)
			{
				var subStr1 = _FindLongestPalindrome(s, i, i);
				if (maxLen < subStr1.Length)
				{
					maxLen = subStr1.Length;
					result = subStr1;
				}
				var subStr2 = _FindLongestPalindrome(s, i, i+1);
				if (maxLen < subStr2.Length)
				{
					maxLen = subStr2.Length;
					result = subStr2;
				}
			}
			return result;
		}

		private string _FindLongestPalindrome(string s, int leftIdx, int rightIdx)
		{
			while (leftIdx >= 0 && rightIdx < s.Length)
			{
				if (s[leftIdx] != s[rightIdx]) break;
				--leftIdx;
				++rightIdx;
			}

			++leftIdx;
			--rightIdx;
			return s.Substring(leftIdx, rightIdx - leftIdx + 1);			
		}
	}
}