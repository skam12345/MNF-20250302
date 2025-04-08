using System.Collections.Generic;
using UnityEngine;

public class ContentShop : MonoBehaviour
{
	private GameObject prefabShopIcon;

	private ShopToScriptable shopData;

	private List<UIShopIcon> slotList;

	private void Awake()
	{
		prefabShopIcon = Resources.Load<GameObject>(ResourcesDirectory.ShopSlotObject);
		slotList = new List<UIShopIcon>();
	}

	public void OnInit(string _scriptableShopListName)
	{
		shopData = Resources.Load<ShopToScriptable>(ResourcesDirectory.ShopScriptable + _scriptableShopListName);
	}

	private void Refresh()
	{
		CheckIconList();

		if (slotList == null) return;
		if (slotList.Count < 0) return;
		int slotCount = slotList.Count;

		
		//ItemBaseUseable data = null;
		//for (int i = 0; i < slotCount; i++)
		//{
		//	if (i < InventoryData.Instance.UseableSize)
		//	{
		//		InventoryData.Instance.GetInventorySlotUseable(i, out data);
		//		iconList[i].Refresh(ref data);
		//	}
		//	else
		//	{
		//		Destroy(iconList[i].gameObject);
		//		iconList.RemoveAt(i);
		//	}
		//}
	}

	// 아이콘 생성함수
	private void CreateIcon(int _max)
	{
		//GameObject prefabCreateObject = null;

		//for (int i = 0; i < _max; i++)
		//{
		//	prefabCreateObject = Instantiate(prefabShopIcon, Vector3.zero, Quaternion.identity);
		//	prefabCreateObject.transform.parent = transform;
		//	slotList.Add(prefabCreateObject.GetComponent<IconShop>());
		//}
	}

	private void CheckIconList()
	{
		//int slotCount = InventoryData.Instance.UseableSize;
		//CreateIcon(slotCount - iconList.Count);
	}

	public void OnOffThisObject(bool _active)
	{
		//this.gameObject.SetActive(_active);
	}
}