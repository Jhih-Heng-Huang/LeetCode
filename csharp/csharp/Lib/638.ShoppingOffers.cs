// LeetCode: 638. Shopping Offers

using System;
using System.Collections.Generic;
using System.Linq;

public class Leet638ShoppingOffers
{
	private Dictionary<string, int> _dic = null;

	public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
	{
		if (price.Count == 0 ||
			price.All(p => p == 0) ||
			needs.Count == 0 ||
			needs.All(n => n == 0))
			return 0;

		_dic = new Dictionary<string, int>();
		return _GetCheapestPrice(price, special, needs);
	}

	private int _GetCheapestPrice(
		IList<int> price,
		IList<IList<int>> special,
		IList<int> needs)
    {
		var key = _GetKey(needs);
		if (_dic.ContainsKey(key)) return _dic[key];

		var result = 0;
		for (int i = 0; i < needs.Count; ++i)
			result += needs[i] * price[i];

		foreach (var sp in special)
        {
			var restNeeds = _GenRestNeeds(needs, sp);
			if (restNeeds == null) continue;

			var newPrice = _GetCheapestPrice(price, special, restNeeds) + sp.Last();
			result = Math.Min(result, newPrice);
		}

		_dic[key] = result;
		return result;
    }

	private IList<int> _GenRestNeeds(IList<int> needs, IList<int> sp)
    {
		var list = new List<int>();
		for (int i = 0; i < needs.Count; ++i)
		{
			var restCount = needs[i] - sp[i];
			if (restCount < 0) return null;
			list.Add(restCount);
		}
		return list;
    }

	private string _GetKey(IList<int> needs)
    {
		var key = string.Empty;
		foreach (var n in needs)
			key += n.ToString() + ",";
		return key;
    }
}
