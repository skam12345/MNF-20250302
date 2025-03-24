using System.Text;

[System.Serializable]
public class EnemyBaseData
{
	private int index;
	public int Index { get { return index; } set { index = value; } }

	private string name;
	public string Name { get { return name; } set { name = value; } }

	private int lv;
	public int LV { get { return lv; } set { lv = value; } }


	private float currhp;
	public float CurrHP { get { return currhp; } set { currhp = value; } }

	private float maxHp;
	public float MaxHP { get { return maxHp; } set { maxHp = value; } }


	private float currMP;
	public float CurrMP { get { return currMP; } set { currMP = value; } }

	private float maxMP;
	public float MaxMP { get { return maxMP; } set { maxMP = value; } }


	private float baseAttack;
	public float ATK { get { return baseAttack; } set { baseAttack = value; } }

	private float baseDef;
	public float DEF { get { return baseDef; } set { baseDef = value; } }


	private float criticalRate;
	public float CRIRATE { get { return criticalRate; } set { criticalRate = value; } }

	private float criticalDmg;
	public float CRIDMG { get { return criticalDmg; } set { criticalDmg = value; } }

	private Elemental element;
	public Elemental ELEMENTAL { get; set; }

	private StringBuilder logText;

	public void Init(int _index, string _name, int _lv, 
		float _currHp, float _maxHp, float _currMp, float _maxMp, 
		float _atk, float _def, float _criRate, float _criDmg, 
		string _element)
	{
		index = _index;
		name = _name;
		lv = _lv;
		currhp = _currHp;
		maxHp = _maxHp;
		currMP = _currMp;
		maxMP = _maxMp;
		baseAttack = _atk;
		baseDef = _def;
		criticalRate = _criRate;
		criticalDmg = _criDmg;

		if(element == null) element = new Elemental();
		element.Init(_element);
	}

	public void Init(int _index, string _name, int _lv,
		float _currHp, float _maxHp, float _currMp, float _maxMp,
		float _atk, float _def, float _criRate, float _criDmg,
		Elemental _element)
	{
		index = _index;
		name = _name;
		lv = _lv;
		currhp = _currHp;
		maxHp = _maxHp;
		currMP = _currMp;
		maxMP = _maxMp;
		baseAttack = _atk;
		baseDef = _def;
		criticalRate = _criRate;
		criticalDmg = _criDmg;

		element = _element;
	}

public void Init(ref EnemyBaseData _data)
	{
		index = _data.Index;
		name = _data.Name;
		lv = _data.LV;
		currhp = _data.CurrHP;
		maxHp = _data.MaxHP;
		currMP = _data.CurrMP;
		maxMP = _data.MaxMP;
		baseAttack = _data.ATK;
		baseDef = _data.DEF;
		criticalRate = _data.CRIRATE;
		criticalDmg = _data.CRIDMG;


		if (element == null)
		{
			element = new Elemental();
			element.ELEMENT = Elemental.ELEMENT_TYPE.None;
		}
		else
		{
			element = _data.ELEMENTAL;
		}
	}

	public string ToString()
	{
		if (logText == null) logText = new StringBuilder();
		
		logText.Clear();

		logText.Append("Name : " + name);
		logText.Append("\n Lv : " + lv);
		logText.Append("\n cHp : " + currhp);
		logText.Append("\n mHp : " + maxHp);
		logText.Append("\n cMp : " + currMP);
		logText.Append("\n mMp : " + maxMP);
		logText.Append("\n atk : " + baseAttack);
		logText.Append("\n def : " + baseDef);
		logText.Append("\n criRate : " + criticalRate);
		logText.Append("\n criDmg : " + criticalDmg);

		if (element == null)
		{
			logText.Append("\n Lv : + element = null");
		}
		else
		{
			logText.Append("\n element : " + element.ELEMENT.ToString());
		}
		return logText.ToString();
	}
}