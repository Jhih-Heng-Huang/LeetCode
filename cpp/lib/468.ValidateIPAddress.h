// 468. Validate IP Address

#ifndef LEEDCODE_468_VALIDATE_IP_ADDRESS
#define LEEDCODE_468_VALIDATE_IP_ADDRESS

#include <string>
#include <vector>

using std::string;
using std::vector;

class LeetCode468ValidateIPAddress {
public:
    string validIPAddress(string IP);

private:
    bool IsIPv4_(string);
    bool IsValidIPv4Value_(string);
    bool IsIPv6_(string);
    bool IsValidIPv6Value_(string);
    vector<string>* Split_(string s, string separator);
};

#endif