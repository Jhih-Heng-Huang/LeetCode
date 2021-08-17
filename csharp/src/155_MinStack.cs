/*
LeetCode: 155. Min Stack
*/

using System.Collections.Generic;

namespace LeetCode.Problem_155
{
	public class MinStack
	{
		#region Private members
		private Stack<int> _stack;
		private Stack<int> _minStack;
		#endregion

		/** initialize your data structure here. */
		public MinStack() {
			_stack = new Stack<int>();
			_minStack = new Stack<int>();
		}
		
		public void Push(int val) {
			_stack.Push(val);
			if (_minStack.Count == 0 || _minStack.Peek() > val)
				_minStack.Push(val);
			else
				_minStack.Push(_minStack.Peek());
		}
		
		public void Pop() {
			if (_stack.Count == 0) return;
			
			_stack.Pop();
			_minStack.Pop();
		}
		
		public int Top() {
			return _stack.Peek();
		}
		
		public int GetMin() {
			return _minStack.Peek();
		}
	}
}