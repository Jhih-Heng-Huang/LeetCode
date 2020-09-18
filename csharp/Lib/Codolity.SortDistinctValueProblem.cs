using System;
using System.Collections.Generic;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class SortDistinctValueProblem {
    public int solution(int[] A) {
        if (A == null || A.Length < 2)
			return 1;

		// split the slices
		var list = new List<HashSet<int>>();

		for (int i = 0; i < A.Length; ++i) {
			var val = A[i];

			var mergeSet = new HashSet<int>();
			mergeSet.Add(val);
			for (int j = 0; j < list.Count;) {
				if (list[j].Any(v => v > val)) {
					mergeSet.UnionWith(list[j]);
					list.RemoveAt(j);
					continue;
				} else ++j;
			}

			list.Add(mergeSet);
		}

		return list.Count;
    }
}