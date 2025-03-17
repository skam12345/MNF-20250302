using System.Collections.Generic;
using UnityEngine;

public class EnemyModelCreator : MonoBehaviour
{
	[SerializeField]private List<GameObject> prefabObj;

	private EnemyAnimator model;

	public void CreateModel(int _number)
	{
		if (_number < 0 || _number >= prefabObj.Count) return;
		GameObject modelobj = Instantiate(prefabObj[_number], Vector3.zero, Quaternion.identity);
		modelobj.transform.parent = transform;
	}

	public void CreateModel(string _name)
	{
		GameObject modelobj = null;
		foreach (var item in prefabObj)
		{
			if(item.name == "_name")
			{
				modelobj = Instantiate(item, Vector3.zero, Quaternion.identity);
				modelobj.transform.parent = transform;
				return;
			}
		}
	}

	public void OnOffMode(bool _active)
	{
		 
	}
}