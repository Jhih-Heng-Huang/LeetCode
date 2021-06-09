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
			while (slow != fast)
			{
				if (fast.next == null || fast.next.next == null) return false;
				slow = slow.next;
				fast = fast.next.next;
			}
			return true;
		}
	}
}