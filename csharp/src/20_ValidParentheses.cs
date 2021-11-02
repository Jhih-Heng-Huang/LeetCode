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
			foreach (var p in s)
			{
				if (_IsLeft(p))
					stack.Push(p);
				else if (stack.Count > 0 && _IsPair(stack.Peek(), p))
					stack.Pop();
				else return false;
			}
			return stack.Count == 0;
		}

		private bool _IsLeft(char left)
		=> left == '(' || left == '[' || left == '{';

		private bool _IsPair(char left, char right)
		=> (left == '(' && right == ')') ||
			(left == '[' && right == ']') ||
			(left == '{' && right == '}');
	}
}