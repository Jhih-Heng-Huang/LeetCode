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
			var fast = head;

			while (true)
			{
				if (fast.next == null || fast.next.next == null) return false;
				else if (fast.next == slow || fast.next.next == slow) return true;
				fast = fast.next.next;
				slow = slow.next;
			}

			return false;
		}
	}
}