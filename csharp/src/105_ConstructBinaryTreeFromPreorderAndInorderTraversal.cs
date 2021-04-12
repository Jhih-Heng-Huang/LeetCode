// LeetCode: 105. Construct Binary Tree from Preorder and Inorder Traversal

namespace LeetCode.Problem_105
{
	public class LeetCode105ConstructBinaryTreeFromPreorderAndInorderTraversal
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

		public TreeNode BuildTree(int[] preorder, int[] inorder)
		{
			if (preorder == null || preorder.Length == 0 ||
				inorder == null || inorder.Length == 0)
				return null;
			return _BuildTree(
				preorder, 0, preorder.Length - 1,
				inorder, 0, inorder.Length - 1);
		}

		private TreeNode _BuildTree(
			int[] preorder, int leftPreorder, int rightPreorder,
			int[] inorder, int leftInorder, int rightInorder)
		{
			if (leftPreorder > rightPreorder ||
				leftInorder > rightInorder)
				return null;

			var node = new TreeNode();
			node.val = preorder[leftPreorder];
			if (leftPreorder == rightPreorder ||
				leftInorder == rightInorder)
				return node;

			var index = _FindIndex(node.val, inorder, leftInorder, rightInorder);
			var len = index - leftInorder;
			node.left = _BuildTree(
				preorder, leftPreorder+1, leftPreorder + len,
				inorder, leftInorder, index-1);
			node.right = _BuildTree(preorder, leftPreorder + len + 1, rightPreorder,
				inorder, index+1, rightInorder);
			return node;
		}

		private int _FindIndex(int value, int[] list, int left, int right)
		{
			if (left > right) return -1;

			for (int i = left; i <= right; ++i)
				if (list[i] == value) return i;

			return -1;
		}
	}
}