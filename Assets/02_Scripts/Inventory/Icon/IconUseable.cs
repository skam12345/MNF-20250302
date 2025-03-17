using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IconUseable : MonoBehaviour
{
	[SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI count;

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

	public void Refresh(ref ItemBaseClass.ItemBaseUseable _item)
	{
		Debug.Log(_item.ToString());

		if (count.text == "")
		{
			count.text = _item.count.ToString();
		}
		else if (_item.count != int.Parse(count.text))
		{
			count.text = _item.count.ToString();
		}

		Sprite targetSpr = SpriteManager.Instance.GetSpriteUseable(_item.index);
		if (iconImage.sprite != targetSpr)
		{
			iconImage.sprite = targetSpr;
		}
	}
}
