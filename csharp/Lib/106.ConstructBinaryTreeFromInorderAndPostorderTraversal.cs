// 106. Construct Binary Tree from Inorder and Postorder Traversal

using System;

public class LeetCode106ConstructBinaryTreeFromInorderAndPostorderTraversal {
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

	public TreeNode BuildTree(int[] inorder,
							  int[] postorder)
	{
		if (inorder.Length == 0 || postorder.Length == 0) return null;

		return _BuildTree(
			inorder, 0, inorder.Length-1,
			postorder, 0, postorder.Length-1);
	}

	private TreeNode _BuildTree(
		int[] inorder,
		int lIn, int rIn,
		int[] postorder,
		int lPost, int rPost)
	{
		if (lIn > rIn) return null;

		var val = postorder[rPost];
		var node = new TreeNode(val);
		if (lIn == rIn) return node;

		var index = Array.IndexOf(inorder, val);
		var len = index - lIn;

		node.left = _BuildTree(
			inorder, lIn, index - 1,
			postorder, lPost, lPost + len - 1);
		node.right = _BuildTree(
			inorder, index+1, rIn,
			postorder, lPost+len, rPost-1);
		return node;
	}
}