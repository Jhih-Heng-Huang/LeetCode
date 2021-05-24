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

		private void _GenParenthesis(
			IList<string> list, string result,
			int leftNum, int rightNum)
		{
			if (leftNum == 0 && rightNum == 0)
			{
				list.Add(result);
				return;
			}

			if (leftNum > 0) _GenParenthesis(list, result + "(" , leftNum-1, rightNum+1);
			if (rightNum > 0) _GenParenthesis(list, result + ")", leftNum, rightNum-1);
		}
	}
}