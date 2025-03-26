using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerTownMove : MonoBehaviour
{
	[Header("Inspector_Settings")]
	[SerializeField] private TownScene townScene;
	[SerializeField] private float walkSpeed = 5;
	[SerializeField] private float runSpeed = 10;

    [SerializeField] private GameObject townplayer;
    [SerializeField] private Animator playeranim;
    [SerializeField] private Animator buddyanim;
    private Vector3 goalPos, moveDir;

    //Ray ray;
    //RaycastHit rayHit;

    private bool isLeft;
	private bool isRight;
	private bool isUp;
	private bool isDown;

    private void Start()
    {
        townplayer = gameObject.transform.GetChild(0).gameObject;
        playeranim = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Animator>();
    }


    #region Start Update
    private void Update()
	{
		Moving();
	}

	#endregion


	

	//캐릭터가 FieldCollision태그의 특정이름에 닿으면 발동하는 함수
	private void OnTriggerEnter(Collider other)
	{
		GameObject collisionobject = other.gameObject;
		switch (collisionobject.tag)
		{
			case "FieldCollision":
				switch (collisionobject.name)
				{
					case "BeautySalon":
						townScene.OnOffBeautySalonBtn(true);
						break;
					case "Smithy":
						townScene.OnOffSmithyBtn(true);
						break;
					case "Church":
						townScene.OnOffChurchBtn(true);
						break;
					case "Shop":
						townScene.OnOffShopBtn(true);
						break;
					case "GoLobby":
						townScene.OnOffLobbyBtn(true);
						break;
					case "GoAdventure":
						townScene.OnOffStageBtn(true);
						break;
					default:
#if UNITY_EDITOR
						// 1. Check : Tag NPCPoint
						// 2. Check : gameobject.name
						Debug.Log("Not Settings");
#endif
						break;
				}

				break;
			default:
				break;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		GameObject collisionobject = other.gameObject;
		switch (collisionobject.tag)
		{
			case "FieldCollision":
				switch (collisionobject.name)
				{
					case "BeautySalon":
						townScene.OnOffBeautySalonBtn(false);
						break;
					case "Smithy":
						townScene.OnOffSmithyBtn(false);
						break;
					case "Church":
						townScene.OnOffChurchBtn(false);
						break;
					case "Shop":
						townScene.OnOffShopBtn(false);
						break;
					case "GoLobby":
						townScene.OnOffLobbyBtn(false);
						break;
					case "GoAdventure":
						townScene.OnOffStageBtn(false);
						break;
					default:
#if UNITY_EDITOR
						// 1. Check : Tag NPCPoint
						// 2. Check : gameobject.name
						Debug.Log("Not Settings");
#endif
						break;
				}

				break;
			default:
				break;
		}
	}



	private void Moving()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float r = Input.GetAxis("Mouse X");

		moveDir = new Vector3(h, 0, v);

		playeranim.SetFloat("Forward", v);
        playeranim.SetFloat("Horizon", h);

		if (moveDir.sqrMagnitude > 0.001f)
		{
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);

        }


        #region 이동 애니메이션

        if (h == 0 && v == 0)
        {
            playeranim.SetBool("MoveTrigger", false);
        }

			 if (h < 0) // 왼쪽
            {
            playeranim.SetBool("MoveTrigger", true);

            } // 왼

            if (h > 0) // 오른쪽
            {
                    playeranim.SetBool("MoveTrigger", true);
            } //오

            if (v > 0) // 앞
            {
                    playeranim.SetBool("MoveTrigger", true);
            }

            if (v < 0) // 뒤
            {
                    playeranim.SetBool("MoveTrigger", true);
            }

            if (moveDir != Vector3.zero)
		{
			goalPos = transform.position + moveDir * runSpeed * Time.deltaTime;
			transform.position = goalPos;
		}
	}
    #endregion
}