/*
LeetCode: 101. Symmetric Tree
*/

namespace LeetCode.Problem_101
{
	public class TreeNode {
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}

	public class Solution
	{
		public bool IsSymmetric(TreeNode root) {
			return root == null || _IsSymmetric(root.left, root.right);
		}

		private bool _IsSymmetric(TreeNode left, TreeNode right)
		{
			if (left == null || right == null)
				return left == right;
			else if (left.val != right.val)
				return false;
			else
				return _IsSymmetric(left.left, right.right) && _IsSymmetric(left.right, right.left);
		}
	}
}