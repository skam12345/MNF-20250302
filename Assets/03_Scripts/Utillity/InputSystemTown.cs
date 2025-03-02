using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemTown : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private PlayerTownMove player;  // 


	private void OnMove(InputValue _valuie)
	{
		player.Move(_valuie.Get<Vector2>());
	}
}
