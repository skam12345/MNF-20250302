using System.Collections.Generic;
using UnityEngine;
using static ItemBaseClass;

public class ContentsUseable : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconUseable> iconList;

	private void Awake()
	{
		iconList = new List<IconUseable>();
	}

	public void Refresh()
	{
		int slotCount = InventoryData.Instance.UseableSize;

		ItemBaseUseable data = null;
		for (int i = 0; i < slotCount; i++)
		{
			InventoryData.Instance.GetInventorySlotUseable(i, ref data);
			iconList[i].Refresh(ref data);
		}
	}
}
