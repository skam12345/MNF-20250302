using UnityEngine;

/// <summary>
/// 스테이지에 마우스 또는 커서가 들어왔을 때 보여지는 이미지
/// </summary>
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