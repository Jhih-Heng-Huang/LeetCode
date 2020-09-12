package LeetCode.UncrossedLines

/*
1035. Uncrossed Lines
Test cases:
[1,4,2]
[1,2,4]
[2,5,1,2,5]
[10,5,2,1,5,2]
[1,3,7,1,7,5]
[1,9,2,5,1]
[4,1,2,3,4,5]
[1,2,3,5,4]
 */



fun maxUncrossedLines(A:IntArray, B:IntArray): Int
{
    val table = Array(A.size + 1, {IntArray(B.size + 1)})
    for (i in 0 until A.size)
        for (j in 0 until B.size)
        {
            if (A[i] == B[j])
                table[i+1][j+1] = 1 + table[i][j]
            else
                table[i+1][j+1] = maxOf(table[i+1][j], table[i][j+1])
        }
    return table[A.size][B.size]
}