using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//여기 클래스 여러개해서 가져오기


public class StateManager : MonoBehaviour
{
    //여기는 현재플레이어 스탯이다. 이걸 부착된 자식 객체의 클래스에서 가져온다.
    //스왑 시 Class에서 변환한다. , 예외상황은 캐릭터가 죽으면 스왑안되게.
    //하나가 죽으면 다른애가 자동으로 나오게


    // 플레이어의 스텟!!!!
    public int lv;
    public int curExp;

    public float maxhp;
    public float hp;
    public int atk;
    [Space(10)]
    [Range(0, 100)]
    public int criChance = 50; //in percentage
    public float criDamage = 1.5f;



    PlayerDataClass playerdata;




    [HideInInspector]
    public HUDManager hudManager;
    //public AttackController atkctrl;


    private void Start()
    {
        //atkctrl = GetComponentInChildren<AttackController>();
        hudManager = gameObject.GetComponent<HUDManager>();
    }


    #region 대미지 계산식######
    //공격력 30 100%
    // 스킬공 60 200 %= 200 / 100
    //내가 float값에 200 넣어서 60 딜이 나오려면
    //30 x 200 x n = 60
    //200n = 2
    //100n = 1
    //n = 0.01
    // 따라서 공격력 x 스킬대미지 x 0.01f 해야 퍼센트대미지가 나온다!
    // skillDMG는 기본적으로 100 줘야함
    /// atk * ( skillDMG * 0.01f); 를 하면, 150%로 줬을 때, 1.5배의 대미지가 들어간다!

    #endregion

    public void DealDamage(GameObject target,float skillDMG )//딜 계산, 105% 느낌으로 할 것!
    {
        Color popupColorsend = Color.white;
        var monster = target.GetComponent<StateManager>();
        if (monster != null)
        {
            float totalDamage = atk * (skillDMG * Random.Range(0.01f, 0.012f));
            if (Random.Range(0f, 100f) <= criChance)
            {
                totalDamage *= criDamage* 0.01f;
                popupColorsend = Color.yellow;
            }

            monster.TakeDamage((int)totalDamage,popupColorsend);
        }
    }
    public void TakeDamage(int hit,Color popupColor) // 딜 팝업
    {
        hp -= hit;
        Vector3 randomness = new Vector3(Random.Range(-0.45f, 0.45f), Random.Range(-0.45f, 0.45f), Random.Range(0f, 0.25f));
        // hit - (hit*def/100)

        DamagePopUpGenerator.current.CreatePopup(transform.position + randomness, hit.ToString(), popupColor);
        hudManager.ChangeUserHUD();

    }
}
