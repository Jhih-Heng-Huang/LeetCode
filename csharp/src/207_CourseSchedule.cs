// LeetCode: 207. Course Schedule

using System.Collections.Generic;

namespace csharp.Lib
{
	public class LeetCode207CourseSchedule
	{
		public enum State
		{
			UNVISITED,
			VISITING,
			VISITED,
		}

		public class Node {

			public State State = State.UNVISITED;
			public bool HasCycle = false;
			public HashSet<int> Nexts = new HashSet<int>();
		}

		public class GraphUtility {
			private Node[] _nodes;
			public bool HasCycle(Node[] nodes) {
				if (nodes == null || nodes.Length == 0)
					return false;
				
				_nodes = (Node[]) nodes.Clone();

				for (int i = 0; i < _nodes.Length; ++i)
					if (_HasCycle(i)) return true;
				return false;
			}

			private bool _HasCycle(int i) {
				if (_nodes[i].State == State.VISITING) return true;
				if (_nodes[i].State == State.VISITED) return _nodes[i].HasCycle;

				_nodes[i].State = State.VISITING;

				foreach (var next in _nodes[i].Nexts) {
					if (_HasCycle(next))
					{
						_nodes[i].HasCycle = true;
						return true;
					}
				}

				_nodes[i].State = State.VISITED;
				_nodes[i].HasCycle = false;
				return false;
			}
		}
		public bool CanFinish(int numCourses, int[][] prerequisites)
		{
			if (numCourses == 0 ||
				prerequisites == null ||
				prerequisites.Length == 0)
				return true;

			var nodes = _GenNodes(numCourses, prerequisites);
			var graph = new GraphUtility();

			return !graph.HasCycle(nodes);
		}

		private Node[] _GenNodes(int numNodes, int[][] edges)
		{
			var nodes = new Node[numNodes];

			for (int i = 0; i < nodes.Length; ++i)
				nodes[i] = new Node();

			foreach (var edge in edges) {
				var i = edge[0];
				var j = edge[1];
				nodes[i].Nexts.Add(j);
			}

			return nodes;
		}
	}
}