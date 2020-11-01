// 1008. Construct Binary Search Tree from Preorder Traversal

#include "1008.ConstructBinarySearchTreeFromPreorderTraversal.h"


TreeNode* LeetCode1008ConstructBinarySearchTreeFromPreorderTraversal::GenBinarySearchTree_(vector<int>& preorder, int leftIndex, int rightIndex) {
	if (leftIndex > rightIndex) return NULL;

	auto val = preorder[leftIndex];
	auto node = new TreeNode(val);
	if (leftIndex == rightIndex) return node;

	auto seperator = rightIndex+1;
	for (int i = leftIndex+1; i <= rightIndex; ++i) {
		if (preorder[i] > val) {
			seperator = i;
			break;
		}
	}
	node->left = GenBinarySearchTree_(preorder, leftIndex+1, seperator-1);
	node->right = GenBinarySearchTree_(preorder, seperator, rightIndex);
	return node;
}

TreeNode* LeetCode1008ConstructBinarySearchTreeFromPreorderTraversal::bstFromPreorder(vector<int>& preorder) {
	if (preorder.size() == 0) return NULL;
	return GenBinarySearchTree_(preorder, 0, preorder.size() - 1);
}