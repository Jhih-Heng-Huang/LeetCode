struct Solution;

impl Solution {
	pub fn valid_path(n: i32, edges: Vec<Vec<i32>>, source: i32, destination: i32) -> bool {
		let neighbor_table = Self::_gen_neighbor_table(n, edges);
		let mut visit_list = Self::_gen_visit_table(n);
		
		Self::_check_if_path_exists(source as usize, destination as usize, &mut visit_list, &neighbor_table)
	}

	fn _gen_neighbor_table(n: i32, edges: Vec<Vec<i32>>) -> Vec<Vec<usize>> {
		let mut table = Vec::new();

		for _ in 0..n { table.push(Vec::new()); }

		for edge in edges.iter() {
			let i = edge[0] as usize;
			let j = edge[1] as usize;

			table[i].push(j);
			table[j].push(i);
		}

		table
	}

	fn _gen_visit_table(n: i32) -> Vec<bool> {
		let mut table = Vec::new();

		for _ in 0..n { table.push(false); }

		table
	}

	fn _check_if_path_exists(source: usize, destination: usize,
		visit_table: &mut Vec<bool>, neighbor_table: &Vec<Vec<usize>>) -> bool
	{
		visit_table[source] = true;
		
		if visit_table[destination] == true { return true; }

		for neighbor in neighbor_table[source].iter() {
			if !visit_table[*neighbor] && Self::_check_if_path_exists(*neighbor, destination, visit_table, neighbor_table) {
				return true;
			}
		}

		false
	}
}