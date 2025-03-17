using UnityEngine;
using System.Collections.Generic;

// 이 클래스는 어떤 플레이어 동작이 활성화되었는지 또는 오버라이딩되었는지를 관리하고 해당 동작의 지역 함수를 호출합니다.
// 모든 플레이어 동작에서 사용되는 기본 설정 및 공통 함수를 포함합니다.
public class BasicBehaviourA : MonoBehaviour
{
	public Transform playerCamera;                        // 플레이어를 초점으로 하는 카메라에 대한 참조.
	public float turnSmoothing = 0.06f;                   // 카메라 방향과 일치하도록 이동할 때 회전 속도.
	public float sprintFOV = 100f;                        // 플레이어가 스프린트하는 동안 카메라에 사용할 FOV.
	public string sprintButton = "Sprint";                // 기본 스프린트 버튼 입력 이름.

	private float h;                                      // 수평 축.
	private float v;                                      // 수직 축.
	private int currentBehaviour;                         // 현재 플레이어 동작에 대한 참조.
	private int defaultBehaviour;                         // 다른 동작이 활성화되지 않았을 때 플레이어의 기본 동작.
	private int behaviourLocked;                          // 오버라이드를 금지하는 임시로 잠긴 동작에 대한 참조.
	private Vector3 lastDirection;                        // 플레이어가 이동하던 마지막 방향.
	private Animator anim;                                // Animator 구성 요소에 대한 참조.
	private ThirdPersonOrbitCamBasicA camScript;          // 세 번째 시점 카메라 스크립트에 대한 참조.
	private bool sprint;                                  // 플레이어가 스프린트 모드를 활성화했는지 여부를 나타내는 부울 값.
	private bool changedFOV;                              // 스프린트 액션이 카메라 FOV를 변경했는지 저장하는 부울 값.
	private int hFloat;                                   // 수평 축과 관련된 애니메이터 변수.
	private int vFloat;                                   // 수직 축과 관련된 애니메이터 변수.
	private List<GenericBehaviour> behaviours;            // 활성화된 모든 플레이어 동작을 포함하는 목록.
	private List<GenericBehaviour> overridingBehaviours;  // 현재 오버라이드되는 동작 목록.
	private Rigidbody rBody;                              // 플레이어의 리지드바디에 대한 참조.
	private int groundedBool;                             // 플레이어가 땅에 있는지 여부와 관련된 애니메이터 변수.
	private Vector3 colExtents;                           // 땅 테스트를 위한 콜라이더 범위. 

	// 현재 수평 및 수직 축을 가져옵니다.

	// 플레이어 카메라 스크립트를 가져옵니다.
	public ThirdPersonOrbitCamBasicA GetCamScript => camScript;

	// 플레이어의 리지드 바디를 가져옵니다.
	public Rigidbody GetRigidBody => rBody;

	// 플레이어의 애니메이터 컨트롤러를 가져옵니다.
	public Animator GetAnim => anim;

	// 현재 기본 동작을 가져옵니다.
	public int GetDefaultBehaviour => defaultBehaviour;

	void Awake ()
	{
		behaviours = new List<GenericBehaviour> ();
		overridingBehaviours = new List<GenericBehaviour>();
		anim = GetComponent<Animator> ();
		hFloat = Animator.StringToHash("H");
		vFloat = Animator.StringToHash("V");
		camScript = playerCamera.GetComponent<ThirdPersonOrbitCamBasicA> ();
		rBody = GetComponent<Rigidbody> ();

		groundedBool = Animator.StringToHash("Grounded");
		colExtents = GetComponent<Collider>().bounds.extents;
	}

	void Update()
	{
		sprint = Input.GetButton (sprintButton);
		if(IsSprinting())
		{
			changedFOV = true;
			camScript.SetFOV(sprintFOV);
		}
		else if(changedFOV)
		{
			camScript.ResetFOV();
			changedFOV = false;
		}
	}

	// 활성 또는 오버라이딩된 동작의 FixedUpdate 함수를 호출합니다
	void FixedUpdate()
	{
		// 다른 동작이 오버라이드되지 않은 경우 활성 동작을 호출합니다.
		bool isAnyBehaviourActive = false;
		if (behaviourLocked > 0 || overridingBehaviours.Count == 0)
		{
			foreach (GenericBehaviour behaviour in behaviours)
			{
				if (behaviour.isActiveAndEnabled && currentBehaviour == behaviour.GetBehaviourCode())
				{
					isAnyBehaviourActive = true;
					behaviour.LocalFixedUpdate();
				}
			}
		}
		// 오버라이드된 동작이 있는 경우 호출합니다.
		else
		{
			foreach (GenericBehaviour behaviour in overridingBehaviours)
			{
				behaviour.LocalFixedUpdate();
			}
		}

		//활성 또는 오버라이딩된 동작이 없는 경우 플레이어가 땅에 서있도록 합니다.
		if (!isAnyBehaviourActive && overridingBehaviours.Count == 0)
		{
			rBody.useGravity = true;
			//Repositioning ();
		}
	}

	// 활성 또는 오버라이딩된 동작의 LateUpdate 함수를 호출합니다.
	private void LateUpdate()
	{
		// 다른 동작이 오버라이드되지 않은 경우 활성 동작을 호출합니다.
		if (behaviourLocked > 0 || overridingBehaviours.Count == 0)
		{
			foreach (GenericBehaviour behaviour in behaviours)
			{
				if (behaviour.isActiveAndEnabled && currentBehaviour == behaviour.GetBehaviourCode())
				{
					behaviour.LocalLateUpdate();
				}
			}
		}
		// 오버라이딩된 동작이 있는 경우 해당 동작을 호출합니다.
		else
		{
			foreach (GenericBehaviour behaviour in overridingBehaviours)
			{
				behaviour.LocalLateUpdate();
			}
		}

	}

	// 새로운 동작을 동작 감시 목록에 추가합니다.
	public void SubscribeBehaviour(GenericBehaviour behaviour)
	{
		behaviours.Add(behaviour);
	}

	// 기본 플레이어 동작을 설정합니다.
	public void RegisterDefaultBehaviour(int behaviourCode)
	{
		defaultBehaviour = behaviourCode;
		currentBehaviour = behaviourCode;
	}

	// 사용자 정의 동작을 활성 동작으로 설정하려고 시도합니다.
	// 기본 동작에서 전달된 동작으로 항상 변경됩니다.
	public void RegisterBehaviour(int behaviourCode)
	{
		if (currentBehaviour == defaultBehaviour)
		{
			currentBehaviour = behaviourCode;
		}
	}

	// 플레이어 동작을 비활성화하고 기본 동작으로 복귀하려고 시도합니다.
	public void UnregisterBehaviour(int behaviourCode)
	{
		if (currentBehaviour == behaviourCode)
		{
			currentBehaviour = defaultBehaviour;
		}
	}

	// 활성 동작을 대기열의 동작으로 재정의하려고 시도합니다.
	// 활성 동작을 오버랩해야 하는 하나 이상의 동작으로 변경합니다(예: 조준 동작).
	public bool OverrideWithBehaviour(GenericBehaviour behaviour)
	{
		// 동작이 대기열에 없습니다.
		if (!overridingBehaviours.Contains(behaviour))
		{
			// 현재 오버라이드되고 있는 동작이 없습니다.
			if (overridingBehaviours.Count == 0)
			{
				// 동작을 재정의하기 전에 활성 동작의 OnOverride 함수를 호출합니다.
				foreach (GenericBehaviour overriddenBehaviour in behaviours)
				{
					if (overriddenBehaviour.isActiveAndEnabled && currentBehaviour == overriddenBehaviour.GetBehaviourCode())
					{
						overriddenBehaviour.OnOverride();
						break;
					}
				}
			}
			// 오버라이드되는 동작을 대기열에 추가합니다.
			overridingBehaviours.Add(behaviour);
			return true;
		}
		return false;
	}


	// 오버라이드된 동작을 철회하고 활성 동작으로 복귀하려고 시도합니다.
	// 오버라이드된 동작을 종료할 때 호출됩니다 (예: 조준 중지).
	public bool RevokeOverridingBehaviour(GenericBehaviour behaviour)
	{
		if (overridingBehaviours.Contains(behaviour))
		{
			overridingBehaviours.Remove(behaviour);
			return true;
		}
		return false;
	}

	// 현재 활성 동작을 재정의 중인지 여부를 확인합니다.
	// 특정 동작이 재정의 중인지 여부를 확인할 수도 있습니다.
	public bool IsOverriding(GenericBehaviour behaviour = null)
	{
		if (behaviour == null)
			return overridingBehaviours.Count > 0;
		return overridingBehaviours.Contains(behaviour);
	}

	// 활성 동작이 지정된 동작인지 확인합니다.
	public bool IsCurrentBehaviour(int behaviourCode)
	{
		return this.currentBehaviour == behaviourCode;
	}

	// 다른 어떤 동작이 임시로 잠겨 있는지 확인합니다.
	public bool GetTempLockStatus(int behaviourCodeIgnoreSelf = 0)
	{
		return (behaviourLocked != 0 && behaviourLocked != behaviourCodeIgnoreSelf);
	}

	// 특정 동작을 잠그려고 시도합니다.
	// 임시 잠금 중에 다른 동작을 재정의할 수 없습니다.
	// 점프, 조준 모드 진입/종료 등과 같은 임시 전환에 사용합니다.
	public void LockTempBehaviour(int behaviourCode)
	{
		if (behaviourLocked == 0)
		{
			behaviourLocked = behaviourCode;
		}
	}

	// 현재 잠겨 있는 동작을 잠금 해제하려고 시도합니다.
	// 임시 전환 종료 후 사용합니다.
	public void UnlockTempBehaviour(int behaviourCode)
	{
		if (behaviourLocked == behaviourCode)
		{
			behaviourLocked = 0;
		}
	}

	// 모든 동작에서 공통적인 함수:

	// 플레이어가 달리는지 확인합니다.
	public virtual bool IsSprinting()
	{
		return sprint && IsMoving() && CanSprint();
	}

	// 플레이어가 달릴 수 있는지 확인합니다 (모든 동작이 달릴 수 있어야 함).
	public bool CanSprint()
	{
		foreach (GenericBehaviour behaviour in behaviours)
		{
			if (!behaviour.AllowSprint())
				return false;
		}
		foreach (GenericBehaviour behaviour in overridingBehaviours)
		{
			if (!behaviour.AllowSprint())
				return false;
		}
		return true;
	}

	// 플레이어가 수평으로 이동 중인지 확인합니다.
	public bool IsHorizontalMoving()
	{
		return h != 0;
	}

	// 플레이어가 움직이는지 확인합니다.
	public bool IsMoving()
	{
		return (h != 0) || (v != 0);
	}

	// 플레이어의 마지막 바라보는 방향을 가져옵니다.
	public Vector3 GetLastDirection()
	{
		return lastDirection;
	}

	// 플레이어의 마지막 바라보는 방향을 설정합니다.
	public void SetLastDirection(Vector3 direction)
	{
		lastDirection = direction;
	}

	// 플레이어를 마지막으로 바라본 방향을 기준으로 일어서게 합니다.
	public void Repositioning()
	{
		if (lastDirection != Vector3.zero)
		{
			lastDirection.y = 0;
			Quaternion targetRotation = Quaternion.LookRotation(lastDirection);
			Quaternion newRotation = Quaternion.Slerp(rBody.rotation, targetRotation, turnSmoothing);
			rBody.MoveRotation(newRotation);
		}
	}

	// 플레이어가 지면에 있는지 여부를 확인하는 함수입니다.
	public bool IsGrounded()
	{
		Ray ray = new Ray(this.transform.position + Vector3.up * (2 * colExtents.x), Vector3.down);
		return Physics.SphereCast(ray, colExtents.x, colExtents.x + 0.2f);
	}
}

// 이것은 모든 플레이어 동작의 기본 클래스입니다. 사용자 정의 동작은 모두 이 클래스에서 상속해야 합니다.
// 동작에 따라 다를 수 있는 로컬 컴포넌트에 대한 참조가 포함되어 있습니다.
public abstract class GenericBehaviour : MonoBehaviour
{
	//protected Animator anim;                       // Animator 컴포넌트에 대한 참조입니다.
	protected int speedFloat;                      // 애니메이터에서의 속도 매개변수입니다.
	protected BasicBehaviourA behaviourManager;     // 기본 동작 관리자에 대한 참조입니다.
	protected int behaviourCode;                   // 동작을 식별하는 코드입니다.
	protected bool canSprint;                      // 동작이 플레이어에게 달리기를 허용하는지 여부를 저장하는 부울입니다.

	void Awake()
	{
		// 참조 설정.
		behaviourManager = GetComponent<BasicBehaviourA>();
		speedFloat = Animator.StringToHash("Speed");
		canSprint = true;

		// 상속 클래스를 기반으로 동작 코드 설정.
		behaviourCode = this.GetType().GetHashCode();
	}

	// 보호된 가상 함수는 상속된 클래스에서 재정의될 수 있습니다.
	// 활성 동작은 다음 함수를 사용하여 플레이어 조작을 제어합니다:

	// MonoBehaviour의 FixedUpdate 함수에 해당하는 로컬 함수입니다.
	public virtual void LocalFixedUpdate() { }
	// MonoBehaviour의 LateUpdate 함수에 해당하는 로컬 함수입니다.
	public virtual void LocalLateUpdate() { }
	// 다른 동작이 현재 동작을 재정의할 때 호출됩니다.
	public virtual void OnOverride() { }

	// 동작 코드를 가져옵니다.
	public int GetBehaviourCode()
	{
		return behaviourCode;
	}

	// 동작이 달리기를 하는지 허용합니다.
	public bool AllowSprint()
	{
		return canSprint;
	}
}
