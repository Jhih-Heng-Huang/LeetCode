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
			
