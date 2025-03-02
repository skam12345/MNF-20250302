using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScene : MonoBehaviour
{
	[SerializeField] private SceneForFade sceneFade;

	// Setting
	[Header("SceneSettings_Fade")]
	[SerializeField] private float fadeInTime;
	[SerializeField] private float fadeOutTime;


	[Header("Setting_LobbyUI")]
	[SerializeField] private GameObject uiQuitBox;

	[SerializeField] private GameObject buddyWindow;


	[SerializeField] private UnityEngine.UI.Button btnTown;
	[SerializeField] private UnityEngine.UI.Button btnOption;
	[SerializeField] private UnityEngine.UI.Button btnQuit;
	[SerializeField] private UnityEngine.UI.Button stageBackBtn;

	[Header("Setting_Script")]
	[SerializeField] private UIOption uiOption;
	[SerializeField] private UIStage uiStage;
	[SerializeField] private UITextBox textBox;

	private WaitForSeconds fadeOutWait;



	#region Awake Start Update Reset
	private void Start()
	{
		
		if (fadeOutWait == null) fadeOutWait = new WaitForSeconds(fadeOutTime);

		stageBackBtn.onClick.RemoveAllListeners();
		stageBackBtn.onClick.AddListener(delegate { uiStage.OnReset(); });


		OnReset();
		sceneFade.StartFadeIn(fadeInTime);

		textBox.OnInit("Lobby01");
		textBox.PlayText();
	}


	/// <summary>
	/// 로비씬을 초기 상태로 돌립니다.
	/// </summary>
	private void OnReset()
	{
		uiOption.OnReset();
		uiStage.OnReset();

		//======== Stage Reset
		uiQuitBox.SetActive(false);
		uiOption.gameObject.SetActive(false);
		buddyWindow.SetActive(false);

		btnOption.interactable = true;
		btnTown.interactable = true;
		btnQuit.interactable = true;

		//=========

	}

	#endregion

	#region button Functions
	public void OnGoAdventure()
	{
		uiStage.OnOpen();
	}

	

	public void OnGoTown()
	{
		btnTown.interactable = false;
		StartCoroutine(FadeOutActionGoTown());
		//textBox.OnOffTextBox(true);
	}

	public void OnQuestView()
	{

	}

	public void OnInventory()
	{

	}

	#region BuddyWindow
	public void OnOpenBuddyWindow()
	{
		buddyWindow.SetActive(true);
	}

	public void OnSelectBuddy(int _index)
	{
		//StageManager.Instance.Select(_index);
	}

	public void OnCloseBuddyWindow()
	{
		buddyWindow.SetActive(false);
	}
	#endregion 

	#region Option Func
	public void OnOpenOption()
	{
		Debug.Log("test debug : OnOpenQuitBox()");

		uiOption.gameObject.SetActive(true);
		btnOption.interactable = false;
	}

	public void OnCloseOption(bool _isFlag)
	{
		switch (_isFlag)
		{
			case true: // save
				uiOption.OnSaveButton();
				break;
			case false: // cancel
				uiOption.OnCancelButton();
				break;
		}
		btnOption.interactable = true;
		uiOption.gameObject.SetActive(false);
	}
	#endregion

	#region QuitMessageBox Func
	public void OnCloseQuitBox()
	{
		btnQuit.interactable = true;
		uiQuitBox.SetActive(false);
	}

	public void OnOpenQuitBox()
	{
		btnQuit.interactable = false;
		uiQuitBox.SetActive(true);
	}

	public void OnQuit()
	{
		Application.Quit();
	}
	#endregion

	#endregion



	private IEnumerator FadeOutActionGoTown()
	{
		while (true)
		{
			sceneFade.StartFadeOut(fadeOutTime);
			yield return fadeOutWait;
			SceneManager.LoadScene("03_TownScene");

			yield break;
		}
	}
}