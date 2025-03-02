using UnityEngine;
//using PlayerEnum;


public class PlayerModel : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private GameObject[] modelPrefabs;


	[Header("Debug")]
	[SerializeField]private GameObject target;
	[SerializeField]private PlayerModelAniCtrl targetAni;
//	[SerializeField]private PlayerEnum.MODEL_NUMBER_NAME targetPartnerEnum = PlayerEnum.MODEL_NUMBER_NAME.NONE;



	private void Start()
	{
		ChangeModel(PlayerEnum.MODEL_NUMBER_NAME.MAWANG);
	}

	/// <summary>
	/// �ܺ������� ���� �ٲ� �� �� �Լ��� ��ġ���� �մϴ�
	/// </summary>
	/// <param name="_targetEnum"></param>
	public void ChangeModel(PlayerEnum.MODEL_NUMBER_NAME _targetEnum)
	{
		Change(_targetEnum);
	}

	/// <summary>
	/// �����Լ��� �۵��Ǵ� �� �����Դϴ�
	/// </summary>
	/// <param name="_targetEnum"></param>
	private void Change(PlayerEnum.MODEL_NUMBER_NAME _targetEnum)
	{
		if(target != null)
		{
			Destroy(target);
			target = null;
			targetAni = null;
			//targetPartnerEnum = PlayerEnum.MODEL_NUMBER_NAME.NONE;
		}


		switch (_targetEnum)
		{
			case PlayerEnum.MODEL_NUMBER_NAME.MAWANG:
				target = Instantiate(modelPrefabs[0],Vector3.zero,Quaternion.identity);
				target.transform.parent = this.transform;
				target.transform.localPosition = Vector3.zero;
				target.transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
				targetAni = target.GetComponent<PlayerModelAniCtrl>();
				break;
			default:
				break;
		}
	}

	/// <summary>
	/// ���� �ִϸ��̼��� ����մϴ�
	/// </summary>
	/// <param name="_aniEnum">PlayerEnum.Model_Ani State</param>
	public void PlayModelAnimation(PlayerEnum.MODEL_ANI _aniEnum)
	{
		if (targetAni == null) return;
		targetAni.PlayAni(ref _aniEnum);
	}



	public void SetFlip(bool _isLeft)
	{
		if (_isLeft == true) transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
		else transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
	}
}