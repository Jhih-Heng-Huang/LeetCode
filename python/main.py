from dfs import DepthFirstSearch as dfs
from bfs import BreadthFirstSearch as bfs

if __name__ == '__main__':
	sol = bfs()
	n = 6
	edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]
	print(sol.findMinHeightTrees(n, edges))
