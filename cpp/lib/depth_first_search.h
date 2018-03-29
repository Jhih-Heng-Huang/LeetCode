#ifndef CPP_LIB_DEPTH_FIRST_SEARCH_H
#define CPP_LIB_DEPTH_FIRST_SEARCH_H

#include <vector>
#include <set>

using std::vector;
using std::set;

class DepthFirstSearch {
// 200. Number of Islands
public:
    int numIslands(const vector<vector<char>>& grid);
private:
	vector<set<int>> genIslands(const vector<vector<char>>& grid);
	bool isExistedIsland(const vector<set<int>>& islands, int point);
	void genIsland(const vector<vector<char>>& grid,
						vector<set<int>>& islands, int start_point);
};

#endif