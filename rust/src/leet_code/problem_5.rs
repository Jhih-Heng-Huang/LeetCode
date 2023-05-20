// 5. Longest Palindromic Substring

#[allow(dead_code)]
struct Solution;

impl Solution {
    #[allow(dead_code)]
    pub fn longest_palindrome(s: String) -> String {
        // longest_palindrome(s, l, r) -> String
        // longest_palindrome(s, i, i)
        // longest_palindrome(s, i, i-1)

        let mut result = String::from("");

        for i in 0..s.len() {
            let sub_str = Self::_long_palindrome(&s, i, i);

            if sub_str.len() > result.len() {
                result = sub_str;
            }
        }

        for i in 1..s.len() {
            let sub_str = Self::_long_palindrome(&s, i-1, i);

            if sub_str.len() > result.len() {
                result = sub_str;
            }
        }

        result
    }

    fn _long_palindrome(s: &String, left_index: usize, right_index: usize) -> String {

        let mut l = left_index;
        let mut r = right_index;
        
        if s[l..l+1] != s[r..r+1] {
            return String::from("");
        }

        loop {
            if l == 0 || r == s.len()-1 {break;}
            
            l -= 1;
            r += 1;

            if s[l..l+1] == s[r..r+1] {
                continue;
            }

            l += 1;
            r -= 1;
            break;
        }

        s[l..r+1].to_string()
    }
}