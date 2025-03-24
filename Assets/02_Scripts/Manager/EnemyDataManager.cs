using SimpleJSON;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyDataManager : SingleTonBase<EnemyDataManager>
{
	private List<EnemyBaseData> dataList;

	// 로딩할 때 파일을 하나하나 읽는 순서로 구현하기 위해
	public void OnInit()
	{
		Init();
	}

	private void Init()
	{
		// TestAsset, JsonNode도 다 이 블럭을 지나면 필요없음
		TextAsset txtFile = Resources.Load<TextAsset>("Jsons/MonsterData");
		JSONNode jsonData = JSON.Parse(txtFile.text);
		if (dataList == null)
			dataList = new List<EnemyBaseData>();

		JSONNode targetSeetData = jsonData["Monsters"];
		int max = targetSeetData.Count;


		for (int i = 0; i < max; i++)
		{
			EnemyBaseData data = new EnemyBaseData();
			data.Init(i,
				targetSeetData[i]["name"],
				targetSeetData[i]["lv"].AsInt,
				targetSeetData[i]["max_hp"].AsFloat,
				targetSeetData[i]["max_hp"].AsFloat,
				targetSeetData[i]["max_mp"].AsFloat,
				targetSeetData[i]["max_mp"].AsFloat,
				targetSeetData[i]["atk"].AsFloat,
				targetSeetData[i]["def"].AsFloat,
				targetSeetData[i]["criRate"].AsFloat,
				targetSeetData[i]["criDmg"].AsFloat,
				
				targetSeetData[i]["element"].ToString());

			dataList.Add(data);
		}
	}

	/// <summary>
	/// 데이터를 찾은 뒤 _searchData에 넣습니다.
	/// </summary>
	/// <param name="_name"></param>
	/// <param name="_searchData"></param>
	/// <returns></returns>
	public bool GetData(string _name, out EnemyBaseData _searchData)
	{
		bool dofindsearchData = false;
		_searchData = null;

		foreach (var item in dataList)
		{
			if (item.Name == _name)
			{
				dofindsearchData = true;
				_searchData = item;
				break;
			}
		}
		return dofindsearchData;
	}


	public bool GetData(int _index, out EnemyBaseData _searchData)
	{
		bool dofindsearchData = false;
		_searchData = null;

		if (dataList.Count <= _index) { return dofindsearchData; }
		else if (_index < 0) { return dofindsearchData; }

		_searchData = dataList[_index];
		return dofindsearchData;
	}


	private StringBuilder logText;
	public string ToString(int _index)
	{
		if (logText == null) logText = new StringBuilder();
		logText.Clear();
		logText.Append(dataList[_index].ToString());
		return logText.ToString();
	}

}