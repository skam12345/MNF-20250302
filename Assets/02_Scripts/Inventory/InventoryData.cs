using UnityEngine;
using static ItemBaseClass;
using System.Collections.Generic;
using UnityEditor.UIElements;

public class InventoryData : SingleTonBase<InventoryData>
{
	private int inGameGold = 0;
	public int InGameGold { get { return inGameGold; } set { inGameGold += value; } }

	private int itemEquiptMax = 99;
	private int itemUseableMax = 99;
	private int itemResourceMax = 99;

	[Header("ItemData")]
	[SerializeField] private List<ItemBaseEquipment> itemEquiptList;
	[SerializeField] private List<ItemBaseUseable> itemUseableList;
	[SerializeField] private List<ItemBaseResource> ItemResourceList;

	private List<ItemData> usingEquipItem;
	private List<ItemData> usingQuickSlotItem;
	
	public int EquiptSize { get { if (itemEquiptList == null) return -1; return itemEquiptList.Count; } }
	public int UseableSize { get { if (itemUseableList == null) return -1; return itemUseableList.Count; } }
	public int ResourceSize { get { if (ItemResourceList == null) return -1; return ItemResourceList.Count; } }

	public void OnInit()
	{
		Init();
	}
	private void Init()
	{
		itemEquiptList = new List<ItemBaseEquipment>();
		itemUseableList = new List<ItemBaseUseable>();
		ItemResourceList = new List<ItemBaseResource>();
		usingEquipItem = new List<ItemData>();
		usingQuickSlotItem = new List<ItemData>();
	}

	public bool ItemInInventoryToItemData(ref ItemData _data)
	{
		//Debug.Log(_data.ToString());
		switch (_data.Type)
		{
			case "장비":		return ItemInInventoryToEquipt(ref _data);
			case "소모품":	return ItemInInventoryToUseable(ref _data);
			case "재료":		return ItemInInventoryToResource(ref _data); 
		}
		return false;
	}

	


	#region equipt [장비관련]

	private bool ItemInInventoryToEquipt(ref ItemData _data)
	{
		// 1. 슬롯 체크
		if (itemEquiptList == null)
		{
#if UNITY_EDITOR
			Debug.LogError("InventoryData.OnInit() 필요함");
#endif
			return false;
		}
		if (itemEquiptList.Count >= itemEquiptMax)
		{
#if UNITY_EDITOR
			Debug.LogError("Equipt Slot Max");
#endif
			return false;
		}

		int dataIndex = _data.Index;

		// 2. 아이템 번호 체크
		if (dataIndex < 0 || ItemDataManager.Instance.EquiptSize <= dataIndex)
		{
			//Debug.Log("index : " + _index + "\t itemdataEquiptSize : " + ItemDataManager.Instance.EquiptSize + 
			//	"\ncase 1 : " + (_index < 0) +
			//	"\ncase 2 : " + (ItemDataManager.Instance.EquiptSize <= _index));
			return false;
		}


		// 3. 아이템 생성
		ItemBaseEquipment itemdata = null;
		if (ItemDataManager.Instance.GetItemDataToEquipt(dataIndex, out itemdata) == false) return false;
		
		// 장비의 경우 중복이라도 다른 슬롯에 넣기 때문에 작업 패스하고 바로 list에 넣음
		itemEquiptList.Add(itemdata);
		if (itemEquiptList.Count >= itemEquiptMax) return false;
		// ui 갱신
		//UIManager.Instance.UIInventoryEquiptRefresh();

		return true;
	}


	public bool GetInventorySlotEquip(int _index, out ItemBaseEquipment _data)
	{
		_data = null;
		if (_index < 0 || ItemDataManager.Instance.EquiptSize <= _index) return false;
		if (itemEquiptList.Count >= itemEquiptMax) return false;
		_data = itemEquiptList[_index];

		return true;
	}


	#endregion


	#region useable [소모품관련 함수]


	private bool ItemInInventoryToUseable(ref ItemData _data)
	{
		// 1. 슬롯 체크
		if (itemUseableList.Count >= itemUseableMax) return false;

		int dataIndex = _data.Index;
		// 2. 아이템 번호 체크
		if (dataIndex < 0 || ItemDataManager.Instance.UseableSize <= dataIndex)
		{
			Debug.Log("index : " + dataIndex + "\t itemdataUseableSize : " + ItemDataManager.Instance.UseableSize +
				"\ncase 1 : " + (dataIndex < 0) +
				"\ncase 2 : " + (ItemDataManager.Instance.UseableSize <= dataIndex));
			return false;
		}

		// 3. 아이템 생성
		ItemBaseUseable findData = null;

		if (ItemDataManager.Instance.GetItemDataToUseable(dataIndex, out findData) == false) return false;

		int remainCount = 0;

		foreach (var item in itemUseableList)
		{
			if(findData.mainName == item.mainName)
			{
				if( item.IsAddCount(_data.Count) == false)	// 얻을 아이템 수량이 최대고 
				{
					Debug.Log(item.count+"\n"+ item.IsAddCount(_data.Count));

					//todo: ㅇㅇ

					if (itemUseableList.Count + 1 >= itemUseableMax)	// 아이템리스트가 최대
					{
						_data.Count = item.AddCount(_data.Count);
						return false;
					}
					else	// 아이템 리스트를 만들 수 있음
					{
						_data.Count = item.AddCount(_data.Count);
						remainCount = _data.Count;

						findData.AddCount(remainCount);
						itemUseableList.Add(findData);
						// 2차 검사를 해야하지만 최대 획득 스택을 99999개로 제한하라고 적어두고 안내할 예정
						return true;
					}
				}
				else
				{
					item.AddCount(_data.Count);
					return true;
				}
			}
		}

        // 여기까지 오면 슬롯에 같은 아이템이 없으니 새로 만들어야함
        findData.count = _data.Count;

        itemUseableList.Add(findData);


		// ui 갱신
		//UIManager.Instance.UIInventoryEquiptRefresh();

		return true;
	}
	public bool GetInventorySlotUseable(int _index, out ItemBaseUseable _data)
	{
		_data = null;
		if (_index < 0 || ItemDataManager.Instance.UseableSize <= _index) return false;
		if (itemUseableList.Count >= itemUseableMax) return false;
		_data = itemUseableList[_index];

		return true;
	}

	public bool ItemRemoveCount(int _item, int _count)
	{
		Debug.Log("리무스카운트 함수 켜짐"+ IsConsumeExist(_item, _count));
		if (IsConsumeExist(_item,_count))
		{
			foreach (var item in itemUseableList)
			{
				if(item.index == _item)
				{
					item.SubstactCount(_count);
                    Debug.Log("아이템이 제거됨"+item.ToString());
                    return true;
                }
            }
		}
		return false;
	}


	//있는지 검증합니다.
    public bool IsConsumeExist(int _itemindex, int _count)
    {
        //아이템 있나 검증하는 함수
        foreach (var item in itemUseableList)
        {
            if (item.index == _itemindex)
            {
                if (item.count >= _count)
                {
                    //아이템이 존재하긴함
                    return true;

                }
            }

        }

        return false;
    }

    #endregion
    #region equipt [재료관련 함수]

    private bool ItemInInventoryToResource(ref ItemData _data)
	{
		// 1. 슬롯 체크
		if (ItemResourceList.Count >= itemResourceMax) return false;

		// 2. 아이템 번호 체크
		int dataIndex = _data.Index;
		if (dataIndex < 0 || ItemDataManager.Instance.ResourceSize <= dataIndex)
		{
			//Debug.Log("index : " + _index + "\t itemdataEquiptSize : " + ItemDataManager.Instance.EquiptSize + 
			//	"\ncase 1 : " + (_index < 0) +
			//	"\ncase 2 : " + (ItemDataManager.Instance.EquiptSize <= _index));
			return false;
		}

		// 3. 아이템 번호 체크
		ItemBaseResource findData = null;
		if (ItemDataManager.Instance.GetItemDataToResource(dataIndex, out findData) == false) return false;
		foreach (var item in ItemResourceList)
		{
			int remainCount = 0;

			if (findData.mainName == item.mainName)
			{
				if (item.IsAddCount(_data.Count) == false)  // 얻을 아이템 수량이 최대고 
				{
					if (ItemResourceList.Count + 1 >= itemUseableMax)    // 아이템리스트가 최대
					{
						_data.Count = item.AddCount(_data.Count);
						return false;
					}
					else    // 아이템 리스트를 만들 수 있음
					{
						_data.Count = item.AddCount(_data.Count);
						remainCount = _data.Count;

						ItemBaseResource addSlot = new ItemBaseResource();
						addSlot.Init(findData);
						addSlot.AddCount(remainCount);
						ItemResourceList.Add(addSlot);
						// 2차 검사를 해야하지만 최대 획득 스택을 99999개로 제한하라고 적어두고 안내할 예정
						return true;
					}
				}
				else
				{
					item.AddCount(_data.Count);
					return true;
				}
			}
		}

		// 여기까지 오면 슬롯에 같은 아이템이 없으니 새로 만들어야함
		findData.count = _data.Count;
		ItemResourceList.Add(findData);

		//UIManager.Instance.UIInventoryEquiptRefresh();

		return true;
	}
	public bool GetInventorySlotResource(int _index, out ItemBaseResource _data)
	{
		_data = null;
		if (_index < 0 || ItemDataManager.Instance.ResourceSize <= _index) return false;
		if (ItemResourceList.Count >= itemResourceMax) return false;
		_data = ItemResourceList[_index];

		return true;
	}
	
	public bool IsResourceExist(int _itemindex,int _count)
	{
		//아이템 있나 검증하는 함수
		foreach (var item in ItemResourceList)
		{
			if(item.index == _itemindex)
			{
				if(item.count >= _count)
				{
					//아이템이 존재하긴함
					return true;
					
				}
			}

		}

		return false;
	}

	#endregion


	//public string Save()
	//{
	//	System.Text.StringBuilder inventoryEquipt = new System.Text.StringBuilder();
	//	System.Text.StringBuilder inventoryUseable = new System.Text.StringBuilder();
	//	System.Text.StringBuilder inventoryResource = new System.Text.StringBuilder();

	//	inventoryEquipt.Append(EquiptSize);
	//	foreach (var item in itemEquiptList)
	//	{
	//		inventoryEquipt.Append(item.ToString());
	//	}

	//	inventoryUseable.Append(UseableSize);
	//	foreach (var item in itemUseableList)
	//	{
	//		inventoryUseable.Append(item.ToString());
	//	}

	//	inventoryResource.Append(ResourceSize);
	//	foreach (var item in ItemResourceList)
	//	{
	//		inventoryResource.Append(item.ToString());
	//	}

	//	return ("\n"+inventoryEquipt.ToString()) +("\n"+inventoryUseable.ToString()) + ("\n"+inventoryResource.ToString()) ;
	//}

	//public bool Load(string _data)
	//{

	//}
}