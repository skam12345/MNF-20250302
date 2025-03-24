using UnityEngine;
using System.Collections.Generic;


public class DamageCreator : MonoBehaviour
{
	[SerializeField]private GameObject prefabUIText;

	List<DamageDetail> damageList;

	private void Awake()
	{
		prefabUIText = Resources.Load<GameObject>("Prefebs/Damage/DamageText");
		damageList = new List<DamageDetail>();
		CreateDamageFont(10);
	}

	public void OnDamageText(in Vector3 _pos, in int _dmg)
	{
		Debug.Log(_pos +"\t" + _dmg);
		foreach (var item in damageList)
		{
			if( item.gameObject.activeSelf == false)
			{
				item.OnDamage(in _pos, in _dmg);
				return;
			}
		}

		// 여기까지 왔으면 새로 생성해야 한다는 상황
		CreateDamageFont(1);
	}

	private void CreateDamageFont(int _createCount)
	{
		for (int i = 0; i < _createCount; i++)
		{
			GameObject obj = Instantiate(prefabUIText, Vector3.zero, Quaternion.identity);
			obj.transform.parent = transform;
			damageList.Add(obj.GetComponent<DamageDetail>());
		}
	}
}