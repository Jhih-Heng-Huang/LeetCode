/*
LeetCode: 1008. Construct Binary Search Tree from Preorder Traversal
*/
using System.Linq;

namespace LeetCode.Problem_1008
{    
	public class ConstructBinarySearchTreeFromPreorderTraversal {
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

		public TreeNode BstFromPreorder(int[] preorder) {
			return _BuildTree(preorder, 0, preorder.Length-1);
		}

		private TreeNode _BuildTree(int[] preorder, int left, int right)
		{
			if (left > right) return null;

			var val = preorder[left];
			var node = new TreeNode(val);

			var index = left;
			for (; index <= right; ++index)
				if (preorder[index] > val) break;
			
			node.left = _BuildTree(preorder, left+1, index-1);
			node.right = _BuildTree(preorder, index, right);
			return node;
		}
	}
}
