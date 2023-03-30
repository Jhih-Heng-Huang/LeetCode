// LeetCode: 827. Making A Large Island

use std::collections::{HashMap, HashSet};

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn largest_island(grid: Vec<Vec<i32>>) -> i32 {

		let mut island_size = HashMap::<i32, i32>::new();
		let mut map = grid.clone();

		let mut color = 2;
		let mut max_size = 0;
		for row in 0..map.len() {
			for col in 0..map[row].len() {
				if map[row][col] == 1 {
					let size = Self::_paint_color_and_get_island_size(color, row, col, &mut map);
					island_size.insert(color, size);
					max_size = max_size.max(size);
					color += 1;
				}
			}
		}


		for row in 0..map.len() {
			for col in 0..map[row].len() {
				if map[row][col] == 0 {
					max_size = max_size.max(Self::_get_connected_size(row, col, &map, &island_size));
				}
			}
		}

		max_size
	}

	fn _paint_color_and_get_island_size(color: i32, row: usize, col: usize, map: &mut Vec<Vec<i32>>) -> i32 {
		if map[row][col] != 1 {
			return 0;
		}

		let mut size = 1;

		map[row][col] = color;

		if row > 0 {
			size += Self::_paint_color_and_get_island_size(color, row-1, col, map);
		}

		if col > 0 {
			size += Self::_paint_color_and_get_island_size(color, row, col-1, map);
		}

		if row + 1 < map.len() {
			size += Self::_paint_color_and_get_island_size(color, row+1, col, map);
		}

		if col + 1 < map[row].len() {
			size += Self::_paint_color_and_get_island_size(color, row, col+1, map);
		}

		size
	}

	fn _get_connected_size(row: usize, col: usize, map: &Vec<Vec<i32>>, island_size: &HashMap<i32, i32>) -> i32 {
		let mut size = 0;

		let mut visited_island = HashSet::<i32>::new();

		if row > 0 && map[row-1][col] != 0 {
			visited_island.insert(map[row-1][col]);
		}

		if row + 1 < map.len() && map[row+1][col] != 0 {
			visited_island.insert(map[row+1][col]);
		}

		if col > 0 && map[row][col-1] != 0 {
			visited_island.insert(map[row][col-1]);
		}

		if col + 1 < map[row].len() && map[row][col+1] != 0 {
			visited_island.insert(map[row][col+1]);
		}

		for color in visited_island {
			if let Some(new_size) = island_size.get(&color) {
				size += new_size;
			}
		}

		size + 1
	}
}