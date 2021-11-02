using System.Collections.Generic;

/*
LeetCode: 886. Possible Bipartition
*/

public class LeetCodePossibleBipartition {
	private enum COLOR
	{
		NONE,
		WHITE,
		BLACK,
	}
	private class Node
	{
		public COLOR color = COLOR.NONE;
		public List<int> nexts = new List<int>();
	}

	public bool PossibleBipartition(
		int N, int[][] dislikes)
    {
		if (N == 0 || dislikes == null || dislikes.Length == 0)
			return true;
		var nodes = _GenGraph(N, dislikes);
		for (int id = 1; id <= N; ++id)
			if (nodes[id].color == COLOR.NONE &&
				!_IsBipartition(id, nodes, COLOR.WHITE))
				return false;

		return true;
	}

	private Node[] _GenGraph(int numNodes, int[][] edges)
	{
		var nodes = new Node[numNodes+1];
		for (int i = 0; i < nodes.Length; ++i)
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

	private bool _IsBipartition(int id, Node[] nodes, COLOR assignedColor)
	{
		nodes[id].color = assignedColor;
		var nextColor = assignedColor == COLOR.WHITE? COLOR.BLACK : COLOR.WHITE;
		foreach (var next in nodes[id].nexts)
		{
			if (nodes[next].color == COLOR.NONE &&
				!_IsBipartition(next, nodes, nextColor))
				return false;
			else if (nodes[next].color != nextColor)
				return false;
		}
		return true;
	}
}