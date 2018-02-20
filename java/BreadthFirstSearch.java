import java.util.ArrayDeque;
import java.lang.Integer;

public class BreadthFirstSearch {
	public int sumNumbers(TreeNode root) {
		if (root == null) {
			return 0;
		}
		// using deque to implement BFS
		ArrayDeque<TreeNode> deque = new ArrayDeque<TreeNode>();
		deque.push(root);
		int sum = 0;
		while (!deque.isEmpty()) {
			TreeNode node = deque.poll();

			if (node.left != null) {
				node.left.val += node.val * 10;
				deque.push(node.left);
			}
			if (node.right != null) {
				node.right.val += node.val * 10;
				deque.push(node.right);
			}
			if (node.left == null && node.right == null) {
				sum += node.val;
			}
		}
		return sum;
	}
}