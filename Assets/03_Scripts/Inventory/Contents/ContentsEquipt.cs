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
		prefabIcon = Resources.Load<GameObject>(ResourcesDirectory.UIIconEquipt);
	}

	private void OnEnable()
	{
		Refresh();
	}

	public void OnRefresh()
	{
		Refresh();
	}

	private void Refresh()
	{
		CheckIconList();

		if (iconList == null) return;
		if (iconList.Count < 0) return;
		int slotCount = iconList.Count;

		ItemBaseEquipment data =null;
		for (int i = 0; i < slotCount; i++)
		{
			InventoryData.Instance.GetInventorySlotEquip(i, out data);
			iconList[i].Refresh(ref data);
		}
	}

	// 아이콘 생성함수
	private void CreateIcon(int _max)
	{
		GameObject prefabCreateObject = null;

		for (int i = 0; i < _max; i++)
		{
			prefabCreateObject = Instantiate(prefabIcon, Vector3.zero, Quaternion.identity);
			prefabCreateObject.transform.parent = transform;
			transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			iconList.Add(prefabCreateObject.GetComponent<IconEquipt>());
		}
	}

	private void CheckIconList()
	{
		int slotCount = InventoryData.Instance.EquiptSize;
		CreateIcon(slotCount - iconList.Count);
	}

	public void OnOffThisObject(bool _active)
	{
		this.gameObject.SetActive(_active);
	}
}