// LeetCode: 513. Find Bottom Left Tree Value

#[allow(dead_code)]
struct Solution;

#[derive(Debug, PartialEq, Eq)]
pub struct TreeNode {
  pub val: i32,
  pub left: Option<Rc<RefCell<TreeNode>>>,
  pub right: Option<Rc<RefCell<TreeNode>>>,
}

use std::rc::Rc;
use std::cell::RefCell;

impl Solution {
	#[allow(dead_code)]
	pub fn find_bottom_left_value(root: Option<Rc<RefCell<TreeNode>>>) -> i32 {
		let mut bottom_left_val = 0;
		
		let mut current_level = Vec::new();

		current_level.push(root.unwrap());

		while !current_level.is_empty() {
			let mut next_level = Vec::new();

			bottom_left_val = current_level[0].borrow().val;

			for rc_node in current_level {
				if let Some(left) = rc_node.borrow().left.clone() {next_level.push(left);}
				if let Some(right) = rc_node.borrow().right.clone() {next_level.push(right);}
			}

			current_level = next_level;
		}
		

		bottom_left_val
	}
}