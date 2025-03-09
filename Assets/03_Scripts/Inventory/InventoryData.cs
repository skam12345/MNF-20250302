using UnityEngine;
using static ItemBaseClass;
using System.Collections.Generic;

public class InventoryData : SingleTonBase<InventoryData>
{
	private int inGameGold = 0;
	public int InGameGold { get { return inGameGold; } set { inGameGold += value; } }

	public int itemEquiptMax;
	public int itemUseableMax;
	public int itemResourceMax;

	[Header("ItemData")]
	[SerializeField] private List<ItemBaseEquipment> itemEquiptList;
	[SerializeField] private List<ItemBaseUseable> itemUseableList;
	[SerializeField] private List<ItemBaseResource> ItemResourceList;

	
	public int EquiptSize { get { if (itemEquiptList != null) return -1; else return itemEquiptList.Count; } }
	public int UseableSize { get { if (itemUseableList != null) return -1; return itemUseableList.Count; } }
	public int ResourceSize { get { if (ItemResourceList != null) return -1; return ItemResourceList.Count; } }

	public void OnInit()
	{
		Init();
	}
	private void Init()
	{
		itemEquiptList = new List<ItemBaseEquipment>();
		itemUseableList = new List<ItemBaseUseable>();
		ItemResourceList = new List<ItemBaseResource>();
	}

	public bool SetFieldItem(ref ItemData _data)
	{
		switch (_data.Type)
		{
			case "장비":		return ItemEquiptIntoInventory(_data.Index, _data.Count);
			case "소모품":	return ItemUseableIntoInventory(_data.Index, _data.Count);
			case "재료":		return ItemResourceIntoInventory(_data.Index, _data.Count); 
		}
		return false;
	}

	public string Save()
	{
		System.Text.StringBuilder inventoryEquipt = new System.Text.StringBuilder();
		System.Text.StringBuilder inventoryUseable = new System.Text.StringBuilder();
		System.Text.StringBuilder inventoryResource = new System.Text.StringBuilder();

		inventoryEquipt.Append(EquiptSize);
		foreach (var item in itemEquiptList)
		{
			inventoryEquipt.Append(item.ToString());
		}

		inventoryUseable.Append(UseableSize);
		foreach (var item in itemUseableList)
		{
			inventoryUseable.Append(item.ToString());
		}

		inventoryResource.Append(ResourceSize);
		foreach (var item in ItemResourceList)
		{
			inventoryResource.Append(item.ToString());
		}

		return ("\n"+inventoryEquipt.ToString()) +("\n"+inventoryUseable.ToString()) + ("\n"+inventoryResource.ToString()) ;
	}

	//public bool Load(string _data)
	//{

	//}


	#region equipt [장비관련]

	private bool ItemEquiptIntoInventory(int _index, int _itemInputCount = 1)
	{
		// 1. 슬롯 체크
		if (itemEquiptList.Count >= itemEquiptMax) return false;

		// 2. 아이템 번호 체크
		if (0 < _index || _index >= ItemDataManager.Instance.EquiptSize) return false;

		// 3. 아이템 생성
		ItemBaseEquipment itemdata = null;
		if (ItemDataManager.Instance.GetItemDataToEquipt(_index, out itemdata) == false) return false;

		for (int i = 0; i < _itemInputCount; i++)
		{
			// 장비의 경우 중복이라도 다른 슬롯에 넣기 때문에 작업 패스하고 바로 list에 넣음
			itemEquiptList.Add(itemdata);
			if (itemEquiptList.Count >= itemEquiptMax) return false;
		}
		// ui 갱신
		//UIManager.Instance.UIInventoryEquiptRefresh();

		return true;
	}


	public bool GetInventorySlotEquipData(int _index, out ItemBaseEquipment _data)
	{
		_data = null;
		if (_index < 0 || _index >= ItemDataManager.Instance.EquiptSize) return false;
		if (itemEquiptList.Count >= itemEquiptMax) return false;
		_data = itemEquiptList[_index];

		return true;
	}


	//public void GetInventorySlotEquipData(out List<ItemBaseClass.ItemBaseEquipment> _equiptdata)
	//{
	//	_equiptdata = new List<ItemBaseEquipment>();
	//	_equiptdata = itemEquiptList;
	//}
	#endregion


	#region equipt [소모품관련 함수]

	private bool ItemUseableIntoInventory(int _index, int _itemInputCount = 1)
	{
		// 1. 슬롯 체크
		if (itemUseableList.Count >= itemUseableMax) return false;

		// 2. 아이템 번호 체크
		if (0 < _index || _index >= ItemDataManager.Instance.UseableSize) return false;

		// 3. 아이템 생성
		ItemBaseUseable itemdata = null;
		if (ItemDataManager.Instance.GetItemDataToUseable(_index, out itemdata) == false) return false;

		bool itemInput = false;

		for (int i = 0; i < _itemInputCount; i++)
		{
			int remainCount = 0;

			// 보유하고 있는 아이템 리스트에 소모품이 있을 시 추가하는 작업
			foreach (var item in itemUseableList)
			{
				if (item.mainName == itemdata.mainName)	// 이름이 같으면
				{
					remainCount = item.AddCount(_itemInputCount);  
					if( remainCount > 0) // 증가가 다 됐는데 잔여값이 있다면
					{
						if (itemUseableList.Count + 1 >= itemUseableMax)	// 소모품 리스트가 최대값이고 더이상 추가할 수 없다면
						{
							return false;
						}


						ItemBaseClass.ItemBaseUseable addData = null;
						ItemDataManager.Instance.GetItemDataToUseable(_index,out addData);
						addData.AddCount(remainCount);
						//input = true;
						//break;
					}

					itemInput = true;
					break;
				}
			}
			if (itemInput == true) break;

			// 슬롯에 없어서 추가해야함
			
		}
		// ui 갱신
		//UIManager.Instance.UIInventoryEquiptRefresh();

		return true;
	}
	public bool GetInventorySlotUseable(int _index, ref ItemBaseUseable _data)
	{
		_data = null;
		if (_index < 0 || _index >= ItemDataManager.Instance.EquiptSize) return false;
		if (itemUseableList.Count >= itemUseableMax) return false;
		_data = itemUseableList[_index];

		return true;
	}

	#endregion


	#region equipt [재료관련 함수]

	private bool ItemResourceIntoInventory(int _index, int _itemInputCount = 1)
	{
		// 1. 아이템 번호 체크
		if (_index < 0 || _index >= ItemDataManager.Instance.ResourceSize) return false;

		// 2. 슬롯 체크
		if (itemUseableList.Count >= itemUseableMax) return false;

		// 3. 아이템 번호 체크
		ItemBaseUseable itemdata = null;
		if (ItemDataManager.Instance.GetItemDataToUseable(_index, out itemdata) == false) return false;
		
		bool itemInput = false;

		for (int i = 0; i < _itemInputCount; i++)
		{
			int remainCount = 0;

			// 보유하고 있는 아이템 리스트에 소모품이 있을 시 추가하는 작업
			foreach (var item in ItemResourceList)
			{
				if (item.mainName == itemdata.mainName) // 이름이 같으면
				{
					remainCount = item.AddCount(_itemInputCount);
					if (remainCount > 0) // 증가가 다 됐는데 잔여값이 있다면
					{
						if (ItemResourceList.Count + 1 >= itemResourceMax)    // 소모품 리스트가 최대값이고 더이상 추가할 수 없다면
						{
							return false;
						}


						ItemBaseClass.ItemBaseResource addData = null;
						ItemDataManager.Instance.GetItemDataToResource(_index, out addData);
						addData.AddCount(remainCount);
						//input = true;
						//break;
					}

					itemInput = true;
					break;
				}
			}
			if (itemInput == true) break;

			// 슬롯에 없어서 추가해야함

		}
		//UIManager.Instance.UIInventoryEquiptRefresh();

		return true;
	}
	public bool GetInventorySlotResource(int _index, ref ItemBaseResource _data)
	{
		_data = null;
		if (_index < 0 || _index >= ItemDataManager.Instance.EquiptSize) return false;
		if (ItemResourceList.Count >= itemResourceMax) return false;
		_data = ItemResourceList[_index];

		return true;
	}
	#endregion
}