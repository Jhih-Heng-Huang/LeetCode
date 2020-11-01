// 207. Course Schedule

#include "207.CourseSchedule.h"

vector<LeetCode207CourseSchedule::Node>& LeetCode207CourseSchedule::GenNodes_(const int num, const vector<vector<int>>& edges) const {
	auto nodes = new vector<Node>(num, Node());

	for (auto& edge: edges) {
		auto i = edge[0];
		auto j = edge[1];
		(*nodes)[i].nexts.push_back(j);
	}
	return *nodes;
}

bool LeetCode207CourseSchedule::HasCycle_(const int i, vector<Node>& nodes) {
	if (nodes[i].state == State::VISITED) return nodes[i].hasCycle;
	if (nodes[i].state == State::VISITING) return true;

	nodes[i].state = State::VISITING;
	bool result = false;

	for (auto& next: nodes[i].nexts) {
		if (HasCycle_(next, nodes)) {
			result = true;
			break;
		}
	}

	nodes[i].state = State::VISITED;
	nodes[i].hasCycle = result;
	return result;
}

bool LeetCode207CourseSchedule::canFinish(int numCourses, vector<vector<int>>& prerequisites) {
	if (numCourses == 0 || prerequisites.size() == 0) return true;

	auto& nodes = GenNodes_(numCourses, prerequisites);

	for (int i = 0; i < nodes.size(); ++i) {
		if (nodes[i].state == State::NON_VISIT &&
			HasCycle_(i, nodes)) return false;
	}

	delete &nodes;
	return true;
}