using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private GameObject prefabItemCube;
	
	// Data
	private EnemyBaseData myData;

	// Damage
	private Vector3 damageFontPos;
	private DamageCreator damageCreator;

	private EnemyModelCreator modelCreator;


	[SerializeField]private EnemyDropTableToScriptableObject itemDropData;


	private void Awake()
	{
		myData = new EnemyBaseData();
		damageCreator = GameObject.Find("DamageCreator").GetComponent<DamageCreator>();
		damageFontPos = new Vector3(0,1.75f,0);
		modelCreator = GetComponentInChildren<EnemyModelCreator>();

		// 테스트목적 나중에 StageManager의 몹 넘버로 
		OnInit(0);
	}

	public void OnInit(int _monsterNumber)
	{
		Init(_monsterNumber);
	}

	private void Init(int _monsterNumber)
	{
		EnemyBaseData getData = null;
		EnemyDataManager.Instance.GetData(_monsterNumber, out getData);
		myData.Init(ref getData);
		modelCreator.CreateModel(myData.Index);

		CreateEnemyDropData();
	}


	private void CreateEnemyDropData()
	{
		System.Text.StringBuilder strDirectory = new System.Text.StringBuilder();
		strDirectory.Append(ResourcesDirectory.MonsterDropTable);

		if (myData.Index < 10)
		{
			strDirectory.Append("00" + (myData.Index + 1));
		}
		else if (myData.Index < 100)
		{
			strDirectory.Append("0" + (myData.Index + 1));
		}
		else
		{
			strDirectory.Append((myData.Index + 1));
		}
		strDirectory.Append("_" + myData.Name);

		//Debug.Log(strDirectory);
		itemDropData = Resources.Load<EnemyDropTableToScriptableObject>(strDirectory.ToString());
	}

	#region [HP]Damage & Headl & Dead
	public void OnDamage(in float _playerAttackTotalDamage)
	{
		float totalDamage = _playerAttackTotalDamage - myData.DEF;
		myData.CurrHP -= totalDamage;


		// 데미지를 띄울 위치값, 최종 데미지 값
		damageCreator.OnDamageText(transform.position + damageFontPos, (int)totalDamage);
		if ( myData.CurrHP <= 0.0f)
		{
			//uiManager.Instance.ChangeEnemyUI(0);
			Dead();
		}
		else
		{
			//uiManager.Instance.ChangeEnemyUI(int.Parse(myData.CurrHP));
		}
	}

	public void Heal(in float _addHp)
	{
		myData.CurrHP += _addHp;
		if( myData.MaxHP <= myData.CurrHP) { myData.CurrHP = myData.MaxHP; }
	}

	private void Dead() 
	{
		GameObject obj = Instantiate(prefabItemCube, transform.position, Quaternion.identity);
		obj.GetComponent<ItemCube>().CreateItemData(ref itemDropData);
		gameObject.SetActive(false);
	}
	#endregion

	public void LookToLeft()
	{

	}

	public void LookToRight()
	{

	}

	public void FrontGoAway()
	{

	}

	public void BackJump()
	{

	}

	public void Die()
	{

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Partner")
		{

		}
	}
}