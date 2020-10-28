// 518. Coin Change 2

#include "518.CoinChange2.h"

int LeetCode518CoinChange2::change(int amount, vector<int>& coins) {
    if (amount == 0) return 1;
    if (coins.size() == 0) return 0;
    
    vector<int> table(amount+1, 0);
    table[0] = 1;

    for (auto coin: coins)
        for (int i = coin; i < table.size(); ++i)
            table[i] += table[i-coin];

    return table[amount];
}