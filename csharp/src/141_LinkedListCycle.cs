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
			var slow = head;
			var fast = head.next;
			while (fast != slow)
			{
				slow = slow.next;
				if (fast.next == null || fast.next.next == null)
					return false;
				fast = fast.next.next;
			}
			return true;
		}
	}
}