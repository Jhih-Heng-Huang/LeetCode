#include "dynamic_programming.h"

vector<int> DynamicProgramming::countBits(const int num) {
	vector<int> list(1, 0);
	if (num == 0) {
		return list;
	}
	for (int i = 1; i <= num; ++i) {
		list.push_back(list[i/2] + i%2);
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