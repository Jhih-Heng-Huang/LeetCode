// 986. Interval List Intersections

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn interval_intersection(first_list: Vec<Vec<i32>>, second_list: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
		let mut list = Vec::<Vec<i32>>::new();

		let mut first_idx = 0 as usize;
		let mut second_idx = 0 as usize;

		while first_idx < first_list.len() && second_idx < second_list.len() {
			let front = first_list[first_idx][0].max(second_list[second_idx][0]);
			let back = first_list[first_idx][1].min(second_list[second_idx][1]);

			if front <= back {
				list.push(vec![front, back]);
			}

			if first_list[first_idx][1] < second_list[second_idx][1] {
				first_idx += 1;
			} else {
				second_idx += 1;
			}
		}

		list
	}
}