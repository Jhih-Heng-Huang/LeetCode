// 468. Validate IP Address

#include "468.ValidateIPAddress.h"
#include <string>

using std::string;

string LeetCode468ValidateIPAddress::validIPAddress(string IP) {
    if (this->IsIPv4_(IP)) return "IPv4";
    if (this->IsIPv6_(IP)) return "IPv6";
    return "Neither";
}

bool LeetCode468ValidateIPAddress::IsIPv4_(string ip) {
    if (ip.length() == 0) return false;

    auto values = this->Split_(ip, ".");
    auto result = false;

    if (values->size() != 4) {
        goto End_IsIPv4_;
    }

    for (auto& value: *values) {
        if (!this->IsValidIPv4Value_(value))
            goto End_IsIPv4_;
    }

    result = true;

End_IsIPv4_:
    delete values;
    return result;
}

bool LeetCode468ValidateIPAddress::IsValidIPv4Value_(string value) {
    if (value.length() < 1 || value.length() > 3)
        return false;

    if (value[0] == '0' && value.length() > 1)
        return false;

    for (auto& c : value) {
        if (!isdigit(c)) return false;
    }

    auto digit = atoi(value.c_str());

    if (digit < 0 || digit > 255) return false;

    return true;
}

bool LeetCode468ValidateIPAddress::IsIPv6_(string ip) {
    if (ip.length() == 0) return false;

    auto result = false;
    auto values = this->Split_(ip, ":");

    if (values->size() != 8) goto End_IsIPv6_;

    for ( auto& value: *values) {
        if (!this->IsValidIPv6Value_(value)) goto End_IsIPv6_;
    }

    result = true;
End_IsIPv6_:
    delete values;
    return result;
}

bool LeetCode468ValidateIPAddress::IsValidIPv6Value_(string value) {
    if (value.length() < 1 || value.length() > 4)
            return false;

    for (auto& c : value) {
        if (!isdigit(c) &&
            (c < 'a' || c > 'f') &&
            (c < 'A' || c > 'F'))
            return false;
    }

    return true;
}

vector<string>* LeetCode468ValidateIPAddress::Split_(string s, string separator)
{
    auto list = new vector<string>();

    for (int i = 0;;) {
        auto pos = s.find(separator, i);

        if (pos != string::npos) {
            list->push_back(s.substr(i, pos-i));
            i = pos + separator.length();
        } else {
            list->push_back(s.substr(i, s.length() - i));
            break;
        }
    }

    return list;
}