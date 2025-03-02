using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class TestFade : MonoBehaviour
{
	[SerializeField] private float fadeInTime ;
	[SerializeField] private float fadeOutTime ;

	[SerializeField] private UnityEngine.UI.Image targetImage;
	bool white = false;

	[SerializeField] private TMPro.TMP_Text fadeInText;
	[SerializeField] private TMPro.TMP_Text fadeOutText;
	[SerializeField] private TMPro.TMP_Text nowTime;

	private IEnumerator StartFadeIn()
	{
		float nowtime = 0.0f;
		float percentage = 0.0f;

		while (nowtime <= fadeInTime)
		{
			nowtime += Time.deltaTime;
			percentage = nowtime/fadeInTime;
			nowTime.text = nowtime.ToString("F1");
			Debug.Log("percentage = " + percentage);

			if (white) targetImage.color = new Color(1,1,1, 1-percentage);
			else targetImage.color = new Color(0,0,0, 1-percentage);
			yield return null;
		}
		if (white) targetImage.color = new Color(1, 1, 1, 0);
		else		targetImage.color = new Color(0, 0, 0, 0);
		Debug.Log("fadeInCoroutine End");
	}

	private IEnumerator StartFadeOut()
	{
		float nowtime = 0.0f;
		float percentage = 0.0f;

		while (nowtime <= fadeOutTime)
		{
			nowtime += Time.deltaTime;
			percentage = nowtime/ fadeOutTime;

			nowTime.text = nowtime.ToString("F1");
			Debug.Log("percentage = " + percentage);

			if (white) targetImage.color = new Color(1, 1, 1, percentage);
			else targetImage.color = new Color(0, 0, 0, percentage);
			yield return null;
		}
		if (white) targetImage.color = new Color(1, 1, 1, 1);
		else		targetImage.color = new Color(0, 0, 0, 1);
		Debug.Log("fadeOutCoroutine End");
	}

	private void FadeIn()
	{
		this.StopAllCoroutines();
		if (white) targetImage.color = new Color(1, 1, 1, 1);
		else targetImage.color = new Color(0, 0, 0, 1);
		StartCoroutine(StartFadeIn());
	}	

	private void FadeOut()
	{
		this.StopAllCoroutines();

		if (white) targetImage.color = new Color(1, 1, 1, 0);
		else targetImage.color = new Color(0, 0, 0, 0);
		StartCoroutine(StartFadeOut());
	}

	public void CalledFadeIn(bool _isWhite)
	{
		white = _isWhite;
		fadeInText.text = fadeInTime.ToString("F1");
		FadeIn();
	}

	public void CalledFadeOut(bool _isWhite)
	{
		white = _isWhite;
		fadeOutText.text = fadeOutTime.ToString("F1");
		FadeOut();
	}

#if UNITY_EDITOR
	private void Update()
	{
		if (Input.GetKey(KeyCode.A)) SetFadeInTimeDoPlus(true);
		if (Input.GetKey(KeyCode.S)) SetFadeInTimeDoPlus(false);
		if (Input.GetKey(KeyCode.Z)) SetFadeOutTimeDoPlus(true);
		if (Input.GetKey(KeyCode.X)) SetFadeOutTimeDoPlus(false);
	}
	public void SetFadeInTimeDoPlus(bool _plus)
	{
		if (_plus) fadeInTime += Time.deltaTime * 2.0f;
		else fadeInTime -= Time.deltaTime * 2.0f;
		if (fadeInTime <= 0.0) fadeInTime = 0;
		fadeInText.text = fadeInTime.ToString("F1");
	}
	public void SetFadeOutTimeDoPlus(bool _plus)
	{
		if (_plus) fadeOutTime += Time.deltaTime * 2.0f;
		else fadeOutTime -= Time.deltaTime * 2.0f;
		if (fadeOutTime <= 0.0) fadeOutTime = 0;
		fadeOutText.text = fadeOutTime.ToString("F1");
	}
#endif
}