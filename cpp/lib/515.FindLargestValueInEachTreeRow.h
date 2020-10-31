// 515. Find Largest Value in Each Tree Row

#include <vector>

using std::vector;

class LeetCode515FindLargestValueInEachTreeRow
{
private:
    struct TreeNode {
        int val;
        TreeNode *left;
        TreeNode *right;
        TreeNode() : val(0), left(nullptr), right(nullptr) {}
        TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
        TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
    };
    inline int GetMaxValue_(vector<TreeNode*> &list);
public:
    vector<int> largestValues(TreeNode* root);
};