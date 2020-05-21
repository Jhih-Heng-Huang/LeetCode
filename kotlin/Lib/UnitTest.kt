package LeetCode.UnitTest

import LeetCode.DepthFirstSeach.MaximumDepthBinaryTree.maxDepth
import LeetCode.TreeNode
import LeetCode.showDetail


fun testMaximumDepthBinaryTree(): Boolean
{
    println("testMaximumDepthBinaryTree")

    var root: TreeNode? = TreeNode(0)
    root?.left = TreeNode(1)
    root?.right = TreeNode(2)
    root?.left?.left = TreeNode(3)
    root?.right?.left = TreeNode(4)
    
    val lazyMsg: () -> String = {"Case ${root?.showDetail()} is failed"}
    assert(maxDepth(root) == 3, lazyMsg)

    root?.left = null
    assert(maxDepth(root) == 3, lazyMsg)

    root?.right?.left = null
    assert(maxDepth(root) == 2, lazyMsg)
    
    root = null
    assert(maxDepth(root) == 0, lazyMsg)
    return true;
}