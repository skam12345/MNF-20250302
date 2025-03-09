using UnityEngine;

public class BattleScene : MonoBehaviour
{
    [SerializeField] private GameObject clearConversation;
    [SerializeField] private UITextBox textBox;
    [SerializeField] private GameObject clearImg;
    [SerializeField] private UIMain uiMain;

    // Start is called before the first frame update
    void Start()
    {
        clearConversation.SetActive(false);
        clearImg.SetActive(false);
        textBox.OnInit("Stage01_Start");
        textBox.PlayText();

        uiMain = GameObject.Find("Canvas").transform.Find("UIMain").GetComponent<UIMain>();
        uiMain.OnInGame();
	}

}
