using UnityEngine;
using System.Collections.Generic;
using static ItemBaseClass;

public class ContentsEquipt : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField]private List<IconEquipt> iconList;

	private void Awake()
	{
		iconList = new List<IconEquipt>();
	}

	public void Refresh()
	{
		int slotCount = InventoryData.Instance.EquiptSize;

		ItemBaseEquipment data =null;
		for (int i = 0; i < slotCount; i++)
		{
			InventoryData.Instance.GetInventorySlotEquipData(i, out data);
			iconList[i].Refresh(ref data);
		}
	}
}