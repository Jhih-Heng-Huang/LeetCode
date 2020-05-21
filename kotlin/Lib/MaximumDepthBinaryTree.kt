package LeetCode.DepthFirstSeach.MaximumDepthBinaryTree

import LeetCode.TreeNode

fun maxDepth(root: TreeNode?): Int = when(root)
{
    null -> 0
    else -> 1 + maxOf(maxDepth(root.left), maxDepth(root.right))
}