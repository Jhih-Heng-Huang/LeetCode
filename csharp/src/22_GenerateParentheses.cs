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
			_GenerateParenthesis(n, 0, string.Empty, results);
			return results;
		}

		private void _GenerateParenthesis(int left, int right, string result, IList<string> results)
		{
			if (left == 0) {
				for (int count = 0; count < right; ++count)
					result += ')';
				results.Add(result);
				return;
			}

			if (left > 0) _GenerateParenthesis(left-1, right+1, result + '(', results);
			if (right > 0) _GenerateParenthesis(left, right-1, result + ')', results);
		}
	}
}