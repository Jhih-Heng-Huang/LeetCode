# 72. Edit Distance

from dataclasses import dataclass

class Solution:
    def minDistance(self, word1: str, word2: str) -> int:
        if not word1 and not word2:
            return 0

        if not word1:
            return len(word2)
        if not word2:
            return len(word1)

        dp = []

        for i in range(0, len(word1) + 1):
            dp.append([])

            for j in range(0, len(word2) + 1):
                val = 0
                if i == 0: val = j
                elif j == 0: val = i
                elif word1[i-1] == word2[j-1]: val = dp[i-1][j-1]
                else: val = 1 + min(dp[i-1][j], dp[i-1][j-1], dp[i][j-1])

                dp[i].append(val)

        return dp[-1][-1]

@dataclass
class MetaData:
    word1: str
    word2: str


if __name__ == "__main__":

    sol = Solution()

    inputs = [
        MetaData("horse", "ros"),
        MetaData("intention", "execution")
    ]

    for input in inputs:
        print(input.__str__() + ": " + sol.minDistance(input.word1, input.word2).__str__())
        