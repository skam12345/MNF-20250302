using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IconResource : MonoBehaviour
{
	private Image iconImage;
	private TextMeshProUGUI count;

	UnityAction click;
	public UnityAction ClickAction { set { click = value; } } 

	private void Awake()
	{
		count = transform.Find("countText_TMP").GetComponent<TextMeshProUGUI>();
		iconImage = transform.Find("Image").GetComponent<Image>();
		count.text = "";
	}


	public void OnClick()
	{
		if (click == null) return;
		click.Invoke();
	}

	public void Refresh(ref ItemBaseClass.ItemBaseResource _item)
	{
		if (count.text == "")
		{
			count.text = _item.count.ToString();
		}
		else if (_item.count != int.Parse(count.text))
		{
			count.text = _item.count.ToString();
		}

		Sprite targetSpr = SpriteManager.Instance.GetSpriteResource(_item.index);
		if (iconImage.sprite != targetSpr)
		{
			iconImage.sprite = targetSpr;
		}
	}
}
