// 146. LRU Cache

use std::collections::HashMap;
use std::rc::Rc;
use std::cell::RefCell;


#[allow(dead_code)]
struct LRUCache {
    max_capacity: usize,
    head: Option<Rc<RefCell<DLNode>>>,
    tail: Option<Rc<RefCell<DLNode>>>,
    hash_map: HashMap<i32, Rc<RefCell<DLNode>>>
}

struct DLNode {
    prev: Option<Rc<RefCell<DLNode>>>,
    post: Option<Rc<RefCell<DLNode>>>,
    key: i32,
    value: i32,
}

/** 
 * `&self` means the method takes an immutable reference.
 * If you need a mutable reference, change it to `&mut self` instead.
 */

/**
 * Your LRUCache object will be instantiated and called as such:
 * let obj = LRUCache::new(capacity);
 * let ret_1: i32 = obj.get(key);
 * obj.put(key, value);
 */

impl LRUCache {

    #[allow(dead_code)]
    fn new(capacity: i32) -> Self {
        let head = Rc::new(RefCell::new(DLNode {
            key: -1,
            value: -1,
            prev: None,
            post: None,
        }));

        let tail = Rc::new(RefCell::new(DLNode {
            key: -1,
            value: -1,
            prev: None,
            post: None,
        }));

        head.borrow_mut().post = Some(tail.clone());
        tail.borrow_mut().prev = Some(head.clone());

        LRUCache {
            max_capacity: capacity as usize,
            head: Some(head.clone()),
            tail: Some(tail.clone()),
            hash_map: HashMap::new(),
        }
    }
    
    #[allow(dead_code)]
    fn get(&mut self, key: i32) -> i32 {

        println!("get {}", key);
        if let Some(node_pointer) = self.hash_map.get(&key) {
            
            let value = node_pointer.borrow_mut().value;
            self.move_to_back(node_pointer.clone());
            
            return value;
        }

        -1
    }
    
    #[allow(dead_code)]
    fn put(&mut self, key: i32, value: i32) {
        println!("put {}, {}", key, value);
        if let Some(node) = self.hash_map.get(&key) {
            node.borrow_mut().value = value;
            self.move_to_back(node.clone());
            return;
        }

        let node = Rc::new(RefCell::new(DLNode{
            key: key,
            value: value,
            prev: None,
            post: None,
        }));

        self.push_back(node.clone());
        self.hash_map.insert(key, node.clone());

        if self.hash_map.len() > self.max_capacity {
            if let Some(front) = self.pop_front() {
                self.hash_map.remove(&front.borrow().key);
            }
        }
    }

    fn push_back(&mut self, node_pointer: Rc<RefCell<DLNode>>) {
        if let Some(post) = self.tail.clone() {
            
            if let Some(prev) = post.borrow().prev.clone() {
                prev.borrow_mut().post = Some(node_pointer.clone());
                node_pointer.borrow_mut().prev = Some(prev.clone());
            }

            post.borrow_mut().prev = Some(node_pointer.clone());
            node_pointer.borrow_mut().post = Some(post.clone());
        }
    }

    fn pop_front(&mut self) -> Option<Rc<RefCell<DLNode>>> {
        if let Some(prev) = self.head.clone() {
            let node_ptr = prev.borrow().post.clone();
            if let Some(node) = node_ptr.clone() {
                let post_ptr = node.borrow().post.clone();
                if let Some(post) = post_ptr.clone() {
                    prev.borrow_mut().post = Some(post.clone());
                    post.borrow_mut().prev = Some(prev.clone());

                    node.borrow_mut().prev = None;
                    node.borrow_mut().post = None;

                    return Some(node.clone());
                }
            }
        }

        None
    }

    fn move_to_back(&mut self, node: Rc<RefCell<DLNode>>) {
        let prev_ptr = node.borrow().prev.clone();
        let post_ptr = node.borrow().post.clone();

        print!("move to back:");
        if let Some(prev) = prev_ptr.clone() {
            prev.borrow_mut().post = post_ptr.clone();
            print!("prev: {},", prev.borrow().value);
        }

        if let Some(post) = post_ptr.clone() {
            post.borrow_mut().prev = prev_ptr.clone();
            print!("post: {},", post.borrow().value);
        }
        println!();

        node.borrow_mut().prev = None;
        node.borrow_mut().post = None;

        self.push_back(node.clone());
    }
}
