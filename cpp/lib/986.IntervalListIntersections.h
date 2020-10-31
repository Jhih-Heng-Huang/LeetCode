// 986. Interval List Intersections

#include <vector>
#include <algorithm>

using std::vector;

class LeetCode986IntervalListIntersections
{
private:
    inline vector<int>* Intersect_(vector<int>& interval1, vector<int>& interval2) {
        auto left = std::max(interval1[0], interval2[0]);
        auto right = std::min(interval1[1], interval2[1]);

        if (left > right) return NULL;

        auto newInterval = new vector<int>();
        newInterval->push_back(left);
        newInterval->push_back(right);
        return newInterval;
    }
public:
    vector<vector<int>> intervalIntersection(vector<vector<int>>& A, vector<vector<int>>& B) {
        vector<vector<int>> list;
        if (A.size() == 0 || B.size() == 0) return list;

        auto i = 0;
        auto j = 0;
        while (i < A.size() && j < B.size()) {
            auto interval = Intersect_(A[i], B[j]);
            if (interval != NULL) list.push_back(*interval);

            delete interval;
            if (A[i][1] <= B[j][1]) ++i;
            else ++j;
        }
        
        return list;
    }
};
