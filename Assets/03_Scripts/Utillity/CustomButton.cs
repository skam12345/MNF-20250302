using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour,IPointerClickHandler,IPointerMoveHandler,IPointerDownHandler, IPointerUpHandler
{
	private UnityAction down;
	public UnityAction SetDownAction{ set { down = value; } }

	private UnityAction up;
	public UnityAction SetUpAction{ set { up = value; } }

	private UnityAction move;
	public UnityAction SetMoveAction{ set { move = value; } }

	private UnityAction click;
	public UnityAction SetClickAction{ set { click = value; } }

	public void OnPointerClick(PointerEventData eventData)
	{
		if (click == null) return;
		click.Invoke();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (down == null) return;
		down.Invoke();
	}

	public void OnPointerMove(PointerEventData eventData)
	{
		if(move == null) return;
		move.Invoke();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (up == null) return;
		up.Invoke();
	}
}