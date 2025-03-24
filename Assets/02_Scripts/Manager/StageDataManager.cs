using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class StageDataManager : SingleTonBase<StageDataManager>
{
	public int stageDungeonType = 1;
	public int stageMainNum;
	public int stageSubNum;
	public int monster1;
	public int monster2;
	public int monster3;
	public int monster4;
	public int bossIdx;

	public string DungeonType()
	{
		switch (stageDungeonType)
		{
			case 1: return "Stage";
			case 2: return "Event";
			case 3:
				return "Raid";
				break;
		}
		//if default
		return "Stage";
	}







	//뒤에 이해 안가서 새로 만듬

	//private Dictionary<string, StageClass> stageJsonDict = new Dictionary<string, StageClass>();
	//public List<StageClass> stageJsonList = new List<StageClass>();
	private int stageArrayIndex;
	public int StageArrayIndex { get { return stageArrayIndex; } set { stageArrayIndex = value; } }

	private string buddyName { get; set; }
	public string BuddyName { get { return buddyName; } set { buddyName = value; } }

	private List<bool> stageOpenCheck;
	public List<bool> StageOpenCheck { get { return stageOpenCheck; } }
}

	//public void OnInit()
	//{
	//	Init();
	//}
	//private void Init()
	//{
	//	TextAsset jsonFile = Resources.Load<TextAsset>(ResourcesDirectory.Json +"StageTable");

	//	if (jsonFile != null)
	//	{
	//		stageJsonDict = JsonConvert.DeserializeObject<Dictionary<string, StageClass>>(jsonFile.text);
	//		foreach (string key in stageJsonDict.Keys)
	//		{
 //               StageClass data = new StageClass();
	//			{
	//				/*
	//				 StageJson 안에 monster1 ~ monster4 속성 중에 null 값이 있어 string 값으로 받았으니
	//				 Stage에서 데이터를 제 위치에 뿌릴 때 null 값은 넘어가고 string으로 된 숫자 값은 int로 
	//				 파싱 시킨 후 사용하세요.
	//				 */
	//				data = stageJsonDict[key];
	//				stageJsonList.Add(data);
	//			}
	//		}
	//	}

	//	stageOpenCheck = new List<bool>();
	//	for (int i = 0; i < stageJsonList.Count; i++)
	//	{
	//		stageOpenCheck.Add(false);
	//	}
	//	stageOpenCheck[0] = true;
	//	buddyName = "";
	//}


//	public void GetStageData(string _stageLabel, out StageClass _stageData)
//	{
//        OnInit();

//        _stageData = null;

//		foreach (var item in stageJsonList)
//		{
//			if (item.dungeonName == _stageLabel)
//			{
//				_stageData = new StageClass();
//				_stageData.Init(item);      //얕은 복사
//				return;
//			}
//		}

//		// bool로 함수형식이 바꿔지면 에러 메세지를 띄우기가 가능
//	}

//	//초기화하고 스테이지넘버 데이터 받음

//	public void GetStageData(out StageClass _stageData)
//	{
//        OnInit();

//        _stageData = new StageClass();
//		_stageData.Init(stageJsonList[stageArrayIndex]);
//	}
//}