using UnityEngine;
using static ItemEnum;

public class ItemFieldImage : MonoBehaviour
{
	[SerializeField] private Sprite[] diamondList;

	public Sprite GetItemImage(ITEMFIELD _index, int _subIndex)
	{
		switch (_index)
		{
			//case ITEMFIELD.None:
			//	return null;
			case ITEMFIELD.White_Diamond: return diamondList[0];
			case ITEMFIELD.Black_Diamond: return diamondList[1];
			case ITEMFIELD.Red_Diamond:	return diamondList[2];
			case ITEMFIELD.Blue_Diamond: return diamondList[3];
			case ITEMFIELD.Green_Diamond: return diamondList[4];
			case ITEMFIELD.Yello_Diamond: return diamondList[5];
			default:
				return null;
		}
	}


}