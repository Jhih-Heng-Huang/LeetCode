// 2359. Find Closest Node to Given Two Nodes

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn closest_meeting_node(edges: Vec<i32>, node1: i32, node2: i32) -> i32 {
		// gen table
		let invalid_path_len = -1;
		let gen_path_len_table = |node: usize, edges: &Vec<i32>| {
			let mut table = vec![invalid_path_len;edges.len()];
			let mut current = node;
			table[current] = 0;

			while edges[current] != -1 {
				let next = edges[current] as usize;

				if table[next] != invalid_path_len {break;}

				table[next] = table[current] + 1;

				current = next;
			}

			table
		};

		let table1 = gen_path_len_table(node1 as usize, &edges);
		let table2 = gen_path_len_table(node2 as usize, &edges);
		
		// find the node
		struct Result {
			index: i32,
			path_len: i32
		}
		
		let mut result = Result {index: -1, path_len: i32::MAX};

		for i in 0..edges.len() {
			if table1[i] == invalid_path_len || table2[i] == invalid_path_len {continue;}

			let max_path_len = std::cmp::max(table1[i], table2[i]);

			if max_path_len >= result.path_len {continue;}
			
			result.index = i as i32;
			result.path_len = std::cmp::max(table1[i], table2[i]);
		}

		result.index
	}

}
