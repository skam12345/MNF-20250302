using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScene : MonoBehaviour
{
    [SerializeField] UITextBox textBox;
    [SerializeField] GameObject conversation;
    // Start is called before the first frame update
    void Start()
    {
        conversation.SetActive(true);
        textBox.OnInit("Opening");
        textBox.PlayText();
    }
}
