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


int maxProduct(vector<int>& nums){
    int maxProd=nums[0];
    int minProd=nums[0];
    int result=nums[0];

    for(int i=1; i<nums.size(); ++i){
        int newMax, newMin;
        newMax=std::max(nums[i]*maxProd,nums[i]);
        newMax=std::max(nums[i]*minProd,newMax);
        newMin=std::min(nums[i]*minProd,nums[i]);
        newMin=std::min(nums[i]*maxProd,newMin);

        maxProd=newMax;
        minProd=newMin;
        result=std::max(maxProd,result);
    }
    return result;
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
    int sumNumbers(TreeNode* root) {
        if (root == NULL) {
            return 0;
        }
        return SumNumbers(root, root->val);
    }
private:
    int SumNumbers(TreeNode* root, int val) {
        if (root->left == NULL && root->right == NULL) {
            return val;
        }

        int left_sum = 0;
        if (root->left != NULL) {
            left_sum = SumNumbers(root->left, val*10 + root->left->val);
        }
        int right_sum = 0;
        if (root->right != NULL) {
            right_sum = SumNumbers(root->right, val*10 + root->right->val);
        }

        return left_sum + right_sum;
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
    UndirectedGraphNode *cloneGraph(UndirectedGraphNode *node) {
        if (node == NULL) {
            return NULL;
        }

        // return the node which has been visited and cloned
        if (visited_nodes.find(node->label) != visited_nodes.end()) {
            return visited_nodes[node->label];
        } else {
            UndirectedGraphNode* clone_node = new UndirectedGraphNode(node->label);
            visited_nodes[clone_node->label] = clone_node;
            // visited all neighbors of this visited node
            for (auto& neighbor: node->neighbors) {
                clone_node->neighbors.push_back(cloneGraph(neighbor));
            }
            return clone_node;
        }
    }

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
private:
    std::map<int, UndirectedGraphNode*> visited_nodes;
};


class GridMap
{
public:
    void InitialMap(int row_num, int col_num, int pos_x, int pos_y,
            vector<vector<long int>>& map) {
        map.assign(row_num, vector<long int>());
        for (auto& list: map) {
            list.assign(col_num, 0);
        }
        map[pos_x][pos_y] = 1;
    }
    void CalculateNumPaths(int path_len,
            vector<vector<long int>>& map) {
        vector<vector<long int>> current = map;
        vector<vector<long int>> next = current;
        for (unsigned int len = 1; len <= path_len; ++len) {
            for (int row = 0; row < next.size(); ++row) {
                for (int col = 0; col < next[row].size(); ++col) {
                    long int sum = 0;
                    if (row - 1 >= 0) {
                        sum += current[row-1][col];
                        sum %= mod;
                    }
                    if (row + 1 < next.size()) {
                        sum += current[row+1][col];
                        sum %= mod;
                    }
                    if (col - 1 >= 0) {
                        sum += current[row][col-1];
                        sum %= mod;
                    }
                    if (col + 1 < next[row].size()) {
                        sum += current[row][col+1];
                        sum %= mod;
                    }
                    next[row][col] = sum;
                    map[row][col] += sum;
                    map[row][col] %= mod;
                }
            }
            current = next;
        }
    }
    int findPaths(int m, int n, int N, int i, int j) {
        if (N == 0) {
            return 0;
        }
        // Get the initial table
        mod = 1000000000 + 7;
        vector<vector<long int>> map;
        InitialMap(m, n, i, j, map);
        // Calculate the number of paths
        CalculateNumPaths(N-1, map);
        // Show the context of the table
        for (const auto& list: map) {
            for (const auto& num: list) {
                std::cout << '\t' << num;
            }
            std::cout << std::endl;
        }

        long int num_path = 0;
        for (auto num: map.front()) {
            num_path += num;
            num_path %= mod;
        }
        for (auto num: map.back()) {
            num_path += num;
            num_path %= mod;
        }
        for (const auto& list: map) {
            num_path += list.front();
            num_path %= mod;
            num_path += list.back();
            num_path %= mod;
        }
        return (int)num_path;
    }
private:
    long int mod;
};

#endif
