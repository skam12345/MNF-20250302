using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStageTooltip : MonoBehaviour
{
	[Header("settings")]
	[SerializeField] private GameObject tooltipObj;
	[SerializeField] private TMPro.TextMeshProUGUI text;
	[SerializeField] private RectTransform imageRT;
	[SerializeField] private Vector2 correctionPos;	// 보정 포지션


	public void Open(ref string _stageName, ref RectTransform pos)
	{
		imageRT.anchoredPosition = pos.anchoredPosition + correctionPos;

		tooltipObj.SetActive(true);
		text.text = _stageName;
	}

	public void Close()
	{
		tooltipObj.SetActive(false);
		text.text = "";

	}
}