// 146. LRU Cache


class LRUCache(capacity: Int) {
    private data class Node(
        val key: Int,
        var value: Int,
        var preNode: Node?,
        var postNode: Node?)

    private val _nodeDic = mutableMapOf<Int, Node>()
    private val _head = Node(0, 0, null, null)
    private val _tail = Node(0, 0, null, null)

    init {
        _head.postNode = _tail
        _tail.preNode = _head
    }

    private val _capacity = capacity

    fun get(key: Int): Int {
        return _GetValue(key)
    }
    
    private fun _HasKey(key: Int): Boolean {
        return _nodeDic.containsKey(key)
    }
    
    private fun _GetValue(key: Int): Int {
        if (!_HasKey(key)) return -1
        val node = _GetNode(key);
        _MoveToHead(node)
        return node!!.value
    }

    private fun _MoveToHead(node: Node?) {
        if (node == null) return
        _RemoveNodeFromList(node)
        val preNode = _head;
        val postNode = _head.postNode
        node.preNode = preNode
        node.postNode = postNode
        preNode.postNode = node
        postNode!!.preNode = node
    }

    private fun _RemoveNodeFromList(node: Node?) {
        if (node == null) return
        if (node.preNode != null) node.preNode!!.postNode = node.postNode
        if (node.postNode != null) node.postNode!!.preNode = node.preNode

        node.preNode = null
        node.postNode = null
    }

    fun put(key: Int, value: Int) {
        if (_HasKey(key)) {
            val node = _GetNode(key);
            `_MoveToHead`(node)
            node!!.value = value
        } else {
            val node = Node(key, value, null, null)
            `_MoveToHead`(node)
            _PutNode(key, node)
            
            if (!_IsOverCapacity()) return

            val popNode = _PopTailFromList()
            `_RemoveNode`(popNode!!.key)
        }
    }
    
    private fun _GetNode(key: Int): Node? {
        return `_nodeDic`[key]
    }
    
    private fun _PutNode(key: Int, node: Node) {
        `_nodeDic`.put(key, node)
    }

    private fun _IsOverCapacity(): Boolean {
        return `_nodeDic`.size > `_capacity`
    }

    private fun _IsEmpty(): Boolean {
        return `_nodeDic`.isEmpty()
    }

    private fun _PopTailFromList(): Node? {
        if (`_IsEmpty`()) return null
        val node = _tail.preNode
        `_RemoveNodeFromList`(node)
        return node
    }

    private fun _RemoveNode(key: Int) {
        `_nodeDic`.remove(key)
    }

}