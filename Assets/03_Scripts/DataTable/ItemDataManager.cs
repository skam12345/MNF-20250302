using UnityEngine;
using SimpleJSON;
using System.Collections.Generic;
using static ItemBaseClass;

// 이 스크립트는 아이템의 대한 정보를 모두 갖고 있습니다.


public class ItemDataManager : SingleTonBase<ItemDataManager>
{
	private JSONNode jsonData;
	List<ItemBaseClass.ItemBaseEquipment> equiptList;
	List<ItemBaseClass.ItemBaseUseable> useableList;
	List<ItemBaseClass.ItemBaseResource> resourceList;

	public int EquiptSize { get { return equiptList.Count; } }
	public int UseableSize { get { return useableList.Count; } }
	public int ResourceSize { get { return resourceList.Count; } }

	// 로딩할 때 파일을 하나하나 읽는 순서로 구현하기 위해


	public void OnInit()
	{
		Init();
	}

	private void Init()
	{
		if (jsonData != null) return;
		TextAsset txtFile = Resources.Load<TextAsset>("Jsons/ItemDataJson");
		jsonData = JSON.Parse(txtFile.text);

		InitEquipt();
		InitUseable();
		InitResource();
	}

	private void InitEquipt()
	{
		if(equiptList == null)
		equiptList = new List<ItemBaseClass.ItemBaseEquipment>();

		JSONNode target = jsonData["장비"];
		int max = target.Count;
	
		for (int i =0; i < max; i++)
		{
			ItemBaseClass.ItemBaseEquipment data = new ItemBaseClass.ItemBaseEquipment();
			data.Init(target[i]["name"].ToString(),
				target[i]["type_name"].ToString(), 
				target[i]["grade"].AsInt, 
				target[i]["need_lv"].AsInt, 
				0,
				target[i]["buy_gold"].AsInt, 
				target[i]["sell_gold"].AsInt, 
				target[i]["item_hp"].AsFloat, 
				target[i]["item_mp"].AsFloat,
				target[i]["item_atk"].AsFloat, 
				target[i]["item_def"].AsFloat, 
				target[i]["criRate"].AsFloat, 
				target[i]["criDmg"].AsFloat, 
				target[i]["enchantRate"].AsInt, 
				target[i]["description"].ToString(), 
				target[i]["skill_event"].AsInt);

			equiptList.Add(data);
		}
	}

	private void InitUseable()
	{
		if (useableList == null)
			useableList = new List<ItemBaseClass.ItemBaseUseable>();

		JSONNode target = jsonData["소모품"];
		int max = target.Count;

		for (int i = 0; i < max; i++)
		{
			ItemBaseClass.ItemBaseUseable data = new ItemBaseClass.ItemBaseUseable();
			data.Init(target[i]["main_name"].ToString(),
				target[i]["type_name"].ToString(),
				target[i]["buy_gold"].AsInt,
				target[i]["sell_gold"].AsInt,
				target[i]["main_description"].ToString(),
				target[i]["sub_descriton"].ToString(),
				target[i]["type"].ToString(),
				target[i]["value"].AsInt,
				1,
				target[i]["stack"].AsInt);
			useableList.Add(data);
		}
	}

	private void InitResource()
	{
		if (resourceList == null)
		resourceList = new List<ItemBaseClass.ItemBaseResource>();

		JSONNode target = jsonData["재료"];
		int max = target.Count;

		for (int i = 0; i < max; i++)
		{
			ItemBaseClass.ItemBaseResource data = new ItemBaseClass.ItemBaseResource();
			data.Init(target[i]["main_name"].ToString(),
				target[i]["type_name"].ToString(),
				target[i]["buy_gold"].AsInt,
				target[i]["sell_gold"].AsInt,
				target[i]["descrition"].ToString(),
				1,
				target[i]["stack"].AsInt);

			resourceList.Add(data);
		}
	}


	public bool GetItemDataToEquipt(in int _itemNumber, out ItemBaseEquipment _itemData)
	{
		_itemData = null;
		if (_itemNumber < 0 || _itemNumber >= equiptList.Count) return false;
		if( _itemData == null) _itemData = new ItemBaseEquipment();

		_itemData.Init(equiptList[_itemNumber]);
		return true;
	}

	public bool GetItemDataToUseable(in int _itemNumber, out ItemBaseUseable _itemData)
	{
		_itemData = null;
		if (_itemNumber < 0 || _itemNumber >= useableList.Count) return false;
		if (_itemData == null) _itemData = new ItemBaseUseable();

		_itemData.Init(useableList[_itemNumber]);
		return true;
	}

	public bool GetItemDataToResource(in int _itemNumber, out ItemBaseResource _itemData)
	{
		_itemData = null;
		if (_itemNumber < 0 || _itemNumber >= resourceList.Count) return false;
		if (_itemData == null) _itemData = new ItemBaseResource();

		_itemData.Init(resourceList[_itemNumber]);
		return true;
	}
}