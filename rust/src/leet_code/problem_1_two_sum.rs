// Leet Code: 1.Two Sum

pub fn two_sum(nums: &Vec<i32>, target: i32) -> Vec<i32> {
	let mut results = Vec::new();
	
	for (i, ele) in nums.iter().enumerate() {
		let sub_target = target - ele;
		let result = find_index_of_array(sub_target, nums, i+1, nums.len()-1);
		
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

fn find_index_of_array(val: i32, arr: &Vec<i32>, start_index: usize, end_index: usize) -> Option<usize> {
	
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

#[cfg(test)]
mod tests {
    use super::{two_sum, find_index_of_array};

	#[cfg(test)]
	struct Data {
		nums: Vec<i32>,
		target: i32,
		expected_output: Vec<i32>
	}

	impl Data {
		pub fn test(&self) {
			let result = two_sum(&self.nums, self.target);
			assert_eq!(result, self.expected_output);
		}
	}

	#[test]
	fn check_some_cases() {
		let inputs = vec![
			Data {nums: vec![2, 7, 11, 15], target: 9, expected_output: vec![0, 1]},
			Data {nums: vec![3,2,4], target: 6, expected_output: vec![1, 2]},
			Data {nums: vec![3,3], target: 6, expected_output: vec![0, 1]},
		];

		for iter in inputs.iter() {
			iter.test();
		}
	}

	#[test]
	fn test_find_index_in_array() {
		let ans = find_index_of_array(5, &vec![0,1,2,3,4,5,6,7,8,9], 2, 8);

		match ans {
			Some(x) => { assert_eq!(x, 5); },
			None => { panic!() },
		}
	}

	#[test]
	fn test_give_wrong_range() {
		let ans = find_index_of_array(5, &vec![0,1,2,3,4,5,6,7,8,9], 9, 0);

		match ans {
			Some(_) => { panic!(); },
			None => { assert!(true); },
		}
	}
}