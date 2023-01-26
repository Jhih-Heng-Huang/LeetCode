// 909. Snakes and Ladders

use std::{cmp::min, collections::VecDeque};

struct Solution;

impl Solution {
	pub fn snakes_and_ladders(board: Vec<Vec<i32>>) -> i32 {
		let board_size = board.len() * board.len();
	
		// gen table
		let none = -1;
		let mut table = vec![none; board_size + 1];
	
		table[1] = 0;

	
		// run dp & bfs
		let mut queue = VecDeque::<usize>::new();
		queue.push_back(1);

		while !queue.is_empty() {
			let current_pos = queue.pop_front();

			if current_pos.is_none() {break;}

			for step in 1..7 {
				if current_pos.unwrap() + step > board_size {break;}

				let next_pos = Self::_get_position_from_board(current_pos.unwrap() + step, &board);

				if table[next_pos] != none {continue;}

				table[next_pos] = table[current_pos.unwrap()] + 1;
				queue.push_back(next_pos);
			}
		}
	
		return table[board_size];
	}

	fn _get_position_from_board(position: usize, board: &Vec<Vec<i32>>) -> usize {
		let index = position - 1;
		let mut first_index = index / board.len();
		let mut second_index = index % board.len();

		second_index = match first_index % 2 {
			0 => second_index,
			_ => board.len() - 1 - second_index,
		};
		first_index = board.len() - 1 - first_index;

		return match board[first_index][second_index] {
			-1 => position,
			value => value as usize,
		};
	}
}
