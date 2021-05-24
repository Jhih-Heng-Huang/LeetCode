/*
LeetCode: 141. Linked List Cycle
*/

namespace LeetCode.Problem_141
{
	public class ListNode {
		public int val;
		public ListNode next;
		public ListNode(int x) {
			val = x;
			next = null;
		}
	}

	class Solution
	{
		public bool HasCycle(ListNode head) {
			if (head == null || head.next == null) return false;
			var slowPointer = head;
			var fastPointer = head.next;
			while (slowPointer != fastPointer)
			{
				if (fastPointer.next == null ||
					fastPointer.next.next == null)
					return false;
				fastPointer = fastPointer.next.next;
				slowPointer = slowPointer.next;
			}
			return true;
		}
	}
}