// LeetCode: 264. Ugly Number II

#[allow(dead_code)]
struct Solution;



impl Solution {
	#[allow(dead_code)]
	pub fn nth_ugly_number(n: i32) -> i32 {

		struct FactorPointer {
			val: i32,
			index: usize
		}

		let factors = &mut[
			FactorPointer {val: 2, index: 0},
			FactorPointer {val: 3, index: 0},
			FactorPointer {val: 5, index: 0},
		];


		let len = n as usize;
		let mut table = vec![i32::MAX;len];

		table[0] = 1;

		for i in 1..len {
			table[i] = factors.iter()
				.map(|f| table[f.index] * f.val)
				.min().unwrap();

			for mut factor in factors.iter_mut() {
				if table[i] == table[factor.index] * factor.val {
					factor.index += 1;
				}
			}
		}

		table[len-1]
	}
}
