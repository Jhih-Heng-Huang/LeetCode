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
			List<string> list, string str,
			int leftNum, int rightNum)
		{
			if (leftNum == 0 && rightNum == 0)
				list.Add(str);
			
			if (rightNum > 0)
				_GenParenthesis(list, str + ")", leftNum, rightNum-1);
			if (leftNum > 0)
				_GenParenthesis(list, str + "(", leftNum-1, rightNum+1);
		}
	}
}