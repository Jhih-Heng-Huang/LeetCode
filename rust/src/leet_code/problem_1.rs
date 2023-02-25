// Leet Code: 1.Two Sum

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn two_sum(nums: &Vec<i32>, target: i32) -> Vec<i32> {
		let mut results = Vec::new();
		
		for (i, ele) in nums.iter().enumerate() {
			let sub_target = target - ele;
			let result = Self::_find_index_of_array(sub_target, nums, i+1, nums.len()-1);
			
			match result {
				Some(j) => {
					results.push(i as i32);
					results.push(j as i32);
					return results;
				}
				None => {}
			};
		}
		
		results
	}
	
	fn _find_index_of_array(val: i32, arr: &Vec<i32>, start_index: usize, end_index: usize) -> Option<usize> {
		
		if start_index > end_index { return None }
	
		if arr.is_empty() { return None }
	
		for i in start_index..end_index+1 {
			if arr[i] != val { continue; }
			else {
				return Some(i);
			}
		}
	
		None
	}
}