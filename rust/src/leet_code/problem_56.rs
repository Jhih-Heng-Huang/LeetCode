// 56. Merge Intervals

#[allow(dead_code)]
struct Solution;

impl Solution {
	#[allow(dead_code)]
	pub fn merge(intervals: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
		
		let mut merge_intervals = Vec::<Vec<i32>>::new();
		let mut sorted_intervals = intervals.clone();

		sorted_intervals.sort_by(|a, b| a[0].cmp(&b[0]));

		let mut pocket_interval = sorted_intervals[0].clone();

		for i in 1..sorted_intervals.len() {

			// if intervals are not overlapping, save current holding interval then update the holding interval
			// else update holding interval
			if !Self::_are_overlapping(&pocket_interval, &sorted_intervals[i]) {
				merge_intervals.push(pocket_interval.clone());
				pocket_interval[0] = sorted_intervals[i][0];
				pocket_interval[1] = sorted_intervals[i][1];
			}

			pocket_interval[0] = pocket_interval[0].min(sorted_intervals[i][0]);
			pocket_interval[1] = pocket_interval[1].max(sorted_intervals[i][1]);
		}

		merge_intervals.push(pocket_interval.clone());

		merge_intervals
	}

	#[inline]
	fn _are_overlapping(prev: &Vec<i32>, post: &Vec<i32>) -> bool {
		return prev[1] >= post[0];
	}
}