// LeetCode: 638. Shopping Offers

using System;
using System.Collections.Generic;
using System.Linq;

public class Leet638ShoppingOffers
{
	public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
	{
		var minPriceDic = new Dictionary<string, int>();
		return _ShoppingOffers(price, special, needs, minPriceDic);
	}

	private int _ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs, Dictionary<string,int> minPriceDic)
	{
		if (needs.All(need => need == 0)) return 0;

		var key = _ToKey(needs);
		if (minPriceDic.ContainsKey(key)) return minPriceDic[key];

		var minPrice = 0;
		for (int i = 0; i < needs.Count; ++i)
			minPrice += needs[i] * price[i];

		foreach (var sp in special)
		{
			if (!_IsSpecialPriceMeetNeeds(sp, needs))
				continue;
			
			var localPrice = sp.Last();
			for (int i = 0; i < needs.Count; ++i)
				needs[i] -= sp[i];
			localPrice += _ShoppingOffers(price, special, needs, minPriceDic);
			for (int i = 0; i < needs.Count; ++i)
				needs[i] += sp[i];
			minPrice = Math.Min(minPrice, localPrice);
		}

		minPriceDic[key] = minPrice;
		return minPrice;
	}

	private bool _IsSpecialPriceMeetNeeds(IList<int> special, IList<int> needs)
	{
		var meetNeeds = true;
		for (int i = 0; i < needs.Count; ++i)
			if (needs[i] < special[i])
			{
				meetNeeds = false;
				break;
			}
		return meetNeeds;
	}

	private string _ToKey(IList<int> needs)
	{
		var key = string.Empty;
		foreach (var need in needs)
			key += need.ToString() + ",";
		return key;
	}
}
