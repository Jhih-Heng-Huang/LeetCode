// LeetCode: 931. Minimum Falling Path Sum

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn min_falling_path_sum(matrix: Vec<Vec<i32>>) -> i32 {
		
		let mut min_path_sum = i32::MAX;
		
		let mut map = matrix.clone();

		let col_len = matrix.len();
		let row_len = col_len;

		for row in 1..row_len {
			for col in 1..col_len-1 {
				let val = map[row][col];
				
				map[row][col] = (val + map[row-1][col])
					.min(val + map[row-1][col-1])
					.min(val + map[row-1][col+1]);
			}

			{
				let val = map[row][0];
				map[row][0] = (val + map[row-1][0]).min(val + map[row-1][1]);
			}

			{
				let val = map[row][col_len-1];
				map[row][col_len-1] = (val + map[row-1][col_len-1]).min(val + map[row-1][col_len-2])
			}
		}

		for col in 0..col_len {
			min_path_sum = min_path_sum.min(map[row_len - 1][col]);
		}

		min_path_sum
	}
}
