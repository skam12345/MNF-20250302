using System;
using UnityEngine;

public class PlayerControllInBattleField : MonoBehaviour
{
    [SerializeField] private GameObject getmodelPlayer;
    [SerializeField] private GameObject getmodelPartner;
    [SerializeField] private GameObject setmodelPlayer;
    [SerializeField] private GameObject setmodelPartner;


    [Space(10)]
    public PlayerModel playermodel;
    public Animator playeranim;
    public Animator buddyanim;


    // 중력 및 점프 처리를 위한 벡터
    private Vector3 velocity; 
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpHeight = 2.7f;

    // jump
    private CharacterController controller;
    public float moveSpeed = 5f;
    private bool isJump = false;

    public bool isHold;
    public bool onMove;

    
    //스텟 갱신용
    public void StateRefresh()
    {

    }



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playermodel = GetComponent<PlayerModel>();

        getmodelPlayer = playermodel.modelPrefabs[0];
        getmodelPartner = playermodel.modelPrefabs[1];
        setmodelPlayer = Instantiate(getmodelPlayer, transform);
        setmodelPartner = Instantiate(getmodelPartner, transform);
        setmodelPartner.transform.position = getmodelPlayer.transform.position + new Vector3(-1, 0, 0);
        setmodelPartner.GetComponent<AttackController>().enabled = false;
        
        playeranim = gameObject.transform.GetChild(0).GetComponent<Animator>();
		buddyanim = gameObject.transform.GetChild(1).GetComponent<Animator>();
    }






   void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        // 애니메이션 파라미터 설정
        playeranim.SetFloat("Forward", h);
        buddyanim.SetFloat("Forward", h);

        // 이동 방향 계산 (수평 이동)
        Vector3 moveDir = new Vector3(h, 0f, 0f).normalized * moveSpeed;

        // 방향 전환
        if (Mathf.Abs(h) > 0.01f)
        {
            float targetYRotation = h > 0 ? 35f : 145f;
            setmodelPlayer.transform.localRotation = Quaternion.Euler(0f, targetYRotation, 0f);
            setmodelPartner.transform.localRotation = Quaternion.Euler(0f, targetYRotation, 0f);
        }

        // 중력 처리, 점프
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (Input.GetButtonDown("Jump")&& !isJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                playeranim.SetBool("Jump", true);
                isJump = true;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        // 수평 + 수직 이동 통합 처리
        Vector3 totalMove = new Vector3(moveDir.x, velocity.y, 0f);
        if (!isHold)
        {
            controller.Move(totalMove * Time.deltaTime);
        }

        // 애니메이션 처리
        bool isMoving = h != 0;
        playeranim.SetBool("MoveTrigger", isMoving);
        buddyanim.SetBool("MoveTrigger", isMoving);


        BuddySwap();
}




    public void BuddySwap()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("버디스왑 받등ㅁ");

            // 기존 모델 파괴
            Destroy(setmodelPlayer);
            Destroy(setmodelPartner);

            // 현재 프리팹 스왑 (인덱스 바꾸기)
            var temp = playermodel.curmodelPrefabs[0];
            playermodel.curmodelPrefabs[0] = playermodel.curmodelPrefabs[1];
            playermodel.curmodelPrefabs[1] = temp;

            // 새 모델 인스턴스화
            setmodelPlayer = Instantiate(playermodel.curmodelPrefabs[0], transform);

            setmodelPartner = Instantiate(playermodel.curmodelPrefabs[1], transform);
            setmodelPartner.transform.position = setmodelPlayer.transform.position + new Vector3(-1, 0, 0);
            setmodelPartner.GetComponent<AttackController>().enabled = false;

            // 애니메이터 재설정
            playeranim = setmodelPlayer.GetComponent<Animator>();
            buddyanim = setmodelPartner.GetComponent<Animator>();
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Plane")&& isJump)
        {
            playeranim.SetBool("Jump", false);
            isJump = false;
            Debug.Log("땅찍힘");
        }
    }
}