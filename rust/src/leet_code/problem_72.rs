// 72. Edit Distance

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn min_distance(word1: String, word2: String) -> i32 {
		let mut table = vec![vec![0; word2.len() + 1]; word1.len() + 1];
		
		for i in 1..=word1.len() { table[i][0] = i as i32;}
		for i in 1..=word2.len() { table[0][i] = i as i32;}

		for i in 1..=word1.len() {
			for j in 1..=word2.len() {

				if word1[i-1..i] == word2[j-1..j] { table[i][j] = table[i-1][j-1];}
				else {
					table[i][j] = 1 + table[i-1][j].min(table[i][j-1]).min(table[i-1][j-1]);
				}
			}
		}

		table[word1.len()][word2.len()]
	}
}