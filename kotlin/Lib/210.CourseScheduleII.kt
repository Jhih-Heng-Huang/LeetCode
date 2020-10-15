// LeetCode: 210. Course Schedule II

private enum class State {
    NonVisited, Visiting, Visited
}


class LeetCode210CourseScheduleII {
    private data class Node(
        var state: State,
        var hasCycle: Boolean,
        val nexts: MutableList<Int>)

    fun findOrder(numCourses: Int, prerequisites: Array<IntArray>): IntArray {
        if (numCourses == 0 || !`_IsValid`(numCourses, prerequisites))
            return IntArray(0)

        return `_GetValidOrder`(numCourses, prerequisites)
    }

    private fun _GenNode(num: Int, edges: Array<IntArray>): Array<Node> {
        val nodes = Array(num) {  Node(State.NonVisited, false, mutableListOf<Int>()) }

        for (edge in edges) {
            val i = edge[0]
            val j = edge[1]
            nodes[i].nexts.add(j)
        }

        return nodes
    }

    private fun _IsValid(num: Int, edges: Array<IntArray>): Boolean {
        val nodes = `_GenNode`(num, edges)

        for (i in 0 until num) {
            if (nodes[i].state == State.NonVisited &&
                `_HasCycle`(i, nodes))
                return false
        }

        return true
    }

    private fun _HasCycle(current: Int, nodes: Array<Node>): Boolean {
        if (nodes[current].state == State.Visiting)
            return true
        else if (nodes[current].state == State.Visited)
            return nodes[current].hasCycle

        nodes[current].state = State.Visiting

        for (next in nodes[current].nexts) {
            if (nodes[next].state == State.Visiting ||
                `_HasCycle`(next, nodes)) {
                nodes[current].state = State.Visited
                nodes[current].hasCycle = true
                return true
            }
        }

        nodes[current].state = State.Visited
        nodes[current].hasCycle = false
        return false
    }

    private fun _GetValidOrder(num: Int, edges: Array<IntArray>): IntArray {
        var nodes = `_GenNode`(num, edges)

        val list = mutableListOf<Int>()

        for (i in 0 until num)
            if (nodes[i].state == State.NonVisited)
                `_Traval`(i, nodes).forEach { id -> list.add(id) }

        return list.toIntArray()
    }

    private fun _Traval(current: Int, nodes: Array<Node>): IntArray {
        if (nodes[current].state == State.Visited)
            return IntArray(0)

        val list = mutableListOf<Int>()

        for (next in nodes[current].nexts) {
            `_Traval`(next, nodes).forEach { id -> list.add(id) }
        }

        list.add(current)
        nodes[current].state = State.Visited
        return list.toIntArray()
    }
}