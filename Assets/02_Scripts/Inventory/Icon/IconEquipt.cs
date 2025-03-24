using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IconEquipt : MonoBehaviour
{
	 private Image iconImage;
	 private TextMeshProUGUI upgateText;

	UnityAction click;
	public UnityAction ClickAction { set { click = value; } }

	private void Awake()
	{
		upgateText = transform.Find("UpgradeText_TMP").GetComponent<TextMeshProUGUI>();
		iconImage = transform.Find("Image").GetComponent<Image>();
		upgateText.text = "";
	}

	public void OnClick()
	{
		if (click == null) return;
		click.Invoke();
	}


	public void Refresh(ref ItemBaseClass.ItemBaseEquipment _item)
	{
		if( upgateText.text == "")
		{
			upgateText.text = _item.grade.ToString();
		}
		else if (_item.grade != int.Parse(upgateText.text))
		{
			upgateText.text = _item.grade.ToString();
		}

		Sprite targetSpr = SpriteManager.Instance.GetSpriteUseable(_item.index);
		if (iconImage.sprite != targetSpr)
		{
			iconImage.sprite = targetSpr;
		}
	}
}