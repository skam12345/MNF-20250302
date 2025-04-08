using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShopIcon : MonoBehaviour
{
	private Image itemImage;
	private TextMeshProUGUI nameText;
	private TextMeshProUGUI goldText;
	private TextMeshProUGUI countText;

	private void Awake()
	{
		Transform findTR = transform.Find("Panel");
		itemImage = findTR.Find("ItemImage").GetComponent<Image>();
		nameText = findTR.Find("NameText").GetComponent<TextMeshProUGUI>();
		goldText = findTR.Find("GoldText").GetComponent<TextMeshProUGUI>();
		countText = findTR.Find("Count").GetComponent<TextMeshProUGUI>();
	}

	public void RefreshBuy(ref ItemBaseClass.ItemData _data)
	{
		ItemBaseClass.ItemBaseEquipment equipt;
		ItemBaseClass.ItemBaseUseable useable;
		ItemBaseClass.ItemBaseResource resource;

		ItemBaseClass.GetItemDataToItem(ref _data,out equipt, out useable, out resource);
		if (equipt == null)
		{
			itemImage.sprite = SpriteManager.Instance.GetSpriteEquipt(_data.Index);
			nameText.text = equipt.name;
			goldText.text = equipt.buyGold.ToString();
			countText.text = 1.ToString();
		}
		else if (useable == null)
		{
			itemImage.sprite = SpriteManager.Instance.GetSpriteUseable(_data.Index);
			nameText.text = useable.mainName;
			goldText.text = useable.buyGold.ToString();
			countText.text = 1.ToString();
		}
		else if (resource == null)
		{
			itemImage.sprite = SpriteManager.Instance.GetSpriteResource(_data.Index);
			nameText.text = resource.mainName;
			goldText.text = resource.buyGold.ToString();
			countText.text = 1.ToString();
		}
		else
		{
#if UNITY_EDITOR
			Debug.LogError("아이템 정보값이 이상합니다" + _data.ToString());
#endif
		}
	}

	public void RefreshSell(ref ItemBaseClass.ItemData _data)
	{
		ItemBaseClass.ItemBaseEquipment equipt;
		ItemBaseClass.ItemBaseUseable useable;
		ItemBaseClass.ItemBaseResource resource;

		ItemBaseClass.GetItemDataToItem(ref _data, out equipt, out useable, out resource);
		if (equipt == null)
		{
			itemImage.sprite = SpriteManager.Instance.GetSpriteEquipt(_data.Index);
			nameText.text = equipt.name;
			goldText.text = equipt.sellGold.ToString();
			countText.text = 1.ToString();
		}
		else if (useable == null)
		{
			itemImage.sprite = SpriteManager.Instance.GetSpriteUseable(_data.Index);
			nameText.text = useable.mainName;
			goldText.text = useable.sellGold.ToString();
			countText.text = 1.ToString();
		}
		else if (resource == null)
		{
			itemImage.sprite = SpriteManager.Instance.GetSpriteResource(_data.Index);
			nameText.text = resource.mainName;
			goldText.text = resource.sellGold.ToString();
			countText.text = 1.ToString();
		}
		else
		{
#if UNITY_EDITOR
			Debug.LogError("아이템 정보값이 이상합니다" + _data.ToString());
#endif
		}
	}
}