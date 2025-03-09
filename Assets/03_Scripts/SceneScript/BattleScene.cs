using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleScene : MonoBehaviour
{
	[SerializeField] private GameObject clearConversation;
	[SerializeField] private UITextBox textBox;
	[SerializeField] private GameObject clearImg;
	[SerializeField] private UIMain uiMain;



	[Header("Setting_Point")]
	[SerializeField] private InputSystem inputSystem;
	[SerializeField] private GameObject startPoint;
	[SerializeField] private GameObject endPoint;
	[SerializeField] private GameObject enemyNormalPoint;
	int stageArrayNumber;
	[SerializeField] private GameObject[] SkyPlane;

	[Header("Setting_Fade")]
	private SceneForFade fade;
	[SerializeField] private float fadeInTime;
	[SerializeField] private float fadeOutTime;

	private DamageCreator damageCreator;

	private void Awake()
	{
		fade = this.GetComponent<SceneForFade>();
		stageArrayNumber = StageDataManager.Instance.StageArrayIndex;
		string str = "Stage";
		if(stageArrayNumber < 10)
		{
			str += (0).ToString() + (stageArrayNumber + 1);
		}

		GameObject map = Resources.Load<GameObject>(ResourcesDirectory.StageMap + str);
		Instantiate(map,Vector3.zero,Quaternion.identity);

		startPoint = GameObject.Find("StartPos");

		endPoint = GameObject.Find("EndPos");

		GameObject player = Resources.Load<GameObject>(ResourcesDirectory.PlayerController );
		GameObject target = Instantiate(player, startPoint.transform.position + Vector3.up, Quaternion.Euler(new Vector3(0,90,0)));
		inputSystem.PlayerCtrl = target.GetComponent<PlayerControll>();

		damageCreator = GameObject.Find("DamageCreator").GetComponent<DamageCreator>();
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
