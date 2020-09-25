# 240.Search a 2D Matrix II

from typing import List
from dataclasses import dataclass

class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        if not matrix: return False

        row = 0
        col = len(matrix[0]) - 1

        while row < len(matrix) and col >= 0:
            if matrix[row][col] == target: return True
            elif matrix[row][col] < target: row +=1
            else: col -= 1
        
        return False

@dataclass
class MetaData:
    matrix: List[List[int]]
    target: int

if __name__ == "__main__":
    sol = Solution()

    inputs = [
        MetaData(
            [[1,4,7,11,15],
            [2,5,8,12,19],
            [3,6,9,16,22],
            [10,13,14,17,24],
            [18,21,23,26,30]],
            5)
    ]

    for input in inputs:
        print(input.__str__() + ": " + sol.searchMatrix(input.matrix, input.target).__str__())