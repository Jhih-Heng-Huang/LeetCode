// 207. Course Schedule

#[allow(dead_code)]
struct Solution;

#[derive(PartialEq, Clone)]
enum State {
	None, Visiting, Visited
}

impl Solution {
	#[allow(dead_code)]
	pub fn can_finish(num_courses: i32, prerequisites: Vec<Vec<i32>>) -> bool {
		let adj_list = Self::_gen_adjacency_list(num_courses as usize, &prerequisites);


		let mut visit_table = vec![State::None; num_courses as usize];

		for i in 0..visit_table.len() {
			if visit_table[i] == State::Visited {continue;}

			if Self::_is_cycle(i, &adj_list, &mut visit_table) {return false;}
		}

		true
	}

	fn _is_cycle(current: usize, adj_list: &Vec<Vec<usize>>, visit_table: &mut Vec<State>) -> bool {
		if visit_table[current] == State::Visited {return false;}
		if visit_table[current] == State::Visiting {return true;}

		visit_table[current] = State::Visiting;

		for next in adj_list[current].iter() {
			if Self::_is_cycle(*next, adj_list, visit_table) {return true;}
		}

		visit_table[current] = State::Visited;
		
		false
	}

	fn _gen_adjacency_list(num: usize, edges: &Vec<Vec<i32>>) -> Vec<Vec<usize>> {
		let mut list = vec![Vec::<usize>::new(); num];

		for edge in edges {
			list[edge[0] as usize].push(edge[1] as usize);
		}

		list
	}
}