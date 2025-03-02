using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCube : MonoBehaviour
{
    [SerializeField] private GameObject clearImg;
    [SerializeField] private BattleScene battleScene;
    [SerializeField] private GameObject clearConversation;
    [SerializeField] private UITextBox textBox;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            StartCoroutine(ClearEvent());
            clearImg.SetActive(true);
        }
    }

    IEnumerator ClearEvent()
    {
        yield return new WaitForSeconds(3.0f);
        clearImg.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        clearConversation.SetActive(true);
        textBox.OnInit("Stage01_Clear");
        textBox.PlayText();
    }
}
