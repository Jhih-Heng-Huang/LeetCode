// 240. Search a 2D Matrix II

#include <vector>
#include <cstdio>

using std::vector;

class LeetCode240SearchA2DMatrixII {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        if (matrix.size() == 0) return false;

        int row = 0;
        int col = matrix[row].size() - 1;

        while (row < matrix.size() && col >= 0) {
            if (matrix[row][col] == target) return true;
            else if (matrix[row][col] < target) ++row;
            else --col;
        }

        return false;
    }
};