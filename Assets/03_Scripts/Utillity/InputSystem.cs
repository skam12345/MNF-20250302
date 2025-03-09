using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Unity 내부 기능인 InputSystem 을 활용하여 입력을 받습니다
/// 
/// </summary>
public class InputSystem : MonoBehaviour
{
	private Vector2 moveDir;	// 저장할 움직임 값

	[Header("Settings")]
	[SerializeField]private PlayerControll playerctrl;  // 
	public PlayerControll PlayerCtrl { set { playerctrl = value; } }
	
	private void OnMove(InputValue _valuie)
	{

		moveDir = _valuie.Get<Vector2>();
		playerctrl.Move(moveDir);
		//Debug.Log("Test : "+_valuie.Get<Vector2>());
	}


	private void OnFire()
	{
		playerctrl.OnAttack();
	}

	public void OnJump()
	{
		playerctrl.OnJump();

	}



}