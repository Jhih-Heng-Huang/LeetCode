package LeetCode.ValidateBinarySearchTree

import LeetCode.TreeNode
import kotlin.math.max
import kotlin.math.min

/*
test case:

[2,1,3]
[5,1,4,null,null,3,6]
[]
[3,1,5,null,null,4,6]
 */

fun isValidBinarySearchTreeByDFS(root: TreeNode?): Boolean
{
    if (root == null)
        return true
    
    fun isValid(root: TreeNode?, min: Int?, max: Int?):Boolean
    {
        if (root == null)
            return true
        if (min != null && min >= root.`val`)
            return false
        if (max != null && max <= root.`val`)
            return false
        return isValid(root.left, min, root.`val`) && isValid(root.right, root.`val`, max)
    }

    return isValid(root, null, null)
}