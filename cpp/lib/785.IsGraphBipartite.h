// 785. Is Graph Bipartite?

#pragma once

#include <vector>

using std::vector;

class LeetCode785IsGraphBipartite
{
public:
	enum Color {NONE, BLUE, RED};
	struct Node {
		Color color;
		vector<int> nexts;
		Node(): color(Color::NONE) {}
	};

	bool isBipartite(vector<vector<int>>& graph) {
		if (graph.size() == 0) return true;

		auto &nodes = GenNode_(graph);

		auto result = true;
		for (int i = 0; i < nodes.size(); ++i)
			if (nodes[i].color == Color::NONE &&
				!IsBipartite_(i, Color::BLUE, nodes)) {
				result = false;
				break;
			}

		delete &nodes;

		return result;
	}
private:
	vector<Node>& GenNode_(const vector<vector<int>>& graph) const;
	bool IsBipartite_(int current, Color color, vector<Node> &nodes) const;
};