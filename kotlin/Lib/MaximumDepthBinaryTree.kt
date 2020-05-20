package LeetCode.DepthFirstSeach.MaximumDepthBinaryTree

class TreeNote(var `val` : Int)
{
    var left: TreeNote ?= null
    var right: TreeNote ?= null
}

fun maxDepth(root: TreeNote?): Int = when(root)
{
    null -> 0
    else -> 1 + maxOf(maxDepth(root.left), maxDepth(root.right))
}