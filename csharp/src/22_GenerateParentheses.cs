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
			var list = new List<string>();
			_GenParenthesis(list, string.Empty, n, 0);
			return list;
		}

		private void _GenParenthesis(IList<string> list, string result,
			int leftCount, int rightCount)
		{
			if (leftCount == 0 && rightCount == 0)
			{
				list.Add(result);
				return;
			}

			if (leftCount > 0)
				_GenParenthesis(list, result +"(", leftCount-1, rightCount+1);
			if (rightCount > 0)
				_GenParenthesis(list, result+")", leftCount, rightCount-1);
		}
	}
}