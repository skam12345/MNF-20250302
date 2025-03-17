using UnityEngine;

public class EnemyDetectCollision : MonoBehaviour
{
	private Collider detectCollsion;

	private UnityEngine.Events.UnityAction enterPlayerAction;
	private UnityEngine.Events.UnityAction exitPlayerAction;

	private void Awake()
	{
		detectCollsion = GetComponent<Collider>();
	}

	public void SetAction(UnityEngine.Events.UnityAction _enter, UnityEngine.Events.UnityAction _exit)
	{
		enterPlayerAction = _enter;
		exitPlayerAction = _exit;
	}

	private void OnTriggerEnter(Collider other)
	{
		switch (other.tag)
		{
			case "Player":
				if (enterPlayerAction == null) return;
				enterPlayerAction.Invoke();
				break;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		switch (other.tag)
		{
			case "Player":
				if (exitPlayerAction == null) return;
				exitPlayerAction.Invoke();
				break;
		}
	}
}