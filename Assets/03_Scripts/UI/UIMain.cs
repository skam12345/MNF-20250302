using UnityEngine;

public class UIMain : MonoBehaviour
{
	public GameObject uiInGame;
	public GameObject uiEscMenu;

	public void OnInGame()
	{
		uiInGame.SetActive(true);
		uiEscMenu.SetActive(false);
	}

	public void OnEscMenu()
	{
		uiInGame.SetActive(false);
		uiEscMenu.SetActive(true);
	}


}