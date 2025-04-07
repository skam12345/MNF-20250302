using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//inventory에서 Top을 담당합니다.

public class UIInventoryTop : MonoBehaviour
{
	private List<IconEquipt> usingEquiptItem;

	private List<IconUseable> quickSlot;
	
	

	private void Awake()
	{
		Transform findObject = transform.Find("QuickSlot");
		findObject.Find("Slot1").Find("IconQuickSlot").Find("Numbering_TextTMP").GetComponent<TMPro.TextMeshProUGUI>().text = 1.ToString();
		findObject.Find("Slot2").Find("IconQuickSlot").Find("Numbering_TextTMP").GetComponent<TMPro.TextMeshProUGUI>().text = 2.ToString();
		findObject.Find("Slot3").Find("IconQuickSlot").Find("Numbering_TextTMP").GetComponent<TMPro.TextMeshProUGUI>().text = 3.ToString();
		findObject.Find("Slot4").Find("IconQuickSlot").Find("Numbering_TextTMP").GetComponent<TMPro.TextMeshProUGUI>().text = 4.ToString();
	}
}