// 886. Possible Bipartition

#[allow(dead_code)]
struct Solution;

struct Graph {
	adjacent_list: Vec<Vec<usize>>
}

#[derive(Clone, PartialEq, Copy)]
enum Color {
	None, White, Red,
}

impl Graph {
	pub fn gen_adjacent_list(n: i32, edges: &Vec<Vec<i32>>) -> Graph {
		let mut graph = Graph{adjacent_list: vec![Vec::<usize>::default(); (n+1) as usize]};

		for edge in edges {
			let node_0 = edge[0] as usize;
			let node_1 = edge[1] as usize;
			graph.adjacent_list[node_0].push(node_1);
			graph.adjacent_list[node_1].push(node_0);
		}

		graph
	}

	pub fn is_bipartition(&self) -> bool {

		let num_node = self.adjacent_list.len() - 1;

		let mut table = vec![Color::None; num_node + 1];

		
		for i in 1..=num_node {
			if table[i] != Color::None {continue;}
			
			if !self._check_is_bipartition(i, Color::Red, &mut table) { return false; }
		}
		
		true
	}

	fn _check_is_bipartition(&self, idx: usize, assign_color: Color, table: &mut Vec<Color>) -> bool {
		if table[idx] == Color::None {table[idx] = assign_color;}
		else if table[idx] != assign_color { return false; }
		else {return true;}

		let adjacent_color = match assign_color {
			Color::Red => Color::White,
			_ => Color::Red
		};

		for adj_idx in &self.adjacent_list[idx] {
			if !self._check_is_bipartition(*adj_idx, adjacent_color, table) {return false;}
		}
		
		true
	}
}

impl Solution {
	#[allow(dead_code)]
	pub fn possible_bipartition(n: i32, dislikes: Vec<Vec<i32>>) -> bool {
		let graph = Graph::gen_adjacent_list(n, &dislikes);
		graph.is_bipartition()
	}
}