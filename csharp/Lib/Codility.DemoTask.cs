using System;
using System.Collections.Generic;

// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class DemoTask {
    public int solution(int[] A) {
        var hashSet = new HashSet<int>();

		var min = 1;
		foreach (var v in A) {
			hashSet.Add(v);

			while (hashSet.Contains(min)) {
				++min;
			}
		}

		return min;
    }
}