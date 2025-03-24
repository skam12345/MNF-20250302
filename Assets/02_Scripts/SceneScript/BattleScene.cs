using UnityEngine;

public class BattleScene : MonoBehaviour
{
	[SerializeField] private GameObject clearConversation;
	[SerializeField] private UITextBox textBox;
	[SerializeField] private GameObject clearImg;
	[SerializeField] private UIMain uiMain;


	[Header("Setting_Point")]
	[SerializeField] private GameObject startPoint;
	[SerializeField] private GameObject endPoint;
	[SerializeField] private GameObject enemyNormalPoint;
	int stageMainNum;
	int stageSubNum;
	[SerializeField] private GameObject[] SkyPlane;

	[Header("Setting_Fade")]
	private SceneForFade fade;
	[SerializeField] private float fadeInTime;
	[SerializeField] private float fadeOutTime;

	private DamageCreator damageCreator;

	private void Awake()
	{



		fade = this.GetComponent<SceneForFade>();

		//스테이지 정보를 확인하고 프리팹 불러오기
        string dungeonType = StageDataManager.Instance.DungeonType();
        stageMainNum = StageDataManager.Instance.stageMainNum;
        stageSubNum = StageDataManager.Instance.stageSubNum;

			//TODO://테스트용
			//stageMainNum++;
			//stageSubNum++;


        dungeonType += ($"{(stageMainNum).ToString()}-{(stageSubNum).ToString()}");
		Debug.Log(dungeonType);



		GameObject map = Resources.Load<GameObject>(ResourcesDirectory.StageMap + dungeonType);
		Instantiate(map,Vector3.zero,Quaternion.identity);
		startPoint = GameObject.Find("StartPos");
		endPoint = GameObject.Find("EndPos");
		//GameObject player = Resources.Load<GameObject>(ResourcesDirectory.PlayerControllerToBattle);
		//GameObject target = Instantiate(player, startPoint.transform.position + Vector3.up, Quaternion.Euler(new Vector3(0,90,0)));
		//inputSystem.PlayerCtrl = target.GetComponent<PlayerControllInBattleField>();

		//damageCreator = GameObject.Find("DamageCreator").GetComponent<DamageCreator>();
	}

	void Start()
	{
		clearConversation.SetActive(false);
		clearImg.SetActive(false);
		textBox.OnInit("Stage01_Start");
		textBox.PlayText();

		uiMain = GameObject.Find("Canvas").transform.Find("UIMain").GetComponent<UIMain>();
		uiMain.OnInGame();


		fade.StartFadeIn(fadeInTime);
	}

}
