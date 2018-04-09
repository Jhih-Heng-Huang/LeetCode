#ifndef CPP_LIB_DYNAMIC_PROGRAMMING_H
#define CPP_LIB_DYNAMIC_PROGRAMMING_H

#include <vector>
#include <string>

using std::vector;
using std::string;

class DynamicProgramming {
public:
	DynamicProgramming() {}
	// 191. Number of 1 Bits
	int hammingWeight(uint32_t n);
	// 338. Counting Bits
	vector<int> countBits(const int num);

	int countSubstrings(string s);
private:
	bool isPalindromic(const string& s, const int front, const int back);

public:
	int findLongestChain(vector<vector<int>>& pairs);
private:
	void sort(vector<vector<int>>& pairs);

// 746. Min Cost Climbing Stairs
public:
	int minCostClimbingStairs(const vector<int>& cost);
};

#endif