// 886. Possible Bipartition

#include "886.PossibleBipartition.h"


bool LeetCode886PossibleBipartition::possibleBipartition(int N, vector<vector<int>>& dislikes)
{
    if (N < 3 || dislikes.size() < 2) return true;

    auto nodes = GenNodes_(N, dislikes);

    for (int i = 1; i < (*nodes).size(); ++i) {
        if ((*nodes)[i].color == Color::NONE && !IsBipartition_(i, Color::WHITE, *nodes)) return false;
    }

    delete nodes;
    return true;
}

bool LeetCode886PossibleBipartition::IsBipartition_(int current, Color assignColor, vector<Node>& nodes) {
    if (nodes[current].color == Color::NONE) nodes[current].color = assignColor;

    auto nextColor = (nodes[current].color == Color::RED)? Color::WHITE : Color::RED;

    for (auto& next: nodes[current].Nexts) {
        if (!IsValidNeighbor_(next, nodes[current].color, nextColor, nodes)) return false;
    }

    return true;
}

bool LeetCode886PossibleBipartition::IsValidNeighbor_(int neighber, Color currentColor, Color assignColor, vector<Node>& nodes) {
    return (nodes[neighber].color == Color::NONE && IsBipartition_(neighber, assignColor, nodes)) || nodes[neighber].color != currentColor;
}

vector<Node>* LeetCode886PossibleBipartition::GenNodes_(int N, vector<vector<int>>& dislikes) {
    vector<Node> *nodes = new vector<Node>(N+1);

    for (auto& edge: dislikes) {
        auto i = edge[0];
        auto j = edge[1];
        (*nodes)[i].Nexts.push_back(j);
        (*nodes)[j].Nexts.push_back(i);
    }

    return nodes;
}