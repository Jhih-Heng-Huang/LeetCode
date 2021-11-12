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
			var list = new List<int>();
			if (root == null) return list;

			var queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				var maxVal = queue.Max(node => node.val);
				list.Add(maxVal);

				for (int count = queue.Count; count > 0; --count)
				{
					var node = queue.Dequeue();
					if (node.left != null) queue.Enqueue(node.left);
					if (node.right != null) queue.Enqueue(node.right);
				}
			}

			return list;
		}
	}
}