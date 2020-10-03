// 105. Construct Binary Tree from Preorder and Inorder Traversal

class TreeNode(var `val`: Int) {
    var left: TreeNode? = null
    var right: TreeNode? = null
}

class LeetCode105ConstructBinaryTreeFromPreorderAndInorderTraversal {
    fun buildTree(preorder: IntArray, inorder: IntArray): TreeNode? {
        return `_buildTree`(
            preorder, 0, preorder.size-1,
            inorder, 0, inorder.size-1)
    }
    
    private fun _buildTree(
        preorder: IntArray, lPre: Int, rPre: Int,
        inorder: IntArray, lIn: Int, rIn: Int): TreeNode? {
        
        if (preorder.isEmpty() || inorder.isEmpty() || lPre > rPre)
            return null
    
        val v = preorder[lPre]
        val node = TreeNode(v);
        val index = inorder.indexOf(v)
        val len = index - lIn

        node.left = `_buildTree`(
            preorder, lPre+1, lPre+len,
            inorder, lIn, index-1
        )
        
        node.right = `_buildTree`(
            preorder, lPre+len+1, rPre,
            inorder, index+1, rIn 
        )
    
        return node
    }
}