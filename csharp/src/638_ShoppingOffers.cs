// LeetCode: 638. Shopping Offers

using System;
using System.Collections.Generic;
using System.Linq;

public class Leet638ShoppingOffers
{
	public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
	{
		if (price == null || price.Count == 0 ||
			needs == null || needs.Count == 0)
			return 0;
		
		var needs2Price = new Dictionary<string, int>();
		return _GetMinPrice(price, special, needs, needs2Price);
	}

	private int _GetMinPrice(
		IList<int> price, IList<IList<int>> special,
		IList<int> needs, Dictionary<string, int> needs2Price)
	{
		var key = _ToKey(needs);
		if (needs2Price.ContainsKey(key))
			return needs2Price[key];
		
		var minPrice = 0;
		for (int i = 0; i < needs.Count; ++i)
			minPrice += price[i] * needs[i];

		foreach (var sp in special)
		{
			var restNeeds = new List<int>();
			for (int i = 0; i < needs.Count; ++i)
				restNeeds.Add(needs[i] - sp[i]);

			if (restNeeds.Any(n => n < 0))
				continue;

			var newPrice = sp.Last() +
				_GetMinPrice(price, special, restNeeds, needs2Price);
			minPrice = Math.Min(minPrice, newPrice);
		}

		needs2Price[key] = minPrice;
		return minPrice;
	}

	private string _ToKey(IList<int> needs)
	{
		string key = string.Empty;
		foreach (var need in needs)
			key += string.Format("{0},", need);
		return key;
	}
}
