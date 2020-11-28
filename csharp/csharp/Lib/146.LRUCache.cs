using System.Collections.Generic;

public class LRUCache {
	private class Node {
		public int Key;
		public int Value;
		public Node Pre = null;
		public Node Post = null;
	}

	private int _capacity;
	private Node _head;
	private Node _tail;
	private Dictionary<int, Node> _dic = new Dictionary<int, Node>();

	public LRUCache(int capacity) {
		_capacity = capacity;

		_head = new Node();
		_tail = new Node();

		_head.Post = _tail;
		_tail.Pre = _head;
	}

	public int Get(int key) {
		if (!_dic.ContainsKey(key))
			return -1;
		
		var node = _dic[key];
		_MoveBack(node);
		return node.Value;
	}
	
	public void Put(int key, int value) {
		Node node = null;
		if (_dic.ContainsKey(key)) {
			node = _dic[key];
			node.Value = value;
			_MoveBack(node);
			return;
		}

		node = new Node();
		node.Key = key;
		node.Value = value;

		_PushBack(node);
		_dic[key] = node;

		if (_dic.Count <= _capacity)
			return;
		
		var head = _PopHead();
		_dic.Remove(head.Key);
	}

	private void _MoveBack(Node node) {
		if (node == null)
			return;

		if (node.Pre != null && node.Post != null) {
			node.Pre.Post = node.Post;
			node.Post.Pre = node.Pre;
		}

		_PushBack(node);
	}
	private void _PushBack(Node node) {
		if (node == null)
			return;

		node.Pre = _tail.Pre;
		node.Post = _tail;

		node.Pre.Post = node;
		node.Post.Pre = node;
	}

	private Node _PopHead() {
		if (_head.Post == _tail)
			return null;
		
		var node = _head.Post;

		node.Post.Pre = node.Pre;
		node.Pre.Post = node.Post;

		node.Post = null;
		node.Pre = null;

		return node;
	}
}