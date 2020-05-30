package LeetCode.CourseSchedule


/*
207. Course Schedule
Test cases:
 */

private data class CourseNode(val index: Int)
{
    var visited = false
    var temporaryVisited = false
    var nextCources = mutableListOf<Int>()
}

private fun hasCycle(graph: Array<CourseNode>, currentIndex: Int): Boolean
{
    if (graph[currentIndex].visited) return false
    if (graph[currentIndex].temporaryVisited) return true

    graph[currentIndex].visited = false
    graph[currentIndex].temporaryVisited = true

    for (courseIndex in graph[currentIndex].nextCources)
    {
        if (hasCycle(graph, courseIndex)) return true
    }

    graph[currentIndex].temporaryVisited = false
    graph[currentIndex].visited = true

    return false
}

fun canFinish(numCourses: Int, prerequisites: Array<IntArray>): Boolean
{
    var graph = Array<CourseNode>(numCourses, {CourseNode(it)})

    for ((courseIndex, nextCourseIndex) in prerequisites)
    {
        graph[courseIndex].nextCources.add(nextCourseIndex)
    }

    for (courseIndex in 0 until numCourses)
    {
        if (hasCycle(graph, courseIndex)) return false
    }

    return true
}