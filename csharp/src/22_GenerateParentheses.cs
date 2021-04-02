/*
LeetCode: 22. Generate Parentheses
*/

using System;
using System.Collections.Generic;

namespace LeetCode.Problem_22
{
	public class Solution
	{
		public IList<string> GenerateParenthesis(int n)
		{
			if (n <= 0) return new List<string>();
			return _GenerateParenthesis(n, 0);
		}

		private IList<string> _GenerateParenthesis(int leftCount, int restRightCount)
		{
			var result = new List<string>();
			if (leftCount <= 0)
				result.Add(_GenRightParenthesis(restRightCount));
			else
			{
				for (int i = 0; i <= restRightCount; ++i)
				{
					var left = _GenRightParenthesis(i) + "(";
					var rightResults = _GenerateParenthesis(
						leftCount - 1, restRightCount - i + 1);
					
					foreach (var right in rightResults)
						result.Add(left + right);
				}
			}
			return result;
		}

		private string _GenRightParenthesis(int count)
		{
			var str = string.Empty;
			for (int i = 0; i < count; ++i)
				str += ")";
			return str;
		}
	}
}