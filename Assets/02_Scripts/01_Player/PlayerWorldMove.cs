using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerWorldMove : MonoBehaviour
{
    private Vector3 moveDir;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator playeranim;
    [SerializeField] private Animator hourseanim;

    public WorldUIManager worldUIManager;
    private CharacterController controller;
    public CinemachineVirtualCamera VirtualCamera;

    void Start()
    {
        worldUIManager = GameObject.Find("WorldUIManager").GetComponent<WorldUIManager>();
        playeranim = transform.GetChild(0).GetComponent<Animator>();
        hourseanim = transform.GetChild(1).GetComponent<Animator>();

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // A/D
        float v = Input.GetAxis("Vertical");    // W/S

        Vector3 inputDir = new Vector3(h, 0, v);

        playeranim.SetFloat("Forward", v);
        playeranim.SetFloat("Horizon", h);
        hourseanim.SetFloat("Forward", v);
        hourseanim.SetFloat("Horizon", h);

        bool isIdle = (h == 0 && v == 0);
        playeranim.SetBool("HoldTrigger", isIdle);
        hourseanim.SetBool("HoldTrigger", isIdle);

        if (inputDir.sqrMagnitude > 0.001f)
        {
            // 이동 방향 정규화
            Vector3 moveDir = inputDir.normalized;

            // 이동 - SimpleMove는 이동 속도 값이 곧 속도(m/s)이며, 자동으로 Time.deltaTime 적용됨
            controller.SimpleMove(moveDir * moveSpeed);

            // 이동 방향으로 회전 (Y축만 회전)
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }
        else
        {
            // 정지 상태에서는 SimpleMove로 이동 없음 처리
            controller.SimpleMove(Vector3.zero);
        }
    }



    private void OnTriggerEnter(Collider other)
    {

        GameObject collisionobject = other.gameObject;
        switch (collisionobject.tag)
        {
            case "WorldCollision":
                switch (collisionobject.name)
                {
                    case "GoTown":
                        //townScene.OnOffBeautyShopBtn(true);
                        break;
                    case "Forest":
                        StageDataManager.Instance.stageMainNum = 1;
                        worldUIManager.targetDungeon = collisionobject.transform.GetChild(0).transform;//forest 내부 spawnpoint
                        worldUIManager.OnDungeonPopup();
                        //townScene.OnOffEnchantShopBtn(true);
                        break;
                    case "Snow":
                        StageDataManager.Instance.stageMainNum = 2;
                        worldUIManager.targetDungeon = collisionobject.transform.GetChild(0).transform;//snow 내부 spawnpoint
                        worldUIManager.OnDungeonPopup();
                        break;
                    case "Desert":
                        StageDataManager.Instance.stageMainNum = 3;
                        worldUIManager.targetDungeon = collisionobject.transform.GetChild(0).transform;//snow 내부 spawnpoint
                        worldUIManager.OnDungeonPopup();
                        break;
                    case "GoLobby":
                        //townScene.OnOffLobbyBtn(true);
                        break;
                    case "GoAdventure":
                        //townScene.OnOffStageBtn(true);
                        break;
                    default:
                        Debug.Log("Not Settings");
                        break;
                }

                break;
            default:
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
       //메인ui가 꺼짐
       GameObject collisionobject = other.gameObject;
       if (collisionobject.tag == "WorldCollision")
       {
            worldUIManager.OffDungeonPopup();
            worldUIManager.OffDetailUI();
       }
    }

}
