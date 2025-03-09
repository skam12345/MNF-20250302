using UnityEngine;

using static ItemBaseClass;

public class ItemCube : MonoBehaviour
{
	//[SerializeField] private Material meshRenderer;
	//[SerializeField] private Material minimapRenderer;

	Rigidbody rigidbody;
	Collider boxCollider;

	[Header("Settings")]
	[SerializeField] private float jumpPower;
	private Vector3 jumpVector;


	private void Awake()
	{
		GameObject cube = transform.Find("FieldCube").gameObject;
		GameObject minimapImage = transform.Find("MinimapImage").gameObject;

		boxCollider = this.GetComponent<Collider>();
		rigidbody = this.GetComponent<Rigidbody>();
		//meshRenderer = cube.GetComponent<Material>();
		//minimapRenderer = minimapRenderer.GetComponent<Material>();
		jumpVector = Vector3.up * jumpPower;

		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;

		boxCollider.isTrigger = true;
	}

	private void Start()
	{
		JumpItem();
	}

	private void JumpItem()
	{
		rigidbody.AddForce(jumpVector, ForceMode.Impulse);
	}

	/// <summary>
	/// 적의 스크립터블 오브젝트를 받으면
	/// ItemBaseClass에 있는 전역함수 CreateItem()에 주소값으로 dropTable, out 으로 받을 변수를 설정합니다.
	/// InventoryData.Instance.SetFieldItem()에 itemFieldData로 넣습니다.
	/// </summary>
	/// <param name="_dropTable"></param>
	public void CreateItemData(ref EnemyDropTableToScriptableObject _dropTable)
	{
		ItemData itemFieldData = null;
		ItemBaseClass.CreateItem(ref _dropTable, out itemFieldData);
		InventoryData.Instance.SetFieldItem(ref itemFieldData);
	}

	

	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.gameObject.tag);
		switch (other.gameObject.tag)
		{
			case "Player":
				boxCollider.enabled = false;

				break;
			case "Plane":
				rigidbody.isKinematic = true;
				rigidbody.useGravity = false;

				Vector3 pos = Vector3.zero;
				pos.x = transform.position.x;
				pos.y = other.transform.position.y + 1;
				pos.z = transform.position.z;
				transform.position = pos;

				
				break;
			default:
				break;
		}
	}

}