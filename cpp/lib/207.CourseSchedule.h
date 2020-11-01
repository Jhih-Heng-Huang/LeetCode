// 207. Course Schedule

#include <vector>

using std::vector;

class LeetCode207CourseSchedule
{
private:
	enum State {NON_VISIT, VISITING, VISITED};
	struct Node {
		State state;
		bool hasCycle;
		vector<int> nexts;
		Node(): state(State::NON_VISIT), hasCycle(false) {}
	};

	vector<Node>& GenNodes_(const int num, const vector<vector<int>>& edges) const;

	bool HasCycle_(const int i, vector<Node>& nodes);
public:
	bool canFinish(int numCourses, vector<vector<int>>& prerequisites);
};
