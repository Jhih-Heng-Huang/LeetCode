// 1008. Construct Binary Search Tree from Preorder Traversal

#include <vector>
#include "TreeNode.h"

using std::vector;

class LeetCode1008ConstructBinarySearchTreeFromPreorderTraversal
{
private:
	TreeNode* GenBinarySearchTree_(vector<int>& preorder, int leftIndex, int rightIndex);
public:
	TreeNode* bstFromPreorder(vector<int>& preorder);
};
