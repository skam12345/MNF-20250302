using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour
{
    [SerializeField] private GameObject clearConversation;
    [SerializeField] private UITextBox textBox;
    [SerializeField] private GameObject clearImg;
    // Start is called before the first frame update
    void Start()
    {
        clearConversation.SetActive(false);
        clearImg.SetActive(false);
        textBox.OnInit("Stage01_Start");
        textBox.PlayText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTouchClearImg()
    {
        
    }
}
