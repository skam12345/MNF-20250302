using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStage : MonoBehaviour
{
	[Header("Settings_Main")]
	[SerializeField] private GameObject stageObject;			// �ֻ��� ������Ʈ
	[SerializeField] private GameObject mainStageObject;        // MainStage�� �ֻ��� ������Ʈ
	[SerializeField] private RectTransform[] mainStageBtnPos;	// TooltipUI�� ���� ��ġ ����

	[Header("Settings_Sub")]
	[SerializeField] private GameObject subStageObject;		// SubStage�� �ֻ��� ������Ʈ
	[SerializeField] private GameObject[] subStage;			// �������� ����
	[SerializeField] private RectTransform[] subStageBtnPos;// TooltipUI�� ���� ��ġ ����

	[Header("Settings_Description")]
	[SerializeField] private UIStageDescription description;

	[Header("Settings_Tooltip")]
	[SerializeField] private UIStageTooltip stageTooltip;
	#region Awake Start Update Reset
	
	// UI Open
	public void OnOpen()
	{
		stageObject.SetActive(true);
		mainStageObject.SetActive(true);
	}

	// UIClose
	public void OnReset()
	{
		stageObject.gameObject.SetActive(false);
		mainStageObject.SetActive(true);
		subStageObject.SetActive(false);
		description.gameObject.SetActive(false);
		foreach (var sub in subStage)
		{
			sub.SetActive(false);
		}
		stageTooltip.gameObject.SetActive(false);

	}
	#endregion


	#region [MainStage] 

	#region mainStage ToolTip
	public void OnMainStageToolTipOpen(int _stageNumber)
	{
		string testString = "";
		switch (_stageNumber)
		{
			case 1:
				testString = "1_stage";
				stageTooltip.Open(ref testString, ref mainStageBtnPos[0]);
				break;
			case 2:
				testString = "2_stage";
				stageTooltip.Open(ref testString, ref mainStageBtnPos[1]);
				break;
			case 3:
				testString = "3_stage";
				stageTooltip.Open(ref testString, ref mainStageBtnPos[2]);
				break;
			case 4:
				testString = "4_stage";
				stageTooltip.Open(ref testString, ref mainStageBtnPos[3]);
				break;
			case 5:
				testString = "5_stage";
				stageTooltip.Open(ref testString, ref mainStageBtnPos[4]);
				break;
			default:
				Debug.Log("���õ� ���� �����ϴ�.");
				break;
		}
		stageTooltip.gameObject.SetActive(true);
	}

	public void OnMainStageToolTipClose()
	{
		stageTooltip.Close();
	}
	#endregion


	public void OnMainStageBtnClick(int _stageNumber)
	{
		// Click MainStage

		foreach (var item in subStage)
		{
			if(item.activeSelf == true)
				item.gameObject.SetActive(false);
		}
		switch (_stageNumber)
		{
			case 1: subStage[0].SetActive(true); break;
			case 2: subStage[1].SetActive(true); break;
			case 3: subStage[2].SetActive(true); break;
			case 4: subStage[3].SetActive(true); break;
			case 5: subStage[4].SetActive(true); break;
			default:
				Debug.Log("���õ� ���� �����ϴ�.");
				break;
		}
		subStageObject.SetActive(true);
	}
	#endregion


	#region [SubStage]
	// PC
	// 1. ���콺�� ������ ���� ����
	// 2. ���콺�� ����� ���� ����
	// 3. ���콺�� Ŭ���ϸ� ���� ���� �� ����
	// 4. ���콺�� ����� Ŭ���ϸ� ���� OFF

	// Mob
	// 1�� ��� ���� �Ұ�
	// 2�� ��� ���� �Ұ�
	// 3�� ��� ���� �������� �̸� �����ְ� ����� ����
	// 4�� �Ȱ��� ����

	// Enter SubStage
	public void OnSubStageClick(string _stageNumber)
	{
		subStageObject.SetActive(true);
		//if (description.gameObject.activeSelf == true) return;

		description.gameObject.SetActive(true);
		description.SetSubStageDescription(_stageNumber);

		//StageManager.Instance.SetStageValue(_stageNumber);

		//switch (_stageNumber)
		//{
		//	case "1-1":
			
		//		break;
		//	case "1-2":

		//		break;
		//	case "1-3":

		//		break;
		//	case "1-4":

		//		break;
		//	case "1-5":

		//		break;

		//	case "2-1":

		//		break;
		//	case "2-2":

		//		break;
		//	case "2-3":

		//		break;
		//	case "2-4":

		//		break;
		//	case "2-5":

		//		break;

		//	case "3-1":

		//		break;
		//	case "3-2":

		//		break;
		//	case "3-3":

		//		break;
		//	case "3-4":

		//		break;
		//	case "3-5":

		//		break;

		//	case "4-1":

		//		break;
		//	case "4-2":

		//		break;
		//	case "4-3":

		//		break;
		//	case "4-4":

		//		break;
		//	case "4-5":

		//		break;

		//	case "5-1":

		//		break;
		//	case "5-2":

		//		break;
		//	case "5-3":

		//		break;
		//	case "5-4":

		//		break;
		//	case "5-5":

		//		break;
		//	default:
		//		break;
		//}
	}

	public void OnSubStageToolTipOpen(string _stageName)
	{
		string str = _stageName;
		
		description.SetSubStageDescription(_stageName);
		switch (_stageName)
		{
			case "1-1":
				stageTooltip.Open(ref str, ref subStageBtnPos[0]);
				break;
			case "1-2":
				stageTooltip.Open(ref str, ref subStageBtnPos[1]);

				break;
			case "1-3":
				stageTooltip.Open(ref str, ref subStageBtnPos[2]);

				break;
			case "1-4":
				stageTooltip.Open(ref str, ref subStageBtnPos[3]);

				break;
			case "1-5":
				stageTooltip.Open(ref str, ref subStageBtnPos[4]);

				break;

			case "2-1":
				stageTooltip.Open(ref str, ref subStageBtnPos[5]);

				break;
			case "2-2":
				stageTooltip.Open(ref str, ref subStageBtnPos[6]);

				break;
			case "2-3":
				stageTooltip.Open(ref str, ref subStageBtnPos[7]);

				break;
			case "2-4":
				stageTooltip.Open(ref str, ref subStageBtnPos[8]);

				break;
			case "2-5":
				stageTooltip.Open(ref str, ref subStageBtnPos[9]);

				break;

			case "3-1":
				stageTooltip.Open(ref str, ref subStageBtnPos[10]);

				break;
			case "3-2":
				stageTooltip.Open(ref str, ref subStageBtnPos[11]);

				break;
			case "3-3":
				stageTooltip.Open(ref str, ref subStageBtnPos[12]);

				break;
			case "3-4":
				stageTooltip.Open(ref str, ref subStageBtnPos[13]);

				break;
			case "3-5":
				stageTooltip.Open(ref str, ref subStageBtnPos[14]);

				break;

			case "4-1":
				stageTooltip.Open(ref str, ref subStageBtnPos[15]);

				break;
			case "4-2":
				stageTooltip.Open(ref str, ref subStageBtnPos[16]);

				break;
			case "4-3":
				stageTooltip.Open(ref str, ref subStageBtnPos[17]);

				break;
			case "4-4":
				stageTooltip.Open(ref str, ref subStageBtnPos[18]);

				break;
			case "4-5":
				stageTooltip.Open(ref str, ref subStageBtnPos[19]);

				break;

			case "5-1":
				stageTooltip.Open(ref str, ref subStageBtnPos[20]);

				break;
			case "5-2":
				stageTooltip.Open(ref str, ref subStageBtnPos[21]);

				break;
			case "5-3":
				stageTooltip.Open(ref str, ref subStageBtnPos[22]);

				break;
			case "5-4":
				stageTooltip.Open(ref str, ref subStageBtnPos[23]);

				break;
			case "5-5":
				stageTooltip.Open(ref str, ref subStageBtnPos[24]);

				break;
			default:
				break;
		}
		stageTooltip.gameObject.SetActive(true);
	}


	public void OnSubStageToolTipClose()
	{
		//description.gameObject.SetActive(false);
		stageTooltip.gameObject.SetActive(false);
	}


	#endregion

	public void OnBackMainStage()
	{
		subStageObject.SetActive(false);
		description.gameObject.SetActive(false);
		foreach (var item in subStage)
		{
			item.SetActive(false);
		}
	}

	public void OnBackLobby()
	{
		SceneManager.LoadScene("02_LobbyScene");
	}
}