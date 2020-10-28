// 518. Coin Change 2

#include <vector>

using std::vector;

class LeetCode518CoinChange2 {
public:
    int change(int amount, vector<int>& coins);

private:
    vector<int>& GenTable_(int amount);
};