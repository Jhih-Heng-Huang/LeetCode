from dfs import DepthFirstSearch as dfs
from tree import TreeNode

if __name__ == '__main__':
	sol = dfs()
	times = [[1,2,3],[1,3,1],[3,4,5]]
	print sol.networkDelayTime(times = times, N=4, K=3)

	times = [[2,1,1],[2,3,1],[3,4,1]]
	print sol.networkDelayTime(times = times, N=4, K=2)
