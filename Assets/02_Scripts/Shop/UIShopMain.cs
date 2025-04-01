using UnityEngine;
using UnityEngine.UI;



public class UIShopMain : MonoBehaviour
{
	private GameObject backGroundObject;

	private TMPro.TextMeshProUGUI buyTapText;
	private TMPro.TextMeshProUGUI sellTapText;

	private Button buyButton;
	private Button sellButton;

	// 유동적인 상점을 원한다면 여기를 리스트로 바꾸고 Awake에서 다 불러 온 뒤 
	// 상점 이름에 맞게 세팅하면 됨
	// 지금은 고정적인 상점
	private ShopToScriptable shopTable;

	

	[Header("Settings")]
	[SerializeField] private Color selectTabColor;
	[SerializeField] private Color unSelectTabColor;


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
	}

	private void Start()
	{
		if ( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "09_Shop")
		{
			OnOff(true, "TestShop");
		}
	}

	public void OnOff(bool _active, string _storeScriptableName)
	{
		backGroundObject.SetActive(_active);
		if( shopTable == null)
		{
			shopTable = Resources.Load<ShopToScriptable>(ResourcesDirectory.ShopScriptable + _storeScriptableName);
		}
		if ( _active == true)
		{
			RefreshBuyList();
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
		buyButton.gameObject.SetActive(true);
		buyTapText.color = selectTabColor;

		sellButton.gameObject.SetActive(false);
		sellTapText.color = unSelectTabColor;

		RefreshBuyList();
	}

	public void OnSellTabClick()
	{
		buyButton.gameObject.SetActive(false);
		buyTapText.color = unSelectTabColor;

		sellButton.gameObject.SetActive(true);
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

	}

	public void OnResetButton()
	{

	}
	#endregion

}