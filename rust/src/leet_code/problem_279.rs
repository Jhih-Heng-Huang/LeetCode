// LeetCode: 279. Perfect Squares

#[allow(dead_code)]
struct Solution;


impl Solution {
	#[allow(dead_code)]
	pub fn num_squares(n: i32) -> i32 {
		let mut table = vec![i32::MAX; (n + 1) as usize];

		table[0] = 0;
		table[1] = 1;

		for i in 2..=n as usize {
			let mut num = 1;
			
			while i >= num * num {
				table[i] = table[i].min(1 + table[i - num * num]);
				num += 1;
			}
		}

		table[n as usize]
	}
}