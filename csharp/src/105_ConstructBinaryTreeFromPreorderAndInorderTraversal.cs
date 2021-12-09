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
			return _BuildTree(
				preorder, 0, preorder.Length-1,
				inorder, 0, inorder.Length-1);
		}

		private TreeNode _BuildTree(
			int[] preorder, int headPreorder, int tailPreorder,
			int[] inorder, int headInorder, int tailInorder)
		{
			if (headPreorder > tailPreorder) return null;

			var node = new TreeNode();
			node.val = preorder[headPreorder];

			var index = _FindIndexOf(inorder, headInorder, tailInorder, node.val);
			var len = index - headInorder;

			node.left = _BuildTree(
				preorder, headPreorder + 1, headPreorder + len,
				inorder, headInorder, index - 1
			);
			node.right = _BuildTree(
				preorder, headPreorder + len + 1, tailPreorder,
				inorder, index + 1, tailInorder
			);

			
			return node;
		}

		private int _FindIndexOf(int[] list, int head, int tail, int val)
		{
			for (int i = head; i <= tail; ++i)
				if (list[i] == val)
					return i;
			return -1;
		}

	}
}