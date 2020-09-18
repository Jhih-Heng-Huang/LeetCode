using System.Linq;
using System.Collections.Generic;

public class StringProblem
{
	public string function(string S, string T) {

		if (string.Equals(S, T))
			return "EQUAL";
		if (string.Equals(S, T.Substring(0, S.Length)))
			return "INSERT " + T.ToCharArray().Last();
		if (string.Equals(S.Substring(1, T.Length), T))
			return "REMOVE " + S[0];
		

		if (S.Length != T.Length)
			return "IMPOSSIBLE";

		var hashSet = new HashSet<int>();

		for (int i = 0; i < S.Length; ++i) {
			if (S[i] != T[i])
				hashSet.Add(i);
		}

		if (hashSet.Count != 2)
			return "IMPOSSIBLE";
		
		var list = hashSet.ToArray();
		var i1 = list[0];
		var i2 = list[1];

		if (S[i1] == T[i2] && S[i2] == T[i1])
			return "SWAP " + S[i1] + " " + S[i2];

		return "IMPOSSIBLE";
	}
}