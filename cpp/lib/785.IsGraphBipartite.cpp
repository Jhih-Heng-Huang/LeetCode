#include "785.IsGraphBipartite.h"

vector<LeetCode785IsGraphBipartite::Node>& LeetCode785IsGraphBipartite::GenNode_(const vector<vector<int>>& graph) const {
	auto nodes = new vector<Node>(graph.size(), Node());

	for (int nodeIndex = 0; nodeIndex < graph.size(); ++nodeIndex)
		(*nodes)[nodeIndex].nexts.assign(graph[nodeIndex].begin(), graph[nodeIndex].end());

	return *nodes;
}

bool LeetCode785IsGraphBipartite::IsBipartite_(int current, Color color, vector<Node> &nodes) const {
	if (nodes[current].color == Color::NONE) nodes[current].color = color;

	auto nextColor = nodes[current].color == Color::BLUE? Color::RED : Color::BLUE;

	auto isValidNeighbor = [&](int nei) mutable -> bool {
		return
			(nodes[nei].color == Color::NONE &&
			!IsBipartite_(nei, nextColor, nodes)) ||
			nodes[nei].color == nodes[current].color;
	};

	for (auto& next: nodes[current].nexts) {
		if (isValidNeighbor(next))
			return false;
	}
	return true;
}