public class DepthFirstSearch {
	public int sumNumbers(TreeNode root) {
		if (root == null) {
			return 0;
		} else {
			return SumNumbers(root, root.val);
		}
	}

	private int SumNumbers(TreeNode root, int val) {
		if (root.left == null && root.right == null) {
			return val;
		}
		int sum_val = 0;
		if (root.left != null) {
			int left_val = val * 10 + root.left.val;
			sum_val += SumNumbers(root.left, left_val);
		}
		if (root.right != null) {
			int right_val = val * 10 + root.right.val;
			sum_val += SumNumbers(root.right, right_val);
		}
		return sum_val;
	}
}