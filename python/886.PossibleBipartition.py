# 886. Possible Bipartition

from typing import List
from dataclasses import dataclass

@dataclass
class _Node:
    Color: int
    Nexts: List[int]

class Solution:
    def possibleBipartition(self, N: int, dislikes: List[List[int]]) -> bool:
        if N == 0 or not dislikes or dislikes.count == 0:
            return True

        nodes = self.__genNodes(N, dislikes)

        for i in range(1, N+1):
            if nodes[i].Color == 0 and self.__hasCycle(i, 1, nodes):
                return False
        
        return True

    def __genNodes(self, num: int, edges: List[List[int]]) -> List[_Node]:
        nodes = []

        for i in range(0, num+1):
            nodes.append(_Node(0, []))

        for edge in edges:
            i = edge[0]
            j = edge[1]
            nodes[i].Nexts.append(j)
            nodes[j].Nexts.append(i)

        return nodes

    def __hasCycle(self, i: int, color: int, nodes: List[_Node]) -> bool:
        if nodes[i].Color == 0:
            nodes[i].Color = color

        nextColor = 2 if nodes[i].Color == 1 else 1

        for next in nodes[i].Nexts:
            if nodes[next].Color == 0 and self.__hasCycle(next, nextColor, nodes):
                return True
            if nodes[next].Color != nextColor:
                return True

        return False


@dataclass
class Input:
    numPerson: int
    dislikes: List[List[int]]

if __name__ == "__main__":
    sol = Solution()

    inputs = [
        Input(4, [[1,2],[1,3],[2,4]]),
        Input(3, [[1,2],[1,3],[2,3]]),
        Input(5, [[1,2],[2,3],[3,4],[4,5],[1,5]])
    ]

    for input in inputs:
        print (input.__str__() + ": " + sol.possibleBipartition(input.numPerson, input.dislikes).__str__())