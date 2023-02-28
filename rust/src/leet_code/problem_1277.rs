// 1277. Count Square Submatrices with All Ones

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn count_squares(matrix: Vec<Vec<i32>>) -> i32 {
		let row_size = matrix.len();
		let col_size = matrix[0].len();
		let mut table = vec!
		[
			vec![0; col_size];
			row_size
		];
			
		for row in 0..row_size { table[row][0] = matrix[row][0]; }
		for col in 0..col_size { table[0][col] = matrix[0][col]; }
			
		for row in 1..row_size {
			for col in 1..col_size {
				if matrix[row][col] == 0 {continue;}
				
				table[row][col] = 1 + table[row-1][col].min(table[row][col-1]).min(table[row-1][col-1]);
			}
		}
			
		let mut count = 0;
		
		for row in 0..row_size {
			for col in 0..col_size {
				count += table[row][col];
			}
		}

		count
	}
}