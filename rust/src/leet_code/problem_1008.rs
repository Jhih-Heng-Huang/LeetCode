// LeetCode: 1008. Construct Binary Search Tree from Preorder Traversal

#[allow(dead_code)]
struct Solution;

// Definition for a binary tree node.
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
	pub fn bst_from_preorder(preorder: Vec<i32>) -> Option<Rc<RefCell<TreeNode>>> {
		Self::_gen(&preorder)
	}

	fn _gen(preorder: &[i32]) -> Option<Rc<RefCell<TreeNode>>> {
		if preorder.len() == 0 {
			return None;
		}

		let mut root = TreeNode::new(preorder[0]);

		let center_index = (0..preorder.len()).find(|i| preorder[*i] > root.val).unwrap_or(preorder.len());

		root.left = Self::_gen(&preorder[1..center_index]);
		root.right = Self::_gen(&preorder[center_index..]);


		Some(Rc::new(RefCell::new(root)))
	}
}