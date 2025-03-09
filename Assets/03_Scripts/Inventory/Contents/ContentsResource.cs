using System.Collections.Generic;
using UnityEngine;
using static ItemBaseClass;

public class ContentsResource : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconResource> iconList;

	private void Awake()
	{
		iconList = new List<IconResource>();
	}

	public void Refresh()
	{
		int slotCount = InventoryData.Instance.ResourceSize;

		ItemBaseResource data = null;
		for (int i = 0; i < slotCount; i++)
		{
			InventoryData.Instance.GetInventorySlotResource(i, ref data);
			iconList[i].Refresh(ref data);
		}
	}
}
