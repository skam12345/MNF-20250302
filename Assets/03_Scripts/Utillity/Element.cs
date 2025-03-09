
public class Elemental
{
	public enum ELEMENT_TYPE: byte
	{
		None,
		Dark,
		Holy,
		Fire,
		Ice,
		Nature,
		earth
	}
	private ELEMENT_TYPE element;
	public ELEMENT_TYPE ELEMENT { get { return element; }  set { element = value; } }


	public int ToInt()
	{
		switch (element)
		{
			case ELEMENT_TYPE.Dark: return 0;
			case ELEMENT_TYPE.Holy: return 1;
			case ELEMENT_TYPE.Fire: return 2;
			case ELEMENT_TYPE.Ice: return 3;
			case ELEMENT_TYPE.Nature: return 4;
			case ELEMENT_TYPE.earth: return 5;
			default:break;
		}
		return -1;
	}

	public void Init(string _elementStr)
	{
		switch (_elementStr)
		{
			case "dark":
				element = ELEMENT_TYPE.Dark; break;
			case "holy":
				element = ELEMENT_TYPE.Holy; break;
			case "fire":
				element = ELEMENT_TYPE.Fire; break;
			case "ice":
				element = ELEMENT_TYPE.Ice; break;
			case "nature":
				element = ELEMENT_TYPE.Nature; break;
			case "earth":
				element = ELEMENT_TYPE.earth; break;
			default: break;
		}
	}

	public string ToString()
	{
		string str = "";
		switch (element)
		{
			case ELEMENT_TYPE.Dark:
				str = "鞠孺加己";
				break;
			case ELEMENT_TYPE.Holy:
				str = "己加己";
				break;
			case ELEMENT_TYPE.Fire:
				str = "拳加己";
				break;
			case ELEMENT_TYPE.Ice:
				str = "倔澜加己";
				break;
			case ELEMENT_TYPE.Nature:
				str = "磊楷加己";
				break;
			case ELEMENT_TYPE.earth:
				str = "顶加己";
				break;
			default: break;
		}

		return str;
	}


	public bool IsElementalCompatibilityCheck(ref ELEMENT_TYPE _targetElement)
	{
		bool check = false;

		switch (element)
		{
			case ELEMENT_TYPE.Dark:
				if (_targetElement == ELEMENT_TYPE.Holy) return true;
				break;
			case ELEMENT_TYPE.Holy:
				if (_targetElement == ELEMENT_TYPE.Dark) return true;
				break;
			case ELEMENT_TYPE.Fire:
				if (_targetElement == ELEMENT_TYPE.Ice) return true;
				break;
			case ELEMENT_TYPE.Ice:
				if (_targetElement == ELEMENT_TYPE.Fire) return true;
				break;
			case ELEMENT_TYPE.Nature:
				if (_targetElement == ELEMENT_TYPE.earth) return true;
				break;
			case ELEMENT_TYPE.earth:
				if (_targetElement == ELEMENT_TYPE.Nature) return true;
				break;
			default: break;
		}
		return false;
	}
}