using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
	Animator ani;
	[SerializeField] private string[] aniName;
	#region public Func
	public void PlayAni(ref EnemyEnum.ANIMATION _aniEnum)
	{
		switch (_aniEnum)
		{
			case EnemyEnum.ANIMATION.IDLE:
				PlayIdle();
				break;
			case EnemyEnum.ANIMATION.IDLE_WAIT_MOTION:
				PlayIdleWaitMotion();
				break;
			case EnemyEnum.ANIMATION.WALK:
				PlayWalk();
				break;
			case EnemyEnum.ANIMATION.RUN:
				PlayRun();
				break;
			case EnemyEnum.ANIMATION.JUMP:
				PlayJump();
				break;
			case EnemyEnum.ANIMATION.HIT:
				PlayHit();
				break;
			case EnemyEnum.ANIMATION.HIT_DOWN:
				PlayHitDown();
				break;
			case EnemyEnum.ANIMATION.FAILED:
				PlayFailled();
				break;
			case EnemyEnum.ANIMATION.ATTACK:
				PlayAttack();
				break;
			default:
#if UNITY_EDITOR
				Debug.Log("Check Enum OR CodeCheck OR Number : " + _aniEnum.ToString());
#endif
				break;
		}

	}
	#endregion

	#region private AnimationPlay Func
	private void PlayIdle()
	{
		ani.SetBool("Idle", true);
		ani.SetBool("Walk", false);
		ani.SetBool("Run", false);

		ani.Play(aniName[0]);
	}
	private void PlayIdleWaitMotion()
	{
		ani.Play(aniName[1]);
	}

	private void PlayWalk()
	{
		if (ani.GetBool("Walk"))
		{
			ani.CrossFade("Walk", 0.0f);
		}
		else
		{
			ani.SetBool("Walk", true);
			ani.SetBool("Run", false);
			ani.SetBool("Idle", false);
			ani.Play(aniName[2], 0, 0.0f);
		}
	}

	private void PlayRun()
	{
		if (ani.GetBool("Run"))
		{
			ani.CrossFade("Run", 0.0f);
		}
		else
		{
			ani.SetBool("Run", true);
			ani.SetBool("Walk", false);
			ani.SetBool("Idle", false);
			ani.Play(aniName[3], 0, 0.0f);
		}

	}

	private void PlayJump()
	{

		ani.Play(aniName[4], 0, 0.0f);
	}

	private void PlayHit()
	{
		ani.SetBool("Idle", false);
		ani.SetBool("Walk", false);
		ani.SetBool("Run", false);
		ani.Play(aniName[5], 0, 0.0f);
	}

	private void PlayHitDown()
	{
		ani.SetBool("Idle", false);
		ani.SetBool("Walk", false);
		ani.SetBool("Run", false);
		ani.Play(aniName[6], 0, 0.0f);
	}

	private void PlayFailled()
	{
		ani.Play(aniName[7], 0, 0.0f);
	}

	private void PlayAttack()
	{
		ani.Play(aniName[8], 0, 0.0f);
	}
	#endregion
}