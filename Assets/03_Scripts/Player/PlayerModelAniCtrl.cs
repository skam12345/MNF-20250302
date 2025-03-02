using UnityEngine;

public class PlayerModelAniCtrl : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private Animator modelAni;
	[SerializeField] private string[] aniName;

	#region public Func
	public void PlayAni(ref PlayerEnum.MODEL_ANI _aniEnum)
	{
		switch (_aniEnum)
		{
			case PlayerEnum.MODEL_ANI.IDLE:
				PlayIdle();
				break;
			case PlayerEnum.MODEL_ANI.IDLE_WAIT_MOTION:
				PlayIdleWaitMotion();
				break;
			case PlayerEnum.MODEL_ANI.WALK:
				PlayWalk();
				break;
			case PlayerEnum.MODEL_ANI.RUN:
				PlayRun();
				break;
			case PlayerEnum.MODEL_ANI.JUMP:
				PlayJump();
				break;
			case PlayerEnum.MODEL_ANI.HIT:
				PlayHit();
				break;
			case PlayerEnum.MODEL_ANI.HIT_DOWN:
				PlayHitDown();
				break;
			case PlayerEnum.MODEL_ANI.FAILED:
				PlayFailled();
				break;
			case PlayerEnum.MODEL_ANI.ATTACK:
				PlayAttack();
				break;
			default:
#if UNITY_EDITOR
				Debug.Log("Check Enum OR CodeCheck OR Number : " +  _aniEnum.ToString());
#endif
				break;
		}

	}
	#endregion

	#region private AnimationPlay Func
	private void PlayIdle()
	{
		modelAni.SetBool("Idle", true);
		modelAni.SetBool("Walk", false);
		modelAni.SetBool("Run", false);

		modelAni.Play(aniName[0]);
	}
	private void PlayIdleWaitMotion()
	{
		modelAni.Play(aniName[1]);
	}

	private void PlayWalk()
	{
		if( modelAni.GetBool("Walk"))
		{
			modelAni.CrossFade("Walk", 0.0f);
		}
		else
		{
			modelAni.SetBool("Walk", true);
			modelAni.SetBool("Run", false);
			modelAni.SetBool("Idle", false);
			modelAni.Play(aniName[2], 0, 0.0f);
		}
	}

	private void PlayRun()
	{
		if (modelAni.GetBool("Run"))
		{
			modelAni.CrossFade("Run", 0.0f);
		}
		else
		{
			modelAni.SetBool("Run", true);
			modelAni.SetBool("Walk", false);
			modelAni.SetBool("Idle", false);
			modelAni.Play(aniName[3], 0, 0.0f);
		}

	}

	private void PlayJump()
	{
	
		modelAni.Play(aniName[4], 0, 0.0f);
	}

	private void PlayHit()
	{
		modelAni.SetBool("Idle", false);
		modelAni.SetBool("Walk", false);
		modelAni.SetBool("Run", false);
		modelAni.Play(aniName[5], 0, 0.0f);
	}

	private void PlayHitDown()
	{
		modelAni.SetBool("Idle", false);
		modelAni.SetBool("Walk", false);
		modelAni.SetBool("Run", false);
		modelAni.Play(aniName[6], 0, 0.0f);
	}

	private void PlayFailled()
	{
		modelAni.Play(aniName[7], 0, 0.0f);
	}

	private void PlayAttack()
	{
		modelAni.Play(aniName[8], 0, 0.0f);
	}
	#endregion

}