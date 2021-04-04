/*
LeetCode: 468. Validate IP Address
*/

namespace LeetCode.Problem_468
{    
	public class ValidateIPAddress {
		public string ValidIPAddress(string IP)
		{
			if (_IsIPV4(IP)) return "IPv4";
			if (_IsIPV6(IP)) return "IPv6";
			return "Neither";
		}

		private bool _IsIPV4(string ip)
		{
			if (string.IsNullOrEmpty(ip))
				return false;
			
			var values = ip.Split('.');

			if (values.Length != 4) return false;

			foreach (var value in values)
				if (!_IsValidIPV4Value(value))
					return false;
			return true;
		}

		private bool _IsValidIPV4Value(string value)
		{
			if (string.IsNullOrEmpty(value)) return false;
			if (value.Length < 1 || value.Length > 3)
				return false;
			if (value[0] == '0' && value.Length > 1)
				return false;

			int result = 0;
			if (!int.TryParse(value, out result))
				return false;
			if (result < 0 || result > 255)
				return false;

			return true;
		}

		private bool _IsIPV6(string ip)
		{
			if (string.IsNullOrEmpty(ip))
				return false;
			
			var values = ip.Split(':');

			if (values.Length != 8) return false;

			foreach (var value in values)
				if (!_IsValidIPV6Value(value))
					return false;

			return true;
		}

		private bool _IsValidIPV6Value(string value)
		{
			if (string.IsNullOrEmpty(value))
				return false;
			
			if (value.Length < 1 || value.Length > 4)
				return false;
			
			foreach (var c in value)
				if (!char.IsDigit(c) &&
					!('a' <= c && c <= 'f') &&
					!('A' <= c && c <= 'F'))
					return false;
			return true;
		}
	}

}
