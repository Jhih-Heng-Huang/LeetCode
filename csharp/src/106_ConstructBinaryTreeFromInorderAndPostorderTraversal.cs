// 106. Construct Binary Tree from Inorder and Postorder Traversal

using System;
using System.Linq;

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
		if (inorder == null ||
			inorder.Length == 0)
			return null;
		return _BuildTree(
			inorder, 0, inorder.Length-1,
			postorder, 0, postorder.Length-1);
	}

	private TreeNode _BuildTree(
		int[] inorder, int inL, int inR,
		int[] postorder, int postL, int postR)
	{
		if (inL > inR)
			return null;
		
		var node = new TreeNode();
		node.val = postorder[postR];
		if (inL == inR) return node;

		var i = inorder.ToList().FindIndex(v => v == node.val);
		var len = i - inL;

		node.left = _BuildTree(
			inorder, inL, i-1,
			postorder, postL, postL + len-1);
		node.right = _BuildTree(
			inorder, i+1, inR,
			postorder, postL + len, postR-1);

		return node;
	}
}