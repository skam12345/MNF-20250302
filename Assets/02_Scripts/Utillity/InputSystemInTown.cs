using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemInTown : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private PlayerControllInTown player;  // 


	private void OnMove(InputValue _valuie)
	{
		Debug.Log("_valuie : " + _valuie.Get<Vector2>());
		player.Move(_valuie.Get<Vector2>());
	}
}
