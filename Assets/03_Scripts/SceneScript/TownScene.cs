using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TownScene : MonoBehaviour
{

	[Header("Setting_UI")]
	[SerializeField] private Button[] uiBtn;
	[SerializeField] private Button stageBackBtn;

	[Header("Setting Fade")]
	[SerializeField] private float fadeInTime;
	[SerializeField] private float fadeOutTime;

	[Header("Setting Script")]
	[SerializeField] private SceneForFade sceneFade;
	[SerializeField] private UIStage uiStage;

	private WaitForSeconds fadeOutWait;

	#region Awake Start Update
	private void Start()
	{
		foreach (var btn in uiBtn)
		{
			btn.gameObject.SetActive(false);
		//	btn.interactable = true;
		}

		if(fadeOutWait == null) fadeOutWait = new WaitForSeconds(fadeOutTime);

		uiBtn[5].interactable = true;
		uiStage.OnReset();
		sceneFade.StartFadeIn(fadeInTime);
		stageBackBtn.onClick.RemoveAllListeners();
		stageBackBtn.onClick.AddListener(OnStageCloseBtn);
	}

	#endregion


	#region button Func

	#region BeautyShop
	public void OnOffBeautyShopBtn(bool _isFlag)
	{
		uiBtn[0].gameObject.SetActive(_isFlag);
	}

	public void OnBeautyShop()
	{

	}

	#endregion



	#region EnchantShop
	public void OnOffEnchantShopBtn(bool _isFlag)
	{
		uiBtn[1].gameObject.SetActive(_isFlag);
	}

	public void OnEnchantShop()
	{

	}
	#endregion


	#region Guild
	public void OnOffGuildBtn(bool _isFlag)
	{
		uiBtn[2].gameObject.SetActive(_isFlag);
	}

	public void OnGuild()
	{

	}
	#endregion


	#region Smithy
	public void OnOffSmithyBtn(bool _isFlag)
	{
		uiBtn[3].gameObject.SetActive(_isFlag);
	}

	public void OnSmithy()
	{

	}

	#endregion


	#region Stage
	public void OnOffStageBtn(bool _isFlag)
	{
		uiBtn[4].gameObject.SetActive(_isFlag);
	}

	public void OnStageOpenBtn()
	{
		uiStage.OnOpen();
	}

	public void OnStageCloseBtn()
	{
		uiStage.OnReset();
	}

	#endregion


	#region Lobby
	public void OnOffLobbyBtn(bool _isFlag)
	{
		uiBtn[5].gameObject.SetActive(_isFlag);
	}

	public void OnGoLobby()
	{
		uiBtn[5].interactable = false;  // 버튼 비활성화
		StartCoroutine(FadeOutActionCoroutine());
	}
	#endregion


	#endregion


	private IEnumerator FadeOutActionCoroutine()
	{
		while (true)
		{
			sceneFade.StartFadeOut(fadeOutTime);
			yield return fadeOutWait;
			SceneManager.LoadScene("02_LobbyScene");

			yield break;
		}
	}
}