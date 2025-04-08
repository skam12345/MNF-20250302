using UnityEngine;

using static ItemBaseClass;

public class ItemCube : MonoBehaviour
{
	//[SerializeField] private Material meshRenderer;


	Rigidbody rigidbody;
	Collider boxCollider;

	[Header("Settings")]
	[SerializeField] private float jumpPower;
	private Vector3 jumpVector;

	ItemData itemFieldData;

	bool isDropped = false;

	private void Awake()
	{
		GameObject cube = transform.Find("FieldCube").gameObject;
		GameObject minimapImage = transform.Find("MinimapImage").gameObject;

		boxCollider = this.GetComponent<Collider>();
		rigidbody = this.GetComponent<Rigidbody>();
		
		//meshRenderer = cube.GetComponent<Material>();
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
		// 위치 보정값
		transform.position = transform.position + (Vector3.up * 0.5f);

		// 이미지 체인지

		// 잠핑
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
		itemFieldData = null;
		ItemBaseClass.CreateItem(ref _dropTable, out itemFieldData);
		JumpItem();
		switch (itemFieldData.Type)
		{
			case "장비":
				if (SpriteManager.Instance == null) return;
				//minimapRenderer.sprite = SpriteManager.Instance.GetSpriteEquipt(itemFieldData.Index);
				break;
			case "소모품":
				if (SpriteManager.Instance == null) return;
				//minimapRenderer.sprite = SpriteManager.Instance.GetSpriteUseable(itemFieldData.Index);
				break;
			case "재료":
				if (SpriteManager.Instance == null) return;
				//minimapRenderer.sprite = SpriteManager.Instance.GetSpriteResource(itemFieldData.Index);
				break;

			default:
				break;
		}
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

	public void ItemDrop()
	{
		if (isDropped == true) return;
		if (isDropped == false)
		{
			isDropped = true;
		}

		InventoryData.Instance.ItemInInventoryToItemData(ref itemFieldData);

		Debug.Log("ItemCube - ItemDrop() : \n" + itemFieldData.ToString());
		Destroy(this.gameObject);	
	}
}