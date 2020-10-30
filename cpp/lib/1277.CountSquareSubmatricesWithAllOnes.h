// 1277. Count Square Submatrices with All Ones

#include <vector>

using std::vector;

class LeetCode1277CountSquareSubmatricesWithAllOnes
{
private:
    vector<vector<int>>* GenTable_(int rowSize, int colSize);
    int CountSquares_(vector<vector<int>>& matrix);
public:
    int countSquares(vector<vector<int>>& matrix);
};
