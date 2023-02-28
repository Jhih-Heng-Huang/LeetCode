// 329. Longest Increasing Path in a Matrix

#[allow(dead_code)]
struct Solution;

#[derive(Clone)]
struct Data {
	is_visited: bool,
	longest_path_len: i32
}

impl Solution {
	#[allow(dead_code)]
	pub fn longest_increasing_path(matrix: Vec<Vec<i32>>) -> i32 {

		let (row_size, col_size) = (matrix.len(), matrix[0].len());
		let mut table = vec![
			vec![
				Data{is_visited: false, longest_path_len: 1};
				col_size
			];
			row_size
		];

		let mut max_len = 0;

		for row in 0..row_size {
			for col in 0..col_size {
				let len = Self::_find_longest_path(row, col, &matrix, &mut table);
				max_len = max_len.max(len);

				print!("{},", table[row][col].longest_path_len);
			}
			println!();
		}

		max_len
	}

	fn _find_longest_path(row: usize, col: usize, matrix: &Vec<Vec<i32>>, table: &mut Vec<Vec<Data>>) -> i32 {
		
		if table[row][col].is_visited { return table[row][col].longest_path_len; }

		let (row_size, col_size) = (matrix.len(), matrix[0].len());
		let mut max_len = table[row][col].longest_path_len;

		if  row > 0 && matrix[row-1][col] > matrix[row][col] {
			max_len = max_len.max(1 + Self::_find_longest_path(row-1, col, matrix, table));
		}

		if  row < row_size - 1 && matrix[row+1][col] > matrix[row][col] {
			max_len = max_len.max(1 + Self::_find_longest_path(row+1, col, matrix, table));
		}

		if  col > 0 && matrix[row][col-1] > matrix[row][col] {
			max_len = max_len.max(1 + Self::_find_longest_path(row, col-1, matrix, table));
		}

		if  col < col_size - 1 && matrix[row][col+1] > matrix[row][col] {
			max_len = max_len.max(1 + Self::_find_longest_path(row, col+1, matrix, table));
		}

		table[row][col].is_visited = true;
		table[row][col].longest_path_len = max_len;

		max_len
	}
}