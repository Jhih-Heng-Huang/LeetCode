// LeetCode: 513. Find Bottom Left Tree Value

#include <vector>

using std::vector;

namespace LeetCode513FindBottomLeftTreeValue
{
    struct TreeNode {
        int val;
        TreeNode *left;
        TreeNode *right;
        TreeNode() : val(0), left(nullptr), right(nullptr) {}
        TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
        TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
    };

    class Solution {
    public:
        int findBottomLeftValue(TreeNode* root) {
            if (root == NULL) return -1;

            vector<TreeNode*> row(1, root);
            auto val = -1;
            while (!row.empty()) {
                val = row.front()->val;

                vector<TreeNode*> nextRow;
                for (auto node: row) {
                    if (node->left != NULL) nextRow.push_back(node->left);
                    if (node->right != NULL) nextRow.push_back(node->right);
                }

                row.assign(nextRow.begin(), nextRow.end());
            }
            return val;
        }
    };
}