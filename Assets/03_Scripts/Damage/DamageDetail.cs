using System.Collections;
using TMPro;
using UnityEngine;

public class DamageDetail : MonoBehaviour
{
	private TextMeshPro text;
	private WaitForSeconds waitingCoroutine;
	private TMP_FontAsset font;

	private float resetFontSize;

	private float liveTime;
	private readonly float reachedTime = 1.5f;

	private void Awake()
	{
		font = Resources.Load<TMP_FontAsset>("Fonts/Font_TMP/neodgm SDF");
		text = GetComponent<TextMeshPro>();

		text.font = font;
		resetFontSize = text.fontSize;

		this.gameObject.SetActive(false);
	}
	
	
	public void OnDamage(in Vector3 _pos, in int _damage)
	{
		text.text = _damage.ToString();
		transform.position = _pos;
		gameObject.SetActive(true);
		StartCoroutine(fontAnimation());
	}
	private IEnumerator fontAnimation()
	{
		while (true)
		{
			if( text.fontSize <= 0.0f)
			{
				OffDamage();
				yield break;
			}
			else
			{
				if (liveTime <= reachedTime)
				{
					liveTime += Time.deltaTime;
					text.fontSize = resetFontSize - (resetFontSize * (liveTime / reachedTime));
				}
			}
			yield return null;
		}
	}


	public void OffDamage()
	{
		gameObject.SetActive(false);
		liveTime = 0.0f;
		text.text = "";
		text.fontSize = resetFontSize;
	}
}