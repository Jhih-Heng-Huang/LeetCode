#include "dynamic_programming.h"
#include <algorithm>

enum Pair {front, back};

// 338. Counting Bits
vector<int> DynamicProgramming::countBits(const int num) {
	vector<int> list(1,0);
	for (int i = 1; i <= num; ++i) {
		int count = i%2 + list[i/2];
		list.push_back(count);
	}
	return list;
}

int DynamicProgramming::countSubstrings(string s) {
	if (s.size() <= 1) {
		return s.size();
	}
	int count = 0;
	for (int front = 0; front < s.size(); ++front) {
		for (int back = front; back < s.size(); ++back) {
			if (this->isPalindromic(s, front, back)) {
				++count;
			}
		}
	}
	return count;
}

bool DynamicProgramming::isPalindromic(const string& s,
		const int front, const int back) {
	for (int f = front, b = back; f < b; ++f, --b) {
		if (s[f] != s[b]) {
			return false;
		}
	}
	return true;
}

int DynamicProgramming::findLongestChain(vector<vector<int>>& pairs) {
	if (pairs.size() <= 1) {
		return pairs.size();
	}
	// sort pairs
	this->sort(pairs);
	// find each longest chain for each element as
	// the end of chain
	int max_len = 1;
	vector<int> len_chains(pairs.size(), 1);
	for (int i = 0; i < pairs.size(); ++i) {
		for (int prev = i - 1; prev >= 0; --prev) {
			if (pairs[i][front] > pairs[prev][back]) {
				len_chains[i] += len_chains[prev];
				max_len = std::max(len_chains[i], max_len);
				break;
			}
		}
	}
	return max_len;
}

void DynamicProgramming::sort(vector<vector<int>>& pairs) {
	// bubble sort
	for (int i = 0; i < pairs.size(); ++i) {
		for (int j = 1; j < pairs.size(); ++j) {
			if (pairs[j][front] < pairs[j-1][front]) {
				std::swap(pairs[j], pairs[j - 1]);
			}
		}
	}
}

// 746. Min Cost Climbing Stairs
int DynamicProgramming::minCostClimbingStairs(const vector<int>& cost) {
	vector<int> min_cost;
	min_cost.push_back(cost[0]);
	min_cost.push_back(cost[1]);

	for (unsigned int i = 2; i < cost.size(); ++i) {
		int min = cost[i] + 
			((min_cost[i-1] < min_cost[i-2])? min_cost[i-1] : min_cost[i-2]);
		min_cost.push_back(min);
	}
	const int n = min_cost.size();
	return (min_cost[n-1] < min_cost[n-2])? min_cost[n-1] : min_cost[n-2];
}