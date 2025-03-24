using UnityEngine;
using static ItemBaseClass;
using System.Collections.Generic;

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

	public bool ItemOutInventoryToItemData(ref ItemData _data)
	{
		//Debug.Log(_data.ToString());
		//Debug.Log(EquiptSize);
		switch (_data.Type)
		{
			case "장비": return SearchToRemoveByEquipt(ref _data);
			case "소모품": return SearchToRemoveByConsume(ref _data);
			case "재료": return SearchToRemoveByResource(ref _data);
		}
		Debug.Log(EquiptSize);
		return false;
	}


	#region equipt [장비관련]

	// 내부 코드
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

	/// <summary>
	/// 장비를 찾습니다.
	/// 반환값 : 인벤토리 번호
	/// 넣을 값 : ItemData 규격
	/// </summary>
	/// <param name="_data"></param>
	/// <returns></returns>
	private int SearchEquipt(ref ItemData _data)
	{
		for (int i = 0; i < itemEquiptList.Count; i++)
		{
			if (itemEquiptList[i].index == _data.Index)
			{
				return i;
			}
		}
		return -1;
	}
	private int SearchEquipt(int _index)
	{
		for (int i = 0; i < itemEquiptList.Count; i++)
		{
			if (itemEquiptList[i].index == _index)
			{
				return i;
			}
		}
		return -1;
	}
	// 외부 코드
	public bool GetInventorySlotEquip(int _index, out ItemBaseEquipment _data)
	{
		_data = null;
		if (_index < 0 || ItemDataManager.Instance.EquiptSize <= _index) return false;
		if (itemEquiptList.Count >= itemEquiptMax) return false;
		_data = itemEquiptList[_index];

		return true;
	}
	
	public bool SearchToRemoveByEquipt(int _equiptIndex)
	{
		int searchArrayNumber = SearchEquipt(_equiptIndex);

		if(searchArrayNumber != -1)
		{
			itemEquiptList.RemoveAt(searchArrayNumber);
			return true;
		}
		return false;
	}

	public bool SearchToRemoveByEquipt(ref ItemData _data)
	{
		int searchArrayNumber = SearchEquipt(ref _data);

		if(searchArrayNumber != -1)
		{
			itemEquiptList.RemoveAt(searchArrayNumber);
			return true;
		}
		return false;
	}


	#endregion


	#region useable [소모품관련 함수]

	public int SearchConsume(ref ItemData _data)
	{
		for (int i = 0; i < itemUseableList.Count; i++)
		{
			if (itemUseableList[i].index == _data.Index)
			{
				if (itemUseableList[i].count >= _data.Count)
				{
					return i;
				}
				return -1;
			}
		}
		return -1;
	}

	public int SearchConsume(int _index, int _count)
	{
		for (int i = 0; i < itemUseableList.Count; i++)
		{
			if (itemUseableList[i].index == _index)
			{
				if (itemUseableList[i].count >= _count)
				{
					return i;
				}
				return -1;
			}
		}
		return -1;
	}

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


	// 1. for로 배열을 돌아서
	// 2. 아이템 태그가 맞는지
	// 3. 맞다면 개수가 0 < 면 차감 후 list 제거
	// 4. 잔여값이 있다면 다시 탐색

	//인자값 : _itemIndex = 아이템 번호
	//인자값 : _count = 개수
	//실패 이유 : 아이템 개수가 적음
	//			 아이템이 존재하지 않음
	private bool SearchToRemoveByConsume(ref ItemData _data)
	{
		if (itemUseableList == null) return false;
		if (itemUseableList.Count == 0) return false;

		foreach (var item in itemUseableList)
		{
			Debug.Log("== ItemConsume ==");
			Debug.Log(" item Index : " +item.index + "\nDataIndex"+ _data.Index);

			if (item.index== _data.Index)
			{
#if UNITY_EDITOR
				Debug.Log("== ItemConsume ==");
				ItemBaseUseable data = null;
				ItemDataManager.Instance.GetItemDataToUseable(_data.Index,out data);
				Debug.Log(data.ToString());
				Debug.Log(item.ToString());
				Debug.Log(_data.ToString());
#endif
				Debug.Log(item.count + "\t" + _data.Count + "\t"+ (item.count >= _data.Count));
				if (item.count >= _data.Count)
				{
					if (item.SubstactCount(_data.Count) == 0)
					{
						itemUseableList.Remove(item);
						return true;
					}
				}
				else
				{
#if UNITY_EDITOR
					Debug.Log("갖고있는 아이템 값이 적음 " + "\n item :" + item.count + "\t inputCount : " + _data.Count);
#endif
					return false;
				}
			}
		}
		return false;
	}
	private bool SearchToRemoveByConsume(int _itemindex, int _count)
    {
		if (itemUseableList == null) return false;
		if (itemUseableList.Count == 0) return false;

		foreach (var item in itemUseableList)
		{
			if(item.index == _itemindex)
			{
#if UNITY_EDITOR
				Debug.Log("인벤토리 소모품 슬롯에 아이템 검색이 됐음");
#endif
				if ( item.count >= _count)
				{
					if (item.SubstactCount(_count) == 0)
					{
						itemUseableList.Remove(item);
						return true;
					}
				}
				else
				{
#if UNITY_EDITOR
					Debug.Log("갖고있는 아이템 값이 적음 " + "\n item :" + item.count + "\t inputCount : " + _count);
#endif
					return false;
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

	// 1. for로 배열을 돌아서
	// 2. 아이템 태그가 맞는지
	// 3. 맞다면 개수가 0 < 면 차감 후 list 제거
	// 4. 잔여값이 있다면 다시 탐색

	//인자값 : _itemIndex = 아이템 번호
	//인자값 : _count = 개수
	//실패 이유 : 아이템 개수가 적음
	//			 아이템이 존재하지 않음
	private bool SearchToRemoveByResource(ref ItemData _data)
	{
		if (ItemResourceList == null) return false;
		if (ItemResourceList.Count == 0) return false;

		foreach (var item in ItemResourceList)
		{
			if (item.index == _data.Index)
			{
#if UNITY_EDITOR
				Debug.Log("인벤토리 소모품 슬롯에 아이템 검색이 됐음");
#endif
				if (item.count >= _data.Count)
				{
					if (item.SubstactCount(_data.Count) == 0)
					{
						ItemResourceList.Remove(item);
						return true;
					}
				}
				else
				{
#if UNITY_EDITOR
					Debug.Log("갖고있는 아이템 값이 적음 " + "\n item :" + item.count + "\t inputCount : " + _data.Count);
#endif
					return false;
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