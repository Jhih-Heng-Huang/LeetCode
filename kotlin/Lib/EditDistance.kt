package LeetCode.EditDistance

/*
Edit Distance
Test cases:
"horse"
"ros"
"intention"
"execution"
 */

fun minDistance(word1: String, word2: String): Int
{
    var distanceTable = Array<IntArray>(word1.length + 1, {IntArray(word2.length + 1)})

    for (i in 0..word1.length)
    {
        for (j in 0..word2.length)
        {
            distanceTable[i][j] = 
                if (i == 0) j
                else if (j == 0) i
                else if (word1[i - 1] == word2[j - 1]) distanceTable[i-1][j-1]
                else 1 + minOf(distanceTable[i-1][j],
                    distanceTable[i][j-1],
                    distanceTable[i-1][j-1])
        }
    }

    return distanceTable[word1.length][word2.length]
}