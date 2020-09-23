# 518. Coin Change 2

from typing import List
from dataclasses import dataclass

class Solution:
    def change(self, amount: int, coins: List[int]) -> int:
        dp = [0] * (amount + 1)
        dp[0] = 1

        for coin in coins:
            for i in range(coin, amount+1):
                dp[i] += dp[i-coin]

        return dp[amount]

@dataclass
class Input:
    amount: int
    coins: List[int]

if __name__ == "__main__":
    sol = Solution()

    inputs = [
        Input(5, [1,2,4]),
        Input(10, [3,5]),
        Input(10, []),
        Input(0, [10,30]),
        Input(5,[20])]

    for input in inputs:
        print(input.__str__() + ": " + sol.change(input.amount, input.coins).__str__())