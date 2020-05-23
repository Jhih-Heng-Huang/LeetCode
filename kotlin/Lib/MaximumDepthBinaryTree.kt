package LeetCode.MaximumDepthBinaryTree

import LeetCode.TreeNode
import java.util.LinkedList

fun maxDepthByDFS(root: TreeNode?): Int = when(root)
{
    null -> 0
    else -> 1 + maxOf(maxDepthByDFS(root.left), maxDepthByDFS(root.right))
}

fun maxDepthByBFS(root: TreeNode?): Int
{
    var oldQueue = LinkedList<TreeNode>()
    var newQueue = LinkedList<TreeNode>()
    var maxDepth = 0
    if (root != null)
        oldQueue.add(root)
    
    while (oldQueue.size != 0)
    {
        ++maxDepth
        for (node in oldQueue)
        {
            if (node.left != null)
                newQueue.add(node.left!!);
            if (node.right != null)
                newQueue.add(node.right!!);
        }
        oldQueue.clear()
        oldQueue = newQueue
        newQueue = LinkedList<TreeNode>()
    }
    return maxDepth
}