#!/usr/bin/env python3
# 5. Longest Palindromic Substring

class Solution:
	def longestPalindrome(self, s: str) -> str:
		if not s or len(s) < 2:
			return s

		maxStr = ""
		for i in range(len(s)):
			str1 = self.__getLongestPalindrome(s, i, i)
			if len(str1) > len(maxStr): maxStr = str1

			str2 = self.__getLongestPalindrome(s, i, i+1)
			if len(str2) > len(maxStr): maxStr = str2


		return maxStr

	def __getLongestPalindrome(self, s:str, left:int, right:int) -> str:
		if not s:
			return s
		
		while left >= 0 and right < len(s) and s[left] == s[right]:
			left-=1
			right+=1
		
		left+=1

		return s[left:right]

if __name__ == "__main__":
	sol = Solution()
	inputs = ["babad", "cbbd"]

	for s in inputs:
		print(s + ": " + sol.longestPalindrome(s))