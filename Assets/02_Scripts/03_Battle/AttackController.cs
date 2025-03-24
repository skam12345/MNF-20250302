using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public WeaponAttribute wepon;
    private Animator anim;
    private PlayerControllInBattleField charmove;
    public Transform cameraTransform;
    public Transform fireTransform;

    [Space(5)]
    [TextArea(3, 10)]
    public string memo = "5-더미 / 6-손거리/ 7-자신위치/ 8-궁극기";

    public GameObject[] autoObject;
    public GameObject[] skillObject;
    public float arrowpower = 25f;


    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !charmove.isHold)
        {
            //charmove.isHold = true;
            anim.SetTrigger("Attack");
        }



        if (Input.GetKeyDown(KeyCode.Q) && !charmove.isHold)
        {
            anim.SetTrigger("Skill_Q");
        }


        if (Input.GetKeyDown(KeyCode.E) && !charmove.isHold)
        {
            anim.SetTrigger("Skill_E");

        }


        }
    void Awake()
    {
        anim = GetComponent<Animator>();
        charmove = GetComponentInParent<PlayerControllInBattleField>();
        Vector3 newPosition = transform.parent.position + transform.parent.forward;
    }


    public void OnAttack()
    {
        charmove.isHold = true;
    }
    public void OffAttack()
    {
        charmove.isHold = false;
    }




    public void SkillEffect1()
    {
        float distanceUpper = 1.0f;
        float distanceForward = 0.0f;
        Vector3 spawnPosition = transform.position + transform.forward* distanceForward + transform.up* distanceUpper;
        Instantiate(autoObject[1], spawnPosition, transform.parent.rotation);
        autoObject[1].GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();
    }
    public void SkillEffect2()
    {
        float distanceUpper = 0.5f;
        float distanceForward = 2.0f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        Instantiate(autoObject[2], spawnPosition, transform.parent.rotation);
        autoObject[2].GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();
    }
    public void SkillEffect3() //  스킬
    {
        float distanceUpper = 0.5f;
        float distanceForward = 3.0f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        Instantiate(autoObject[3], spawnPosition, transform.parent.rotation);
        autoObject[3].GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();

    }
    public void SkillEffect4()
    {
        float distanceUpper = 0.5f;
        float distanceForward = 4.0f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        Instantiate(autoObject[4], spawnPosition, transform.parent.rotation);
        autoObject[4].GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();

    }
    public void SkillEffect5() //더미
    {
        float distanceUpper = Random.Range(0.2f, 0.7f);
        float distanceForward = Random.Range(2.5f, 3.5f);
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        Instantiate(autoObject[5], spawnPosition, transform.parent.rotation);
        autoObject[5].GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();

    }


    public void SkillEffect_Shield() // 마법진 0번
    {
        float distanceUpper = 0f;
        float distanceForward = 1f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        Instantiate(autoObject[0], spawnPosition, transform.parent.rotation);
        autoObject[0].GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();
    }
    public void SkillEffect_Buff() // 버프스킬
    {
        float distanceUpper = 0f;
        float distanceForward = 0f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        Instantiate(skillObject[0], spawnPosition, transform.parent.rotation);
    }

    public void Skill_FlyObject() // 하늘로 미사일 날림 핵같은거
    {
        float distanceUpper = 0.5f;
        float distanceForward = 0.5f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        GameObject arrow = Instantiate(autoObject[1], spawnPosition, transform.parent.rotation);
        arrow.GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();
        arrow.GetComponent<Rigidbody>().velocity = Vector3.up * 25f;
    }
    public void SkillEffect_BackMove()
    {
        transform.parent.Translate(0, 0, -5);
        float distanceUpper = 1.0f;
        float distanceForward = 0.0f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        Instantiate(skillObject[1], spawnPosition, transform.parent.rotation);
        skillObject[1].GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();
    } // 뒤로가면서 스킬씀
    public void SkillEffect_AutoMissile() // 미사일 만듬
    {
        StartCoroutine(MissileLoad());
    }
    IEnumerator MissileLoad()
    {

        float distanceUpper = 4.5f;
        float distanceForward = 1f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-1f, 1f), 0);
            GameObject arrow = Instantiate(autoObject[2], spawnPosition + randomOffset, transform.parent.rotation);

            arrow.GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();
        }
    }

    public void SlashEffect1()
    {

        float distanceUpper = 1f;
        float distanceForward = 0f;
        Vector3 spawnPosition = (transform.position ) + transform.forward * distanceForward + transform.up * distanceUpper;
        GameObject slash2 = Instantiate(skillObject[1], spawnPosition, Quaternion.identity);
        slash2.transform.rotation = transform.parent.rotation  * Quaternion.Euler(0, 0, 90);
    }
    public void SlashEffect2()
    {
        float distanceUpper = 1f;
        float distanceForward = 0f;
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        GameObject slash2 = Instantiate(skillObject[1], spawnPosition, Quaternion.identity);
        slash2.transform.rotation = transform.parent.rotation  * Quaternion.Euler(0, 0, 27);
    }
    public void SlashEffect3()
    {
        float distanceUpper = 1f;
        float distanceForward = 0f;
        Vector3 spawnPosition = (transform.position ) + transform.forward * distanceForward + transform.up * distanceUpper;
        GameObject slash3 = Instantiate(skillObject[1], spawnPosition, Quaternion.identity);
        slash3.transform.rotation = transform.parent.rotation  * Quaternion.Euler(20, 0, 180);
    }
    public void SlashEffect4()
    {

        float distanceUpper = 1f;
        float distanceForward = 0f;
        Vector3 spawnPosition = (transform.position ) + transform.forward * distanceForward + transform.up * distanceUpper;
        GameObject slash4 = Instantiate(skillObject[1], spawnPosition, Quaternion.identity);
        //slash4.transform.rotation = Quaternion.Euler(0, 0, 27);
    }

    public void SkillEffect_Ultimate()
    {
        //코루틴 돌려서 컷신?
        float distanceUpper = Random.Range(0.2f, 0.7f);
        float distanceForward = Random.Range(2.5f, 3.5f);
        Vector3 spawnPosition = transform.position + transform.forward * distanceForward + transform.up * distanceUpper;
        Instantiate(autoObject[8], spawnPosition, transform.parent.rotation);
        autoObject[8].GetComponent<WeaponAttribute>().playerMgr = transform.parent.GetComponent<StateManager>();
    }
}


