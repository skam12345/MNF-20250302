using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerTownMove : MonoBehaviour
{
	[Header("Inspector_Settings")]
	[SerializeField] private TownScene townScene;

	[SerializeField] float walkSpeed = 5;
	[SerializeField] float runSpeed = 10;

	private Vector3 goalPos, startPos, moveDir;
	private Vector3 moveLeftUp;
	private Vector3 moveLeftDown;
	private Vector3 moveRightUp;
	private Vector3 moveRightDown;

	Ray ray;
	RaycastHit rayHit;

	private bool isLeft;
	private bool isRight;
	private bool isUp;
	private bool isDown;


	#region Awake Start Update
	private void Update()
	{
		Moving();
	}

	#endregion

	public void Move(Vector2 _inputVector)
	{
		isLeft = isRight = isUp = isDown = false;

		moveDir.x = _inputVector.x;
		moveDir.y = 0;
		moveDir.z = _inputVector.y;

		if (moveDir.x < 0) { isLeft = true; isRight = false; }
		else if (moveDir.x > 0) { isLeft = false; isRight = true; }

		if (moveDir.z > 0) { isUp = true; isDown = false; }
		else if (moveDir.z < 0) { isUp = false; isDown = true; }

		//Debug.Log("L : " + isLeft + "\t R : " + isRight + "\t U : " + isUp + "\t D : " + isDown + "MoveDir : " + moveDir);
		if (!isUp && !isDown && !isLeft && !isRight) { moveDir = Vector3.zero; return; }
	}

	

	private void OnTriggerEnter(Collider other)
	{
		GameObject collisionobject = other.gameObject;
		switch (collisionobject.tag)
		{
			case "FieldCollision":
				switch (collisionobject.name)
				{
					case "BeautySalon":
						townScene.OnOffBeautyShopBtn(true);
						break;
					case "EnchantShop":
						townScene.OnOffEnchantShopBtn(true);
						break;
					case "Guild":
						townScene.OnOffGuildBtn(true);
						break;
					case "Smithy":
						townScene.OnOffSmithyBtn(true);
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
						townScene.OnOffBeautyShopBtn(false);
						break;
					case "EnchantShop":
						townScene.OnOffEnchantShopBtn(false);
						break;
					case "Guild":
						townScene.OnOffGuildBtn(false);
						break;
					case "Smithy":
						townScene.OnOffSmithyBtn(false);
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
		if (moveDir != Vector3.zero)
		{
			goalPos = transform.position + moveDir * runSpeed * Time.deltaTime;
			transform.position = goalPos;
		}
	}
}