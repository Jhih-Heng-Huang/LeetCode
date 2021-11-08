// LeetCode: 207. Course Schedule

using System.Collections.Generic;

namespace csharp.Lib
{
	public class LeetCode207CourseSchedule
	{
		private enum State
		{
			Unvisited,
			Visiting,
			Visited,
		}
		private class Node
		{
			public State state = State.Unvisited;
			public List<int> Nexts = new List<int>();
		}

		public bool CanFinish(int numCourses, int[][] prerequisites)
		{
			if (prerequisites.Length == 0) return true;
			var nodes = _GenGraph(numCourses, prerequisites);

			for (int id = 0; id < nodes.Length; ++id)
				if (nodes[id].state == State.Unvisited &&
					_HasCycle(id, nodes))
					return false;
			return true;
		}

		private Node[] _GenGraph(int num, int[][] edges)
		{
			var nodes = new Node[num];
			for (int i = 0; i < num; ++i)
				nodes[i] = new Node();
			foreach (var edge in edges)
			{
				var i = edge[0];
				var j = edge[1];
				nodes[i].Nexts.Add(j);
			}
			return nodes;
		}

		private bool _HasCycle(int id, Node[] nodes)
		{
			nodes[id].state = State.Visiting;
			foreach (var next in nodes[id].Nexts)
			{
				if (nodes[next].state == State.Unvisited &&
					_HasCycle(next, nodes))
					return true;
				else if (nodes[next].state == State.Visiting)
					return true;
			}
			nodes[id].state = State.Visited;
			return false;
		}
	}
}