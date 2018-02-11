from dfs import DepthFirstSearch as dfs
from tree import TreeNode

if __name__ == '__main__':
	sol = dfs()
	root = TreeNode(5)
	root.left = TreeNode(2)
	root.right = TreeNode(3)
	root.left.left = TreeNode(0)
	root.right.left = TreeNode(0)
	root.right.right = TreeNode(1)
	print sol.sumNumbers(root)
