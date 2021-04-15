// LeetCode: 5. Longest Palindromic Substring

using System;

namespace LeetCode.Problem_5
{
	public class LongestPalindromicSubstring {
		public string LongestPalindrome(string s) {
			if (s == null || s.Length == 0)
				return string.Empty;
			if (s.Length == 1)
				return s;
			
			var result = string.Empty;
			for (int i = 0; i < s.Length; ++i)
			{
				var str1 = _FindLongestPalindrome(s, i-1, i);
				if (str1.Length > result.Length)
					result = str1;
				
				var str2 = _FindLongestPalindrome(s, i, i);
				if (str2.Length > result.Length)
					result = str2;
			}

			return result;
		}

		private string _FindLongestPalindrome(string s, int left, int right)
		{
			while (left >= 0 && right < s.Length && s[left] == s[right])
			{
				--left;
				++right;
			}
			++left;
			--right;
			
			if (left > right)
				return string.Empty;
			return s.Substring(left, right - left + 1);
		}
	}
}