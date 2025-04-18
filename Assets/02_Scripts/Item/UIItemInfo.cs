using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static ItemBaseClass;
using Unity.VisualScripting;

public class UIItemInfo : MonoBehaviour
{
	// debug
	//[Header("BackObject")]
	//[SerializeField] private GameObject back;

	//[Header("Inspector_Top")]
	//[SerializeField] private Image type;
	//[SerializeField] TextMeshProUGUI starNumber;
	//[SerializeField] TextMeshProUGUI itemName;
	//[SerializeField] Image itemImage;

	//[Header("Inspector_Explan")]
	//[SerializeField] TextMeshProUGUI mainExplan;
	//[SerializeField] TextMeshProUGUI mainExplanDetail;
	//[SerializeField] TextMeshProUGUI subExplan;
	//[SerializeField] TextMeshProUGUI subExplanDetail;

	//[Header("Inspector_Bottom_BtnText")]
	//[SerializeField] TextMeshProUGUI btnOKAndUse;
	//[SerializeField] TextMeshProUGUI btnClose;

	//[Header("BackObject")]
	private GameObject back;

	//[Header("Inspector_Top")]
	private Image type;
	private TextMeshProUGUI starNumber;
	private TextMeshProUGUI itemName;
	private Image itemImage;

	//[Header("Inspector_Explan")]
	private TextMeshProUGUI mainExplan;
	private TextMeshProUGUI mainExplanDetail;
	private TextMeshProUGUI subExplan;
	private TextMeshProUGUI subExplanDetail;

	//[Header("Inspector_Bottom_BtnText")]
	private TextMeshProUGUI btnOKAndUse;
	private TextMeshProUGUI btnClose;

	private void Awake()
	{
		back = transform.Find("Back").gameObject;
		GameObject title = back.transform.Find("Title").gameObject;
		type = title.transform.Find("TypeImage").GetComponent<Image>();
		starNumber = title.transform.Find("StarImange").transform.Find("StarText(TMP)").GetComponent<TextMeshProUGUI>();
		itemName = title.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();

		itemImage = back.transform.Find("FrameImage").transform.Find("ItemImage").GetComponent<Image>();

		GameObject bottom = back.transform.Find("Bottom").gameObject;
		GameObject textMain = bottom.transform.Find("TextMain").gameObject;
		mainExplan = textMain.transform.Find("MainExplanText").GetComponent<TextMeshProUGUI>();
		mainExplanDetail = textMain.transform.Find("MainDetail").GetComponent<TextMeshProUGUI>();

		textMain = bottom.transform.Find("TextSub").gameObject;
		subExplan = textMain.transform.Find("SubExplanText").GetComponent<TextMeshProUGUI>();
		subExplanDetail = textMain.transform.Find("SubDetail").GetComponent<TextMeshProUGUI>();

		btnOKAndUse = back.transform.Find("btnOK").GetComponentInChildren<TextMeshProUGUI>();
		btnClose = back.transform.Find("btnClose").GetComponentInChildren<TextMeshProUGUI>();
	}

	public void Active(bool _active)
	{
		back.SetActive(_active);
	}

	public void ItemViewToEquipt(ref ItemBaseEquipment _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		itemImage.sprite = SpriteManager.Instance.GetSpriteEquipt(_item.index);
		starNumber.text = _item.grade.ToString();
		itemName.text = _item.name;
		mainExplanDetail.text = _item.description;
		subExplanDetail.text = "";
	}

	public void ItemViewToUseable(ref ItemBaseUseable _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		itemImage.sprite = SpriteManager.Instance.GetSpriteUseable(_item.index);
		//starNumber.text = _item..ToString();
		itemName.text = _item.mainName;
		mainExplanDetail.text = _item.mainDescription;
		subExplanDetail.text = _item.subDescriton;
	}

	public void ItemViewToResource(ref ItemBaseResource _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;
		itemImage.sprite = SpriteManager.Instance.GetSpriteResource(_item.index);
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