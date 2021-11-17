/*
1192. Critical Connections in a Network
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class CriticalConnectionsInANetwork {
	private const int NON_VISITED = -2;
	private class Node {
		public int rank = NON_VISITED;
		public List<int> nexts = new List<int>();
	}


	public IList<IList<int>> CriticalConnections(
		int n, IList<IList<int>> connections)
	{
		var nodes = _GenGraph(n, connections);

		var edges = new List<IList<int>>();
		for (int i = 0; i < nodes.Length; ++i)
			if (nodes[i].rank == NON_VISITED)
				_GetRank(-1, i, 0, nodes, edges);
		return edges;
	}


	private Node[] _GenGraph(int n, IList<IList<int>> edges)
	{
		var nodes = new Node[n];
		for (int i = 0; i < n; ++i)
			nodes[i] = new Node();
		foreach (var edge in edges)
		{
			var i = edge[0];
			var j = edge[1];
			nodes[i].nexts.Add(j);
			nodes[j].nexts.Add(i);
		}
		return nodes;
	}
	private int _GetRank(
		int last,
		int current,
		int assignRank,
		Node[] nodes,
		IList<IList<int>> edges)
	{
		nodes[current].rank = assignRank;

		foreach (var next in nodes[current].nexts)
		{
			if (next == last) continue;

			var nextRank = (nodes[next].rank != NON_VISITED)?
				nodes[next].rank : _GetRank(current, next, assignRank+1, nodes, edges);
			
			if (nextRank <= assignRank)
				nodes[current].rank = Math.Min(nodes[current].rank, nextRank);
			else
				edges.Add(new int[]{current, next}.ToList());
		}
		return nodes[current].rank;
	}

}