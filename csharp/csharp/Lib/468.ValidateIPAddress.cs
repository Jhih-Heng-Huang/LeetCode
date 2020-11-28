/*
LeetCode: 468. Validate IP Address
*/

using System;
using System.Linq;

public class ValidateIPAddress {
    public string ValidIPAddress(string IP) {
        if (_IsIPv4(IP)) return "IPv4";
        if (_IsIPv6(IP)) return "IPv6";
        return "Neither";
    }

    private bool _IsIPv4(string ip)
    {
        if (string.IsNullOrEmpty(ip)) return false;

        var ipValues = ip.Split('.');

        if (ipValues.Length != 4) return false;
        foreach (var ipValue in ipValues)
            if (!_IsValidIPv4Value(ipValue))
                return false;

        return true;
    }

    private bool _IsValidIPv4Value(string ipValue)
    {
        if (string.IsNullOrEmpty(ipValue)) return false;

        if (ipValue.Length > 3) return false;
        if (ipValue.Any(c => !Char.IsDigit(c))) return false;
        if (ipValue.Length > 1 && ipValue.First() == '0') return false;
        var value = int.Parse(ipValue);
        if (255 < value || value < 0) return false;

        return true;
    }

    private bool _IsIPv6(string ip)
    {
        if (string.IsNullOrEmpty(ip)) return false;

        var ipValues = ip.Split(':');

        if (ipValues.Length != 8) return false;

        foreach (var ipValue in ipValues)
            if (!_IsIPv6Value(ipValue))
                return false;

        return true;
    }

    private bool _IsIPv6Value(string ipValue)
    {
        if (string.IsNullOrEmpty(ipValue)) return false;

        if (ipValue.Length > 4 || ipValue.Length < 1)
            return false;

        for (int i = 0; i < ipValue.Length; ++i)
        {
            var c = ipValue[i];
            if (!Char.IsDigit(c) &&
                (c < 'a' || c > 'f') &&
                (c < 'A' || c > 'F'))
                return false;
        }

        return true;
    }
}