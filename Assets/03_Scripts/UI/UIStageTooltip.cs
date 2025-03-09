using UnityEngine;

/// <summary>
/// ���������� ���콺 �Ǵ� Ŀ���� ������ �� �������� �̹���
/// </summary>
public class UIStageTooltip : MonoBehaviour
{
	[Header("settings")]
	[SerializeField] private GameObject tooltipObj;
	[SerializeField] private TMPro.TextMeshProUGUI text;
	[SerializeField] private RectTransform imageRT;
	[SerializeField] private Vector2 correctionPos;	// ���� ������


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