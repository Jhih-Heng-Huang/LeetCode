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