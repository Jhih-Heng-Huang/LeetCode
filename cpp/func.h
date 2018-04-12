#ifndef FUNC_H
#define FUNC_H
#include <iostream>
#include <vector>
#include <climits>
#include <algorithm>
#include <cmath>
#include <map>
#include <set>
#include <unordered_map>
#include <utility>
#include <deque>
#include <cctype>
#include <string>

using std::deque;
using std::vector;
using std::unordered_map;
using std::pair;

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

// 461. Hamming Distance
int hammingDistance(int x, int y) {
    int num = x ^ y;
    int count = 0;
    while (num != 0) {
        count += (num%2);
        num/=2;
    }
    return count;
}

// 477. Total Hamming Distance
int totalHammingDistance(vector<int>& nums) {
    if (nums.size() == 0) {
        return 0;
    }
    // find out the index of max number in the list
    int max_i = 0;
    for (int i = 0; i < nums.size(); ++i) {
        if (nums[i] > nums[max_i]) {
            max_i = i;
        }
    }
    // compute total hamming distance until
    // the max number equal to 0
    int dist = 0;
    while (nums[max_i] != 0) {
        // compute the total hamming distance of
        // all least significant bits
        int count_0 = 0;
        int count_1 = 0;
        for (auto &num: nums) {
            (num % 2 == 0)? ++count_0 : ++count_1;
            num /= 2;
        }
        dist += (count_0 * count_1);
    }
    return dist;
}

// 231. Power of Two
bool isPowerOfTwo(int n) {
    if (n >= 0) {
        return false;
    }
    while (n != 1) {
        if (n % 2 == 1) {
            return false;
        }
        n /= 2;
    }
    return true;
}

bool isSameTree(TreeNode* s, TreeNode* t){
    if(s==NULL && t==NULL)
        return true;
    else if(s!=NULL && t!=NULL){
        return (s->val!=t->val)?false:isSameTree(s->left,t->left) & isSameTree(s->right,t->right);
    }
    else
        return false;
}

bool isSubtree(TreeNode* s, TreeNode* t){
    if(isSameTree(s,t))
        return true;
    else if(s!=NULL)
        return isSubtree(s->left,t)|isSubtree(s->right,t);
    else
        return false;
}

int maxDepth(TreeNode* root){
    if(root==NULL)
        return 0;
    else{
        int leftDepth=maxDepth(root->left)+1;
        int rightDepth=maxDepth(root->right)+1;
        return (leftDepth>rightDepth)?leftDepth:rightDepth;
    }
}

int LongestRootValueDepth(const TreeNode* root)
{
    if (root == NULL) {
        return 0;
    }
    // Get left longest depth with the same value of root
    int left_max_depth = 0;
    if (root->left != NULL &&
        root->val == root->left->val) {
        left_max_depth = 1 + LongestRootValueDepth(root->left);
    }
    // Get right longest depth with the same value of root
    int right_max_depth = 0;
    if (root->right != NULL &&
        root->val == root->right->val) {
        right_max_depth = 1 + LongestRootValueDepth(root->right);
    }

    return (left_max_depth > right_max_depth)?
        left_max_depth : right_max_depth;
}

int longestUnivaluePath(const TreeNode* root) {
    if (root == NULL) {
        return 0;
    }

    const int left_max_path_length = longestUnivaluePath(root->left);
    const int right_max_path_length = longestUnivaluePath(root->right);
    const int max_subtree_path_length =
            (left_max_path_length > right_max_path_length)?
            left_max_path_length : right_max_path_length;
    int max_root_path_length = 0;
    if (root->left != NULL &&
        root->val == root->left->val) {
        max_root_path_length +=
            (1 + LongestRootValueDepth(root->left));
    }

    if (root->right != NULL &&
        root->val == root->right->val) {
        max_root_path_length +=
            (1 + LongestRootValueDepth(root->right));
    }

    return (max_root_path_length > max_subtree_path_length)?
        max_root_path_length : max_subtree_path_length;
}

bool isBalanced(TreeNode* root){
    if(root==NULL)
        return true;
    else{
        bool ans=isBalanced(root->left) & isBalanced(root->right);
        if(!ans)
            return ans;
        else{
            int leftMaxDepth=(root->left!=NULL)?maxDepth(root->left):0;
            int rightMaxDepth=(root->right!=NULL)?maxDepth(root->right):0;
            return (abs(leftMaxDepth-rightMaxDepth)<2)?true:false;
        }
    }
}



int minDepth(TreeNode* root){
    if(root==NULL)
        return 0;
    else if(root->left==NULL && root->right==NULL)
        return 1;
    else{
        int leftDepth=(root->left!=NULL)?minDepth(root->left)+1:INT_MAX;
        int rightDepth=(root->right!=NULL)?minDepth(root->right)+1:INT_MAX;
        return (leftDepth<rightDepth)?leftDepth:rightDepth;
    }
}


int maxProduct(const vector<int>& nums){
    vector<int> max = nums;
    vector<int> min = nums;
    int res = nums[0];

    for (unsigned int i = 1; i < nums.size(); ++i) {
        if (nums[i] >= 0) {
            max[i] = (max[i-1]*nums[i] > nums[i])?
                max[i-1]*nums[i]:nums[i];
            min[i] = (min[i-1]*nums[i] < nums[i])?
                min[i-1]*nums[i]:nums[i];
        } else {
            max[i] = (min[i-1]*nums[i] > nums[i])?
                min[i-1]*nums[i]:nums[i];
            min[i] = (max[i-1]*nums[i] < nums[i])?
                max[i-1]*nums[i]:nums[i];
        }
        res = (max[i] > res)? max[i]:res;
    }
    return res;
}

int maxSubArray(std::vector<int>& nums){
    int sum=nums[0];
    int maxSum=sum;
    for(int i=1; i<nums.size(); ++i){
        sum=(sum<0)?nums[i]:nums[i]+sum;
        maxSum=std::max(maxSum,sum);
    }
    return maxSum;
}

int maxProfit(std::vector<int>& prices){
    int low=INT_MAX;
    int max=0;
    for(int i=0; i<prices.size(); ++i){
        low=(low>prices[i])?prices[i]:low;
        max=(max<(prices[i]-low))?(prices[i]-low):max;
    }
    return max;
}

template<class X>
void mergeList(std::vector<X>& nums, size_t first, size_t middle, size_t last){
    size_t left=first, right=middle;
    std::vector<X> tmp;
    while(left<middle && right<last){
        if(nums[left]<nums[right]){
            tmp.push_back(nums[left]);
            ++left;
        }
        else{
            tmp.push_back(nums[right]);
            ++right;
        }
    }

    while(left<middle){
        tmp.push_back(nums[left]);
        ++left;
    }

    while(right<last){
        tmp.push_back(nums[right]);
        ++right;
    }

    for(size_t i = 0; i<(last-first); ++i){
        nums[i+first]=tmp[i];
    }
    tmp.clear();
}

template <class X>
void mergeSort(std::vector<X>& nums, size_t first, size_t last){
    if(last-first>1){
        size_t middle=(first+last)/2;
        mergeSort(nums,first,middle);
        mergeSort(nums,middle,last);
        mergeList(nums,first,middle,last);
    }
}

int majorityElement(std::vector<int>& nums){
    // Moore's voting
    int major=nums[0];
    size_t count=1;
    for(size_t i=1; i<nums.size(); ++i){
        (major==nums[i])?++count:--count;
        if(count==0){
            major=nums[i];
            ++count;
        }
    }
    return major;
}

vector<int> twoSum(const vector<int>& nums, const int target)
{
    vector<int> solution_index;
    for (unsigned int sub_end = 1; sub_end < nums.size();
        ++sub_end) {
        solution_index.clear();
        for (unsigned int i = 0; i < sub_end; ++i) {
            if (nums[i] + nums[sub_end] == target) {
                solution_index.push_back(i);
                solution_index.push_back(sub_end);
                return solution_index;
            }
        }
    }

    return solution_index;
}

int reverse(int x){
    // reverse x
    long long reverse_x = 0;
    while (x != 0) {
        reverse_x = reverse_x * 10 + (long long)(x % 10);
        x /= 10;
    }

    // set reverse_x to 0 when reverse_x overflow 
    reverse_x = (INT_MIN <= reverse_x && reverse_x <= INT_MAX )? 
                reverse_x : 0;

    return (int)reverse_x;
}

struct ListNode{
    int val;
    ListNode *next;
    ListNode(int x) : val(x), next(NULL) {}
};



ListNode* reverseList(ListNode* head){
    if (head == NULL || head->next == NULL) {
        return head;
    }

    ListNode* previous_node = NULL;
    ListNode* present_node = head;
    ListNode* next_node = head->next;
    while (next_node != NULL) {
        present_node->next = previous_node;
        previous_node = present_node;
        present_node = next_node;
        next_node = next_node->next;
    }
    present_node->next = previous_node;

    return present_node;
}

bool isPalindrome(ListNode* head){
    if (head == NULL || head->next == NULL) {
        return true;
    } else {
        // get full length of the link list
        unsigned int full_length = 0;
        ListNode* post_head = head;
        while (post_head != NULL) {
            ++full_length;
            post_head = post_head->next;
        }

        // reverse the post of half link list
        unsigned int half_length = (full_length + 1)/2;
        post_head = head;
        for (unsigned int i = 0; i < half_length; ++i) {
            post_head = post_head->next;
        }
        post_head = reverseList(post_head);

        // check if the link list is palindrome
        ListNode* pre_head = head;
        while (post_head != NULL) {
            if (post_head->val != pre_head->val) {
                return false;
            }
            pre_head = pre_head->next;
            post_head = post_head->next;
        }
        return true;
    }
}


int climbStairs(int n){
    if (n < 3) {
        return n;
    }

    vector<int> num_ways;
    num_ways.push_back(0);
    num_ways.push_back(1);
    num_ways.push_back(2);
    for (unsigned int i = 3; i <= n; ++i) {
        num_ways.push_back(num_ways[i - 1] + num_ways[i - 2]);
    }

    return num_ways.back();
}

int minCostClimbingStairs(const vector<int>& cost) {
    vector<int> min_cost;
    min_cost.push_back(cost[0]);
    min_cost.push_back(cost[1]);
    for (unsigned int i = 2; i < cost.size(); ++i) {
        if (min_cost[i - 1] < min_cost[i - 2]) {
            min_cost.push_back(min_cost[i - 1] + cost[i]);
            continue;
        }
        min_cost.push_back(min_cost[i - 2] + cost[i]);
    }

    const int last_first_stair = min_cost.back();
    const int last_second_stair = min_cost[min_cost.size() - 2];
    return (last_first_stair < last_second_stair)?
        last_first_stair : last_second_stair;
}

vector<int> countBits(int num){
    vector<int> result(1,0);

    for(int i=1; i<=num; ++i)
        result.push_back(result[i/2]+i%2);

    return result;
}

int rob(vector<int>& nums){
    int odd=0,even=0;

    for(int i=0; i<nums.size(); ++i){
        if(i%2==0)
            even=std::max(nums[i]+even,odd);
        else
            odd=std::max(nums[i]+odd,even);
    }

    return ((nums.size()-1)%2==0)?even:odd;
}

class NumArray {
public:
    NumArray(vector<int> nums){
        sum.push_back(0);
        for(size_t i=0; i<nums.size(); ++i){
            sum.push_back(sum.back()+nums[i]);
        }
    }
    
    int sumRange(int i, int j){
        return sum[j+1]-sum[i];
    }
    
private:
    vector<int> sum;
};

void reverse1DArray(vector<int>& array){
    for(int i=0; i<(array.size()+1)/2; ++i){
        // swap
        int temp=array[i];
        array[i]=array[array.size()-i-1];
        array[array.size()-i-1]=temp;
    }
}

void reverseMatrix(vector<vector<int> >& matrix){
    // reverse all rows
    for(int i=0; i<matrix.size(); ++i){
        reverse1DArray(matrix[i]);
    }

    // transport of matrix
    for(int i=0; i<matrix.size(); ++i){
        for(int j=i; j<matrix.size(); ++j){
            // swap (i,j) and (j,i)
            int temp=matrix[i][j];
            matrix[i][j]=matrix[j][i];
            matrix[j][i]=temp;
        }
    }
}

void InitialMatrix(const vector<vector<int>>& matrix,
        vector<vector<int>>& dist)
{
    for (const auto &list: matrix) {
        dist.push_back(list);
    }

    for (auto &list: dist) {
        for (auto &element: list) {
            if (element == 1) {
                element = 20000;
            }
        }
    }
}

void UpdateLeftDist(vector<vector<int>>& dist)
{
    for (unsigned int row = 0; row < dist.size(); ++row) {
        for (unsigned int col = 1; col < dist[row].size(); ++col) {
            int ori_dist = dist[row][col];
            dist[row][col] = (dist[row][col-1] + 1 < ori_dist)?
                dist[row][col-1] + 1 : ori_dist;
        }
    }
}

void UpdateRightDist(vector<vector<int>>& dist)
{
    for (unsigned int row = 0; row < dist.size(); ++row) {
        for (int col = dist[row].size() - 2;
            col >= 0; --col) {
            int ori_dist = dist[row][col];
            dist[row][col] = (dist[row][col+1] + 1 < ori_dist)?
                dist[row][col+1] + 1 : ori_dist;
        }
    }
}

void UpdateAboveDist(vector<vector<int>>& dist)
{
    for (unsigned int row = 1; row < dist.size(); ++row) {
        for (unsigned int col = 0; col < dist[row].size(); ++col) {
            int ori_dist = dist[row][col];
            dist[row][col] = (dist[row-1][col] + 1 < ori_dist)?
                dist[row-1][col] + 1 : ori_dist;
        }
    }
}

void UpdateBelowDist(vector<vector<int>>& dist)
{
    for (int row = dist.size() - 2; row >= 0; --row) {
        for (unsigned int col = 0; col < dist[row].size(); ++col) {
            int ori_dist = dist[row][col];
            dist[row][col] = (dist[row+1][col] + 1 < ori_dist)?
                dist[row+1][col] + 1 : ori_dist;
        }
    }
}

// return a matrix with each element recording a distance with nearest 0
vector<vector<int>> updateMatrix(const vector<vector<int>>& matrix){
    vector<vector<int>> dist;
    // get the initial distance matrix
    InitialMatrix(matrix, dist);
    // update the left distance
    UpdateLeftDist(dist);
    // update the right distance
    UpdateRightDist(dist);
    // update the above distance
    UpdateAboveDist(dist);
    // update the below distance
    UpdateBelowDist(dist);

    return dist;
}

void depthFirstSearch(vector<vector<char> >& board, const int rIndex, const int cIndex){
    deque<std::pair<int,int>> stack;
    stack.push_back({rIndex,cIndex});

    while(!stack.empty()){
        std::pair<int,int> pos;
        pos=stack.back();
        stack.pop_back();
        if(board[pos.first][pos.second]=='O'){
            board[pos.first][pos.second]='I';
            if(pos.first>=1)
                stack.push_back({pos.first-1,pos.second});
            if(pos.second>=1)
                stack.push_back({pos.first,pos.second-1});
            if(pos.first+1<board.size())
                stack.push_back({pos.first+1,pos.second});
            if(pos.second+1<board[pos.first].size())
                stack.push_back({pos.first,pos.second+1});
        }
    }
}

void solve(vector<vector<char> >& board){
    if(!board.empty()){
        const int upBound=0, downBound=board.size()-1;
        const int leftBound=0, rightBound=board[0].size()-1;

        for(int j=0; j<board[upBound].size(); ++j)
            depthFirstSearch(board,upBound,j);
        for(int j=0; j<board[downBound].size(); ++j)
            depthFirstSearch(board,downBound,j);
        for(int i=0; i<board.size(); ++i)
            depthFirstSearch(board,i,leftBound);
        for(int i=0; i<board.size(); ++i)
            depthFirstSearch(board,i,rightBound);

        for(int i=0; i<board.size(); ++i)
            for(int j=0; j<board[i].size(); ++j)
                switch(board[i][j]){
                    case 'I':
                        board[i][j]='O';
                        break;
                    case 'O':
                        board[i][j]='X';
                        break;
                    default:
                        break;
                }
    }
}

void levelOrderBottom(TreeNode* root, vector<vector<int>>& levelStack){
    if(root!=NULL){
        deque<pair<TreeNode*,int>> path;
        path.push_back({root,0});

        while(!path.empty()){
            TreeNode* p=path.front().first;
            int depth=path.front().second;
            path.pop_front();
            if(p->left!=NULL)
                path.push_back({p->left,depth+1});
            if(p->right!=NULL)
                path.push_back({p->right,depth+1});
            
            if(depth<levelStack.size())
                levelStack[depth].push_back(p->val);
            else
                levelStack.push_back(vector<int>(1,p->val));
            
        }
    }
}

template<class T>
void reverseStack(vector<vector<T>>& v){
    vector<vector<T>> tempStack;
    while(!v.empty()){
        tempStack.push_back(v.back());
        v.pop_back();
    }
    v=tempStack;
}

vector<vector<int>> levelOrderBottom(TreeNode* root){
    vector<vector<int>> levelStack;
    levelOrderBottom(root,levelStack);
    reverseStack(levelStack);
    return levelStack;
}

class Math
{
public:
    int myAtoi(std::string str) {
        int pos = str.find_first_not_of(' ');
        long int num = 0;
        long int indicator = 1;
        switch (str[pos]) {
            case '-':
                indicator = -1;
                break;
            case '+':
                indicator = 1;
                break;
            default:
                if (isdigit(str[pos])) {
                    num = str[pos] - '0';
                } else {
                    return 0;
                }
        }

        for (unsigned int i = pos + 1; i < str.size(); ++i) {
            if (!isdigit(str[i])) {
                return num * indicator;
            }
            num = num * 10 + (str[i] - '0');
            if (num * indicator > INT_MAX) return INT_MAX;
            if (num * indicator < INT_MIN) return INT_MIN;
        }
        return num * indicator;
    }
};

class Tree
{
public:
    int sumNumbers(const TreeNode* root) {
        if (root == NULL) {
            return 0;
        }
        return sumNumbers(root, root->val);
    }
private:
    int sumNumbers(const TreeNode* root, int val) {
        // return val if the root is a leaf of tree
        if (root->left == NULL && root->right == NULL) {
            return val;
        }
        // get the val of left subtree
        int sum_val = 0;
        if (root->left != NULL) {
            int left_val = val * 10 + root->left->val;
            sum_val += sumNumbers(root->left, left_val);
        }

        // get the val of right subtree
        if (root->right != NULL) {
            int right_val = val * 10 + root->right->val;
            sum_val += sumNumbers(root->right, right_val);
        }
        return sum_val;
    }
};


struct UndirectedGraphNode {
    int label;
    vector<UndirectedGraphNode *> neighbors;
    UndirectedGraphNode(int x) : label(x) {};
};

class Graph
{
public:
    UndirectedGraphNode *cloneGraph(const UndirectedGraphNode *node) {
        if (node == NULL) {
            return NULL;
        }

        if (visited_nodes.find(node->label) != visited_nodes.end()) {
            // return the node from the list if the node has been visited
            return visited_nodes[node->label];
        } else {
            // Or clone the unvisited node & push it into the visited list
            UndirectedGraphNode *new_node
                = new UndirectedGraphNode(node->label);
            visited_nodes[node->label] = new_node;
            for (const auto& neighbor: node->neighbors) {
                new_node->neighbors.push_back(cloneGraph(neighbor));
            }
            return new_node;
        }
    }
private:
    std::map<int, UndirectedGraphNode*> visited_nodes;
public:
    void GetAdjacencyList(const int n,
            const vector<pair<int,int>>& edges,
            std::map<int, std::set<int>>& adj_list) {
        for (const auto& edge: edges) {
            adj_list[edge.first].insert(edge.second);
            adj_list[edge.second].insert(edge.first);
        }
    }

    vector<int> findMinHeightTrees(const int n,
            const vector<pair<int, int>>& edges)
    {
        if (n == 1) {
            return vector<int>(1, 0);
        }
        // get the adjacency list of the given graph
        std::map<int, std::set<int>> adj_list;
        GetAdjacencyList(n, edges, adj_list);

        // erase every layer of the leaf nodes
        // until not exited any node in the adjacency list
        vector<int> current_leaf;
        while (!adj_list.empty()) {
            // find the leaf nodes
            vector<int> next_leaf;
            for (const auto& node: adj_list) {
                if (node.second.size() <= 1) {
                    next_leaf.push_back(node.first);
                }
            }
            current_leaf = next_leaf;
            // erase the leaf nodes
            for (const auto& leaf_node: next_leaf) {
                for (const auto& leaf_neighbor: adj_list[leaf_node]) {
                    adj_list[leaf_neighbor].erase(leaf_node);
                }
                adj_list.erase(leaf_node);
            }
        }
        return current_leaf;
    }

    void GetAdjacencyList(const int N,
        const vector<vector<int>>& times,
        vector<vector<std::pair<int, int>>>& adj_list)
    {
        adj_list.assign(N + 1, vector<std::pair<int, int>>());
        const int source = 0, target = 1, length = 2;

        for (const auto& edge: times) {
            adj_list[edge[source]].push_back(
                std::pair<int, int>(edge[target], edge[length]));
        }
    }

    void DijstraAlgorithm(const int N, const int K,
            const vector<vector<std::pair<int, int>>>& adj_list,
            vector<int>& distance)
    {
        distance.assign(N+1, INT_MAX);
        distance[0] = 0;
        distance[K] = 0;
        vector<int> head(1, K);
        while (!head.empty()) {
            const int node = head.back();
            head.pop_back();
            for (const auto& end: adj_list[node]) {
                const int new_dist = distance[node] + end.second;
                if (new_dist < distance[end.first]) {
                    distance[end.first] = new_dist;
                    head.push_back(end.first);
                }
            }
        }

    }

    int networkDelayTime(vector<vector<int>>& times, int N, int K) {
        // preprocessing data (adjacency matrix)
        vector<vector<std::pair<int, int>>> adj_list;
        GetAdjacencyList(N, times, adj_list);
        // get the minimum delay time to broadcast the signal
        vector<int> distance;
        DijstraAlgorithm(N, K, adj_list, distance);
        int max_dist = 0;
        for (const auto& dist: distance) {
            if (dist == INT_MAX) {
                return -1;
            }
            max_dist = (max_dist < dist)? dist : max_dist;
        }
        return max_dist;
    }
};


class GridMap
{
public:
    int findPaths(int m, int n, int N, int i, int j) {
        if (N == 0) {
            return 0;
        }
        // gen a num table for recording the number of ways go to the grid
        // for each step
        vector<vector<long long>> num_table(m, vector<long long>(n, 0));
        num_table[i][j] = 1;
        vector<vector<long long>> sum_table = num_table;

        // compute the num table from 1 step to N-1 step
        mod = 1000000000 + 7;
        for (int step = 1; step < N; ++step) {
            ComputeNumTable(num_table);
            ComputeSumTable(sum_table, num_table);
        }
        // summing the number of ways to go out of the boundary
        long long sum_ways = 0;
        // top boundary
        for (const auto& num: sum_table.front()) {
            sum_ways += num;
            sum_ways %= mod;
        }
        // bottom boundary
        for (const auto& num: sum_table.back()) {
            sum_ways += num;
            sum_ways %= mod;
        }
        // left & right boundary
        for (const auto& list: sum_table) {
            sum_ways += list.front();
            sum_ways %= mod;
            sum_ways += list.back();
            sum_ways %= mod;
        }
        return sum_ways;
    }
private:
    long long mod;
    void ComputeNumTable(vector<vector<long long>>& table) {
        vector<vector<long long>> temp(table.size(),
            vector<long long>(table[0].size(), 0));
        for (int row = 0; row < table.size(); ++row) {
            for (int col = 0; col < table[row].size(); ++col) {
                // up
                if (row - 1 >= 0) {
                    temp[row][col] += table[row - 1][col];
                    temp[row][col] %= mod;
                }
                // down
                if (row + 1 < table.size()) {
                    temp[row][col] += table[row + 1][col];
                    temp[row][col] %= mod;
                }
                // left
                if (col - 1 >= 0) {
                    temp[row][col] += table[row][col - 1];
                    temp[row][col] %= mod;
                }
                // right
                if (col + 1 < table[row].size()) {
                    temp[row][col] += table[row][col + 1];
                    temp[row][col] %= mod;
                }
            }
        }
        table = temp;
    }
    void ComputeSumTable(vector<vector<long long>>& sum,
            const vector<vector<long long>>& table) {
        for (int row = 0; row < table.size(); ++row) {
            for (int col = 0; col < table[row].size(); ++col) {
                sum[row][col] += table[row][col];
                sum[row][col] %= mod;
            }
        }
    }
};

#endif

struct tree {
    int x;
    tree * l;
    tree * r;
};
struct Point3D {
    int x;
    int y;
    int z;
};
class Rayark {
public:
    // task 1
    int solution(vector<Point3D> &A) {
        // write your code in C++14 (g++ 6.2.0)
        std::set<long long> r_set;
        for (const auto& point: A) {
            long long val = point.x * point.x +
                point.y * point.y +
                point.z * point.z;
            r_set.insert(val);
        }
        return r_set.size();
    }

    int MaxDistinctVal(const tree* root, std::map<int, int>& set_val) {
        if (root->l == NULL && root->r == NULL) {
            return set_val.size();
        }
        int max = -1;
        if (root->l != NULL) {
            if (set_val.find(root->l->x) == set_val.end()) {
                set_val[root->l->x] = 1;
            } else {
                ++set_val[root->l->x];
            }
            int left_max = MaxDistinctVal(root->l,set_val);
            --set_val[root->l->x];
            if (set_val[root->l->x] == 0) {
                set_val.erase(root->l->x);
            }

            max = (left_max > max)? left_max:max;
        }
        if (root->r != NULL) {
            if (set_val.find(root->r->x) == set_val.end()) {
                set_val[root->r->x] = 1;
            } else {
                ++set_val[root->r->x];
            }
            int right_max = MaxDistinctVal(root->r, set_val);
            --set_val[root->r->x];
            if (set_val[root->r->x] == 0) {
                set_val.erase(root->r->x);
            }

            max = (right_max > max)? right_max:max;
        }
        return max;
    }
    // task 2
    int solution(tree * root) {
        if (root == NULL) {
            return 0;
        } else {
            std::map<int, int> set_val;
            set_val[root->x] = 1;
            return MaxDistinctVal(root, set_val);
        }
    }
    // task 3
    int solution(int A) {
        if ((A/10) == 0) {
            return A;
        }
        // get the digit length of A
        int len = 0;
        long long temp = A;
        for (; temp != 0; ++len) {
            temp /= 10;
        }
        std::cout << len << std::endl;
        // create the new digit from A
        long long front = 1;
        for (int i = 1; i < len; ++i) {
            front *= 10;
        }
        long long new_digit = 0;
        temp = A;
        while (front >= 1) {
            // get the front and the back of digit of A
            new_digit = new_digit * 10 + (temp/front);
            if (front != 1) {
                new_digit = new_digit * 10 + (temp%10);
            }
            // remove the front and the back digit of A
            temp%=front;
            temp/=10;
            front/=100;
        }
        return new_digit;
    }
};