import java.util.Queue;
import java.util.ArrayDeque;
import java.util.List;
import java.util.ArrayList;
import java.util.Set;
import java.util.TreeSet;
import java.util.Stack;
import java.util.Map;
import java.util.TreeMap;
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

	private Map<Integer, Set<Integer>> GetAdjacencyList(final int n,
			final int [][] edges) {
		Map<Integer, Set<Integer>> adj_list =
			new TreeMap<Integer, Set<Integer>>();
		for (int i = 0; i < n; ++i) {
			adj_list.put(i, new TreeSet<Integer>());
		}
		final int start_node = 0;
		final int end_node = 1;
		for (int[] edge: edges) {
			adj_list.get(edge[start_node]).add(edge[end_node]);
			adj_list.get(edge[end_node]).add(edge[start_node]);
		}
		return adj_list;
	}

	private List<Integer> FindLeaves(Map<Integer, Set<Integer>> adj_list) {
		List<Integer> leaves = new ArrayList<Integer>();
		for (Map.Entry<Integer, Set<Integer>> node: adj_list.entrySet()) {
			if (node.getValue().size() < 2) {
				leaves.add(node.getKey());
			}
		}
		return leaves;
	}

	private List<Integer> FindTreeCenter(Map<Integer, Set<Integer>> adj_list) {
		List<Integer> leaves = new ArrayList<Integer>();

		while (!adj_list.isEmpty()) {
			// get the new leaves
			leaves = FindLeaves(adj_list);
			// remove the leaves from tree
			for (Integer leaf: leaves) {
				for (Integer neighbor: adj_list.get(leaf)) {
					adj_list.get(neighbor).remove(leaf);
				}
				adj_list.remove(leaf);
			}
		}

		return leaves;
	}

	public List<Integer> findMinHeightTrees(int n,
			int[][] edges) {
		if (n == 0) {
			return new ArrayList<Integer>();
		}
		// generate the adjacency list of tree from edges
		Map<Integer, Set<Integer>> adj_list = GetAdjacencyList(n, edges);
		// find the center of the tree
		return FindTreeCenter(adj_list);
    }
}