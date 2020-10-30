// 1277. Count Square Submatrices with All Ones

#include "1277.CountSquareSubmatricesWithAllOnes.h"
#include <algorithm>

vector<vector<int>>* LeetCode1277CountSquareSubmatricesWithAllOnes::GenTable_(int rowSize, int colSize) {
    auto table = new vector<vector<int>>(rowSize, vector<int>(colSize));

    return table;
}

int LeetCode1277CountSquareSubmatricesWithAllOnes::CountSquares_(vector<vector<int>>& matrix) {
    auto rowSize = matrix.size();
    auto colSize = matrix[0].size();
    auto& table = *GenTable_(rowSize, colSize);

    auto count = 0;
    for (int row = 0; row < matrix.size(); ++row) {
        for (int col = 0; col < matrix[row].size(); ++col) {
            if (row == 0 || col == 0) table[row][col] = matrix[row][col];
            else if (matrix[row][col] == 0) table[row][col] = 0;
            else table[row][col] = 1 + std::min({table[row-1][col], table[row-1][col-1], table[row][col-1]});
            count += table[row][col];
        }
    }

    delete &table;
    return count;
}

int LeetCode1277CountSquareSubmatricesWithAllOnes::countSquares(vector<vector<int>>& matrix) {
    if (matrix.size() == 0) return 0;
    return CountSquares_(matrix);
}
