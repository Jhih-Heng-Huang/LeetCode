using System.Collections.Generic;
using System.Linq;

public class BigNumberProblem {
	private class BigNumber {
		public List<int> List = new List<int>();
	}

	public int function (int N) {
		if (N == 0)
			return 1;
		
		var b = new BigNumber();
		b.List.Add(1);

		for (int i = 1; i <= N; ++i)
			_Multiply11(b);
		
		return b.List.Count(v => v == 1);
	}

	private void _Multiply11(BigNumber b) {
		
		var r = 0;
		for (int i = 1; i < b.List.Count; ++i) {
			var v = b.List[i] + b.List[i-1] + r;
			if (v > 9){
				r = 1;
				v = v%10;
			}

			b.List[i] = v;
		}

		b.List.Add(r + b.List.Last());
	}
}