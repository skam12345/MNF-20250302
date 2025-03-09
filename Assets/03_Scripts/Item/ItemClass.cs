using System.Text;
using static UnityEditor.Progress;

public class ItemBaseClass
{
	// 기초 장비 아이템의 모든 것
	public class ItemBaseEquipment
	{
		public string name { get; set; }	// 이름
		public string typeText { get; set; }	// 종류
		public int grade { get; set; }		// 등급 or 스타
		public int enforce{ get; set; }		// 강화
		public int needLv { get; set; }		// 아이템 최소 레벨
		public int buyGold { get; set; }	// -1 구매불가 0이상 판매 가능
		public int sellGold { get; set; }	// -1 판매불가 0이상 판매 가능
		public float itemBaseHP { get; set; }    // 아이템 장착시 올라가는 Hp량
		public float itemBaseMP { get; set; }    // 아이템 장착시 올라가는 Mp량
		public float itemBaseAtk { get; set; }	// 아이템 장착시 올라가는 Atk
		public float itemBaseDef { get; set; }	// 아이템 장착시 올라가는 Def
		public float criRate { get; set; }	// 아이템 장착시 올라가는 크리확률
		public float criDmg { get; set; }	// 아이템 장착시 올라가는 크리데미지
		public int enchantRate { get; set; }	// 아이템 장착시 재료합성 컨텐츠에서 올라가는 행운 량
		public string description { get; set; }	// 설명
		public int skillEvent { get; set; } // 아이템 장착 시 스킬을 사용할 수 있는 번호

		StringBuilder itemText;

		public override string ToString()
		{
			if (itemText == null) itemText = new StringBuilder();

			itemText.Clear();

			itemText.Append(name);
			itemText.Append(typeText);
			itemText.Append(grade);
			itemText.Append(needLv);
			itemText.Append(enforce);
			itemText.Append(buyGold);
			itemText.Append(sellGold);
			itemText.Append(itemBaseHP);
			itemText.Append(itemBaseMP);
			itemText.Append(itemBaseAtk);
			itemText.Append(itemBaseDef);
			itemText.Append(criRate);
			itemText.Append(criDmg);
			itemText.Append(enchantRate);
			itemText.Append(description);
			itemText.Append("");
			return itemText.ToString();
		}

		public void Init(string _name, string _typeText, int _grade, int _needLv, int _enforce,
			int _buygold, int _sellgold, 
			float _itemHp, float _itemMp, 
			float _itemAtk, float _itemDef,
			float _criRate, float _criDmg,
			int _enchant, string _desc, int _skillEvent)
		{
			name = _name; typeText = _typeText; grade = _grade; needLv = _needLv; enforce = _enforce;
			buyGold = _buygold; sellGold = _sellgold;
			itemBaseHP = _itemHp; itemBaseMP = _itemMp;
			itemBaseAtk = _itemAtk; itemBaseDef = _itemDef;
			criRate = _criRate; criDmg = _criDmg;
			enchantRate = _enchant; description = _desc; skillEvent = _skillEvent;
		}

		public void Init(ItemBaseEquipment _data)
		{
			name = _data.name;
			typeText = _data.typeText;
			grade = _data.grade;
			needLv = _data.needLv;
			enforce = _data.enforce;
			buyGold = _data.buyGold;
			sellGold = _data.sellGold;
			itemBaseHP = _data.itemBaseHP;
			itemBaseMP = _data.itemBaseMP;
			itemBaseAtk = _data.itemBaseAtk;
			itemBaseDef = _data.itemBaseDef;
			criRate = _data.criRate;
			criDmg = _data.criDmg;
			enchantRate = _data.enchantRate;
			description = _data.description;
			skillEvent = _data.skillEvent;
		}
	}

	// 기초 소모품 아이템의 모든 것
	public class ItemBaseUseable
	{
		public string mainName { get; set; }		// 맨 위에 사용될 핵심 이름
		public string typeText { get; set; }		// 바로 아래 적을 타입
		public int buyGold { get; set; }			// 구매 골드 장비와 똑같이 -1 판매불가 0보다 크거나 같을 때 판매가능
		public int sellGold { get; set; }          // 판매 골드 장비와 똑같이 -1 판매불가 0보다 크거나 같을 때 판매가능
		public string mainDescription { get; set; }// 아이템의 효과 설명
		public string subDescriton { get; set; }	// 아이템의 서사 설명
		public string typeFunc { get; set; }		// 소모품 사용시 어떻게 작동될지의 기능을 담음
		public int value { get; set; }				// 소모품 사용시 적용될 값 물약은 +- 증가값, 효과 기능들은 번호로 쓰일 예정
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
			value = 0;
			count = 0;
			stack = 1;
		}

		public void Init(string _mainName, string _typeText, int _buyGold, int _sellGold, string _mainDescription, string _subDescriton, string _typeFunc, int _value, int _itemCount,int _stack)
		{
			mainName = _mainName;
			typeText = _typeText;
			buyGold = _buyGold;
			sellGold = _sellGold;
			mainDescription = _mainDescription;
			subDescriton = _subDescriton;
			typeFunc = _typeFunc;
			value = _value;
			count = _itemCount;
			stack = _stack;
		}

		public void Init(ItemBaseUseable _data)
		{
			mainName = _data.mainName;
			typeText = _data.typeText;
			buyGold = _data.buyGold;
			sellGold = _data.sellGold;
			mainDescription = _data.mainDescription;
			subDescriton = _data.subDescriton;
			typeFunc = _data.typeFunc;
			value = _data.value;
			count = _data.count;
			stack = _data.stack;
		}

		public int AddCount(int _count)
		{
			// 999 < 1000
			if (stack < count + _count)
			{
				count = stack;
				int temp = (count + _count) - stack;

				return temp;
			}

			count += _count;
			return 0;
		}
	}

	// 기초 재료 아이템의 모든 것
	public class ItemBaseResource
	{
		public string mainName { get; set; }       // 맨 위에 사용될 핵심 이름
		public string typeText { get; set; }       // 바로 아래 적을 타입
		public int buyGold { get; set; }           // 구매 골드 장비와 똑같이 -1 판매불가 0보다 크거나 같을 때 판매가능
		public int sellGold { get; set; }          // 판매 골드 장비와 똑같이 -1 판매불가 0보다 크거나 같을 때 판매가능
		public string description { get; set; }// 아이템의 효과 설명
		public int count { get; set; }              // 현재 보유량
		public int stack { get; set; }             // 최대 스택량

		public void Init(string _mainName, string _typeText, int _buyGold, int _sellGold, string _description,int _itemCount, int _stack)
		{
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
			if (stack < count + _count)
			{
				count = stack;
				int temp = (count + _count) - stack;

				return temp;
			}

			count += _count;
			return 0;
		}
	}


	#region ScriptObject에 쓰이는 것
	// ScriptableObject에 쓰입니다
	// 필드에 떨어지는 아이템 모든 것
	[System.Serializable]
	public class ItemEquiptScriptObject
	{
		public int itemIndex;		// 아이템 고유 번호
		public int itemPercent;		// 아이템을 n%확률로 드랍할 퍼센티지
	}

	[System.Serializable]
	public class ItemUseableScriptObject
	{
		public int itemIndex;       // 아이템 고유 번호
		public int itemPercent;     // 아이템을 n%확률로 드랍할 퍼센티지
		public int itemMinCount;	// 아이템 최소 드롭값
		public int itemMaxCount;	// 아이템 최대 드롭값 최소와 최대가 같으면 Min값으로 아이템 넣어짐
	}

	[System.Serializable]
	public class ItemResourceScriptObject
	{
		public int itemIndex;       // 아이템 고유 번호
		public int itemPercent;     // 아이템을 n%확률로 드랍할 퍼센티지
		public int itemMinCount;    // 아이템 최소 드롭값
		public int itemMaxCount;    // 아이템 최대 드롭값 최소와 최대가 같으면 Min값으로 아이템 넣어짐
	}
	#endregion

	[System.Serializable]
	public class ItemData
	{
		public string Type;	// "장비" / "소모품" / "재료"
		public int Index;	// 아이템 번호
		public int Count;	// 장비 안쓰임, 소모품 & 재료 : 드랍 개수
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
	}


	/// <summary>
	/// 사용법
	/// 
	/// 
	/// </summary>
	/// <param name="_dataTable"></param>
	public static void CreateItem(ref EnemyDropTableToScriptableObject _dataTable, out ItemData _itemData )
	{
		_itemData = new ItemData();
		int random = UnityEngine.Random.Range(0, 100);
			
		// equpt값이 있다면
		if( _dataTable.equipt != null)
		{
			if (random < _dataTable.equiptPercent)	// 장비를 드랍할 수 있나요?
			{
				foreach (var item in _dataTable.equipt)
				{
					random = UnityEngine.Random.Range(0, 100);	// 개별 아이템 체크
					if (random < item.itemPercent)
					{
						_itemData.Type = "장비";
						_itemData.Index = item.itemIndex;
						_itemData.Count = 1;	// 의미없음
						return;
					}
				}
			}
		}
		else if( _dataTable.useable != null)
		{
			random = UnityEngine.Random.Range(0, 100);
			if (random < _dataTable.useablePercent)
			{
				foreach (var item in _dataTable.useable)
				{
					random = UnityEngine.Random.Range(0, 100);
					if (random < item.itemPercent)
					{
						_itemData.Type = "소모품";
						_itemData.Index = item.itemIndex;

						if (item.itemMaxCount == item.itemMinCount)
							_itemData.Count = item.itemMinCount;
						else
							_itemData.Count = UnityEngine.Random.Range(item.itemMinCount, item.itemMaxCount);
						return;
					}
				}
			}
		}
		else if( _dataTable.resource != null)
		{
			random = UnityEngine.Random.Range(0, 100);
			if (random < _dataTable.useablePercent)
			{
				foreach (var item in _dataTable.useable)
				{
					random = UnityEngine.Random.Range(0, 100);
					if (random < item.itemPercent)
					{
						_itemData.Type = "재료";
						_itemData.Index = item.itemIndex;

						if (item.itemMaxCount == item.itemMinCount)
							_itemData.Count = item.itemMinCount;
						else
							_itemData.Count = UnityEngine.Random.Range(item.itemMinCount, item.itemMaxCount);
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