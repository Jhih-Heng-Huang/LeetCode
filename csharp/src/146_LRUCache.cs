// LeetCode: 146. LRU Cache
using System.Collections.Generic;

namespace LeetCode.Problem_146
{
	public class LRUCache {
		private class Node
		{
			public int Key;
			public int Value;
			public Node Previous = null;
			public Node Next = null;
		}

		private Dictionary<int, Node> _cache = new Dictionary<int, Node>();
		private int _capacity;
		private Node _head;
		private Node _tail;
		public LRUCache(int capacity) {
			_capacity = capacity;

			_head = new Node();
			_tail = new Node();

			_head.Next = _tail;
			_tail.Previous = _head;
		}

		public int Get(int key) {
			if (!_cache.ContainsKey(key))
				return -1;
			var node = _cache[key];
			_Extract(node);
			_PutOnTail(node);
			return node.Value;
		}
		
		public void Put(int key, int value) {
			Node node = null;
			if (_cache.ContainsKey(key))
			{
				node = _cache[key];
				node.Value = value;
				_Extract(node);
				_PutOnTail(node);
				return;
			}

			node = new Node()
			{
				Key = key,
				Value = value,
			};
			_PutOnTail(node);
			_cache[key] = node;

			if (_cache.Count == 0 ||
				_cache.Count <= _capacity)
				return;
			
			var head = _PopHead();
			if (head == null) return;
			_cache.Remove(head.Key);
		}

		private void _Extract(Node node)
		{
			var previous = node.Previous;
			var next = node.Next;

			previous.Next = next;
			next.Previous = previous;

			node.Previous = null;
			node.Next = null;
		}

		private void _PutOnTail(Node node)
		{
			var previous = _tail.Previous;
			var next = _tail;

			node.Previous = previous;
			node.Next = next;

			previous.Next = node;
			next.Previous = node;
		}

		private Node _PopHead()
		{
			if (_head.Next == _tail)
				return null;
			
			var node = _head.Next;
			_Extract(node);
			return node;
		}
	}
}