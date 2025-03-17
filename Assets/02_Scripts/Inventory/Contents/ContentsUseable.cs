using UnityEngine;
using System.Collections.Generic;

using static ItemBaseClass;

public class ContentsUseable : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconUseable> iconList;

	private void Awake()
	{
		iconList = new List<IconUseable>();
		prefabIcon = Resources.Load<GameObject>(ResourcesDirectory.UIIconUseable);
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

		ItemBaseUseable data = null;
		for (int i = 0; i < slotCount; i++)
		{
			InventoryData.Instance.GetInventorySlotUseable(i, out data);
			iconList[i].Refresh(ref data);

			Debug.Log(data.ToString()+"이거임이거임ㅇ지금작업");

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
			iconList.Add(prefabCreateObject.GetComponent<IconUseable>());
		}
	}

	private void CheckIconList()
	{
		int slotCount = InventoryData.Instance.UseableSize;
		CreateIcon(slotCount - iconList.Count);
	}

	public void OnOffThisObject(bool _active)
	{
		this.gameObject.SetActive(_active);
	}
}
