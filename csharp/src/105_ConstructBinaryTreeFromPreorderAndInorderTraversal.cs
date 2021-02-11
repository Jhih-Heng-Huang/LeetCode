// LeetCode: 105. Construct Binary Tree from Preorder and Inorder Traversal

namespace csharp.Lib
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
			int[] preorder, int leftPreOrder, int rightPreorder,
			int[] inorder, int leftInorder, int rightInorder)
		{
			if (leftPreOrder > rightPreorder) return null;

			var rootVal = preorder[leftPreOrder];
			var node = new TreeNode(rootVal);

			if (leftPreOrder == rightPreorder) return node;

			var index = _FindIndexOf(rootVal, inorder, leftInorder, rightInorder);
			var length = index - leftInorder;

			node.left = _BuildTree(
				preorder, leftPreOrder + 1, leftPreOrder + length,
				inorder, leftInorder, index - 1);
			node.right = _BuildTree(
				preorder, leftPreOrder + length + 1, rightPreorder,
				inorder, index + 1, rightInorder);

			return node;
		}

		private int _FindIndexOf(int val, int[] list, int left, int right) {
			if (left > right) return -1;

			var selectedIndex = -1;

			for (int i = left; i <= right; ++i) {
				if (list[i] == val) {
					selectedIndex = i;
					break;
				}
			}

			return selectedIndex;
		}
	}
}