package LeetCode

import java.util.LinkedList

class TreeNode(var `val` : Int)
{
    var left: TreeNode ?= null
    var right: TreeNode ?= null
}


fun TreeNode.showDetail(): String {
    val leftTreeDetail = left?.showDetail()
    val rightTreeDetail = right?.showDetail()
    return "[$`val`, [$leftTreeDetail, $rightTreeDetail]]"
}