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
        int n, IList<IList<int>> connections) {
		
		var list = new List<IList<int>>();
		
		if (n == 0 || connections == null || connections.Count == 0)
			return list;

		var nodes = _GenNodes(n, connections);

		for (int i = 0; i < nodes.Length; ++i)
			if (nodes[i].Rank == -2)
				_FindMinRank(i, 0, nodes, list);
		return list;
    }

	private int _FindMinRank(int i, int rank,
		Node[] nodes, List<IList<int>> list)
	{
		if (nodes[i].Rank != -2)
			return nodes[i].Rank;

		nodes[i].Rank = rank;
		var n = nodes.Length;
		var minRank = rank;

		foreach (var next in nodes[i].Nexts) {
			if (nodes[next].Rank == n ||
				nodes[next].Rank == rank-1)
				continue;
			
			var newRank = _FindMinRank(next, rank+1, nodes, list);

			if (newRank <= rank)
				minRank = Math.Min(minRank, newRank);
			else {
				var edge = new int[] {i, next}.ToList();
				list.Add(edge);
			}
		}

		nodes[i].Rank = n;

		return minRank;
	}

	private Node[] _GenNodes(int n, IList<IList<int>> connections) {
		var nodes = new Node[n];

		for (int i = 0; i < nodes.Length; ++i)
			nodes[i] = new Node();

		foreach (var edge in connections) {
			var i = edge[0];
			var j = edge[1];
			nodes[i].Nexts.Add(j);
			nodes[j].Nexts.Add(i);
		}

		return nodes;
	}
}