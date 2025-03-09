using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : MonoBehaviour
{
	private static StageMgr instance;

	private Dictionary<string, StageObjectClass> stageJsonDict = new Dictionary<string, StageObjectClass>();
	public List<StageObjectClass> stageJsonList = new List<StageObjectClass>();

	private string selectStageText;
	public string SelectStageText { get { return selectStageText; } set { selectStageText = value; } }

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void Start()
	{
		TextAsset jsonFile = Resources.Load<TextAsset>("Jsons/StageTable");

		if (jsonFile != null)
		{
			stageJsonDict = JsonConvert.DeserializeObject<Dictionary<string, StageObjectClass>>(jsonFile.text);
			foreach (string key in stageJsonDict.Keys)
			{
				StageObjectClass data = new StageObjectClass();
				{
					/*
					 StageJson 안에 monster1 ~ monster4 속성 중에 null 값이 있어 string 값으로 받았으니
					 Stage에서 데이터를 제 위치에 뿌릴 때 null 값은 넘어가고 string으로 된 숫자 값은 int로 
					 파싱 시킨 후 사용하세요.
					 */
					data = stageJsonDict[key];
					stageJsonList.Add(data);
				}
			}
		}
	}


	/// <summary>
	/// 사용법
	/// StageObjectClass stageData = null;
	/// GetStageData("1-1", out stageData);
	/// 
	/// 목적
	/// 어디서든 스테이지 정보를 받아오기 위함
	/// 
	/// 사용처
	/// BattleScene이 시작됐을 때 스테이지 정보가 필요하며 BattleScene Start() 함수에서 사용될 예정
	/// 
	/// </summary>
	/// <param name="_stage">스테이지의 [n-n] 형식의 텍스트</param>
	/// <param name="_stageData">받아갈 데이터</param>
	public void GetStageData(string _stageLabel, out StageObjectClass _stageData)
	{
		_stageData = null;

		foreach (var item in stageJsonList)
		{
			if(item.dungeonName == _stageLabel)
			{
				_stageData = new StageObjectClass();
				_stageData.Init(item);		//얕은 복사
				return;
			}
		}

		// bool로 함수형식이 바꿔지면 에러 메세지를 띄우기가 가능
	}
}