using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Unity ���� ����� InputSystem �� Ȱ���Ͽ� �Է��� �޽��ϴ�
/// 
/// </summary>
public class InputSystem : MonoBehaviour
{
	private Vector2 moveDir;	// ������ ������ ��

	[Header("Settings")]
	[SerializeField]private PlayerControll playerctrl;  // 


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