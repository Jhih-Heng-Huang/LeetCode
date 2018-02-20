import java.util.Stack;
import java.util.Map;
import java.util.TreeMap;
import java.lang.Integer;

public class DepthFirstSearch {
	public int sumNumbers(TreeNode root) {
		if (root == null) {
			return 0;
		}
		// using stack and map to implement DFS
		Stack<TreeNode> stack = new Stack<TreeNode>();
		stack.push(root);
		int sum = 0;
		while (!stack.empty()) {
			TreeNode node = stack.pop();

			if (node.left != null) {
				node.left.val += node.val * 10;
				stack.push(node.left);
			}
			if (node.right != null) {
				node.right.val += node.val * 10;
				stack.push(node.right);
			}
			if (node.left == null && node.right == null) {
				sum += node.val;
			}
		}
		return sum;
	}
}