using System.Collections.Generic;

/*
886. Possible Bipartition
*/

public class LeetCodePossibleBipartition {
    private class Node
	{
		public int Color = 0;
		public List<int> Nexts = new List<int>();
	};

	public bool PossibleBipartition(
		int N, int[][] dislikes)
    {
		if (N == 0 ||
			dislikes == null ||
			dislikes.Length == 0)
			return true;
		var nodes = _GenNotes(N, dislikes);
		return _IsBipartition(nodes);
	}

	private Node[] _GenNotes(int N, int[][] edges) {
		var nodes = new Node[N+1];

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

	private bool _IsBipartition(Node[] nodes) {
		if (nodes == null ||
			nodes.Length == 0) return true;
		
		for (int i = 1; i < nodes.Length; ++i)
			if (nodes[i].Color == 0 &&
				!_IsBipartition(i, 1, nodes))
				return false;
		return true;
	}

	private bool _IsBipartition(
		int id, int color, Node[] nodes)
	{
		if (nodes[id].Color == 0)
			nodes[id].Color = color;
		else if (nodes[id].Color != color)
			return false;
		
		var nextColor = color == 1? 2 : 1;

		foreach (var next in nodes[id].Nexts)
		{
			if (nodes[next].Color == 0 &&
				!_IsBipartition(next, nextColor, nodes))
				return false;
			if (nodes[next].Color != nextColor)
				return false;
		}
		return true;
	}
}