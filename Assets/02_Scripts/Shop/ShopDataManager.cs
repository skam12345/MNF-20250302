using System.Collections.Generic;
using UnityEngine;

public class ShopDataManager
{
	private List<ItemBaseClass.ItemData> buyShop;
	private List<ItemBaseClass.ItemData> buyList;
	private List<ItemBaseClass.ItemData> sellShop;
	private List<ItemBaseClass.ItemData> sellList;

	public ShopDataManager() {
		buyShop = new List<ItemBaseClass.ItemData>();
		buyList = new List<ItemBaseClass.ItemData>();
		sellShop = new List<ItemBaseClass.ItemData>();
		sellList = new List<ItemBaseClass.ItemData>();
	}


	public void AddBuyShop(ref ItemBaseClass.ItemData _data)
	{
		buyShop.Add(_data);
	}
	public void AddBuyList(ref ItemBaseClass.ItemData _data)
	{
		buyList.Add(_data);
	}

	public void AddSellShop(ref ItemBaseClass.ItemData _data)
	{
		sellShop.Add(_data);
	}

	public void AddSellList(ref ItemBaseClass.ItemData _data)
	{
		sellList.Add(_data);
	}
}