// LeetCode: 1192. Critical Connections in a Network

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn critical_connections(n: i32, connections: Vec<Vec<i32>>) -> Vec<Vec<i32>> {

		let mut level = vec![-1; n as usize];
		let mut adj_list = vec![Vec::<usize>::new() ; n as usize];

		Self::_contruct_adjacency_list(&connections, &mut adj_list);
		
		let mut critical_edges = Vec::<Vec<i32>>::new();

		for i in 0..n {
			Self::_visit_next_level(i as usize, i as usize, &mut level, &adj_list, &mut critical_edges);
		}

		critical_edges
	}

	fn _contruct_adjacency_list(edges: &Vec<Vec<i32>>, output: &mut Vec<Vec<usize>>) {

		for edge in edges.iter() {

			let i = edge[0] as usize;
			let j = edge[1] as usize;

			output[i].push(j);
			output[j].push(i);
		}
	}

	fn _visit_next_level(parent: usize, current: usize, level: &mut Vec<i32>, adj_list: &Vec<Vec<usize>>, critical_edges: &mut Vec<Vec<i32>>) -> i32 {
		
		if level[current] != -1 {
			return level[current];
		}
		
		level[current] = if parent == current {0} else {level[parent] + 1};

		let mut output = i32::MAX;

		for &next in adj_list[current].iter() {
			if next == parent {continue;}

			let next_level = Self::_visit_next_level(current, next, level, adj_list, critical_edges);

			if next_level <= level[current] {
				output = output.min(next_level);
				continue;
			}

			critical_edges.push(vec![current as i32,next as i32]);
		}

		level[current] = output;

		output
	}
}
