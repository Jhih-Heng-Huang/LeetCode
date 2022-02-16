// LeetCode: 146. LRU Cache
using System.Collections.Generic;

namespace LeetCode.Problem_146
{
	public class LRUCache {
		private class Node
		{
			public int key;
			public int value;
			public Node previous = null;
			public Node next = null;
		}
		private int _capacity;
		private Node _head = null;
		private Node _tail = null;
		private Dictionary<int, Node> _dic = new Dictionary<int, Node>();

		public LRUCache(int capacity)
		{
			_capacity = capacity;
			_head = new Node();
			_tail = new Node();
			_head.next = _tail;
			_tail.previous = _head;
		}

		public int Get(int key)
		{
			if (!_dic.ContainsKey(key)) return -1;

			_MoveToHead(_dic[key]);
			return _dic[key].value;
		}
		
		public void Put(int key, int value)
		{
			if (_dic.ContainsKey(key))
			{
				_dic[key].value = value;
				_MoveToHead(_dic[key]);
				return;
			}

			_PutOnList(key, value);
		}

		private void _MoveToHead(Node node)
		{
			_Remove(node);
			_AddToHead(node);
		}

		private void _PutOnList(int key, int value)
		{
			if (_dic.Keys.Count == _capacity)
				_PopLast();

			var node = new Node();
			node.key = key;
			node.value = value;

			_dic.Add(key, node);
			_AddToHead(node);
		}

		private void _AddToHead(Node node)
		{
			var previousNode = _head;
			var nextNode = _head.next;

			node.previous = previousNode;
			node.next = nextNode;
			
			previousNode.next = node;
			nextNode.previous = node;
		}

		private void _PopLast()
		{
			var last = _tail.previous;
			_dic.Remove(last.key);
			_Remove(last);
		}

		private void _Remove(Node node)
		{
			var previousNode = node.previous;
			var nextNode = node.next;
			node.previous = null;
			node.next = null;

			previousNode.next = nextNode;
			nextNode.previous = previousNode;
		}
	}
}