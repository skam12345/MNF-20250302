using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IconResource : MonoBehaviour
{
	int slotNumber;

	[SerializeField] private Image iconImage;
	[SerializeField] private GameObject[] star;
	[SerializeField] private Image iconNew;
	[SerializeField] private Image iconLock;
	[SerializeField] private Image iconFavorit;
	[SerializeField] private GameObject CheckObject;
	[SerializeField] private TextMeshProUGUI levelText;

	private UnityAction selectAction;

	//UIItemInfo uiInfo;
	public void Init(int _selectNumber)//, ref UIItemInfo uiInfo)
	{
		slotNumber = _selectNumber;
	}

	public void OnClick()
	{
		//if( info.gameObject.activeSelf == false)
		//{
		//	info.gameObject.SetActive(true);
		//	info.OpenWeapon(ref select);
		//}
		//else
		//{
		//	info.gameObject.SetActive(false);
		//}
	}

	public void Refresh(ref ItemBaseClass.ItemBaseResource _item)
	{
		//iconImage.sprite = item.ItemSprite;
		//iconNew.gameObject.SetActive(item.New);
		//iconLock.gameObject.SetActive(item.Lock);

		//iconFavorit.gameObject.SetActive(item.Favorit);
		//levelText.text = item.Level.ToString();

		//for (int i = 0; i < star.Length; i++)
		//{
		//	if (i <item.Star )
		//	{
		//		star[i].gameObject.SetActive(true);
		//	}
		//	else
		//	{
		//		star[i].gameObject.SetActive(false);
		//	}
		//}

		//select = item;
	}
}
