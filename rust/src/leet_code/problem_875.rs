// 875. Koko Eating Bananas

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn min_eating_speed(piles: Vec<i32>, h: i32) -> i32 {
		let mut max_value = 10i32.pow(9);
		let mut min_value = 0;

		while max_value - min_value > 1 {
			let middle_value = (min_value + max_value) / 2;
			if Self::_is_valid_eating_speed(&piles, h, middle_value) {
				max_value = middle_value;
			} else {
				min_value = middle_value;
			}
		};

		max_value
	}

	fn _is_valid_eating_speed(piles: &Vec<i32>, h: i32, eat_num: i32) -> bool {

		let mut sum = 0 as i64;

		for i in 0..piles.len() {
			sum += (piles[i] / eat_num) as i64;
			
			if piles[i] % eat_num > 0 {sum += 1;}
			
		}

		h as i64 >= sum
	}
}