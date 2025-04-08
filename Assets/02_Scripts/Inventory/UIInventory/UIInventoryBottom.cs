using UnityEngine;
using UnityEngine.UI;

public class UIInventoryBottom : MonoBehaviour
{
	private ContentsEquipt contentEquipt;
	private ContentsUseable contentUseable;
	private ContentsResource contentResource;

	[Header("Settings")]
	[SerializeField] private UnityEngine.Color TabColorToSelect;
	[SerializeField] private UnityEngine.Color TabColorToUnSelect;

	//[Header("Tab")]
	private Image tabIamgeEquipt;
	private Image tabIamgeUseable;
	private Image tabIamgeResource;


	private void Awake()
	{
		Transform findObject = transform.Find("TapMenu_Button");
		tabIamgeEquipt = findObject.Find("Tab Equipt").Find("IconNormal").GetComponent<Image>();
		tabIamgeUseable = findObject.Find("Tab Useable").Find("IconNormal").GetComponent<Image>();
		tabIamgeResource = findObject.Find("Tab Resource").Find("IconNormal").GetComponent<Image>();

		findObject = transform.Find("Scroll View").Find("Viewport");
		contentEquipt = findObject.GetComponentInChildren<ContentsEquipt>();
		contentUseable = findObject.GetComponentInChildren<ContentsUseable>();
		contentResource = findObject.GetComponentInChildren<ContentsResource>();

		// 기본 상태는 장비탭 오픈으로 초기화
		OnTabClick(0);
	}


	/// <summary>
	/// 버튼에 넣는 함수
	/// UI_MainInventory - Back - SlotBottom - TapMenu - Tab ~~GetComponent<Button>()
	/// 새로운 아이템 탭이 추가되면 추가해줘야함
	/// 수정하는 곳 SlotBottom Prefab에서 수정하고 저장하면 됨
	/// </summary>
	/// <param name="_tabIndex">string으로 하기 귀찮</param>
	public void OnTabClick(int _tabIndex)
	{
		switch (_tabIndex)
		{
			case 0:
				contentEquipt.OnOffThisObject(true);
				tabIamgeEquipt.color = TabColorToSelect;

				if (contentUseable.gameObject.activeSelf == true) contentUseable.OnOffThisObject(false);
				if (contentResource.gameObject.activeSelf == true) contentResource.OnOffThisObject(false);
				tabIamgeUseable.color = TabColorToUnSelect;
				tabIamgeResource.color = TabColorToUnSelect;
				break;
			case 1:
				contentUseable.OnOffThisObject(true);
				tabIamgeUseable.color = TabColorToSelect;

				if (contentEquipt.gameObject.activeSelf == true) contentEquipt.OnOffThisObject(false);
				if (contentResource.gameObject.activeSelf == true) contentResource.OnOffThisObject(false);

				tabIamgeEquipt.color = TabColorToUnSelect;
				tabIamgeResource.color = TabColorToUnSelect;
				break;
			case 2:
				contentResource.OnOffThisObject(true);
				tabIamgeResource.color = TabColorToSelect;

				if (contentEquipt.gameObject.activeSelf == true) contentEquipt.OnOffThisObject(false);
				if (contentUseable.gameObject.activeSelf == true) contentUseable.OnOffThisObject(false);

				tabIamgeEquipt.color = TabColorToUnSelect;
				tabIamgeUseable.color = TabColorToUnSelect;

				break;
		}
	}



	public void RefreshAll()
	{
		contentEquipt.OnRefresh();
		contentUseable.OnRefresh();
		contentResource.OnRefresh();
	}

	public void RefreshEquipt()
	{
		contentEquipt.OnRefresh();
	}

	public void RefreshUseable()
	{
		contentUseable.OnRefresh();
	}

	public void RefreshResource()
	{
		contentResource.OnRefresh();
	}

}