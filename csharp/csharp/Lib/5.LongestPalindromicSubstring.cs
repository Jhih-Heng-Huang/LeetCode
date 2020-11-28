using System;

public class LongestPalindromicSubstring {
    public string LongestPalindrome(string s) {
		if (s == null || s.Length < 2)
			return s;
		
		var maxStr = string.Empty;

		for (int i = 0; i < s.Length; ++i) {
			var str1 = _GetLongPalindrome(s, i, i);
			if (maxStr.Length < str1.Length)
				maxStr = str1;

			var str2 = _GetLongPalindrome(s, i, i+1);
			if (maxStr.Length < str2.Length)
				maxStr = str2;
		}

		return maxStr;
    }

	private string _GetLongPalindrome(
		string s, int left, int right)
	{
		if (left > right)
			return string.Empty;
		
		while (left >= 0 && right < s.Length &&
			   s[left] == s[right])
		{
			--left;
			++right;
		}

		++left;
		--right;
		var len = right - left + 1;

		return s.Substring(left, len);
	}
}