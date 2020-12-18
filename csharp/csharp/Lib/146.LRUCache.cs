// LeetCode: 146. LRU Cache
using System.Collections.Generic;

public class LRUCache {
	#region Inner classes
	private class Node {
		public int Key;
		public int Value;
		public Node Previous = null;
		public Node Next = null;
	}
	#endregion

	private int _capacity;
	private Dictionary<int, Node> _cache = new Dictionary<int, Node>();
	private Node _head = null;
	private Node _tail = null;

	public LRUCache(int capacity) {
		_capacity = capacity;

		_head = new Node();
		_tail = new Node();

		_head.Next = _tail;
		_tail.Previous = _head;
	}

	public int Get(int key) {
		if (!_cache.ContainsKey(key)) return -1;

		var node = _cache[key];
		_Extract(node);
		_PushBack(node);

		return node.Value;
	}
	
	public void Put(int key, int value) {
		if (_cache.ContainsKey(key)) {
			
			var node = _cache[key];
			node.Value = value;
			_Extract(node);
			_PushBack(node);

		} else {

			var node = new Node();

			node.Key = key;
			node.Value = value;

			_cache.Add(key, node);
			_PushBack(node);

			if (_cache.Count <= _capacity) return;

			Node popNode = null;
			if (!_TryPopHead(out popNode)) return;

			_cache.Remove(popNode.Key);
		}
	}

	private void _Extract(Node node) {
		var previousNode = node.Previous;
		var nextNode = node.Next;

		node.Previous = null;
		node.Next = null;

		previousNode.Next = nextNode;
		nextNode.Previous = previousNode;
	}

	private void _PushBack(Node node) {
		var previous = _tail.Previous;
		var next = _tail;

		node.Previous = previous;
		node.Next = next;

		previous.Next = node;
		next.Previous = node;
	}

	private bool _TryPopHead(out Node node) {
		if (_head.Next == _tail)
		{
			node = null;
			return false;
		}

		var head = _head.Next;
		_Extract(head);
		node = head;
		return true;
	}
}