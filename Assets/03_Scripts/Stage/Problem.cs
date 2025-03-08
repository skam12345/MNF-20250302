using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Problem : MonoBehaviour
{


	private Dictionary<string, StageObjectClass> stageDict;
	private List<StageObjectClass> stageList = new List<StageObjectClass>();

	public void Awake()
	{
		TextAsset jsonFile = Resources.Load<TextAsset>("Jsons/StageJson");
		if (jsonFile != null)
		{
			stageDict = JsonConvert.DeserializeObject<Dictionary<string, StageObjectClass>>(jsonFile.text);
			foreach (string key in stageDict.Keys)
			{
				StageObjectClass data = stageDict[key];
				stageList.Add(data);
			}
		}
	}
}