package LeetCode.PossibleBipartition

/*
886. Possible Bipartition
Test cases:
4
[[1,2],[1,3],[2,4]]
3
[[1,2],[1,3],[2,3]]
5
[[1,2],[2,3],[3,4],[4,5],[1,5]]
*/

import java.util.LinkedList

fun possibleBipartition(N: Int, dislikes: Array<IntArray>): Boolean
    = possibleBipartitionByBFS(N, dislikes)

private enum class COLOR
{
    NO_COLOR, RED, BLACK
}

private fun possibleBipartitionByBFS(N: Int, dislikes: Array<IntArray>): Boolean
{
    var adjTable = Array<MutableSet<Int>>(N+1, {_ -> mutableSetOf<Int>()})

    for (dislike in dislikes)
    {
        val i = dislike[0]
        val j = dislike[1]
        adjTable[i].add(j)
        adjTable[j].add(i)
    }

    var queue = LinkedList<Int>()
    var color = Array<COLOR>(N+1, {_ -> COLOR.NO_COLOR})
    var visited = BooleanArray(N+1, {_ -> false})
    for (node in 1..N)
    {
        if (visited[node])
            continue
        
        color[node] = COLOR.RED
        queue.add(node)
        while(queue.size > 0) {
            var currentNode = queue.remove()
            val neighbors = adjTable[currentNode].filter { neighbor -> !visited[neighbor] }

            for (neighbor in neighbors)
            {
                if (color[neighbor] == color[currentNode])
                    return false
                else
                    color[neighbor] = if (color[currentNode] == COLOR.RED) COLOR.BLACK
                    else COLOR.RED
            }
            visited[currentNode] = true
            queue.addAll(neighbors)
        }
    }

    return true
}