using UnityEngine;
using UnityEngine.UI;


// 상점을 열기에 필요한 것 
// SpriteManager Object
// ItemDataManager.Instance.OnInit(); 아이템 정보를 담는 한 줄 (게임 실행시 최초 1회 실행
// InventoryData.Instance.OnInit(); 인벤토리를 활성화 시키는 한 줄(게임 실행시 최초 1회 실행
// 테스트 씬으로 해당 코드의 Start 참고

public class UIShopMain : MonoBehaviour
{
	private GameObject backGroundObject;

	private TMPro.TextMeshProUGUI buyTapText;
	private TMPro.TextMeshProUGUI sellTapText;

	private Button buyButton;
	private Button sellButton;

	[Header("Settings")]
	[SerializeField] private Color selectTabColor;
	[SerializeField] private Color unSelectTabColor;

	private ContentShop buyScrollView;
	private ContentShop sellScrollView;

	private ShopToScriptable shopTable;

	private void Awake()
	{
		backGroundObject = transform.Find("BackGroundImage").gameObject;

		buyButton = backGroundObject.transform.Find("BottomBtn").transform.Find("BuyBtn").GetComponent<Button>();
		sellButton = backGroundObject.transform.Find("BottomBtn").transform.Find("SellBtn").GetComponent<Button>();

		buyTapText = backGroundObject.transform.Find("Tap").transform.Find("BuyTap").transform.Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>();
		sellTapText = backGroundObject.transform.Find("Tap").transform.Find("SellTap").transform.Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>();

		if ( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "09_Shop")
		{
			ItemDataManager.Instance.OnInit();
			InventoryData.Instance.OnInit();
		}

		buyScrollView = transform.Find("BackGroundImage").Find("Left Scroll View").GetComponent<ContentShop>();
		sellScrollView = transform.Find("BackGroundImage").Find("Right Scroll View").GetComponent<ContentShop>();
	}

	private void Start()
	{
		if ( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "09_Shop")
		{
			// 상점을 열려면 이 코드로 열어야 합니다.
			// 45 ~ 50 줄의  if문은 씬 테스트 용 예시입니다.

			OnOff(true, "TestShop");
		}
	}

	public void OnOff(bool _active, string _storeScriptableName)
	{
		backGroundObject.SetActive(_active);
		if (_active == true)
		{
			if (shopTable == null)
			{
				shopTable = Resources.Load<ShopToScriptable>(ResourcesDirectory.ShopScriptable + _storeScriptableName);
				if (shopTable == null)
				{
#if UNITY_EDITOR
					Debug.LogError("상점 이름이 이상합니다. 경로와 이름을 확인 해주세요\n" + "name : " + _storeScriptableName + "\t dir : " + ResourcesDirectory.ShopScriptable);
#endif
				}
			}
			else if (shopTable.name != _storeScriptableName)
			{
				shopTable = Resources.Load<ShopToScriptable>(ResourcesDirectory.ShopScriptable + _storeScriptableName);
				if (shopTable == null)
				{
#if UNITY_EDITOR
					Debug.LogError("상점 이름이 이상합니다. 경로와 이름을 확인 해주세요\n" + "name : " + _storeScriptableName + "\t dir : " + ResourcesDirectory.ShopScriptable);
#endif
				}
			}
		}
	}

	private void RefreshBuyList()
	{

	}

	private void RefreshSellList()
	{

	}

	#region Tab
	public void OnBuyTabClick()
	{
		buyButton.interactable = true;
		buyTapText.color = selectTabColor;

		sellButton.interactable = false;
		sellTapText.color = unSelectTabColor;

		RefreshBuyList();
	}

	public void OnSellTabClick()
	{
		buyButton.interactable = false;
		buyTapText.color = unSelectTabColor;

		sellButton.interactable = true;
		sellTapText.color = selectTabColor;

		RefreshSellList();
	}
	#endregion

	#region Button
	public void OnBuyButton()
	{
		
	}

	public void OnSellButton()
	{
		
	}

	public void OnCloseButton()
	{
		OnOff(false, "");
	}

	public void OnResetButton()
	{

	}
	#endregion

}