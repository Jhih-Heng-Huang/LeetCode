// 67. Add Binary

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn add_binary(a: String, b: String) -> String {
		let (first_part, carry) = Self::_add_first_part(&a, &b);
		let last_part = Self::_add_last_part(Self::_extract_last_part(&a, &b), carry);

		let mut result = String::from("");

		result.push_str(&last_part);
		result.push_str(&first_part);

		result
	}

	fn _add_first_part(left: &String, right: &String) -> (String, char) {
		let mut result = String::from("");

		let mut left_chars = left.chars().rev();
		let mut right_chars = right.chars().rev();

		let mut carry = '0' as char;

		while let Some((left_char, right_char)) = left_chars.next().zip(right_chars.next()) {
			let (sum, new_carry) = Self::_add_binary(left_char, right_char, carry);

			result.push(sum);
			carry = new_carry
		}

		(result.chars().rev().collect(), carry)
	}

	fn _extract_last_part(left: &String, right: &String) -> String {
		if left.len() == right.len() {
			return String::from("");
		} else if left.len() > right.len() {
			return String::from(&left[0..left.len() - right.len()]);
		} else {
			return String::from(&right[0..right.len() - left.len()]);
		}
	}

	fn _add_last_part(str: String, carry: char) -> String {
		let mut vals = str.chars().rev();
		
		let mut result = String::from("");
		let mut prev_carry = carry;
		while let Some(val) = vals.next() {
			let (sum, next_carry) = Self::_add_binary(val, '0', prev_carry);

			result.push(sum);
			prev_carry = next_carry;
		}

		if prev_carry == '1' { result.push('1')}
		
		result.chars().rev().collect()
	}

	fn _add_binary(left:char, right: char, carry: char) -> (char, char) {
		let binary_radix = 2;
		let l_val = left.to_digit(binary_radix).unwrap();
		let r_val = right.to_digit(binary_radix).unwrap();
		let c_val = carry.to_digit(binary_radix).unwrap();

		let ret_sum = std::char::from_digit(l_val ^ r_val ^ c_val, binary_radix).unwrap();
		let ret_carry = std::char::from_digit((l_val & r_val) | (l_val & c_val) | (r_val & c_val) , binary_radix).unwrap();

		print!("({},{}),", ret_sum, ret_carry);

		(ret_sum, ret_carry)
	}
}