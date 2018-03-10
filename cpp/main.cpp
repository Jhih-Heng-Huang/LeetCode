#include <iostream>
#include <cstdio>
#include <cstdlib>
#include "func.h"
#include "lib/dynamic_programming.h"


template<class T>
void show(vector<T>& v){
    if(!v.empty()){
        for(size_t i=0; i<v.size(); ++i)
            std::cout << v[i];
        std::cout << std::endl;
    }
}

template<class T>
void show2D(vector<vector<T>>& v){
    if(!v.empty()){
        for(size_t i=0; i<v.size(); ++i){
            for(size_t j=0; j<v[i].size(); ++j)
                std::cout << v[i][j];
            std::cout << std::endl;
        }
        std::cout << std::endl;
    }
}

int main(){
    const size_t rowLen=5,colLen=6;
    char table[rowLen][colLen] ={
        "XXXXX",
        "XOOOX",
        "XOOOX",
        "XXXXO",
        "XXOOO",
        };
    vector<vector<char>> map(rowLen);
    for(size_t i=0; i<map.size(); ++i)
        map[i].assign(table[i], table[i]+sizeof(table[i])/sizeof(char));

    show2D(map);
    solve(map);
    show2D(map);

    

    return 0;
}
