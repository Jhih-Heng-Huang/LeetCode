/*
LeetCode: 468. Validate IP Address
*/

using System;
using System.Linq;

public class ValidateIPAddress {
    public string ValidIPAddress(string IP) {
        if (_IsIPv4(IP))
			return "IPv4";
		if (_IsIPv6(IP))
			return "IPv6";
		return "Neither";
    }

	private bool _IsIPv4(string ip) {
		if (ip == null || ip.Length == 0)
			return false;
		
		var strs = ip.Split('.');
		if (strs.Length != 4)
			return false;

		foreach (var str in strs) {
			if (str.Length < 1 || str.Length > 3)
				return false;

			if (!_IsDigitalVal(str))
				return false;
			
			if (str[0] == '0' && str.Length > 1)
				return false;

			var val = int.Parse(str);
			if (val < 0 || val > 255)
				return false;
		}
		return true;
	}

	private bool _IsDigitalVal(string val) {
		foreach (var c in val.ToCharArray()) {
			if (!Char.IsDigit(c))
				return false;
		}
		return true;
	}

	private bool _IsIPv6(string ip) {
		if (ip == null || ip.Length == 0)
			return false;
		
		var strs = ip.Split(':');
		if (strs.Length != 8)
			return false;

		foreach (var str in strs) {
			if (str.Length < 1 || str.Length > 4)
				return false;

			foreach (var c in str.ToCharArray())
				if (!_IsIPv6Val(c))
					return false;
		}
		return true;
	}

	private bool _IsIPv6Val(char c) {
		return Char.IsDigit(c) ||
			(c >= 'a' && c <= 'f') ||
			(c >= 'A' && c <= 'F');
	}
}