#!/usr/bin/env python3
# 468. Validate IP Address

import string

class Solution:
	def validIPAddress(self, IP: str) -> str:
		if self.__isIPv4(IP):
			return "IPv4"
		if self.__isIPv6(IP):
			return "IPv6"
		return "Neither"
	
	def __isIPv4(self, ip: str) -> bool:
		if not ip: return False
		
		vals = ip.split(".")

		if len(vals) != 4: return False

		for val in vals:
			if not self.__isValidIPv4Value(val):
				return False

		return True

	def __isValidIPv4Value(self, val: str) -> bool:
		if not val: return False

		if len(val) < 1 or len(val) > 3: return False

		if val[0] == '0' and len(val) > 1: return False

		if not val.isdigit(): return False

		if int(val) < 0 or int(val) > 255: return False

		return True
		

	def __isIPv6(self, ip: str) -> bool:
		if not ip: return False

		vals = ip.split(":")

		if len(vals) != 8: return False

		for val in vals:
			if not self.__isValidIPv6Value(val):
				return False

		return True

	def __isValidIPv6Value(self, val: str) -> bool:
		if not val: return False

		if len(val) < 1 or len(val) > 4: return False

		for c in val:
			if not c.isdigit() and c not in string.hexdigits:
				return False

		return True

if __name__ == "__main__":
	sol = Solution()
	data = ["155.125.1.1",
			"192.168.1.00",
			"192.168@1.1",
			"2001:db8:85a3:0:0:8A2E:0370:7334",
			"2001:0db8:85a3::8A2E:037j:7334",
			"02001:0db8:85a3:0000:0000:8a2e:0370:7334",
			"155:125:1:1:255:4627:4627:4627",
			"155:125:1:1:255:4627:4627:462G"]

	for ip in data:
		print (ip + ": " + sol.validIPAddress(ip))