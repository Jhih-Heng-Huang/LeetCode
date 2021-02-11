using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class WoodStick {
    public int solution(int A, int B) {
        var len = (A+B)/4;

		if (len == 0)
			return 0;

		while (len != 0) {
			if ((A/len) + (B/len) >= 4)
				return len;
			--len;
		}

		return len;
    }
}