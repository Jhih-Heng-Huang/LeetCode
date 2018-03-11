#include <iostream>
#include <cstdio>
#include <cstdlib>
#include "func.h"
#include "lib/dynamic_programming.h"

int main(){
    DynamicProgramming dp;

    string s = "abc";
    std::cout << s << std::endl;
    std::cout << dp.countSubstrings(s) << std::endl;

    return 0;
}
