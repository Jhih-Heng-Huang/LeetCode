// 105. Construct Binary Tree from Preorder and Inorder Traversal

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

#[allow(dead_code)]
struct Solution;

use std::rc::Rc;
use std::cell::RefCell;
impl Solution {
	#[allow(dead_code)]
	pub fn build_tree(preorder: Vec<i32>, inorder: Vec<i32>) -> Option<Rc<RefCell<TreeNode>>> {
		Self::_build_tree(&preorder, &inorder)
	}

	fn _build_tree(preorder: &[i32], inorder: &[i32]) -> Option<Rc<RefCell<TreeNode>>> {
		if preorder.len() == 0 {
			return None;
		}

		let mut root = TreeNode::new(preorder[0]);

		let left_len = (0..inorder.len())
			.into_iter()
			.find(|&idx| inorder[idx] == root.val).unwrap();

		root.left = Self::_build_tree(&preorder[1..left_len+1], &inorder[..left_len]);
		root.right = Self::_build_tree(&preorder[left_len+1..], &inorder[left_len+1..]);

		Some(Rc::from(RefCell::from(root)))
	}
}