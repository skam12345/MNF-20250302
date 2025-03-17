using UnityEngine;
using TMPro;

public class UIStatus : MonoBehaviour
{
	[Header("First_Object")]
	[SerializeField] private GameObject uiStatus;

	[Header("Status_Value")]

	[SerializeField] private TextMeshProUGUI statusValueExp;
	[SerializeField] private TextMeshProUGUI statusValueHP;
	[SerializeField] private TextMeshProUGUI statusValueMP;
	[SerializeField] private TextMeshProUGUI statusValueAtk;
	[SerializeField] private TextMeshProUGUI statusValueLuck;

	[Header("Elents_Value")]
	[SerializeField] private TextMeshProUGUI elementValueHoly;
	[SerializeField] private TextMeshProUGUI elementValueDark;
	[SerializeField] private TextMeshProUGUI elementValueFire;
	[SerializeField] private TextMeshProUGUI elementValueIce;
	[SerializeField] private TextMeshProUGUI elementValueErath;
	[SerializeField] private TextMeshProUGUI elementValueNature;

	public void OnUIStatus()
	{
		uiStatus.SetActive(true);
	}

	public void OffUIStatus()
	{
		uiStatus.SetActive(false);
	}

}