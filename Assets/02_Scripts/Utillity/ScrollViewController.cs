using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
	private ScrollRect scrollRect;

	public float space = 50f;

	public GameObject prefabObject;

	public List<RectTransform> uiObjects = new List<RectTransform>();

	private void Awake()
	{
		scrollRect = GetComponent<ScrollRect>();
	}

	public void AddNewUIObject()
	{
		var newUI = Instantiate(prefabObject, scrollRect.content).GetComponent<RectTransform>();
		uiObjects.Add(newUI);

		float y = 0f;
		for (int i = 0; i < uiObjects.Count; i++)
		{
			uiObjects[i].anchoredPosition = new Vector2(0f, -y);
			y += uiObjects[i].sizeDelta.y + space;
		}
		scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, y);
	}

}