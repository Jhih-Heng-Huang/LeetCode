import sys

class DepthFirstSearch(object):
	def __init__(self):
		pass
	def sumNumbers(self, root):
		if root == None:
			return 0
		return self.SumPathNum(root, root.val)

	def SumPathNum(self, root, val):
		if root.left == None and root.right == None:
			return val
		sum = 0
		if root.left != None:
			sum += self.SumPathNum(root.left,
				val * 10 + root.left.val)
		if root.right != None:
			sum += self.SumPathNum(root.right,
				val * 10 + root.right.val)
		return sum

	# type times: List[List[]]
	# type N: int
	# rtype: dict{List[(target, weight)]}
	def GetAdjacencyList(self, times, N):
		(source , target, weight) = (0, 1, 2)
		adj_list = dict()
		for i in range(1, N+1):
			adj_list[i] = list()
		for edge in times:
			adj_list[edge[source]].append((edge[target], edge[weight]))
		return adj_list

	# type adj_list: dict{List[(target, weight)]}
	# type start_node: int
	# rtype: List[]
	def DijstraAlgo(self, adj_list, start_node):
		dist = dict()
		for key in adj_list.keys():
			dist[key] = (sys.maxint)
		dist[start_node] = 0
		
		# visit the start node then visit its neighbors
		# then visit their neighbors ...and so no
		# update the dist if the dist[key] > len
		stack = [start_node]
		while stack:
			node = stack.pop()
			for tar, wei in adj_list[node]:
				new_dist = dist[node] + wei
				if new_dist < dist[tar]:
					dist[tar] = new_dist
					stack.append(tar)
		return dist

	# :type times: List[List[int]]
	# :type N: int
	# :type K: int
	# :rtype: int
	def networkDelayTime(self, times, N, K):
		# turn times to the adjacency list
		adj_list = self.GetAdjacencyList(times, N)
		# find out the minimax network delay time
		dist = self.DijstraAlgo(adj_list, K)
		max_len = 0
		for length in dist.values():
			if length == sys.maxint:
				return -1
			elif length > max_len:
				max_len = length
		return max_len