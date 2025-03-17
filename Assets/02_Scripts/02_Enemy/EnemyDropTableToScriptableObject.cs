using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDropTable", menuName = "Scriptable Object/ItemDropScriptableObject", order = 0)]
public class EnemyDropTableToScriptableObject : ScriptableObject
{
	public List<ItemBaseClass.ItemEquiptScriptObject> equipt;
	public List<ItemBaseClass.ItemUseableScriptObject> useable;
	public List<ItemBaseClass.ItemResourceScriptObject> resource;
	public int minInGameGold;
	public int maxInGameGold;

	public int equiptPercent ;
	public int useablePercent ;
	public int resourcePercent ;
}