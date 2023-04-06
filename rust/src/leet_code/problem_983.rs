// LeetCode: 983. Minimum Cost For Tickets

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn mincost_tickets(days: Vec<i32>, costs: Vec<i32>) -> i32 {
		
		let &last_day = days.last().unwrap();
		let mut table = vec![-1; last_day as usize + 1];

		table[0] = 0;
		
		for &date in days.iter() {
			table[date as usize] = i32::MAX;
		}

		for date in 1..table.len() {
			if table[date] == -1 {
				table[date] = table[date-1];
			} else {
				table[date] = (table[date-1] + costs[0])
					.min(table[if date < 7 {0} else {date - 7}] + costs[1])
					.min(table[if date < 30 {0} else {date - 30}] + costs[2]);
			}
		}

		table[last_day as usize]
	}
}
