// LeetCode: 240. Search a 2D Matrix II

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn search_matrix(matrix: Vec<Vec<i32>>, target: i32) -> bool {
		
		let mut row = 0;
		let mut col = matrix[0].len() as i32 - 1;

		let row_len = matrix.len();

		while row < row_len && col >= 0 {
			
			let val = matrix[row][col as usize];
			
			if val == target {
				return true;
			} else if val < target {
				row += 1;
			} else {
				col -= 1;
			}
		}
		
		false
	}
}