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
			if (head == null) return false;

			ListNode slow = head, fast = head;
			do
			{
				if (fast.next == null || fast.next.next == null)
					return false;
				fast = fast.next.next;
				slow = slow.next;

				if (fast == slow) return true;
			} while (fast != null);
			return false;
		}
	}
}