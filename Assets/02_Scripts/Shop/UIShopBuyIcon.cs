using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShopBuyIcon : MonoBehaviour
{
	private Image itemImage;
	private TextMeshProUGUI textName;
	private TextMeshProUGUI textBuyGold;

	private void Awake()
	{
		itemImage = GetComponent<Image>();
		textName = transform.Find("TextNameTMP").GetComponent<TextMeshProUGUI>();
		textBuyGold = transform.Find("TextGoldTMP").GetComponent<TextMeshProUGUI>();
	}

	public void Refresh(ItemBaseClass.ItemData _data)
	{
		switch (_data.Type)
		{
			case "장비":
				{
					ItemBaseClass.ItemBaseEquipment itemData = null;
					ItemDataManager.Instance.GetItemDataToEquipt(_data.Index, out itemData);
					itemImage.sprite = SpriteManager.Instance.GetSpriteEquipt(_data.Index);
					textName.text = itemData.name;
					textBuyGold.text = itemData.buyGold.ToString();
				}
				break;
			case "소모품":
				{
					ItemBaseClass.ItemBaseUseable itemData = null;
					ItemDataManager.Instance.GetItemDataToUseable(_data.Index, out itemData);
					itemImage.sprite = SpriteManager.Instance.GetSpriteUseable(_data.Index);
					textName.text = itemData.mainName;
					textBuyGold.text = itemData.buyGold.ToString();
				}
				break;
			case "재료":
				{
					ItemBaseClass.ItemBaseResource itemData = null;
					ItemDataManager.Instance.GetItemDataToResource(_data.Index, out itemData);
					itemImage.sprite = SpriteManager.Instance.GetSpriteResource(_data.Index);
					textName.text = itemData.mainName;
					textBuyGold.text = itemData.buyGold.ToString();
				}
				break;
			default:
				break;
		}
	}
}