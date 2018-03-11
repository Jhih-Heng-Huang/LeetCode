#ifndef CPP_LIB_DYNAMIC_PROGRAMMING_H
#define CPP_LIB_DYNAMIC_PROGRAMMING_H

#include <vector>
#include <string>

using std::vector;
using std::string;

class DynamicProgramming {
public:
	DynamicProgramming() {}
	vector<int> countBits(const int num);
	int countSubstrings(string s);
private:
	bool isPalindromic(const string& s, const int front, const int back);
};

#endif