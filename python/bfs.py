class BreadthFirstSearch(object):
	def __init__(self):
		pass

	def genAdjList(self, n, edges):
		adj_list = dict()
		for i in range(0, n):
			adj_list[i] = set()
		fir_node = 0
		sec_node = 1
		for edge in edges:
			adj_list[edge[fir_node]].add(edge[sec_node])
			adj_list[edge[sec_node]].add(edge[fir_node])
		return adj_list

	def findTreeCenter(self, adj_list):
		stack = list()
		while adj_list:
			stack = list()
			# find the leaves
			for key, val in adj_list.items():
				if len(val) <= 1:
					stack.append(key)
			# remove the leaves
			for leaf in stack:
				for node in adj_list[leaf]:
					adj_list[node].remove(leaf)
				adj_list.pop(leaf)
		return stack
	def findMinHeightTrees(self, n, edges):
		# gen the adjacency list of tree
		adj_list = self.genAdjList(n, edges)
		# find the centers of tree by BFS
		return self.findTreeCenter(adj_list)