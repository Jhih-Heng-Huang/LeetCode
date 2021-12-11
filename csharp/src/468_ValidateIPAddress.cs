/*
LeetCode: 468. Validate IP Address
*/
using System;

namespace LeetCode.Problem_468
{    
	public class ValidateIPAddress {
		public string ValidIPAddress(string IP)
		{
			if (string.IsNullOrEmpty(IP)) return "Neither";
			if (_IsIPv4(IP)) return "IPv4";
			if (_IsIPv6(IP)) return "IPv6";
			return "Neither";
		}

		private bool _IsIPv4(string ip)
		{
			var vals = ip.Split('.');

			if (vals.Length != 4) return false;

			foreach (var val in vals)
				if (!_IsValidIPv4Value(val))
					return false;

			return true;
		}
		private bool _IsIPv6(string ip)
		{
			var vals = ip.Split(':');
			if (vals.Length != 8) return false;

			foreach (var val in vals)
				if (!_IsValidIPv6Value(val))
					return false;

			return true;
		}

		private bool _IsValidIPv4Value(string str)
		{
			foreach (var c in str)
				if (!char.IsDigit(c)) return false;

			if (str.Length == 0 || str.Length > 3) return false;
			if (str.Length > 1 && str[0] == '0') return false;

			var val = int.Parse(str);
			if (val < 0 || val > 255) return false;
			return true;
		}

		private bool _IsValidIPv6Value(string str)
		{
			if (str.Length == 0 || str.Length > 4) 	return false;
			foreach (var c in str)
				if (!_IsHexDigit(c))
					return false;
			return true;
		}

		private bool _IsHexDigit(char c)
		{
			return
				('A' <= c && c <= 'F') ||
				('a' <= c && c <= 'f') ||
				char.IsDigit(c);
		}
	}

}
