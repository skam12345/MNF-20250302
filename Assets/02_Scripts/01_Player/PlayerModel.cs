using UnityEngine;
//using PlayerEnum;


public class PlayerModel : MonoBehaviour
{

	//싱글톤해야할지도

	[Header("Settings")]
	[SerializeField] public GameObject[] modelPrefabs;
	[SerializeField] public GameObject[] curmodelPrefabs;



    [SerializeField]private GameObject target;
	[SerializeField]private Animator targetAni;
	//	[SerializeField]private PlayerEnum.MODEL_NUMBER_NAME targetPartnerEnum = PlayerEnum.MODEL_NUMBER_NAME.NONE;

	private void Awake()
	{
		InitAddmodel();
		curmodelPrefabs = new GameObject[2];
        curmodelPrefabs[0] = modelPrefabs[0];
		curmodelPrefabs[1] = modelPrefabs[1];
    }

	//모델파일을 Project에서 추가.
	private void InitAddmodel()
	{
		GameObject[] loadCurHero;
		loadCurHero = Resources.LoadAll<GameObject>("Prefebs/Players");
        modelPrefabs = loadCurHero;
		Debug.Log(modelPrefabs[0]);
		Debug.Log(modelPrefabs[1]);
    }

	private void ChangeModel(int codeName)
	{
        curmodelPrefabs[1] = modelPrefabs[codeName];
    }


	//public void ChangeModel()
	//{
	//	Change();
	//}


	//private void Change()
	//{
	
	//	if(target != null)
	//	{
	//		//타겟 바꾸기

	//		//애니메이션 바꾸기
	//		target = null;
	//		targetAni = null;
	//		//targetPartnerEnum = PlayerEnum.MODEL_NUMBER_NAME.NONE;
	//	}


	//	switch (_targetEnum)
	//	{
	//		case PlayerEnum.MODEL_NUMBER_NAME.Mawang:
	//			target = Instantiate(modelPrefabs[0],Vector3.zero,Quaternion.identity);
	//			target.transform.parent = this.transform;
	//			target.transform.localPosition = Vector3.zero;
	//			targetAni = target.GetComponent<Animator>();
	//			break;
	//		default:
	//			break;
	//	}
	//}




	//public void SetFlip(bool _isLeft)
	//{
	//	if (_isLeft == true) transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
	//	else transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
	//}
}