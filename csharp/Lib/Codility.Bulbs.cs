public class BulbsProblem
{
	private class Bulb {
		public bool IsTurnOn = false;
		public bool IsLight = false;
	}
	public int function(int[] A) {
		if (A == null || A.Length == 0)
			return 0;

		int pointer = 0;
		var list = _GenBulbs(A.Length+1);

		var count = 0;
		foreach (var i in A) {
			list[i].IsTurnOn = true;
			if (pointer == i-1)
			{
				++count;
				for (int j = pointer + 1;; ++j) {
					if (list[j].IsTurnOn)
						list[j].IsLight = true;
					else
					{
						pointer = j-1;
						break;
					}
				}
			}
		}

		return count;
	}

	private Bulb[] _GenBulbs(int n) {
		var list = new Bulb[n];
		for (int i = 0; i < list.Length; ++i)
			list[i] = new Bulb();
		return list;
	}
}