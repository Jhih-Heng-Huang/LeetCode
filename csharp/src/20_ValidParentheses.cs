/*
LeetCode: 20. Valid Parentheses
*/

using System.Collections.Generic;

namespace LeetCode.Problem_20
{
	public class Solution {
		public bool IsValid(string s)
		{
			if (string.IsNullOrEmpty(s)) return true;

			var stack = new Stack<char>();
			foreach(var c in s) {
				if (_IsLeft(c)) {
					stack.Push(c);
					continue;
				}
				
				if (stack.Count == 0) return false;

				var left = stack.Pop();
				
				if (!_IsPair(left, c)) return false;
			}

			if (stack.Count > 0) return false;
			return true;
		}

		private bool _IsLeft(char c)
		=> (c == '(') || (c == '[') || (c == '{');

		private bool _IsPair(char left, char right)
		=> (left == '(' && right == ')') ||
		(left == '[' && right == ']') ||
		(left == '{' && right == '}');

	}
}