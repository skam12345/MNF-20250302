using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField] private SceneForFade sceneForFade;
    [SerializeField] private GameObject background;
    
    public void OpenShop(bool apear)
    {
        if(apear)
        {
            OnBeforeAPearFadeInShopUI();
        }
    }

    public void OnBeforeAPearFadeInShopUI()
    {
        StartCoroutine(FirstFadeInOutAfterOpenShopUI());
    }

    IEnumerator FirstFadeInOutAfterOpenShopUI()
    {
        sceneForFade.StartFadeOut(1.0f);
        yield return new WaitForSeconds(0.5f);
        background.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sceneForFade.StartFadeIn(1.0f);


    }
}
