/*
LeetCode: 513. Find Bottom Left Tree Value
*/

using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problem_513
{
	public class FindBottomLeftTreeValue {
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

		public int FindBottomLeftValue(TreeNode root) {
			if (root == null) return -1;

			var result = root.val;
			var currentRow = new List<TreeNode>();
			currentRow.Add(root);

			while (currentRow.Count > 0) {
				result = currentRow.First().val;

				var nextRow = new List<TreeNode>();
				foreach  (var node in currentRow) {
					if (node.left != null) nextRow.Add(node.left);
					if (node.right != null) nextRow.Add(node.right);
				}
				currentRow.Clear();
				currentRow.AddRange(nextRow);
			}

			return result;
		}
		
	}
}