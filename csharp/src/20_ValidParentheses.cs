/*
LeetCode: 20. Valid Parentheses
*/

using System.Collections.Generic;

namespace LeetCode.Problem_20
{
	public class Solution {
		public bool IsValid(string s)
		{
			var stack = new Stack<char>();

			foreach (var c in s)
			{
				if (_IsLeftParenthesis(c))
					stack.Push(c);
				else if (stack.Count != 0 &&
					_IsPaired(stack.Peek(), c))
					stack.Pop();
				else
					return false;
			}

			return stack.Count == 0;
		}

		private bool _IsLeftParenthesis(char c)
		{
			return c == '[' || c == '(' || c == '{';
		}

		private bool _IsPaired(char left, char right)
		{
			return
				(left == '(' && right == ')') ||
				(left == '[' && right == ']') ||
				(left == '{' && right == '}');
		}
	}
}