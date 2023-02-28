// 67. Add Binary

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn add_binary(a: String, b: String) -> String {
		let mut binary_0 = a.chars().rev();
		let mut binary_1 = b.chars().rev();
		let mut reminder = 0 as u32;

		let mut result = String::new();

		loop {
			let (v_0, v_1) = {
				let iter_0 = binary_0.next();
				let iter_1 = binary_1.next();

				if iter_0.is_none() && iter_1.is_none() {
					if reminder == 1 { result.push('1'); }
					break;
				} else {
					(
						iter_0.unwrap_or('0').to_digit(2).unwrap(),
						iter_1.unwrap_or('0').to_digit(2).unwrap()
					)
				}
			};

			match v_0 + v_1 + reminder {
				0 => {result.push('0'); reminder = 0;}
				1 => {result.push('1'); reminder = 0;}
				2 => {result.push('0'); reminder = 1;}
				3 => {result.push('1'); reminder = 1;}
				_ => unreachable!()
			}
		}

		result.chars().rev().collect()
	}
}