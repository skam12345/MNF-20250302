using UnityEngine;
using Cinemachine;
using System.Collections;

// AimBehaviour inherits from GenericBehaviour. This class corresponds to aim and strafe behaviour.
public class AimBehaviourBasicA : GenericBehaviour
{
	//public AttackController atkController;
	public string aimButton = "Aim";     // Default aim and switch shoulders buttons.
	public string aimButton2 = "AimRight";
	public Texture2D crosshair;                                           // Crosshair texture.
	public float aimTurnSmoothing = 0.15f;                                // Speed of turn response when aiming to match camera facing.
	public Vector3 aimPivotOffset = new Vector3(0.5f, 1.2f,  0f);         // Offset to repoint the camera when aiming.
	public Vector3 aimCamOffset   = new Vector3(0f, 0.4f, -0.7f);         // Offset to relocate the camera when aiming.
                                              // Animator variable related to aiming.
	public bool aim;                                                     // Boolean to determine whether or not the player is aiming.
	public bool isAimFix;

 
    // Start is always called after any Awake functions.

    // Update is used to set features regardless the active behaviour.
    void Update ()
	{
		if(gameObject.tag == "BowClass")
        {
			// Activate/deactivate aim by input.
			if (Input.GetAxisRaw(aimButton) != 0 && !aim && !isAimFix)
			{
				StartCoroutine(ToggleAimOn());
			}
			else if (aim && Input.GetAxisRaw(aimButton) == 0 && !isAimFix)
			{
				StartCoroutine(ToggleAimOff());
			}

		}
		if(gameObject.tag == "Player")
        {
			if (Input.GetAxisRaw(aimButton2) != 0 && !aim && !isAimFix)
			{
				StartCoroutine(ToggleAimOn());
			}
			else if (aim && Input.GetAxisRaw(aimButton2) == 0 && !isAimFix)
			{
				StartCoroutine(ToggleAimOff());
			}
		}




		// No sprinting while aiming.
		canSprint = !aim;




	}

	// Co-routine to start aiming mode with delay.
	private IEnumerator ToggleAimOn()
	{
		yield return new WaitForSeconds(0.05f);
		// Aiming is not possible.
		if (behaviourManager.GetTempLockStatus(this.behaviourCode) || behaviourManager.IsOverriding(this))
			yield return false;

		// Start aiming.
		else
		{
			aim = true;
			int signal = 1;
			aimCamOffset.x = Mathf.Abs(aimCamOffset.x) * signal;
			aimPivotOffset.x = Mathf.Abs(aimPivotOffset.x) * signal;
			yield return new WaitForSeconds(0.1f);
			// This state overrides the active one.
			behaviourManager.OverrideWithBehaviour(this);
		}
	}

	// Co-routine to end aiming mode with delay.
	private IEnumerator ToggleAimOff()
	{
		aim = false;
		yield return new WaitForSeconds(0.3f);
		behaviourManager.GetCamScript.ResetTargetOffsets();
		behaviourManager.GetCamScript.ResetMaxVerticalAngle();
		yield return new WaitForSeconds(0.05f);
		behaviourManager.RevokeOverridingBehaviour(this);
	}

	// LocalFixedUpdate overrides the virtual function of the base class.
	public override void LocalFixedUpdate()
	{
		// Set camera position and orientation to the aim mode parameters.
		if(aim)
			behaviourManager.GetCamScript.SetTargetOffsets (aimPivotOffset, aimCamOffset);
	}

	// LocalLateUpdate: manager is called here to set player rotation after camera rotates, avoiding flickering.
	public override void LocalLateUpdate()
	{
		AimManagement();
	}

	// Handle aim parameters when aiming is active.
	void AimManagement()
	{
		// Deal with the player orientation when aiming.
		Rotating();
	}

	// Rotate the player to match correct orientation, according to camera.
	void Rotating()
	{
		Vector3 forward = behaviourManager.playerCamera.TransformDirection(Vector3.forward);
		// 플레이어는 땅 위를 이동하고 있으므로 카메라의 전방으로의 Y 구성요소는 관련이 없습니다.
		forward.y = 0.0f;
		forward = forward.normalized;

		// 항상 aim 모드에서 카메라의 수평 회전에 따라 플레이어를 회전시킵니다.
		Quaternion targetRotation =  Quaternion.Euler(0, behaviourManager.GetCamScript.GetH, 0);

		float minSpeed = Quaternion.Angle(transform.rotation, targetRotation) * aimTurnSmoothing;

		// 플레이어를 카메라를 향하게 전체적으로 회전합니다.
		behaviourManager.SetLastDirection(forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, minSpeed * Time.deltaTime);
        
		if (aim)
        {
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");
			float r = Input.GetAxis("Mouse X");

			// 움직임 방향을 설정할 때 월드 좌표계를 사용합니다.
			Vector3 moveDirection = new Vector3(h, 0, v).normalized;
			// 플레이어의 회전 각도와 일치하도록 움직임 방향을 회전합니다.
			moveDirection = transform.TransformDirection(moveDirection);
			// 움직임을 적용합니다.
			transform.Translate(moveDirection * Time.deltaTime * 2f, Space.World);
		}

	}

 	// Draw the crosshair when aiming.
	void OnGUI () 
	{
		if (crosshair)
		{
			float mag = behaviourManager.GetCamScript.GetCurrentPivotMagnitude(aimPivotOffset);
			if (mag < 0.05f)
				GUI.DrawTexture(new Rect(Screen.width / 1.95f - (crosshair.width * 0.8f),
										 Screen.height / 1.9f - (crosshair.height * 0.5f),
										 crosshair.width, crosshair.height), crosshair);
		}
	}
}
