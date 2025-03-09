using System.Collections;
using UnityEngine;

public class SceneForFade : MonoBehaviour
{
	[Header("Setting")]
	[SerializeField] private UnityEngine.UI.Image targetImage;

	[Header("Debugging SerializeField")]
	[SerializeField] private bool fadeInModeWhite;
	[SerializeField] private bool fadeOutModeWhite;
	[SerializeField] private float fadeInTime;
	[SerializeField] private float fadeOutTime;


	private void Start()
	{
		targetImage.gameObject.SetActive(true);
		//StartCoroutine(FadeIn());
	}

	//#if UNITY_EDITOR
	//private IEnumerator FadeDebugText()
	//{
	//	while (true)
	//	{
	//		Debug.Log("FadeinWhite? : " + fadeInModeWhite +
	//				"\nFadeOutWhite? : " + fadeOutModeWhite +
	//				"\nfadeInTime : " + fadeInTime.ToString("F1") +
	//				"\nfadeOutTime : " + fadeOutTime.ToString("F1"));
	//		yield return new WaitForSeconds(1.0f);
	//	}
	//}
	//#endif

	private IEnumerator FadeIn()
	{
		float nowtime = 0.0f;
		float percentage = 0.0f;

		while (nowtime <= fadeInTime)
		{
			nowtime += Time.deltaTime;
			percentage = nowtime / fadeInTime;

			if (fadeInModeWhite) targetImage.color = new Color(1, 1, 1, 1 - percentage);
			else targetImage.color = new Color(0, 0, 0, 1 - percentage);
			yield return null;
		}
		targetImage.gameObject.SetActive(false);


		//if (fadeInModeWhite) targetImage.color = new Color(1, 1, 1, 0);
		//else targetImage.color = new Color(0, 0, 0, 0);
	}

	private IEnumerator FadeOut()
	{
		targetImage.gameObject.SetActive(true);
		float nowtime = 0.0f;
		float percentage = 0.0f;

		while (nowtime <= fadeOutTime)
		{
			nowtime += Time.deltaTime;
			percentage = nowtime / fadeOutTime;

			if (fadeOutModeWhite) targetImage.color = new Color(1, 1, 1, percentage);
			else targetImage.color = new Color(0, 0, 0, percentage);
			yield return null;
		}
		if (fadeOutModeWhite) targetImage.color = Color.white;
		else targetImage.color = Color.black;
	}

	public void StartFadeIn(float _time, bool _isWhite = false)
	{
		fadeInModeWhite = _isWhite;
		fadeInTime = _time;
		StartCoroutine(FadeIn());
	}

	public void StartFadeOut(float _time, bool _isWhite = false)
	{
		fadeOutModeWhite = _isWhite;
		fadeOutTime = _time;
		StartCoroutine(FadeOut());
	}

	public void ResetFadeImage(bool _isFadeIn, bool _isFadeWhite)
	{
		if( _isFadeIn )
		{
			targetImage.gameObject.SetActive(false);

			//if (_isFadeWhite) targetImage.color = new Color(1, 1, 1, 0);
			//else			targetImage.color = new Color(0,0,0,0);
		}
		else
		{
			if (_isFadeWhite) targetImage.color = Color.white;
			else			targetImage.color = Color.black;
		}
	}


}