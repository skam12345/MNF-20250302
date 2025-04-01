using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopList", menuName = "Scriptable Object/ShopListScriptableObject", order = 0)]
public class ShopToScriptable : ScriptableObject
{
	[Header("Project Create File- Inspector 수정")]
	[Tooltip("구매 아이템 리스트")][SerializeField] private List<ItemBaseClass.ItemData> itemList;

	System.Text.StringBuilder logText;

	
	public override string ToString()
	{
		if (logText == null) logText = new System.Text.StringBuilder();

		logText.Clear();

		for (int i = 0; i < itemList.Count; i++)
		{
			logText.Append("\n "+ i + "번째 아이템 : " + itemList[i].Type + " " + itemList[i].Index);
		}

		return base.ToString();
	}
}