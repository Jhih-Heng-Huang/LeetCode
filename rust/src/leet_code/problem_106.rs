// LeetCode: 106. Construct Binary Tree from Inorder and Postorder Traversal

// Definition for a binary tree node.

#[allow(dead_code)]
struct Solution;

#[derive(Debug, PartialEq, Eq)]
pub struct TreeNode {
  pub val: i32,
  pub left: Option<Rc<RefCell<TreeNode>>>,
  pub right: Option<Rc<RefCell<TreeNode>>>,
}

impl TreeNode {
	#[inline]
	pub fn new(val: i32) -> Self {
	TreeNode {
		val,
		left: None,
		right: None
	}
	}
}

use std::rc::Rc;
use std::cell::RefCell;
impl Solution {
	#[allow(dead_code)]
	pub fn build_tree(inorder: Vec<i32>, postorder: Vec<i32>) -> Option<Rc<RefCell<TreeNode>>> {
		Self::_gen(&inorder, &postorder)
	}

	fn _gen(inorder: &[i32], postorder: &[i32]) -> Option<Rc<RefCell<TreeNode>>> {
		if inorder.len() == 0 {
			return None;
		}

		let root_val = postorder[postorder.len()-1];
		let mut root = TreeNode::new(root_val);

		let inorder_idx = (0..inorder.len()).find(|i| inorder[*i] == root_val).unwrap();

		root.left = Self::_gen(&inorder[..inorder_idx], &postorder[..inorder_idx]);
		root.right = Self::_gen(&inorder[inorder_idx+1..], &postorder[inorder_idx..postorder.len()-1]);

		Some(Rc::new(RefCell::new(root)))
	}
}
