// 329. Longest Increasing Path in a Matrix

#include <vector>
#include <algorithm>

using std::vector;

class LeetCode329LongestIncreasingPathInAMatrix
{
private:
    struct Point {
        int X, Y;
        Point(int x, int y):X(x), Y(y) {}
    };

    vector<vector<int>>* cache_ = NULL;

    void InitCache_(int rowSize, int colSize) {
        if (cache_ != NULL) delete cache_;
        cache_ = new vector<vector<int>>(rowSize, vector<int>(colSize, 0));
    }

    void ReleaseCache_() {
        delete cache_;
        cache_ = NULL;
    }

    int FindLongestIncreasingPath_(vector<vector<int>>& matrix) {
        auto rowSize = matrix.size();
        auto colSize = matrix[0].size();
        InitCache_(rowSize, colSize);

        auto max = 0;

        for (int row = 0; row < rowSize; ++row) {
            for (int col = 0; col < colSize; ++col) {
                auto len = FindLongestIncreasingPath_(row, col, matrix);
                max = std::max(max, len);
            }
        }

        ReleaseCache_();
        return max;
    }

    int FindLongestIncreasingPath_(int row, int col, vector<vector<int>>& matrix) {
        if ((*cache_)[row][col] != 0) return (*cache_)[row][col];
        
        auto paths = FindPaths_(row, col, matrix);
        auto maxLen = 1;
        for (auto& path: *paths) {
            auto len = FindLongestIncreasingPath_(path.X, path.Y, matrix);
            maxLen = std::max(maxLen, 1+len);
        }

        (*cache_)[row][col] = maxLen;

        delete paths;
        return maxLen;
    }

    vector<Point>* FindPaths_(int row, int col, vector<vector<int>>& matrix) {
        auto rowSize = matrix.size();
        auto colSize = matrix[0].size();
        auto list = new vector<Point>();
        auto val = matrix[row][col];

        if (row > 0 && val < matrix[row-1][col]) list->push_back(Point(row-1, col));
        if (col > 0 && val < matrix[row][col-1]) list->push_back(Point(row, col-1));
        if (row < rowSize-1 && val < matrix[row+1][col]) list->push_back(Point(row+1, col));
        if (col < colSize-1 && val < matrix[row][col+1]) list->push_back(Point(row, col+1));

        return list;
    }
public:
    int longestIncreasingPath(vector<vector<int>>& matrix) {
        if (matrix.size() == 0 || matrix[0].size() == 0) return 0;
        return FindLongestIncreasingPath_(matrix);
    }
};
