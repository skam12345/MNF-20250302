using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private GameObject back;
    private UIInventoryTop top;
	private UIInventoryBottom bottom;

	private void Awake()
	{
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "08_InventoryAndItem")
		{
			InventoryData.Instance.OnInit();
			ItemDataManager.Instance.OnInit();
		}


		back = transform.Find("Back").gameObject;

		top = back.transform.Find("SlotTop").GetComponent<UIInventoryTop>();
		bottom = back.transform.Find("SlotBottom").GetComponent<UIInventoryBottom>();

	}

	//인벤토리 온오프
	public void OnOffInventory(bool _active)
    {
        back.SetActive(_active);
	}

	#region 상단부 사용중인 장비(usingEquipt) 퀵슬롯(QuickSlot) 함수
	public void RefeshUsingEquip()
	{

	}

	#endregion

	#region 하단부 장비,소모품,재료 테이블(Content~) 함수


	#endregion


	#region 08_InventoryAndItem Scene TestFunc()
	public void TestOnItemInputToEquipt()
	{
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "08_InventoryAndItem")
		{
			ItemBaseClass.ItemData data = new ItemBaseClass.ItemData();
			data.Index = UnityEngine.Random.Range(0, 10);
			data.Type = "장비";
			data.Count = 1;
			InventoryData.Instance.ItemInInventoryToItemData(ref data);

			bottom.RefreshEquipt();
		}
	}

	public void TestOnItemInputToUseable()
	{
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "08_InventoryAndItem")
		{
			ItemBaseClass.ItemData data = new ItemBaseClass.ItemData();
			data.Index = UnityEngine.Random.Range(0, 3);
			data.Type = "소모품";
			data.Count = UnityEngine.Random.Range(1, 999);
			InventoryData.Instance.ItemInInventoryToItemData(ref data);
			bottom.RefreshUseable();
		}
	}

	public void TestOnItemInputToResource()
	{
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "08_InventoryAndItem")
		{
			ItemBaseClass.ItemData data = new ItemBaseClass.ItemData();
			data.Index = UnityEngine.Random.Range(0, 10);
			data.Type = "재료";
			data.Count = UnityEngine.Random.Range(1, 999);
			InventoryData.Instance.ItemInInventoryToItemData(ref data);

			bottom.RefreshResource();
		}
	}
	#endregion
}