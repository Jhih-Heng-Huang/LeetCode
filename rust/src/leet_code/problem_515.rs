// 515. Find Largest Value in Each Tree Row

// Definition for a binary tree node.
#[derive(Debug, PartialEq, Eq)]
struct TreeNode {
  pub val: i32,
  pub left: Option<Rc<RefCell<TreeNode>>>,
  pub right: Option<Rc<RefCell<TreeNode>>>,
}

#[allow(dead_code)]
struct Solution;

use std::rc::Rc;
use std::cell::RefCell;
impl Solution {
	
	#[allow(dead_code)]
	pub fn largest_values(root: Option<Rc<RefCell<TreeNode>>>) -> Vec<i32> {
	
		let mut results = Vec::<i32>::new();

		if let Some(root_node) = root {

			let mut queue = vec![root_node];
			
			while !queue.is_empty() {
					
				let mut next_queue = Vec::new();
				
				let mut max_value = i32::MIN;
		
				for node in queue {
		
					let mut n = node.borrow_mut();

					if n.val > max_value  {max_value = n.val};
		
					if let Some(left) = n.left.take() {next_queue.push(left)};
					if let Some(right) = n.right.take() {next_queue.push(right)};
				}
		
				queue = next_queue;

				results.push(max_value);
			}
		}

		results
	}
}