using System;

[Serializable]
public class PlayerDataClass
{
	// 내부 처리 코드 private 
	// 외부 겟셋 
	private string name;
	public string Name { get { return name; } set { name = value; } }

	private int lv;
	public int LV { get { return lv; } set { lv = value; } }


	private float currHP;
	public float CurrHP { get { return currHP; } set { currHP = value; } }

	private float maxHP;
	public float MaxHP { get { return maxHP; } set { maxHP = value; } }


	private float currMP;
	public float CurrMP { get { return currMP; } set { currMP = value; } }

	private float maxMP;
	public float MaxMP { get { return maxMP; } set { maxMP = value; } }


	private float baseAttack;
	public float ATK { get { return baseAttack; } set { baseAttack = value; } }

	private float baseDef;
	public float DEF { get { return baseDef; } set { baseDef = value; } }


	private float criRate;
	public float CRIRATE { get { return criRate; } set { criRate = value; } }

	private float criticalDmg;
	public float CRIDMG { get { return criticalDmg; } set { criticalDmg = value; } }


	public float currExp;
	public float CurrEXP { get { return currExp; } set { currExp = value; } }

	private float needEXP;
	public float NeedEXP { get { return needEXP; } set { needEXP = value; } }


	private Elemental element;
	private PlayerEnum.MODEL_NUMBER_NAME modelNumber;

	System.Text.StringBuilder logText;
	public override string ToString()
	{
		if (logText == null) logText = new System.Text.StringBuilder();
		logText.Clear();

		logText.Append("name : " +name);
		logText.Append("\nlv : " +lv);
		logText.Append("\ncurrHP : " +currHP + "\t MaxHp : " + maxHP);
		logText.Append("\nCurrMP : " +currMP + "\t MaxMp : " + maxMP);
		logText.Append("\nAtk : " + baseAttack);
		logText.Append("\nDef : " +baseDef);
		logText.Append("\ncriRate : " +criRate);
		logText.Append("\ncriDmg : " +criticalDmg);
		logText.Append("\ncurrExp : " +currExp);
		logText.Append("\nneedExp : " + needEXP);
		return logText.ToString();
	}

	public void Init(string _name, int _lv, float _maxHP, float _maxMP, float _atk, float _def, float _criRate, float _criDmg, int _currExp, int _needExp)
	{
		name = _name;
		lv = _lv;
		maxHP = currHP = _maxHP;
		maxMP = currMP = _maxMP;
		baseAttack = _atk;
		baseDef = _def;
		criRate = _criRate;
		criticalDmg = _criDmg;
		currExp = _currExp;
		needEXP = _needExp;
	}

	public void Init(PlayerDataClass _data)
	{
		name = _data.Name;
		lv = _data.LV;
		maxHP = currHP = _data.MaxHP;
		maxMP = currMP = _data.MaxMP;
		baseAttack = _data.ATK;
		baseDef = _data.DEF;
		criRate = _data.CRIRATE;
		criticalDmg = _data.CRIDMG;
		currExp = _data.CurrEXP;
		needEXP = _data.NeedEXP;
		ElementSetting();
	}


	private void ElementSetting()
	{
		if(element == null) element = new Elemental();

		switch (name)
		{
			case "마왕":
				element.ELEMENT = Elemental.ELEMENT_TYPE.Dark;
				modelNumber = PlayerEnum.MODEL_NUMBER_NAME.Mawang;
				break;
			case "용병1":
				break;
			default:
				
				break;
		}
	}
}