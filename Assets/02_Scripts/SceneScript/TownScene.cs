using System.Collections;
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
	[SerializeField] private StageUIManager uiStage;

	private WaitForSeconds fadeOutWait;

	[SerializeField]private GameObject enchantUI;
	[SerializeField]private GameObject smithyUI;
	[SerializeField]private GameObject beautyShopUI;
	[SerializeField]private GameObject guildUI;

	private bool isUIOpen;
	public bool IsUIOpen { get { return isUIOpen; } set { isUIOpen = value; } }

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
		isUIOpen = false;   // 임시로 넣은 코드임
		//isUIOpen = true;	// 나중에 이걸로 구현
	}
	public void OffBeautyShop()
	{
		isUIOpen = false;

	}
	#endregion


	#region EnchantShop=>church
	public void OnOffEnchantShopBtn(bool _isFlag)
	{
		uiBtn[1].gameObject.SetActive(_isFlag);
	}

	public void OnEnchantShop()
	{
		isUIOpen = false;	// 임시로 넣은 코드임
		//isUIOpen = true;	// 나중에 이걸로 구현
	}

	#endregion


	#region Guild
	public void OnOffGuildBtn(bool _isFlag)
	{
		uiBtn[2].gameObject.SetActive(_isFlag);
	}

	public void OnGuild()
	{
		isUIOpen = false;   // 임시로 넣은 코드임
		//isUIOpen = true;	// 나중에 이걸로 구현
	}

	public void OffGuild()
	{
		isUIOpen = false;

	}
	#endregion


	#region Smithy(대장간)
	public void OnOffSmithyBtn(bool _isFlag)
	{
		uiBtn[3].gameObject.SetActive(_isFlag);
	}

	public void OnSmithy()
	{
		isUIOpen = false;   // 임시로 넣은 코드임
		//isUIOpen = true;	// 나중에 이걸로 구현
	}
	public void OffSmithy()
	{
		isUIOpen = false;
	}

	#endregion


	#region Stage
	public void OnOffStageBtn(bool _isFlag)
	{
		uiBtn[4].gameObject.SetActive(_isFlag);
	}

	public void OnStageOpenBtn()
	{
		isUIOpen = true;
		FadeOutGoStageCoroutine();

    }

	public void OnStageCloseBtn()
	{
		isUIOpen = false;
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
		isUIOpen = true;
		StartCoroutine(FadeOutActionCoroutine());

	}
    #endregion


    #endregion

    private IEnumerator FadeOutGoStageCoroutine()
    {
        while (true)
        {
            sceneFade.StartFadeOut(fadeOutTime);
            yield return fadeOutWait;
            SceneManager.LoadScene("04_FieldScene");

            yield break;
        }
    }
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