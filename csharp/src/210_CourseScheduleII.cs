/*
LeetCode: 210. Course Schedule II
*/

using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problem_210
{
	public class CourseScheduleII {
		private enum State
		{
			Unvisited,
			Visiting,
			Visited,
		}
		private class Node
		{
			public State state = State.Unvisited;
			public List<int> nexts = new List<int>();
		}

		public int[] FindOrder(
			int numCourses,
			int[][] prerequisites)
		{
			var orders = new List<int>();

			var nodes = _GenNodes(numCourses, prerequisites);

			for (int i = 0; i < nodes.Length; ++i)
				if (nodes[i].state == State.Unvisited && _HasCycle(i, nodes, orders))
					return new int[]{};

			return orders.ToArray();
		}

		private Node[] _GenNodes(int numNodes, int[][] edges)
		{
			var nodes = new Node[numNodes];
			for (int i = 0; i < nodes.Length; ++i)
				nodes[i] = new Node();
			foreach (var edge in edges)
			{
				var i = edge[0];
				var j = edge[1];
				nodes[i].nexts.Add(j);
			}
			return nodes;
		}

		private bool _HasCycle(int current, Node[] nodes, List<int> orders)
		{
			nodes[current].state = State.Visiting;

			foreach (var next in nodes[current].nexts)
			{
				if (nodes[next].state == State.Visited)
					continue;
				if (nodes[next].state == State.Visiting)
					return true;
				if (nodes[next].state == State.Unvisited &&
					_HasCycle(next, nodes, orders))
					return true;
			}
			nodes[current].state = State.Visited;
			orders.Add(current);
			return false;
		}
	}
}
