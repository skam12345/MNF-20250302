using UnityEngine;

public class PlayerControll : MonoBehaviour
{
	// speed
	private float currSpeed = 0.0f;
	private float reachHalfMoveSpeed = 0.0f;
	[SerializeField] private float reachMoveSpeed = 10.0f;

	private Vector3 moveDir;
	private Rigidbody rigidbody;

	[SerializeField] private float jumpPower = 100.0f;
	[SerializeField] private GameObject model;
	[SerializeField] private PlayerModel modelPlayer;
	[SerializeField] private PlayerModel modelPartner;

	// jump
	private bool isJump = false;

	

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}


	private void Update()
	{
		if (moveDir != Vector3.zero)
		{
		//	Debug.Log(moveDir );
			transform.Translate(moveDir * Time.deltaTime * currSpeed);
		}
	}


	/// <summary>
	/// inputsystem을 활용한 move Function
	/// </summary>
	/// <param name="_moveValue">Inputsystem.InputValue</param>
	public void Move(Vector2 _moveValue)
	{
		moveDir = Vector3.zero;
		SpeedAniCheck(_moveValue.x);
	}

	/// <summary>
	/// X값에 따라 애니메이션 조절
	/// </summary>
	/// <param name="_x">입력값</param>
	private void SpeedAniCheck(float _x)
	{
		if (_x < 0.0f)
		{
			// Ani
			if (_x < -0.5f && isJump == false)
			{
				SetAni(false, PlayerEnum.MODEL_ANI.RUN);
			}
			else if (_x < 0.0f && isJump == false)
			{
				SetAni(false, PlayerEnum.MODEL_ANI.WALK);
			}

			// left move
			moveDir.z = -_x;
			SetFlip(true);
		}
		else if (_x > 0.0f)
		{
			// Ani
			if (_x > 0.5f && isJump == false)
			{
				SetAni(false, PlayerEnum.MODEL_ANI.RUN);
			}
			else if (_x > 0.0f && isJump == false)
			{
				SetAni(false, PlayerEnum.MODEL_ANI.WALK);
			}

			// right move
			moveDir.z = _x;
			SetFlip(false);
		}
		else // _moveValue.x == 0.0f
		{
			// ani
			if (isJump == false)
			{
				SetAni(false, PlayerEnum.MODEL_ANI.IDLE);
			}
		}
		currSpeed = _x * reachMoveSpeed;
	}


	public void OnAttack()
	{
		SetAni(true, PlayerEnum.MODEL_ANI.ATTACK);
	}

	private void Jump()
	{
		if (isJump == true) return;
		isJump = true;
		SetAni(false, PlayerEnum.MODEL_ANI.JUMP);
		rigidbody.AddForce(transform.up * jumpPower,ForceMode.Impulse);
	}

#if UNITY_EDITOR
	public void TestAniFunc(int _aniNumber)
	{
		if (_aniNumber < 0) return; else if (_aniNumber >= (int)PlayerEnum.MODEL_ANI.MAX) return;
		PlayerEnum.MODEL_ANI aniEnum = (PlayerEnum.MODEL_ANI)_aniNumber;
		modelPlayer.PlayModelAnimation(aniEnum);
	}
#endif

	public void OnLeftBtn()
	{
		moveDir = Vector3.zero;
		moveDir.z = -1.0f;
		currSpeed = reachMoveSpeed;
		SetAni(false, PlayerEnum.MODEL_ANI.RUN);
		SetFlip(true); 
	}
	public void OnLeftBtnUp()
	{
		moveDir = Vector3.zero;
		currSpeed = 0.0f;
		SetAni(false,PlayerEnum.MODEL_ANI.IDLE);
	}

	public void OnRightBtn()
	{
		moveDir = Vector3.zero;
		moveDir.z = 1.0f;
		currSpeed = reachMoveSpeed;
		SetAni(false,PlayerEnum.MODEL_ANI.RUN);
		SetFlip(false);
	}

	public void OnRightBtnUp()
	{
		moveDir = Vector3.zero;
		currSpeed = 0.0f;
		SetAni(false,PlayerEnum.MODEL_ANI.IDLE);
	}

	public void OnJump()
	{
		Jump();
	}

	public void OnSkill1()
	{

	}


	public void OnSkill2()
	{

	}


	private void SetAni(bool _isPlayerOnly, PlayerEnum.MODEL_ANI _aniEnum)
	{
		// if( _isPlayerOnly == true){
		// if(partner.HP == 0) { _isPlayerOnly = true } } 
		//
		//

		if (_isPlayerOnly)
		{
			modelPlayer.PlayModelAnimation(_aniEnum);
		}
		else
		{
			modelPlayer.PlayModelAnimation(_aniEnum);
			modelPartner.PlayModelAnimation(_aniEnum);
		}
	}

	private void SetFlip(bool _isLeft)
	{
		if(_isLeft)
		{
			model.transform.localRotation = Quaternion.Euler(0, -90, 0);
		}
		else
		{
			model.transform.localRotation = Quaternion.Euler(0, 90, 0);
		}

		modelPlayer.SetFlip(_isLeft);
		modelPartner.SetFlip(_isLeft);
	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Plane")
		{
			if(isJump == true)isJump = false;
		}
	}
}