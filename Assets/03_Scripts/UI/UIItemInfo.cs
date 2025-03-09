using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static ItemBaseClass;

public class UIItemInfo : MonoBehaviour
{
	//public Sprite[] typeSprite;
	[Header("BackObject")]
	[SerializeField] private GameObject back;

	[Header("Inspector_Top")]
	[SerializeField] Image type;
	[SerializeField] TextMeshProUGUI starNumber;
	[SerializeField] TextMeshProUGUI itemName;
	[SerializeField] Image itemImage;

	[Header("Inspector_Explan")]
	[SerializeField] TextMeshProUGUI mainExplan;
	[SerializeField] TextMeshProUGUI mainExplanDetail;
	[SerializeField] TextMeshProUGUI subExplan;
	[SerializeField] TextMeshProUGUI subExplanDetail;

	[Header("Inspector_Bottom_BtnText")]
	[SerializeField] TextMeshProUGUI btnUse;
	[SerializeField] TextMeshProUGUI btnClose;

	public void Active(bool _active)
	{
		back.SetActive(_active);
	}

	public void ItemViewToEquipt(ref ItemBaseEquipment _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		//itemImage.sprite = _item.ItemSprite;
		//starNumber.text = _item.Star.ToString();
		itemName.text = _item.name;
		mainExplanDetail.text = _item.description;
		subExplanDetail.text = "";
	}

	public void ItemViewToUseable(ref ItemBaseUseable _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		//itemImage.sprite = _item.ItemSprite;
		//starNumber.text = _item.Star.ToString();
		itemName.text = _item.mainName;
		mainExplanDetail.text = _item.mainDescription;
		subExplanDetail.text = _item.subDescriton;
	}

	public void ItemViewToResource(ref ItemBaseResource _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;
		//itemImage.sprite = _item.ItemSprite;
		//starNumber.text = _item.Star.ToString();
		itemName.text = _item.mainName;
		mainExplanDetail.text = _item.description;
		subExplanDetail.text = "";
	}

	public void Close()
	{
		Active(false);
	}


	public void OK()
	{
		Active(false);
	}
}