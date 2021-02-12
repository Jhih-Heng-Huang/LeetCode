/*
LeetCode: 785. Is Graph Bipartite?
*/
using System.Collections.Generic;

namespace LeetCode.Problem_785
{
	public class IsGraphBipartite {
		private enum Color {
			None,
			Black,
			Red,
		}

		private class Node {
			public Color Color = Color.None;
			public HashSet<int> Nexts = new HashSet<int>();
		}

		private class GraphUtility {
			private Node[] _nodes = null;
			public bool IsBipartite(Node[] nodes) {
				if (nodes == null || nodes.Length == 0)
					return true;

				_nodes = nodes;
				for (int i = 0; i < nodes.Length; ++i)
					if (_nodes[i].Color == Color.None &&
						!_IsBipartite(i, Color.Black))
						return false;

				return true;
			}

			private bool _IsBipartite(int index, Color color) {
				_nodes[index].Color = color;
				var nextColor = color == Color.Black? Color.Red : Color.Black;

				foreach (var next in _nodes[index].Nexts)
				{
					if (_nodes[next].Color == Color.None &&
						!_IsBipartite(next, nextColor))
						return false;
					else if (_nodes[next].Color != nextColor)
						return false;
				}
				return true;
			}
		}

		public bool IsBipartite(int[][] graph) {
			if (graph == null || graph.Length == 0)
				return true;

			var nodes = _Transform(graph);
			var utility = new GraphUtility();
			return utility.IsBipartite(nodes);
		}

		private Node[] _Transform(int[][] graph) {
			var nodes = new Node[graph.Length];

			for (int i = 0; i < nodes.Length; ++i)
				nodes[i] = new Node();

			for (int i = 0; i < graph.Length; ++i)
				foreach (var next in graph[i])
					nodes[i].Nexts.Add(next);

			return nodes;
		}
	}
}