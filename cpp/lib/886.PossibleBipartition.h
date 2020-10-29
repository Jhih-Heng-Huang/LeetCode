// 886. Possible Bipartition

#include <vector>

using std::vector;

enum Color {NONE, WHITE, RED};

class Node {
public:
    Color color = Color::NONE;
    vector<int> Nexts;
};

class LeetCode886PossibleBipartition
{
private:
    bool IsBipartition_(int current, Color assignColor, vector<Node>& nodes);
    bool IsValidNeighbor_(int neighber, Color currentColor, Color assignColor, vector<Node>& nodes);
    vector<Node>* GenNodes_(int N, vector<vector<int>>& dislikes);
public:
    bool possibleBipartition(int N, vector<vector<int>>& dislikes);
};
