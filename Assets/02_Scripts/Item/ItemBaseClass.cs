using System.Text;

public class ItemBaseClass
{
	// 기초 장비 아이템의 모든 것
	public class ItemBaseEquipment
	{
		public int index { get; set; }
		public string name { get; set; }	// 이름
		public string typeText { get; set; }	// 종류
		public int grade { get; set; }		// 등급 or 스타
		public int upgrade{ get; set; }		// 강화
		public int needLv { get; set; }		// 아이템 최소 레벨
		public int buyGold { get; set; }	// -1 구매불가 0이상 판매 가능
		public int sellGold { get; set; }	// -1 판매불가 0이상 판매 가능
		public float itemBaseHP { get; set; }    // 아이템 장착시 올라가는 Hp량
		public float itemBaseMP { get; set; }    // 아이템 장착시 올라가는 Mp량
		public float itemBaseAtk { get; set; }	// 아이템 장착시 올라가는 Atk
		public float itemBaseDef { get; set; }	// 아이템 장착시 올라가는 Def
		public float criRate { get; set; }	// 아이템 장착시 올라가는 크리확률
		public float criDmg { get; set; }	// 아이템 장착시 올라가는 크리데미지
		public int enchantLuck { get; set; }	// 아이템 장착시 재료합성 컨텐츠에서 올라가는 행운 량
		public string description { get; set; }	// 설명
		public int skillEvent { get; set; } // 아이템 장착 시 스킬을 사용할 수 있는 번호

		StringBuilder itemText;

		public override string ToString()
		{
			if (itemText == null) itemText = new StringBuilder();

			itemText.Clear();

			itemText.Append(index);
			itemText.Append("\nname: "+name);
			itemText.Append("\ntype: "+typeText);
			itemText.Append("\ngrade: "+grade);
			itemText.Append("\nneedLV: "+needLv);
			itemText.Append("\nupgrade: "+upgrade);
			itemText.Append("\nbuyGold: "+buyGold);
			itemText.Append("\nsellGold: "+sellGold);
			itemText.Append("\nbaseHP: "+itemBaseHP);
			itemText.Append("\nbaseMP: "+itemBaseMP);
			itemText.Append("\nbaseATK: "+itemBaseAtk);
			itemText.Append("\nbaseDef: "+itemBaseDef);
			itemText.Append("\ncriRate: "+criRate);
			itemText.Append("\ncriDmg: "+criDmg);
			itemText.Append("\nencLuck"+ enchantLuck);
			itemText.Append("\ndesc"+description);
			return itemText.ToString();
		}

		public void Init(string _name, string _typeText, int _grade, int _needLv, int _upgrade,
			int _buygold, int _sellgold, 
			float _itemHp, float _itemMp, 
			float _itemAtk, float _itemDef,
			float _criRate, float _criDmg,
			int _enchantLuck, string _desc, int _skillEvent)
		{
			name = _name; typeText = _typeText; grade = _grade; needLv = _needLv; upgrade = _upgrade;
			buyGold = _buygold; sellGold = _sellgold;
			itemBaseHP = _itemHp; itemBaseMP = _itemMp;
			itemBaseAtk = _itemAtk; itemBaseDef = _itemDef;
			criRate = _criRate; criDmg = _criDmg;
			enchantLuck = _enchantLuck; description = _desc; skillEvent = _skillEvent;
		}

		public void Init(ItemBaseEquipment _data)
		{
			name = _data.name;
			typeText = _data.typeText;
			grade = _data.grade;
			needLv = _data.needLv;
			upgrade = _data.upgrade;
			buyGold = _data.buyGold;
			sellGold = _data.sellGold;
			itemBaseHP = _data.itemBaseHP;
			itemBaseMP = _data.itemBaseMP;
			itemBaseAtk = _data.itemBaseAtk;
			itemBaseDef = _data.itemBaseDef;
			criRate = _data.criRate;
			criDmg = _data.criDmg;
			enchantLuck = _data.enchantLuck;
			description = _data.description;
			skillEvent = _data.skillEvent;
		}
	}

	// 기초 소모품 아이템의 모든 것
	public class ItemBaseUseable
	{
		public int index { get; set; }
		public string mainName { get; set; }		// 맨 위에 사용될 핵심 이름
		public string typeText { get; set; }		// 바로 아래 적을 타입
		public int buyGold { get; set; }			// 구매 골드 장비와 똑같이 -1 판매불가 0보다 크거나 같을 때 판매가능
		public int sellGold { get; set; }          // 판매 골드 장비와 똑같이 -1 판매불가 0보다 크거나 같을 때 판매가능
		public string mainDescription { get; set; }// 아이템의 효과 설명
		public string subDescriton { get; set; }	// 아이템의 서사 설명
		public string typeFunc { get; set; }		// 소모품 사용시 어떻게 작동될지의 기능을 담음
		public int funcValue { get; set; }				// 소모품 사용시 적용될 값 물약은 +- 증가값, 효과 기능들은 번호로 쓰일 예정
		public int count { get; set; }              // 현재 보유량
		public int stack { get; set; }              // 최대 스택량

		public ItemBaseUseable()
		{
			mainName = "";
			typeText = "";
			buyGold = 0;
			sellGold = 0;
			mainDescription = "";
			subDescriton = "";
			typeFunc = "";
			funcValue = 0;
			count = 0;
			stack = 1;
		}

		StringBuilder itemText;
		public override string ToString()
		{
			if (itemText == null) itemText = new StringBuilder();

			itemText.Clear();

			itemText.Append(index);
			itemText.Append("\nname: "+ mainName);
			itemText.Append("\ntype: "+typeText);
			itemText.Append("\nbuyGold: "+buyGold);
			itemText.Append("\nsellGold: "+sellGold);
			itemText.Append("\nmainDesc: "+mainDescription);
			itemText.Append("\nsubDesc: "+subDescriton);
			itemText.Append("\ntypeFunc"+typeFunc);
			itemText.Append("\nFuncValue: "+ funcValue);
			itemText.Append("\ncount: "+count);
			itemText.Append("\nstack: "+stack);
			return itemText.ToString();
		}
		public void Init(int _index,string _mainName, string _typeText, int _buyGold, int _sellGold, string _mainDescription, string _subDescriton, string _typeFunc, int _value, int _itemCount,int _stack)
		{
			index = _index;
			mainName = _mainName;
			typeText = _typeText;
			buyGold = _buyGold;
			sellGold = _sellGold;
			mainDescription = _mainDescription;
			subDescriton = _subDescriton;
			typeFunc = _typeFunc;
			funcValue = _value;
			count = _itemCount;
			stack = _stack;
		}

		public void Init(ItemBaseUseable _data)
		{
			index = _data.index;
			mainName = _data.mainName;
			typeText = _data.typeText;
			buyGold = _data.buyGold;
			sellGold = _data.sellGold;
			mainDescription = _data.mainDescription;
			subDescriton = _data.subDescriton;
			typeFunc = _data.typeFunc;
			funcValue = _data.funcValue;
			count = _data.count;
			stack = _data.stack;
		}

		public int AddCount(int _count)
		{
			// 999 < 1000
			if (IsAddCount(_count) == false)
			{
				count = stack;
				return (count + _count) - stack;
			}

			count += _count;
			return 0;
		}
		public bool IsAddCount(int _count)
		{
			return (stack > count + _count);
		}
		

		public int SubstactCount(int _count)
		{
			//		1	2
			if (count - _count < 0)
			{
				int remain = _count - count;    // 나머지 값
				count = 0;
				return remain;
			}
			else
			{
				count -= _count;
				return count;
			}
			return 0;
		}
	}

	// 기초 재료 아이템의 모든 것
	public class ItemBaseResource
	{
		public int index { get; set; }
		public string mainName { get; set; }       // 맨 위에 사용될 핵심 이름
		public string typeText { get; set; }       // 바로 아래 적을 타입
		public int buyGold { get; set; }           // 구매 골드 장비와 똑같이 -1 판매불가 0보다 크거나 같을 때 판매가능
		public int sellGold { get; set; }          // 판매 골드 장비와 똑같이 -1 판매불가 0보다 크거나 같을 때 판매가능
		public string description { get; set; }// 아이템의 효과 설명
		public int count { get; set; }              // 현재 보유량
		public int stack { get; set; }             // 최대 스택량
		StringBuilder itemText;

		public override string ToString()
		{
			if (itemText == null) itemText = new StringBuilder();

			itemText.Clear();

			itemText.Append(index);
			itemText.Append("\nname: " + mainName);
			itemText.Append("\ntype: " + typeText);
			itemText.Append("\nbuyGold: " + buyGold);
			itemText.Append("\nsellGold: " + sellGold);
			itemText.Append("\ndesc: " + description);
			itemText.Append("\ncount: " + count);
			itemText.Append("\nstack: " + stack);
			return itemText.ToString();
		}

		public void Init(int _index, string _mainName, string _typeText, int _buyGold, int _sellGold, string _description,int _itemCount, int _stack)
		{
			index = _index;
			mainName = _mainName;
			typeText = _typeText;
			buyGold = _buyGold;
			sellGold = _sellGold;
			description = _description;
			count = _itemCount;
			stack = _stack;
		}

		public void Init(ItemBaseResource _data)
		{
			index = _data.index;
			mainName = _data.mainName;
			typeText = _data.typeText;
			buyGold = _data.buyGold;
			sellGold = _data.sellGold;
			description = _data.description;
			count = _data.count;
			stack = _data.stack;
		}
		public int AddCount(int _count)
		{
			// 999 < 1000
			if (IsAddCount(_count) == false)
			{
				count = stack;
				return (count + _count) - stack;
			}

			count += _count;
			return 0;
		}
		public bool IsAddCount(int _count)
		{
			return (stack > count + _count);
		}

		public int SubstactCount(int _count)
		{
			if (count - _count < 0)
			{
				int remain = _count - count;    // 나머지 값
				count = 0;
				return remain;
			}
			else
			{
				count -= _count;
				return count;
			}
			return 0;
		}
	}


	#region ScriptObject에 쓰이는 것
	// ScriptableObject에 쓰입니다
	// 필드에 떨어지는 아이템 모든 것
	[System.Serializable]
	public class ItemEquiptScriptObject
	{
		// using UnityEngine;을 스크립트 상에서 맨 위에 사용하면 좋지만 
		// tooltip 기능을 여기서밖에 안쓰기 때문에 
		// using UnityEngine은 쓰지 않았습니다.
		// 그리고 이 스크립트도 MonoBehaviour를 상속하지 않기 때문에 더더욱 안적었습니다.
		[UnityEngine.Tooltip("아이템 번호")]public int itemIndex;        // 아이템 고유 번호
		[UnityEngine.Tooltip("해당 아이템을 %확률로 드랍할 것인가?")] public int itemPercent;		// 아이템을 n%확률로 드랍할 퍼센티지
	}

	[System.Serializable]
	public class ItemUseableScriptObject
	{
		[UnityEngine.Tooltip("아이템 번호")] public int itemIndex;
		[UnityEngine.Tooltip("해당 아이템을 %확률로 드랍할 것인가?")] public int itemPercent;
		[UnityEngine.Tooltip("아이템 최소 드롭 개수")] public int itemMinCount;   
		[UnityEngine.Tooltip("아이템 최대 드롭 개수")] public int itemMaxCount;	// 아이템 최대 드롭값 최소와 최대가 같으면 Min값으로 아이템 넣어짐
	}

	[System.Serializable]
	public class ItemResourceScriptObject
	{
		[UnityEngine.Tooltip("아이템 번호")] public int itemIndex;
		[UnityEngine.Tooltip("해당 아이템을 %확률로 드랍할 것인가?")] public int itemPercent;
		[UnityEngine.Tooltip("아이템 최소 드롭 개수")] public int itemMinCount;
		[UnityEngine.Tooltip("아이템 최대 드롭 개수")] public int itemMaxCount;	// 아이템 최대 드롭값 최소와 최대가 같으면 Min값으로 아이템 넣어짐
	}
	#endregion

	[System.Serializable]
	public class ItemData
	{
		[UnityEngine.Tooltip("Type [String To 한글]주석 참고")] public string Type;   // "장비" / "소모품" / "재료"
		[UnityEngine.Tooltip("Type의 번호")] public int Index; // 아이템 번호
		[UnityEngine.Tooltip("장비1로, 소모품, 재료 = 획득 개수")] public int Count;	// 장비 안쓰임, 소모품 & 재료 : 드랍 개수
		StringBuilder itemText;
		public ItemData()
		{
			Type = "";
			Index = 0;
			Count = 0;
		}

		public void SetData(ref ItemData _data)
		{
			Type = _data.Type;
			Index = _data.Index;
			Count = _data.Count;
		}


		public override string ToString()
		{
			if (itemText == null) itemText = new StringBuilder();

			itemText.Clear();

			itemText.Append(Type);
			itemText.Append("\nidx : " + Index);
			itemText.Append("\ncount : " + Count);
			return itemText.ToString();
		}
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="_dataTable">ref 이 변수는 몬스터가 갖고있는 스크립터블 오브젝트 변수를 받습니다.</param>
	/// <param name="_itemData"></param>
	public static void CreateItem(ref EnemyDropTableToScriptableObject _dataTable, out ItemData _itemData )
	{
		_itemData = new ItemData();
		int random = 0;

		random = UnityEngine.Random.Range(0, 100);
		UnityEngine.Debug.Log((random < _dataTable.equiptPercent) + "\n random" + random + "\t equiptPercent" + _dataTable.equiptPercent);
		if (random < _dataTable.equiptPercent)
		{
			UnityEngine.Debug.Log("장비 인");
			if (_dataTable.equipt == null)
			{
#if UNITY_EDITOR
				UnityEngine.Debug.LogError("Enemy ScriptableObject에서 장비 리스트가 없습니다.");
				//return;
				// 골드로 생성하기 위해 return을 하지 않음
#endif
			}
			else
			{
				foreach (var item in _dataTable.equipt)
				{
					random = UnityEngine.Random.Range(0, 100);   // 개별 아이템 드롭 확률
					if (random < item.itemPercent)
					{
						if (item.itemPercent <= 0)
						{
#if UNITY_EDITOR
							UnityEngine.Debug.LogError("아이템 생성 실패\n스크립터블 장비에서 갖고있는 개별 아이템 퍼센티지 값이 0입니다. \n name :" + item.itemIndex);
#endif
							return;
						}
						_itemData.Index = item.itemIndex;
						_itemData.Type = "장비";
						_itemData.Count = 1;
						UnityEngine.Debug.Log(_itemData.ToString());
						return;
					}
				}
			}
		}
		
		random = UnityEngine.Random.Range(0, 100);
		UnityEngine.Debug.Log((random < _dataTable.useablePercent) + "\n random" + random + "\t useablePercent" + _dataTable.useablePercent);
		if (random < _dataTable.useablePercent)
		{
			UnityEngine.Debug.Log("소모품 인");
			if (_dataTable.useable == null)
			{
#if UNITY_EDITOR
				UnityEngine.Debug.LogError("Enemy ScriptableObject에서 소모품 리스트가 없습니다.");
#endif
			}
			else
			{
				foreach (var item in _dataTable.useable)
				{
					random = UnityEngine.Random.Range(0, 100);
					if (random <= item.itemPercent)
					{
						if (item.itemPercent <= 0)
						{
#if UNITY_EDITOR
							UnityEngine.Debug.LogError("아이템 생성 실패\n스크립터블 소모품에서 갖고있는 개별 아이템 퍼센티지 값이 0입니다. \n name :" + item.itemIndex);
#endif
							return;
						}
						_itemData.Index = item.itemIndex;
						_itemData.Type = "소모품";
						_itemData.Count = UnityEngine.Random.Range(item.itemMinCount, item.itemMaxCount);
						UnityEngine.Debug.Log(_itemData.ToString());
						return;
					}
				}
			}
		}
		random = UnityEngine.Random.Range(0, 100);
		UnityEngine.Debug.Log((random < _dataTable.resourcePercent) + "\n random" + random + "\t resourcePer" + _dataTable.resourcePercent);
		if (random < _dataTable.resourcePercent)
		{
			UnityEngine.Debug.Log("재료 인");
			if (_dataTable.resource == null)
			{
#if UNITY_EDITOR
				UnityEngine.Debug.LogError("Enemy ScriptableObject에서 재료 리스트가 없습니다.");
#endif
			}
			else
			{
				foreach (var item in _dataTable.resource)
				{
					random = 0; UnityEngine.Random.Range(0, 100);
					if (random <= item.itemPercent)
					{
						if (item.itemPercent <= 0)
						{
#if UNITY_EDITOR
							UnityEngine.Debug.LogError("아이템 생성 실패\n스크립터블 제료에서 갖고있는 개별 아이템 퍼센티지 값이 0입니다. \n name :" + item.itemIndex);
#endif
							return;
						}
						_itemData.Index = item.itemIndex;
						_itemData.Type = "재료";
						_itemData.Count = UnityEngine.Random.Range(item.itemMinCount, item.itemMaxCount);
						UnityEngine.Debug.Log(_itemData.ToString());
						return;
					}
				}
			}
		}

		_itemData.Type = "골드";
		_itemData.Index = 0;
		_itemData.Count = UnityEngine.Random.Range(_dataTable.minInGameGold,_dataTable.maxInGameGold);
		return;

	}
}