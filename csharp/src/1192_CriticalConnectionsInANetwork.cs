/*
1192. Critical Connections in a Network
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class CriticalConnectionsInANetwork {
	private class Node {
		public int Rank = -2;
		public List<int> Nexts = new List<int>();
	}

	public IList<IList<int>> CriticalConnections(
		int n, IList<IList<int>> connections)
	{
		if (n == 0 || connections == null ||
			connections.Count == 0)
			return new List<IList<int>>();

		var nodes = _GenGraph(n, connections);
		var criticalEdges = new List<IList<int>>();

		for (int i = 0; i < nodes.Length; ++i)
			if (nodes[i].Rank == -2)
				_GetMinRank(i, 0, nodes, criticalEdges);

		return criticalEdges;
	}

	private Node[] _GenGraph(int n, IList<IList<int>> edges)
	{
		var nodes = new Node[n];

		for (int i = 0; i < nodes.Length; ++i)
			nodes[i] = new Node();

		foreach (var edge in edges) {
			var i = edge[0];
			var j = edge[1];
			nodes[i].Nexts.Add(j);
			nodes[j].Nexts.Add(i);
		}

		return nodes;
	}

	private int _GetMinRank(int i, int rank, Node[] nodes, IList<IList<int>> criticalEdges)
	{
		if (nodes[i].Rank != -2) return nodes[i].Rank;

		nodes[i].Rank = rank;
		var minRank = rank;
		var num = nodes.Length;

		foreach (var next in nodes[i].Nexts)
		{
			if (nodes[next].Rank == rank-1 ||
				nodes[next].Rank == num)
				continue;
			
			var nextRank = _GetMinRank(next, rank + 1,
				nodes, criticalEdges);
			
			if (rank >= nextRank)
				minRank = Math.Min(minRank, nextRank);
			else {
				criticalEdges.Add(new int[]{i, next}.ToList());
			}
		}

		nodes[i].Rank = num;
		return minRank;
	}
}