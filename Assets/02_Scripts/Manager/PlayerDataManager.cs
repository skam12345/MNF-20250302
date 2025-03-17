using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class PlayerDataManager : SingleTonBase<PlayerDataManager>
{
	List<PlayerDataClass> playerInfo;

	// 로딩할 때 파일을 하나하나 읽는 순서로 구현하기 위해
	public void OnInit()
	{
		Init();
	}


	private void Init()
	{
		TextAsset txtFile = Resources.Load<TextAsset>("Jsons/PlayerDataJson");
		JSONNode jsonData = JSON.Parse(txtFile.text);
		if (playerInfo == null)
			playerInfo = new List<PlayerDataClass>();

		JSONNode target = jsonData["PlayerState"];
		int max = target.Count;


		for (int i = 0; i < max; i++)
		{
			PlayerDataClass data = new PlayerDataClass();
			data.Init(target[i]["name"].ToString(),1,
				target[i]["max_hp"].AsFloat,
				target[i]["max_mp"].AsFloat,
				target[i]["atk"].AsFloat,
				target[i]["def"].AsFloat,
				target[i]["criRate"].AsFloat,
				target[i]["criDmg"].AsFloat,
				0,
				target[i]["need_exp"].AsInt);

			playerInfo.Add(data);
		}
	}

	public void GetData(int _index, out PlayerDataClass _data)
	{
		_data = null;
		if (_index < 0 || _index >= playerInfo.Count) return;
		_data = new PlayerDataClass();
		_data.Init(playerInfo[_index]);
	}

	public string ToString(int _index)
	{
		if (_index < 0 || _index >= playerInfo.Count) return "";

		PlayerDataClass target = playerInfo[_index];

		return target.ToString();
	}
}