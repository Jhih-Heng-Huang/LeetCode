#include "depth_first_search.h"
#include <utility>

using std::set;
using std::pair;

// 200. Number of Islands
int DepthFirstSearch::numIslands(const vector<vector<char>>& grid) {
	vector<set<int>> islands;
	islands = this->genIslands(grid);
	return islands.size();
}

vector<set<int>> DepthFirstSearch::genIslands(const vector<vector<char>>& grid) {
	vector<set<int>> islands;
	for (int i = 0; i < grid.size(); ++i) {
		for (int j = 0; j < grid[i].size(); ++j) {
			int point = i * grid[i].size() + j;
			if (grid[i][j] == '0' ||
				this->isExistedIsland(islands, point)) {
				continue;
			}
			// gen the new island if no such island exist
			this->genIsland(grid, islands, point);
		}
	}
	return islands;
}

bool DepthFirstSearch::isExistedIsland(const vector<set<int>>& islands,
															int point) {
	for (const auto &island: islands) {
		if (island.find(point) != island.end()) {
			return true;
		}
	}
	return false;
}

void DepthFirstSearch::genIsland(const vector<vector<char>>& grid,
						vector<set<int>>& islands, int start_point) {
	islands.push_back(set<int>());
	auto& island = islands.back();
	vector<int> stack(1, start_point);
	while (!stack.empty()) {
		int point = stack.back();
		stack.pop_back();
		int row = point/grid[0].size();
		int col = point%grid[0].size();
		if (grid[row][col] == '0' ||
			island.find(point) != island.end()) {
			continue;
		}
		island.insert(point);
		if (row - 1 >= 0) {
			stack.push_back(point - grid[0].size());
		}
		if (row + 1 < grid.size()) {
			stack.push_back(point + grid[0].size());
		}
		if (col - 1 >= 0) {
			stack.push_back(point - 1);
		}
		if (col + 1 < grid[0].size()) {
			stack.push_back(point + 1);
		}
	}
}