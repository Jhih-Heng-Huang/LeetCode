/*
LeetCode: 515. Find Largest Value in Each Tree Row
*/

using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problem_515
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

	public class FindLargestValueInEachTreeRow {
		public IList<int> LargestValues(TreeNode root) {
			if (root == null) return new List<int>();

			var list = new List<int>();
			var row = new List<TreeNode>();
			row.Add(root);

			while (row.Count > 0) {
				var max = row.Select(node => node.val).Max();
				list.Add(max);

				var nextRow = new List<TreeNode>();
				foreach (var node in row)
				{
					if (node.left != null)
						nextRow.Add(node.left);
					if (node.right != null)
						nextRow.Add(node.right);
				}
				row.Clear();
				row.AddRange(nextRow);
			}

			return list;
		}
	}
}