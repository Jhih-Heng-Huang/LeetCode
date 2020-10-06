// LeetCode: 5. Longest Palindromic Substring

class LeetCode5LongestPalindromicSubstring {
    fun longestPalindrome(s: String): String {
        if (s.isNullOrEmpty() || s.length < 2) return s;

        return `_FindLongestPalindrome`(s)
    }

    private fun _FindLongestPalindrome(s: String): String {
        var maxString = ""
        for (i in 0 until s.length) {
            val str1 = `_GetLongestPalindrome`(s, i, i)
            if (str1.length > maxString.length)
                maxString = str1

            val str2 = `_GetLongestPalindrome`(s, i, i+1)
            if (str2.length > maxString.length)
                maxString = str2
        }

        return maxString
    }

    private fun _GetLongestPalindrome(s: String, left: Int, right: Int): String {
        var leftIndex = left
        var rightIndex = right
        while (leftIndex <= 0 &&
            rightIndex < s.length &&
            s[leftIndex] == s[rightIndex])
        {
            --leftIndex
            ++rightIndex
        }

        ++leftIndex
        if (leftIndex > rightIndex) return ""
        return s.substring(leftIndex, rightIndex)
    }
}