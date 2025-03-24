using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniHUDBar : MonoBehaviour
{
    private StateManager stateMgr;

    [SerializeField]
    Image hpFillbar;

    // Start is called before the first frame update
    void Awake()
    {
        stateMgr = this.GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetFillAmount = Mathf.InverseLerp(0, stateMgr.maxhp, stateMgr.hp);

        if (hpFillbar.fillAmount > targetFillAmount)
        {
            hpFillbar.fillAmount -= 3f * Time.deltaTime;
            hpFillbar.fillAmount = Mathf.Max(hpFillbar.fillAmount, targetFillAmount);
        }
    }
}
