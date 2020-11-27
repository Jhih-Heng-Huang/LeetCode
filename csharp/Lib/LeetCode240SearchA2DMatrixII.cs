// LeetCode: 240. Search a 2D Matrix II

using System;

public class LeetCode240SearchA2DMatrixII
{
    public bool SearchMatrix(int[,] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0) return false;

        var rowLength = matrix.GetLength(0);
        var colLength = matrix.GetLength(1);
        var row = 0;
        var col = colLength - 1;

        while (row < rowLength && col >= 0)
        {
            if (matrix[row, col] == target) return true;
            else if (matrix[row, col] < target) ++row;
            else --col;
        }
        return false;
    }
}
