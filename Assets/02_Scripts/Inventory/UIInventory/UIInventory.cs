using JetBrains.Annotations;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private GameObject bag;
    private UIInventoryTop top;
	private UIInventoryBottom bottom;

	private void Awake()
	{
		InventoryData.Instance.OnInit();
		ItemDataManager.Instance.OnInit();

		bag = transform.Find("Back").gameObject;
		top = bag.transform.Find("SlotTop").GetComponent<UIInventoryTop>();
		bottom = bag.transform.Find("SlotBottom").GetComponent<UIInventoryBottom>();

	}

	//인벤토리 온오프
	public void OnOffInventory(bool _active)
    {
        bag.SetActive(_active);
	}

	#region 상단부 사용중인 장비(usingEquipt) 퀵슬롯(QuickSlot) 함수, 미완
	public void RefeshUsingEquip()
	{

	}

	#endregion

	#region 하단부 장비,소모품,재료 테이블(Content~) 함수(미완)


	#endregion





	#region 매개변수를 받아서 아이템을 추가하는 함수. 아이템넘버,개수

	//장비추가 / 소모품추가 / 재료 추가
	public void AddEquiptoInventory(int itemNum,int itemcount)
	{
		ItemBaseClass.ItemData data = new ItemBaseClass.ItemData();
		data.Index = itemNum;
		data.Type = "장비";
		data.Count = itemcount;
		InventoryData.Instance.ItemInInventoryToItemData(ref data);
		bottom.RefreshEquipt();
	}

	public void AddConsumetoInventory(int itemNum, int itemcount)
	{
		ItemBaseClass.ItemData data = new ItemBaseClass.ItemData();
		data.Index = itemNum;
        data.Type = "소모품";
		data.Count = itemcount;
        InventoryData.Instance.ItemInInventoryToItemData(ref data);
		bottom.RefreshUseable();
	}
	//재료를 얻게하는 함수
	public void AddItemtoInventory(int itemNum, int itemcount)
	{
        ItemBaseClass.ItemData data = new ItemBaseClass.ItemData();
        data.Index = itemNum;
        data.Type = "재료";
        data.Count = itemcount;
        InventoryData.Instance.ItemInInventoryToItemData(ref data);
        bottom.RefreshUseable();
    }

	public void AddGold(int gaingold)
	{

	}
	public void AddExp(int exp)
	{

	}
    #endregion


    #region 아이템 빼는 함수

	public void RemoveConsumeBtn()
	{
		RemoveConsume(Random.Range(0,2),3);
    }

	public void RemoveConsume(int itemNum, int itemcount)
	{
        InventoryData.Instance.ItemRemoveCount(itemNum,itemcount);
        bottom.RefreshUseable();
    }


    #endregion


    //사용법
    #region 퀘스트 보상 시 응용하는 법
    public void GetEquipButton()
	{
		//퀘스트 보상이 1번장비를 3개 얻고싶다면
		AddEquiptoInventory(Random.Range(1,5), 3);
	}

    public void GetConsumeButton()
    {
        //퀘스트 보상이 랜덤한물약 20개를 얻고싶다면
        AddConsumetoInventory(Random.Range(0, 3), 20);
    }

    public void GetExpButton()
    {
        //퀘스트 보상이 랜덤한물약 20개를 얻고싶다면
        AddEquiptoInventory(Random.Range(1, 5), 20);
    }

    #endregion
}