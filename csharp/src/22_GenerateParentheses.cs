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

		private void _GenParenthesis(IList<string> results, string result, int leftCount, int rightCount)
		{
			if (leftCount == 0 && rightCount == 0)
			{
				results.Add(result);
				return;
			}

			if (leftCount > 0)
				_GenParenthesis(results, result + '(', leftCount - 1, rightCount + 1);
			if (rightCount > 0)
				_GenParenthesis(results, result + ')', leftCount, rightCount - 1);
		}
	}
}