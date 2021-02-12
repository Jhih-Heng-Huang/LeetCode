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
			if (preorder == null || preorder.Length == 0) return null;

			var node = new TreeNode();
			node.val = preorder.First();
			node.left = BstFromPreorder(preorder.Where(v => v < node.val).ToArray());
			node.right = BstFromPreorder(preorder.Where(v => v > node.val).ToArray());
			return node;
		}
	}
}
