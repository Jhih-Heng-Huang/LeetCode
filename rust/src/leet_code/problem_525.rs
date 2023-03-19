// LeetCode: 525. Contiguous Array

use std::collections::HashMap;

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn find_max_length(nums: Vec<i32>) -> i32 {
		let mut table = HashMap::new();

		table.insert(0, -1);

		let mut max_len = 0;
		let mut count = 0;

		for i in 0..nums.len() {
			if nums[i] > 0 {
				count -= 1;
			} else {
				count += 1;
			}

			match table.get(&count) {
				Some(&start_index) => {
					max_len = max_len.max(i as i32 - start_index);
				}
				_ => { table.insert(count, i as i32); }
			}
		}

		max_len
	}
}