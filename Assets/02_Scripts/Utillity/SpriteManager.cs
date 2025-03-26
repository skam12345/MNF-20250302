using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : SingleTonToUnityObject<SpriteManager>
{
	[SerializeField]private List<Sprite> equiptList;
	[SerializeField]private List<Sprite> useableList;
	[SerializeField]private List<Sprite> resoureList;

	private void Awake()
	{
		int forSize = 11;
		//equiptSize = ItemDataManager.Instance.EquiptSize;

	
		equiptList = new List<Sprite>();
		useableList = new List<Sprite>();
		resoureList = new List<Sprite>();

		// 임시 코드
		for (int i = 0; i < forSize; i++)
		{
			if( i < 10)
			{
				string str = ResourcesDirectory.IconEquiptSprite + "0" + i ;
				equiptList.Add(Resources.Load<Sprite>(str));
			}
			else
				equiptList.Add(Resources.Load<Sprite>(ResourcesDirectory.IconEquiptSprite+ + i));
		}

		//useableSize = ItemDataManager.Instance.UseableSize;
		for (int i = 0; i < forSize; i++)
		{
			if (i < 10)
				useableList.Add(Resources.Load<Sprite>(ResourcesDirectory.IconUseableSprite + "0" + i));
			else
				useableList.Add(Resources.Load<Sprite>(ResourcesDirectory.IconUseableSprite + +i));
		}

		//int resourceSize = ItemDataManager.Instance.ResourceSize;
		for (int i = 0; i < forSize; i++)
		{
			if (i < 10)
				resoureList.Add(Resources.Load<Sprite>(ResourcesDirectory.IconResourceSprite + "0" + i));
			else
				resoureList.Add(Resources.Load<Sprite>(ResourcesDirectory.IconResourceSprite + +i)); 
		}
	}


	/// <summary>
	/// 값을 변경하지말고 대입용으로만 사용해주시면 감사하겠습니다.
	/// </summary>
	/// <param name="_itemNumber">불러올 스프라이트 번호</param>
	/// <returns></returns>
	public Sprite GetSpriteEquipt(int _itemNumber)
	{
		return equiptList[_itemNumber];
	}
	public Sprite GetSpriteUseable(int _itemNumber)
	{
		return useableList[_itemNumber];
	}
	public Sprite GetSpriteResource(int _itemNumber)
	{
		return resoureList[_itemNumber];
	}

	public Sprite GetSpriteItem(ref ItemBaseClass.ItemData _data)
	{
		switch (_data.Type)
		{
			case "장비": return GetSpriteEquipt(_data.Index);
			case "소모품": return GetSpriteUseable(_data.Index);
			case "재료": return GetSpriteResource(_data.Index);
			default:
				break;
		}
		return null;
	}
}