package LeetCode.CountSquareSubmatriceswithAllOnes

/*
1277. Count Square Submatrices with All Ones
Test Cases:
[[0,1,1,1],[1,1,1,1],[0,1,1,1]]
[[1,0,1],[1,1,0],[1,1,0]]
[[1]]
[[1,1],[1,1]]
*/

fun countSquares(matrix: Array<IntArray>): Int
{
    var rightBottomCornerSquareCount = Array<IntArray>(matrix.size, {i -> matrix[i]});
    for (i in matrix.indices)
    {
        for (j in matrix[i].indices)
        {
            if (i == 0 || j == 0)
                continue
            
            if (matrix[i][j] != 1)
                continue

            rightBottomCornerSquareCount[i][j] = minOf(rightBottomCornerSquareCount[i-1][j],
                rightBottomCornerSquareCount[i][j-1], rightBottomCornerSquareCount[i-1][j-1]) + 1
        }
    }

    var sum = 0
    for (i in rightBottomCornerSquareCount.indices)
    {
        for (j in rightBottomCornerSquareCount[i].indices)
        {
            sum += rightBottomCornerSquareCount[i][j]
        }
    }
    return sum
}