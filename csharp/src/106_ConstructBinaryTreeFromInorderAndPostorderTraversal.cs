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
		return _BuildTree(
			inorder, 0, inorder.Length-1,
			postorder, 0, postorder.Length-1);
	}

	private TreeNode _BuildTree(
		int[] inorder, int leftIn, int rightIn,
		int[] postorder, int leftPost, int rightPost)
	{
		if (leftIn > rightIn) return null;

		var val = postorder[rightPost];
		var node = new TreeNode(val);

		var index = leftIn;
		for (;index <= rightIn; ++index)
			if (inorder[index] == val) break;
		
		var leftLen = index-leftIn;
		node.left = _BuildTree(
			inorder, leftIn, index-1,
			postorder, leftPost, leftPost+leftLen-1
		);
		node.right = _BuildTree(
			inorder, index+1, rightIn,
			postorder, leftPost+leftLen, rightPost-1
		);

		return node;
	}
}