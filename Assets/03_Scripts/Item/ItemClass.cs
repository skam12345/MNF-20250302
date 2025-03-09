using System.Text;
using static UnityEditor.Progress;

public class ItemBaseClass
{
	// ���� ��� �������� ��� ��
	public class ItemBaseEquipment
	{
		public string name { get; set; }	// �̸�
		public string typeText { get; set; }	// ����
		public int grade { get; set; }		// ��� or ��Ÿ
		public int enforce{ get; set; }		// ��ȭ
		public int needLv { get; set; }		// ������ �ּ� ����
		public int buyGold { get; set; }	// -1 ���źҰ� 0�̻� �Ǹ� ����
		public int sellGold { get; set; }	// -1 �ǸźҰ� 0�̻� �Ǹ� ����
		public float itemBaseHP { get; set; }    // ������ ������ �ö󰡴� Hp��
		public float itemBaseMP { get; set; }    // ������ ������ �ö󰡴� Mp��
		public float itemBaseAtk { get; set; }	// ������ ������ �ö󰡴� Atk
		public float itemBaseDef { get; set; }	// ������ ������ �ö󰡴� Def
		public float criRate { get; set; }	// ������ ������ �ö󰡴� ũ��Ȯ��
		public float criDmg { get; set; }	// ������ ������ �ö󰡴� ũ��������
		public int enchantRate { get; set; }	// ������ ������ ����ռ� ���������� �ö󰡴� ��� ��
		public string description { get; set; }	// ����
		public int skillEvent { get; set; } // ������ ���� �� ��ų�� ����� �� �ִ� ��ȣ

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

	// ���� �Ҹ�ǰ �������� ��� ��
	public class ItemBaseUseable
	{
		public string mainName { get; set; }		// �� ���� ���� �ٽ� �̸�
		public string typeText { get; set; }		// �ٷ� �Ʒ� ���� Ÿ��
		public int buyGold { get; set; }			// ���� ��� ���� �Ȱ��� -1 �ǸźҰ� 0���� ũ�ų� ���� �� �ǸŰ���
		public int sellGold { get; set; }          // �Ǹ� ��� ���� �Ȱ��� -1 �ǸźҰ� 0���� ũ�ų� ���� �� �ǸŰ���
		public string mainDescription { get; set; }// �������� ȿ�� ����
		public string subDescriton { get; set; }	// �������� ���� ����
		public string typeFunc { get; set; }		// �Ҹ�ǰ ���� ��� �۵������� ����� ����
		public int value { get; set; }				// �Ҹ�ǰ ���� ����� �� ������ +- ������, ȿ�� ��ɵ��� ��ȣ�� ���� ����
		public int count { get; set; }              // ���� ������
		public int stack { get; set; }              // �ִ� ���÷�

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

	// ���� ��� �������� ��� ��
	public class ItemBaseResource
	{
		public string mainName { get; set; }       // �� ���� ���� �ٽ� �̸�
		public string typeText { get; set; }       // �ٷ� �Ʒ� ���� Ÿ��
		public int buyGold { get; set; }           // ���� ��� ���� �Ȱ��� -1 �ǸźҰ� 0���� ũ�ų� ���� �� �ǸŰ���
		public int sellGold { get; set; }          // �Ǹ� ��� ���� �Ȱ��� -1 �ǸźҰ� 0���� ũ�ų� ���� �� �ǸŰ���
		public string description { get; set; }// �������� ȿ�� ����
		public int count { get; set; }              // ���� ������
		public int stack { get; set; }             // �ִ� ���÷�

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


	#region ScriptObject�� ���̴� ��
	// ScriptableObject�� ���Դϴ�
	// �ʵ忡 �������� ������ ��� ��
	[System.Serializable]
	public class ItemEquiptScriptObject
	{
		public int itemIndex;		// ������ ���� ��ȣ
		public int itemPercent;		// �������� n%Ȯ���� ����� �ۼ�Ƽ��
	}

	[System.Serializable]
	public class ItemUseableScriptObject
	{
		public int itemIndex;       // ������ ���� ��ȣ
		public int itemPercent;     // �������� n%Ȯ���� ����� �ۼ�Ƽ��
		public int itemMinCount;	// ������ �ּ� ��Ӱ�
		public int itemMaxCount;	// ������ �ִ� ��Ӱ� �ּҿ� �ִ밡 ������ Min������ ������ �־���
	}

	[System.Serializable]
	public class ItemResourceScriptObject
	{
		public int itemIndex;       // ������ ���� ��ȣ
		public int itemPercent;     // �������� n%Ȯ���� ����� �ۼ�Ƽ��
		public int itemMinCount;    // ������ �ּ� ��Ӱ�
		public int itemMaxCount;    // ������ �ִ� ��Ӱ� �ּҿ� �ִ밡 ������ Min������ ������ �־���
	}
	#endregion

	[System.Serializable]
	public class ItemData
	{
		public string Type;	// "���" / "�Ҹ�ǰ" / "���"
		public int Index;	// ������ ��ȣ
		public int Count;	// ��� �Ⱦ���, �Ҹ�ǰ & ��� : ��� ����
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
	/// ����
	/// 
	/// 
	/// </summary>
	/// <param name="_dataTable"></param>
	public static void CreateItem(ref EnemyDropTableToScriptableObject _dataTable, out ItemData _itemData )
	{
		_itemData = new ItemData();
		int random = UnityEngine.Random.Range(0, 100);
			
		// equpt���� �ִٸ�
		if( _dataTable.equipt != null)
		{
			if (random < _dataTable.equiptPercent)	// ��� ����� �� �ֳ���?
			{
				foreach (var item in _dataTable.equipt)
				{
					random = UnityEngine.Random.Range(0, 100);	// ���� ������ üũ
					if (random < item.itemPercent)
					{
						_itemData.Type = "���";
						_itemData.Index = item.itemIndex;
						_itemData.Count = 1;	// �ǹ̾���
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
						_itemData.Type = "�Ҹ�ǰ";
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
						_itemData.Type = "���";
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

		_itemData.Type = "���";
		_itemData.Index = 0;
		_itemData.Count = UnityEngine.Random.Range(_dataTable.minInGameGold,_dataTable.maxInGameGold);
		return;

	}
}