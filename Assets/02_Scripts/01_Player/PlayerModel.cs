using UnityEngine;
//using PlayerEnum;


public class PlayerModel : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] public GameObject[] modelPrefabs;



	[SerializeField]private GameObject target;
	[SerializeField]private Animator targetAni;
	//	[SerializeField]private PlayerEnum.MODEL_NUMBER_NAME targetPartnerEnum = PlayerEnum.MODEL_NUMBER_NAME.NONE;

	private void Awake()
	{
		InitAddmodel();
        ChangeModel(PlayerEnum.MODEL_NUMBER_NAME.Mawang);
	}

	//모델파일을 Project에서 추가.
	private void InitAddmodel()
	{
        GameObject[] loadedPrefabs = Resources.LoadAll<GameObject>("Prefebs/Players");
        modelPrefabs = loadedPrefabs;
    }



	public void ChangeModel(PlayerEnum.MODEL_NUMBER_NAME _targetEnum)
	{
		Change(_targetEnum);
	}


	private void Change(PlayerEnum.MODEL_NUMBER_NAME _targetEnum)
	{
	
		if(target != null)
		{
			//타겟 바꾸기

			//애니메이션 바꾸기
			target = null;
			targetAni = null;
			//targetPartnerEnum = PlayerEnum.MODEL_NUMBER_NAME.NONE;
		}


		switch (_targetEnum)
		{
			case PlayerEnum.MODEL_NUMBER_NAME.Mawang:
				target = Instantiate(modelPrefabs[0],Vector3.zero,Quaternion.identity);
				target.transform.parent = this.transform;
				target.transform.localPosition = Vector3.zero;
				targetAni = target.GetComponent<Animator>();
				break;
			default:
				break;
		}
	}




	public void SetFlip(bool _isLeft)
	{
		if (_isLeft == true) transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
		else transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
	}
}