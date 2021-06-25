/*
LeetCode: 22. Generate Parentheses
*/

using System.Collections.Generic;

namespace LeetCode.Problem_22
{
	public class Solution
	{
		public IList<string> GenerateParenthesis(int n)
		{
			var results = new List<string>();
			_GenParenthesis(results, string.Empty, n, 0);
			return results;
		}

		private void _GenParenthesis(
			IList<string> results, string result,
			int leftNum, int rightNum)
		{
			if (leftNum == 0 && rightNum == 0)
			{
				results.Add(result);
				return;
			}

			if (leftNum > 0) _GenParenthesis(results, result+"(", leftNum-1, rightNum+1);
			if (rightNum > 0) _GenParenthesis(results, result+")", leftNum, rightNum-1);
		}
	}
}