#include "depth_first_search.h"
#include <utility>
#include <algorithm>
#include <stack>

using std::set;
using std::pair;
using std::max;
using std::stack;

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

// 695. Max Area of Island
int DepthFirstSearch::maxAreaOfIsland(vector<vector<int>>& grid) {
	int max_count = 0;
	for (int row = 0; row < grid.size(); ++row) {
		for (int col = 0; col < grid[row].size(); ++col) {
			int position = row * grid[row].size() + col;
			int count = this->getAreaOfIsland(grid, position);
			max_count = max(max_count, count);
		}
	}
	return max_count;
}

int DepthFirstSearch::getAreaOfIsland(vector<vector<int>>& grid, int position) {
	int row = position/grid[0].size();
	int col = position%grid[0].size();
	if (grid[row][col] == 0) {
		return 0;
	}

	grid[row][col] = 0;
	int count = 1;
	if (row - 1 >= 0) {
		count += this->getAreaOfIsland(grid, position - grid[0].size());
	}
	if (row + 1 < grid.size()) {
		count += this->getAreaOfIsland(grid, position + grid[0].size());
	}
	if (col - 1 >= 0) {
		count += this->getAreaOfIsland(grid, position - 1);
	}
	if (col + 1 < grid[0].size()) {
		count += this->getAreaOfIsland(grid, position + 1);
	}
	return count;
}

// 547. Friend Circles
int DepthFirstSearch::findCircleNum(vector<vector<int>>& M) {
	int count = 0;
	for (int i = 0; i < M.size(); ++i) {
		if (M[i][i] == 1) {
			this->findCircle(M, i);
			++count;
		}
	}
	return count;
}

void DepthFirstSearch::findCircle(vector<vector<int>> &M, int person) {
	for (int j = 0; j < M[person].size(); ++j) {
		if (M[person][j] == 1) {
			M[person][j] = 0;
			M[j][person] = 0;
			this->findCircle(M, j);
		}
	}
}