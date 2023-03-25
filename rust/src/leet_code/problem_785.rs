// 785. Is Graph Bipartite?

#[allow(dead_code)]
struct Solution;

#[derive(Clone, PartialEq)]
enum Color {
	None, Red, Black
}

impl Solution {
	#[allow(dead_code)]
	pub fn is_bipartite(graph: Vec<Vec<i32>>) -> bool {
		
		let mut table = vec![Color::None;graph.len()];

		for i in 0..graph.len() {
			if table[i] == Color::None && !Self::_is_bipartite(i, Color::Red, &graph, &mut table) {
				return false;
			}
		}

		true
	}

	fn _is_bipartite(current: usize, assigned_color: Color, graph: &Vec<Vec<i32>>, table: &mut Vec<Color>) -> bool {

		if table[current] == assigned_color {return true;}
		if table[current] != Color::None {return false;}

		let next_color = if assigned_color == Color::Black {Color::Red} else {Color::Black};

		table[current] = assigned_color;

		for &next in graph[current].iter() {
			if !Self::_is_bipartite(next as usize, next_color.clone(), graph, table) {
				return false;
			}
		}

		true
	}
}