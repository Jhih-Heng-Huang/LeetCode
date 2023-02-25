// 909. Snakes and Ladders

use std::collections::VecDeque;

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn snakes_and_ladders(board: Vec<Vec<i32>>) -> i32 {
		#[derive(Clone)]
		struct Data {
			step_nums: i32,
			next_pos: usize,
		}

		// gen table
		let board_size = board.len() * board.len();
		let none = -1;
		let mut list = vec![Data{step_nums: none, next_pos: 0};board_size + 1];

		for i in 1..board_size+1 {
			let mut row = (i - 1) / board.len();
			let col = match row % 2 {
				0 => (i - 1) % board.len(),
				_ => (board.len() - 1) - (i - 1) % board.len(),
			};

			row = (board.len() - 1) - row;

			list[i].next_pos = match board[row][col] {
				-1 => i,
				value => value as usize,
			};
		}
		list[1].step_nums = 0;

		// run dp + bfs
		let mut queue = VecDeque::<usize>::new();
		queue.push_back(1);
		while !queue.is_empty() {
			let current = queue.pop_front().unwrap();

			for step in 1..7 {
				if current + step > board_size {break;}

				let next = list[current+step].next_pos;

				if list[next].step_nums != none {continue;}

				list[next].step_nums = list[current].step_nums + 1;
				
				queue.push_back(next);
			}
		}

		return list[board_size].step_nums;
	}
}
