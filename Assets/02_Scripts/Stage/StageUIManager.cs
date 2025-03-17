using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class StageUIManager : MonoBehaviour
{
	[Header("Settings_Main")]
	[SerializeField] private GameObject stageObject;			// 최상위 오브젝트
	[SerializeField] private GameObject mainStageObject;        // MainStage의 최상위 오브젝트
	[SerializeField] private RectTransform[] mainStageBtnPos;	// TooltipUI를 위해 위치 저장

	[Header("Settings_Sub")]
	[SerializeField] private GameObject subStageObject;		// SubStage의 최상위 오브젝트
	[SerializeField] private GameObject[] subStage;			// 스테이지 낱개
	[SerializeField] private RectTransform[] subStageBtnPos;// TooltipUI를 위해 위치 저장

	[Header("Settings_Description")]
	[SerializeField] private UIStageDescription description;

	[Header("Settings_Tooltip")]
	[SerializeField] private UIStageTooltip stageTooltip;


    TextAsset txtFile; //Jsonfile

    private void Awake()
    {

    }
    #region 홍조코드
    public void StageSelectBtn(int stage) //테마던전 선택 버튼은 Json의 idx값을 넣어야함
	{
        var jsonitemFIle = Resources.Load<TextAsset>($"Json/DungeonList{stage}");
        txtFile = jsonitemFIle;

		int idx = stage - 1; // 매개변수
		//**ui에 표기 코드 쓰기

    }
	public void StageSubSelectBtn(int stage)
	{
		
	}
	public void OnPanel()
	{

	}


    #endregion




    #region Awake Start Update Reset
    // UI Open
    public void OnOpen()
	{
		stageObject.SetActive(true);
		mainStageObject.SetActive(true);

		//List<bool> stageOpenCheck = StageManager.Instance.StageOpenCheck;

		//bool firstCheck, secondCheck;
		//Button targetBtn;

		//for (int i = 0; i < stageOpenCheck.Count; i++)
		//{
		//	targetBtn = subStageBtnPos[i].GetComponent<Button>();
		//	firstCheck = targetBtn.interactable;
		//	secondCheck = stageOpenCheck[i];
		//	if (firstCheck != secondCheck) targetBtn.interactable = secondCheck;
		//	else continue;
		//}

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

	//메인스테이지 버튼 누르면 작용
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
				Debug.Log("세팅된 값이 없습니다.");
				break;
		}
		stageTooltip.gameObject.SetActive(true);
	}

	public void OnMainStageToolTipClose()
	{
		stageTooltip.Close();
	}
	#endregion

	//메인스테이지 클릭->1탄 (1-0) 서브 스테이지가 켜집니다.
	public void OnMainStageBtnClick(int _stageNumber)
	{
        StageClass stageClass = new StageClass();
		stageClass.setStageNum(_stageNumber);


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
				Debug.Log("세팅된 값이 없습니다.");
				break;
		}
		subStageObject.SetActive(true);
	}
	#endregion


	#region [SubStage]

 	public void OnSubStageClick(int _stageArray)
	{
        StageClass stageClass = new StageClass();
		stageClass.setSubNum(_stageArray);


        Debug.Log(stageClass.stageNum);
		Debug.Log(stageClass.subNum);
        StageDataManager.Instance.StageArrayIndex = _stageArray;
		OnSubStageToolTipOpen(_stageArray);
		subStageObject.SetActive(true);
		StageDataManager.Instance.GetStageData(out stageClass);

		description.gameObject.SetActive(true);
		//description.SetSubStageDescription(stageData.description);
		OnSubStageToolTipOpen(_stageArray);
		//Debug.Log(StageManager.Instance.SelectStageText);
	}


	public void OnSubStageToolTipOpen(int _stageArray)
	{
		StageClass stageData = null;
		StageDataManager.Instance.GetStageData(_stageArray, out stageData);
		string str = stageData.dungeonName;
		stageTooltip.Open(ref str, ref subStageBtnPos[_stageArray]);
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


	//로비로 돌아갑니다
	public void OnBackLobby()
	{
		SceneManager.LoadScene("02_LobbyScene");
	}
}