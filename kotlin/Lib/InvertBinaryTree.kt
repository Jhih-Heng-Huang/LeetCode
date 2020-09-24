package LeetCode.InvertBinaryTree

/*
226. Invert Binary Tree
Test cases:
[4,2,7,1,3,6,9]
 */

import LeetCode.TreeNode

fun invertTree(root: TreeNode?): TreeNode?
{
    if (root == null)
        return null
    
    // invert left subtree & right subtree
    val leftSubTree = invertTree(root.right)
    val rightSubTree = invertTree(root.left)

    var result: TreeNode? = TreeNode(root.`val`)
    if (result != null) 
    {
        result.left = leftSubTree
        result.right = rightSubTree
    }
    return result
}