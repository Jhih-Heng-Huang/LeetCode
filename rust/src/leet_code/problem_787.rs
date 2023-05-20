// 787. Cheapest Flights Within K Stops

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn find_cheapest_price(n: i32, flights: Vec<Vec<i32>>, src: i32, dst: i32, k: i32) -> i32 {
		// note: src and dst are not 'stops'
		// dp, 1D dist table
		// k+1 times to update table
		// clone current table before start to calculate new dist
		// table[to] = clone_table[from] + price[from > to]
		// [from, to, price]
		let mut table = vec![-1; n as usize];

		table[src as usize] = 0;

		for _ in 0..k+1 {
			let clone_table = table.clone();

			for flight in flights.iter() {
				let from = flight[0] as usize;
				
				if clone_table[from] == -1 {continue;}
				
				let to = flight[1] as usize;
				let price = flight[2];
				
				table[to] =
					if table[to] == -1 {clone_table[from] + price}
					else {table[to].min(clone_table[from] + price)};
			}
		}

		table[dst as usize]
	}
}