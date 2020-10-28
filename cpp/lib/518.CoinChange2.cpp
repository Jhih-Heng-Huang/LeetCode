// 518. Coin Change 2

#include "518.CoinChange2.h"

int LeetCode518CoinChange2::change(int amount, vector<int>& coins) {
    if (amount == 0) return 1;
    
    auto& table = GenTable_(amount);

    for (auto coin: coins)
        for (int i = coin; i < table.size(); ++i)
            table[i] += table[i-coin];

    auto result = table[amount];
    delete &table;
    return result;
}

vector<int>& LeetCode518CoinChange2::GenTable_(int amount) {
    auto table = new vector<int>(amount + 1);
    for (auto& e: *table) {
        e = 0;
    }
    (*table)[0] = 1;
    return *table;
}