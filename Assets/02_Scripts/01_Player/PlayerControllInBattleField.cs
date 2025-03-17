using UnityEngine;

public class PlayerControllInBattleField : MonoBehaviour
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
	}

	/// <summary>
	/// X값에 따라 애니메이션 조절
	/// </summary>
	/// <param name="_x">입력값</param>

	public void OnJump()
	{
	}

	public void OnSkill1()
	{

	}


	public void OnSkill2()
	{

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