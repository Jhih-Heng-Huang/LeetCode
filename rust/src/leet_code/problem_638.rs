// LeetCode: 638. Shopping Offers

use std::collections::HashMap;

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn shopping_offers(price: Vec<i32>, special: Vec<Vec<i32>>, needs: Vec<i32>) -> i32 {
		let mut table = HashMap::<String, i32>::new();
		Self::_get_min_price(&price, &special, &mut needs.clone(), &mut table)
	}

	fn _get_min_price(prices: &Vec<i32>, specials: &Vec<Vec<i32>>, needs: &mut Vec<i32>, table: &mut HashMap<String, i32>) -> i32 {
		if let Some(&price) = table.get(&Self::_get_key(needs)) {
			return price;
		}

		let mut min_price = 0;
		
		for (i, &need) in needs.iter().enumerate() {
			min_price += prices[i] * need;
		}

		for special in specials {
			if needs.iter().enumerate().any(|(i, &need)| special[i] > need) {
				continue;
			}
			
			for i in 0..needs.len() {
				needs[i] -= special[i];
			}

			min_price = min_price.min(
				special[special.len()-1] + Self::_get_min_price(prices, specials, needs, table)
			);

			for i in 0..needs.len() {
				needs[i] += special[i];
			}
		}

		table.insert(Self::_get_key(needs), min_price);

		min_price
	}

	fn _get_key(needs: &Vec<i32>) -> String {
		let mut key = String::new();

		for &need in needs {
			key.push_str(&format!("{need},"));
		}

		key
	}
}