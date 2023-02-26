// 518. Coin Change II

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn change(amount: i32, coins: Vec<i32>) -> i32 {
		let mut table = vec![0;amount as usize + 1];

		table[0] = 1;

		for coin in coins {
			if coin > amount {continue;}

			for i in coin..=amount {
				table[i as usize] += table[(i-coin) as usize];
			}
		}

		table[amount as usize]
	}
}