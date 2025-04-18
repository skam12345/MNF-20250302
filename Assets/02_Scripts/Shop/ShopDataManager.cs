using System.Collections.Generic;
using UnityEngine;

public class ShopDataManager
{
	[Header("Debugging Test")]
	[SerializeField]private ShopToScriptable shopData;
	[SerializeField]private List<ItemBaseClass.ItemData> buyShop;
	[SerializeField]private List<ItemBaseClass.ItemData> buyList;
	[SerializeField]private List<ItemBaseClass.ItemData> sellShop;
	[SerializeField]private List<ItemBaseClass.ItemData> sellList;

	// 
	//public ShopDataManager(string _shopScriptableName) {
	public ShopDataManager() {

		buyShop = new List<ItemBaseClass.ItemData>();
		buyList = new List<ItemBaseClass.ItemData>();
		sellShop = new List<ItemBaseClass.ItemData>();
		sellList = new List<ItemBaseClass.ItemData>();
	}

	public void OnInit(string _shopScriptableName)
	{
		Init(_shopScriptableName);
	}
	private void Init(string _shopScriptableName)
	{
		if (shopData == null)
		{
			shopData = Resources.Load<ShopToScriptable>(ResourcesDirectory.ShopScriptable + _shopScriptableName);
			if (shopData == null)
			{
#if UNITY_EDITOR
				Debug.LogError("상점 이름이 이상합니다. 경로와 이름을 확인 해주세요\n" + "name : " + _shopScriptableName + "\t dir : " + ResourcesDirectory.ShopScriptable);
#endif
			}
		}
		else if (shopData.name != _shopScriptableName)
		{
			shopData = Resources.Load<ShopToScriptable>(ResourcesDirectory.ShopScriptable + _shopScriptableName);
			if (shopData == null)
			{
#if UNITY_EDITOR
				Debug.LogError("상점 이름이 이상합니다. 경로와 이름을 확인 해주세요\n" + "name : " + _shopScriptableName + "\t dir : " + ResourcesDirectory.ShopScriptable);
#endif
			}
		}
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