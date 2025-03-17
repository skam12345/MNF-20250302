using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public StateManager mainState;
    public Animator playeranim;
    public Transform lookedcam;
    public bool onMove = false;

    public AimBehaviourBasicA aimOn; //화살용

    public bool isHold = false;

    public float moveSpeed = 2f;
    public float runSpeed = 8f;
    public float totalSpeed;
    public float rotSpeed = 120f;
    private Vector3 moveDir;

    public int heroIndex;
    public GameObject changeEffect;

    [HideInInspector]
    //public HUDManager hudManager;
    //public AttackController atkctrl;

    //점프용
    public float jumpForce = 7f;
    private Rigidbody rb;
    public bool isGrounded = true;


    void Start()
    {
        totalSpeed = moveSpeed;
        heroIndex = 1; //TODO: 나중에 스토리로 설정하기
        playeranim = transform.GetChild(heroIndex).GetComponent<Animator>(); 
        //atkctrl = GetComponentInChildren<AttackController>();
        aimOn = GetComponent<AimBehaviourBasicA>(); //화살용
        mainState = GetComponent<StateManager>();
       // hudManager = gameObject.GetComponent<HUDManager>();
        //GetCharacterState();

        //점프용
        rb = GetComponent<Rigidbody>();

    }
    public void HeroChange(int changeHeroNum)
    {
        //SetCharacterState();
        Transform beforeHero = transform.GetChild(heroIndex);
        beforeHero.gameObject.SetActive(false);
        heroIndex = changeHeroNum;
        playeranim = transform.GetChild(heroIndex).GetComponent<Animator>();
        transform.GetChild(heroIndex).gameObject.SetActive(true);
        //TODO: 이 때, GetChild가 가진 class에 있는 스텟값 init하기!!
        //GetCharacterState();
        //hudManager.InitHP();
    }

    //public void SetCharacterState()
    //{
    //    //ClassState charState = transform.GetChild(heroIndex).GetComponent<ClassState>();
    //    charState.lv = mainState.lv;
    //    charState.curExp = mainState.curExp;
    //    charState.maxhp = mainState.maxhp;
    //    charState.hp = mainState.hp;
    //    charState.atk = mainState.atk;
    //    charState.criChance = mainState.criChance;
    //    charState.criDamage = mainState.criDamage;
    //}
    //public void GetCharacterState()
    //{

    //    mainState.lv = transform.GetChild(heroIndex).GetComponent<ClassState>().lv;
    //    mainState.curExp = transform.GetChild(heroIndex).GetComponent<ClassState>().curExp;
    //    mainState.maxhp = transform.GetChild(heroIndex).GetComponent<ClassState>().maxhp;
    //    mainState.hp = transform.GetChild(heroIndex).GetComponent<ClassState>().hp;
    //    mainState.atk = transform.GetChild(heroIndex).GetComponent<ClassState>().atk;
    //    mainState.criChance = transform.GetChild(heroIndex).GetComponent<ClassState>().criChance;
    //    mainState.criDamage = transform.GetChild(heroIndex).GetComponent<ClassState>().criDamage;
    //}
    void Update()
    {

        //#region 캐릭터 변경
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    gameObject.tag = "Player";
        //    atkctrl.OffAttack();
        //    Instantiate(changeEffect, gameObject.transform);
        //    HeroChange(1);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    gameObject.tag = "Player";
        //    atkctrl.OffAttack();
        //    Instantiate(changeEffect, gameObject.transform);
        //    HeroChange(2);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    gameObject.tag = "Player";
        //    atkctrl.OffAttack();
        //    Instantiate(changeEffect, gameObject.transform);
        //    HeroChange(3);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    gameObject.tag = "BowClass";
        //    atkctrl.OffAttack();
        //    Instantiate(changeEffect, gameObject.transform);
        //    HeroChange(4);
        //}
        //#endregion

        //점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)  // 점프 키 입력
        {
            Jump();
        }

        //이동
        float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float r = Input.GetAxis("Mouse X");

            moveDir = new Vector3(h,0,v);

            playeranim.SetFloat("Forward", v);
            playeranim.SetFloat("Horizon", h);

        if (aimOn.aim)
        {

        }
              
        if(!aimOn.aim && (v != 0 || h != 0))
        {
            if (Input.GetKey(KeyCode.LeftShift) )
            {
                playeranim.SetBool("RunTrigger", true);
                totalSpeed = runSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) )
            {
                playeranim.SetBool("RunTrigger", false);
                totalSpeed = moveSpeed;
            }

        } // 달리기

        #region 이동 애니메이션
        if (onMove == false && !isHold)
        {
            if (h < 0) // 왼쪽
            {
                if (aimOn.aim)
                    playeranim.SetBool("HoldTrigger", true);
                else
                    playeranim.SetBool("MoveTrigger", true);

            } // 왼

            if (h > 0) // 오른쪽
            {
                if (aimOn.aim)
                    playeranim.SetBool("HoldTrigger", true);
                else
                    playeranim.SetBool("MoveTrigger", true);
            } //오

            if (v > 0) // 앞
            {
                if (aimOn.aim)
                    playeranim.SetBool("HoldTrigger", true);
                else
                    playeranim.SetBool("MoveTrigger", true);
            }

            if (v < 0) // 뒤
            {
                if (aimOn.aim)
                    playeranim.SetBool("HoldTrigger", true);
                else
                    playeranim.SetBool("MoveTrigger", true);
            } 

            if (aimOn.aim ) // aim 활성화
            {
                if (moveDir != Vector3.zero)
                {
                    //Vector3 moveDirection = lookedcam.rotation * new Vector3(h, 0, v);
                    //moveDirection.y = 0;

                    //transform.Translate(moveDirection * Time.deltaTime * totalSpeed);
                }
            }
            else        //aim 비활성화
            {
                if (moveDir != Vector3.zero && !aimOn.aim)
                {
                    playeranim.SetBool("HoldTrigger", false);
                    moveDir = Camera.main.transform.rotation * new Vector3(h, 0, v);
                    moveDir.y = 0;
                    transform.rotation = Quaternion.LookRotation(moveDir);
                    transform.Translate(Vector3.forward * Time.deltaTime * totalSpeed);


                    if (Input.GetKey(KeyCode.LeftShift) && !aimOn.aim && (v!= 0 || h!=0))
                    {
                        playeranim.SetBool("RunTrigger", true);
                    }
                    else
                        playeranim.SetBool("RunTrigger", false);
                     }
            }
        }
          

        if (h == 0 && v == 0)
            {
            totalSpeed = moveSpeed;
                playeranim.SetBool("MoveTrigger", false);
                playeranim.SetBool("HoldTrigger", false);
            }




            #endregion // 캐릭터 움직임



        }

    #region
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 위로 힘을 가함
        isGrounded = false; // 공중 상태로 변경
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 바닥 감지
        {
            Debug.Log("바닥이 감지되었습니다");
            isGrounded = true;
        }
    }
    #endregion
}
