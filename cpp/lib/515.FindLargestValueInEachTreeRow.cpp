#include "515.FindLargestValueInEachTreeRow.h"
#include <climits>
#include <algorithm>

inline int LeetCode515FindLargestValueInEachTreeRow::GetMaxValue_(vector<TreeNode*> &list) {
    auto max = INT_MIN;
    for (auto node: list) {
        max = std::max(max, node->val);
    }
    return max;
}

vector<int> LeetCode515FindLargestValueInEachTreeRow::largestValues(TreeNode* root) {
    vector<int> list;
    if (root == NULL) return list;

    vector<TreeNode*> row;
    row.push_back(root);

    while (!row.empty()) {
        auto max = GetMaxValue_(row);
        list.push_back(max);

        vector<TreeNode*> next;
        for (auto node: row) {
            if (node->left != NULL) next.push_back(node->left);
            if (node->right != NULL) next.push_back(node->right);
        }

        row.clear();
        row.assign(next.begin(), next.end());

    }
    return list;
}