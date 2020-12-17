// LeetCode: 5. Longest Palindromic Substring

using System;

public class LongestPalindromicSubstring {
    public string LongestPalindrome(string s) {
		if (s == null || s.Length < 2) return s;

		var maxLength = int.MinValue;
		var maxString = string.Empty;
		for (int i = 1; i < s.Length; ++i) {
			var str1 = _FindLongestPalindrome(s, i, i);
			if (maxLength < str1.Length) {
				maxLength = str1.Length;
				maxString = str1;
			}

			var str2 = _FindLongestPalindrome(s, i-1, i);
			if (maxLength < str2.Length) {
				maxLength = str2.Length;
				maxString = str2;
			}
		}

		return maxString;
    }

	private string _FindLongestPalindrome(string s, int left, int right) {
		if (left > right) return string.Empty;

		while (left >= 0 && right < s.Length && s[left] == s[right]) {
			--left;
			++right;
		}

		++left;
		--right;

		return s.Substring(left, right - left + 1);
	}
}