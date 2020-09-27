// 240. Search a 2D Matrix II

class LeetCode240SearchA2DMatrixII {
    fun searchMatrix(matrix: Array<IntArray>, target: Int): Boolean {
        if (matrix.size == 0)
            return false

        var row = 0
        var col = matrix[0].size - 1

        while (row < matrix.size && col >= 0)
            if (matrix[row][col] == target) return true
            else if (matrix[row][col] < target) ++row
            else --col

        return false
    }
}