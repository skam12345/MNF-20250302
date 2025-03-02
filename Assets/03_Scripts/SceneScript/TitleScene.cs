using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
	[SerializeField] private SceneForFade sceneFade;

	WaitForSeconds waitForSeconds;
	private enum TITLESCENE_STATE
	{
		FIRST_TEAMLOGO_FADEIN,
		FIRST_TEAMLOGO_WAIT,
		FIRST_TEAMLOGO_FADEOUT,
		
		SECOND_GAMELOGO_FADEIN,
		//SECOND_WAIT_TITLE_LOGO,
		//SECOND_FADEOUT,
		THIRD_GOOGLE_LOGIN,
		
		FOURTH_FILE_CHECK_AND_DOWN,		// 파일 버전 체크 및 다운
		FOURTH_FILE_INSPECTION,			// 다운로드 파일 점검 (유효성 검사)
		FOURTH_FILE_READ,				// 파일 정보 읽기 및 소스코드 매니저 세팅

		FIFTH_PLAY_GAME_TOUCH,			
		LAST_FADEOUT,					
	};
	private TITLESCENE_STATE sceneState = TITLESCENE_STATE.FIRST_TEAMLOGO_FADEIN;


	[SerializeField]private float firstFadeIn;
	[SerializeField]private float firstFadeOut;
	[SerializeField]private float secondFadeIn;
	[SerializeField]private float secondFadeOut;

	[SerializeField] private GameObject[] sceneView;

	private void Start()
	{
		foreach (var item in sceneView)
		{
			item.SetActive(false);
		}
		sceneState = TITLESCENE_STATE.FIRST_TEAMLOGO_FADEIN;
		sceneView[0].SetActive(true);
		StartCoroutine(StartScene());
	}

	// ======== First Logo ========
	private IEnumerator StartScene()
	{
		while (true)
		{
			sceneFade.StartFadeIn(firstFadeIn);
			yield return new WaitForSeconds(firstFadeIn);

			sceneState = TITLESCENE_STATE.FIRST_TEAMLOGO_WAIT;
			yield return new WaitForSeconds(1.0f);

			sceneFade.StartFadeOut(firstFadeOut);
			sceneState = TITLESCENE_STATE.FIRST_TEAMLOGO_FADEOUT;
			yield return new WaitForSeconds(firstFadeOut);
			sceneView[0].SetActive(false);
			sceneView[1].SetActive(true);

			sceneFade.StartFadeIn(secondFadeIn);
			sceneState = TITLESCENE_STATE.SECOND_GAMELOGO_FADEIN;
			yield return new WaitForSeconds(secondFadeIn);

			sceneFade.ResetFadeImage(true, false);
			sceneState = TITLESCENE_STATE.THIRD_GOOGLE_LOGIN;

			//sceneView[1].SetActive(false);

			// 구글 버전 체크 공간<>
			// 버전이 바뀐다면 
			//sceneView[2].SetActive(true);	// Google_version


			sceneView[3].SetActive(true);

			//Debug.Log("End");
			yield break;
		}
	}

	//===========3_Google_download============
	public void OnVersionDownloadOK()
	{
		sceneView[2].SetActive(false);

	}
	public void OnVersionDownloadCancel()
	{
		SaveData();
	}
	//===========


	// ====4_Google+===============
	public void OnGoogleLogIn()
	{
		Debug.Log("google LogIn Button Push");
	}

	public void OnGuestLogIn()
	{
		Debug.Log("guest Login Button Push");
	}


	public void OnLogInOK()
	{
		sceneView[3].SetActive(false);
		sceneView[4].SetActive(true);
	}
	//=======================================


	//===5 FileCheck=============
	public void OnDownloadPathFilesOK()
	{
		sceneView[4].SetActive(false);
		sceneView[5].SetActive(true);
	}

	public void OnDownloadPathFilesCancel()
	{
		SaveData();
	}
	//====================


	//=====6 downloadOK================
	public void OnDownloadOK()
	{
		sceneView[5].SetActive(false);
		sceneView[6].SetActive(true);
	}
	public void OnDownloadCancel()
	{
		SaveData();
	}
	//====================


	// 
	public void OnTitleGoLobby()
	{
		SceneManager.LoadScene("02_LobbyScene");
	}



	private void SaveData()
	{
		//
		//
		//

		Application.Quit();
	}
	// ================
}