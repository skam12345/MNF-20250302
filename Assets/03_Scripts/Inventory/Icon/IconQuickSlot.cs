using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor.Localization.Plugins.XLIFF.V12;

public class IconQuickSlot : MonoBehaviour
{
	int slotNumber;

	private ItemBaseClass.ItemData data;
	
	[SerializeField] private Image iconImage;
	[SerializeField] private TextMeshProUGUI itemCount;

	UnityAction click;
	public UnityAction ClickAction { set { click = value; } }

	private void Awake()
	{
		itemCount = transform.Find("Count_TextTMP").GetComponent<TextMeshProUGUI>();
		iconImage = transform.Find("Image").GetComponent<Image>();
		itemCount.text = "";
	}


	public void OnClick()
	{
		if (click == null) return;
		click.Invoke();
	}

	public void Refresh(ref ItemBaseClass.ItemData _item)
	{
		Sprite targetSpr = null;

		switch (_item.Type)
		{
			case "장비":
				{
					ItemBaseClass.ItemBaseEquipment equiptData = null;
					InventoryData.Instance.GetInventorySlotEquip(_item.Index, out equiptData);
					targetSpr = SpriteManager.Instance.GetSpriteEquipt(equiptData.index);

					if (equiptData.grade != int.Parse(itemCount.text))
					{
						itemCount.text = equiptData.grade.ToString();
					}

					if (iconImage.sprite != targetSpr)
					{
						iconImage.sprite = targetSpr;
					}
				}
				break;
			case "소모품":
				{
					ItemBaseClass.ItemBaseUseable useableData = null;
					InventoryData.Instance.GetInventorySlotUseable(_item.Index, out useableData);
					targetSpr = SpriteManager.Instance.GetSpriteUseable(useableData.index);

					if (useableData.count != int.Parse(itemCount.text))
					{
						itemCount.text = useableData.count.ToString();
					}

					if (iconImage.sprite != targetSpr)
					{
						iconImage.sprite = targetSpr;
					}
				}
				break;
			case "재료":
				{
					ItemBaseClass.ItemBaseResource resourceData = null;
					InventoryData.Instance.GetInventorySlotResource(_item.Index, out resourceData);
					targetSpr = SpriteManager.Instance.GetSpriteEquipt(resourceData.index);

					if (resourceData.count != int.Parse(itemCount.text))
					{
						itemCount.text = resourceData.count.ToString();
					}

					if (iconImage.sprite != targetSpr)
					{
						iconImage.sprite = targetSpr;
					}
				}
				break;
		}
	}
}