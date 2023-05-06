// LeetCode: 468. Validate IP Address

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn valid_ip_address(query_ip: String) -> String {
		if Self::_is_ipv4(&query_ip) {
			return String::from("IPv4");
		} else if Self::_is_ipv6(&query_ip) {
			return String::from("IPv6");
		}

		String::from("Neither")
	}

	fn _is_ipv4(query_ip: &String) -> bool {
		let elements = query_ip.split('.').collect::<Vec<&str>>();

		if elements.len() != 4 {
			return false;
		}

		if elements.iter().any(|s| s.len() == 0 || s.len() > 3) {
			return false;
		}

		if elements.iter().any(|&s| s.chars().any(|c| !c.is_digit(10))) {
			return false;
		}

		if elements.iter().any(|&s| s.len() > 1 && &s[0..1] == "0") {
			return false;
		}

		if elements.iter().any(|&s| s.parse::<i32>().unwrap() > 255) {
			return false;
		}

		true
	}

	fn _is_ipv6(query_ip: &String) -> bool {
		let elements = query_ip.split(':').collect::<Vec<&str>>();

		if elements.len() != 8 {
			return false;
		}

		if elements.iter().any(|s| s.len() == 0 || s.len() > 4) {
			return false;
		}

		if elements.iter().any(|&s| s.chars().any(|c| !c.is_digit(16))) {
			return false;
		}

		true
	}
}