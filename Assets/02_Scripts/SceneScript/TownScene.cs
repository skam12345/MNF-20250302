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
	[SerializeField]private GameObject churchUI;
	[SerializeField]private GameObject beautyShopUI;
	[SerializeField]private GameObject shopUI;

	private bool isUIOpen;
	public bool IsUIOpen { get { return isUIOpen; } set { isUIOpen = value; } }

	private PlayerModel playerModel;
	private GameObject player;

    private void Awake()
    {
		//player = GameObject.Find("Player");
  //      playerModel = player.GetComponent<PlayerModel>();
		//Instantiate(playerModel.modelPrefabs[0],player.transform);
    }



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

	}

	#endregion



	#region button Func

	

	#region BeautySalon
	public void OnOffBeautySalonBtn(bool _isFlag)
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


	#region Smithy
	public void OnOffSmithyBtn(bool _isFlag)
	{
		uiBtn[1].gameObject.SetActive(_isFlag);
	}

	public void OnEnchantShop()
	{
		isUIOpen = false;	// 임시로 넣은 코드임
		//isUIOpen = true;	// 나중에 이걸로 구현
	}

	#endregion


	#region Shop
	public void OnOffShopBtn(bool _isFlag)
	{
		uiBtn[2].gameObject.SetActive(_isFlag);
	}

	public void OnShop()
	{
		isUIOpen = false;   // 임시로 넣은 코드임
		//isUIOpen = true;	// 나중에 이걸로 구현
	}

	public void OffShop()
	{
		isUIOpen = false;

	}
	#endregion


	#region Church(교회)
	public void OnOffChurchBtn(bool _isFlag)
	{
		uiBtn[3].gameObject.SetActive(_isFlag);
	}

	public void OnChurch()
	{
		isUIOpen = false;   // 임시로 넣은 코드임
		//isUIOpen = true;	// 나중에 이걸로 구현
	}
	public void OffChurch()
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
		Debug.Log("스테이지오픈 눌렀음");
		isUIOpen = true;
		StartCoroutine(FadeOutGoStageCoroutine());
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
            SceneManager.LoadScene("04_WorldScene");

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