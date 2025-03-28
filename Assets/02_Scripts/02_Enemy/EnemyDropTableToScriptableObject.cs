using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDropTable", menuName = "Scriptable Object/ItemDropScriptableObject", order = 0)]
public class EnemyDropTableToScriptableObject : ScriptableObject
{
	public List<ItemBaseClass.ItemEquiptScriptObject> equipt;
	public List<ItemBaseClass.ItemUseableScriptObject> useable;
	public List<ItemBaseClass.ItemResourceScriptObject> resource;
	public int minInGameGold;
	public int maxInGameGold;

	[Header("반드시 이 3개의 확률의 합이 100%가 되어야함")]
	[Tooltip("장비를 얻을 확률 이 확률에 걸리면 장비리스트에서 무조건 드롭되게 설정")] public int equiptPercent ;
	[Tooltip("소모품을 얻을 확률 이 확률에 걸리면 소모품리스트에서 무조건 드롭되게 설정")] public int useablePercent ;
	[Tooltip("재료를 얻을 확률 이 확률에 걸리면 재료리스트에서 무조건 드롭되게 설정")] public int resourcePercent ;

	System.Text.StringBuilder strLog;
	public override string ToString()
	{
		if (strLog == null) strLog = new System.Text.StringBuilder();

		strLog.Clear();
		strLog.Append(name);
		if (equipt != null)
		{
			foreach (var item in equipt)
			{
				strLog.Append("\nequipt" + item.itemIndex + " \t ItemPer" + item.itemPercent);
			}
		}
		if (useable != null)
		{
			foreach (var item in useable)
			{
				strLog.Append("\nuseable" + item.itemIndex + " \t ItemPer" + item.itemPercent + "\tminCount : "+item.itemMinCount + "\t " +item.itemMaxCount);
			}
		}

		if (resource != null)
		{
			foreach (var item in resource)
			{
				strLog.Append("\nresource" + item.itemIndex + " \t ItemPer" + item.itemPercent + "\tminCount : "+item.itemMinCount + "\t " +item.itemMaxCount);
			}
		}
		return strLog.ToString();
	}
}