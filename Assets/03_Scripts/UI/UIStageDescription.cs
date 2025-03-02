using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStageDescription : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]private TMPro.TextMeshProUGUI mainStageText;
	[SerializeField]private TMPro.TextMeshProUGUI staminaText;
	[SerializeField]private TMPro.TextMeshProUGUI subStageText;
	[SerializeField] private TMPro.TextMeshProUGUI descStageText;

	public void SetMainStageDescription(int _stageNumber)
	{
		switch (_stageNumber)
		{
			case 1:
				break;
			case 2:

				break;
			case 3:

				break;
			case 4:

				break;
			case 5:

				break;
			default:
				Debug.Log("세팅된 값이 없습니다.");
				break;
		}
	}


	public void SetSubStageDescription(string _stageNumber)
	{
		string stagemain = "";
		string stagesub = "";
		string stagestemina = "";
		string stagedesc = "";

		int stagestamina;
		int mystamina;

		switch (_stageNumber)
		{
			case "1-1":
				stagemain = "1 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 1;
				mystamina = 1;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "1-2":
				stagemain = "1 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 1;
				mystamina = 2;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "1-3":
				stagemain = "1 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 1;
				mystamina = 3;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "1-4":
				stagemain = "1 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 1;
				mystamina = 4;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "1-5":
				stagemain = "1 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 1;
				mystamina = 5;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;

			case "2-1":
				stagemain = "2 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 2;
				mystamina = 1;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "2-2":
				stagemain = "2 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 2;
				mystamina = 2;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "2-3":
				stagemain = "2 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 2;
				mystamina = 3;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "2-4":
				stagemain = "2 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 2;
				mystamina = 4;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "2-5":
				stagemain = "2 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 2;
				mystamina = 5;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;

			case "3-1":
				stagemain = "3 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 3;
				mystamina = 1;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "3-2":
				stagemain = "3 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 3;
				mystamina = 2;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "3-3":
				stagemain = "3 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 3;
				mystamina = 3;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "3-4":
				stagemain = "3 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 3;
				mystamina = 4;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "3-5":
				stagemain = "3 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 3;
				mystamina = 5;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;

			case "4-1":
				stagemain = "4 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 4;
				mystamina = 1;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "4-2":
				stagemain = "4 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 4;
				mystamina = 2;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "4-3":
				stagemain = "4 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 4;
				mystamina = 3;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "4-4":
				stagemain = "4 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 4;
				mystamina = 4;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "4-5":
				stagemain = "4 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 4;
				mystamina = 5;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;

			case "5-1":
				stagemain = "5 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 5;
				mystamina = 1;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "5-2":
				stagemain = "5 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 5;
				mystamina = 2;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "5-3":
				stagemain = "5 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 5;
				mystamina = 3;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "5-4":
				stagemain = "5 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 5;
				mystamina = 4;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			case "5-5":
				stagemain = "5 Stage";
				stagesub = _stageNumber;
				stagestemina = "";

				stagestamina = 5;
				mystamina = 5;
				stagestemina = stagestamina + "/" + mystamina;

				stagedesc = "description";

				SetText(ref stagemain, ref stagesub, ref stagestemina, ref stagedesc);
				break;
			default:
				break;
		}
	}

	public void OnStageGoBtn()
	{
		SceneManager.LoadScene("04_BattleField");
	}

	private void SetText(ref string _main, ref string _sub, ref string _stam, ref string _desc)
	{
		mainStageText.text = _main;
		subStageText.text = _sub;
		staminaText.text = _stam;
		descStageText.text = _desc;
	}

}