/*
210. Course Schedule II
*/

using System.Collections.Generic;
using System.Linq;

public class CourseScheduleII {
	private enum State {
		NonVisit,
		Visiting,
		Visited,
	}


	private class Node {
		public State State = State.NonVisit;
		public bool HasCycle = false;
		public List<int> Nexts = new List<int>();
	}

    public int[] FindOrder(int numCourses,
                           int[][] prerequisites)
    {
		if (numCourses == 0)
			return new int[]{};

		var nodes = _GenNodes(numCourses, prerequisites);
		return _FindOrder(nodes);
    }

	private Node[] _GenNodes(int n, int[][] edges) {
		var nodes = new Node[n];

		for (int i = 0; i < nodes.Length; ++i)
			nodes[i] = new Node();

		foreach (var edge in edges) {
			var i = edge[0];
			var j = edge[1];
			nodes[i].Nexts.Add(j);
		}

		return nodes;
	}

	private int[] _FindOrder(Node[] nodes) {
		var list = new List<int>();

		for (int i = 0; i < nodes.Length; ++i) {
			if (_HasCycle(i, nodes, list))
				return new int[]{};
		}

		return list.ToArray();
	}

	private bool _HasCycle(int i, Node[] nodes, List<int> list) {

		if (nodes[i].State == State.Visited)
			return nodes[i].HasCycle;
		if (nodes[i].State == State.Visiting)
			return true;

		nodes[i].State = State.Visiting;

		foreach (var next in nodes[i].Nexts) {
			if (_HasCycle(next, nodes, list)) {
				nodes[i].HasCycle = true;
				return true;
			}
		}

		nodes[i].State = State.Visited;
		nodes[i].HasCycle = false;
		list.Add(i);

		return false;

	}
}