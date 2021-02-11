/*
1192. Critical Connections in a Network
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class CriticalConnectionsInANetwork {
    private class Node
    {
        public int Rank = -2;
        public List<int> Nexts = new List<int>();
    }

    public IList<IList<int>> CriticalConnections(
        int n, IList<IList<int>> connections)
    {
        var list = new List<IList<int>>();
        if (n == 0 || connections == null || connections.Count == 0)
            return list;

        var nodes = _GenGraph(n, connections);

        for (int i = 0; i < nodes.Length; ++i)
        {
            if (nodes[i].Rank == -2)
                _Traverse(i, 0, nodes, list);
        }

        return list;
    }

    private Node[] _GenGraph(int num, IList<IList<int>> edges)
    {
        var nodes = new Node[num];

        for (int i = 0; i < nodes.Length; ++i)
            nodes[i] = new Node();

        foreach (var edge in edges)
        {
            var i = edge[0];
            var j = edge[1];
            nodes[i].Nexts.Add(j);
            nodes[j].Nexts.Add(i);
        }

        return nodes;
    }

    private bool _IsVisited(Node node)
    {
        return node.Rank >= 0;
    }


    private int _Traverse(int i, int rank, Node[] nodes, IList<IList<int>> criticalEdges)
    {
        if (nodes[i].Rank != -2) return nodes[i].Rank;

        var num = nodes.Length;
        nodes[i].Rank = rank;
        var minRank = rank;

        foreach (var next in nodes[i].Nexts)
        {
            var nextRank = nodes[next].Rank;
            if (nextRank == rank - 1 || nextRank == num)
                continue;

            nextRank = _Traverse(next, rank + 1, nodes, criticalEdges);
            if (rank >= nextRank)
                minRank = Math.Min(minRank, nextRank);
            else
            {
                var edge = new int[] { i, next }.ToList();
                criticalEdges.Add(edge);
            }
        }

        nodes[i].Rank = num;
        return minRank;
    }
}