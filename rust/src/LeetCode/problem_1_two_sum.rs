// Leet Code: 1.Two Sum

pub fn two_sum(nums: &Vec<i32>, target: i32) -> Vec<i32> {
	let mut results = Vec::new();
	
	for (i, ele) in nums.iter().enumerate() {
		let sub_target = target - ele;
		for j in i+1..nums.len() {
			if nums[j] == sub_target {
				results.push(i as i32);
				results.push(j as i32);
				return results;
			}
		}
	}
	
	results
}

#[cfg(test)]
mod tests {
    use super::two_sum;

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
}