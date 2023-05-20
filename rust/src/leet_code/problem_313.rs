// 313. Super Ugly Number

#[allow(dead_code)]
struct Solution;

impl Solution {
    #[allow(dead_code)]
    pub fn nth_super_ugly_number(n: i32, primes: Vec<i32>) -> i32 {
        // find nth smallest number which's factor is from prime factors
        // pointers
        // primes
        // dp, table 1D length:n

        let len = n as usize;
        let mut table = vec![i64::MAX; len];
        let mut prime_pos = vec![0 as usize; primes.len()];

        table[0] = 1;

        for i in 1..len {
            for j in 0..primes.len() {
                table[i] = table[i].min(
                    primes[j] as i64 * table[prime_pos[j]]
                );
            }

            for j in 0..prime_pos.len() {
                if table[i] != primes[j] as i64 * table[prime_pos[j]] {continue;}

                prime_pos[j] += 1;
            }
        }

        table[len-1] as i32
    }
}