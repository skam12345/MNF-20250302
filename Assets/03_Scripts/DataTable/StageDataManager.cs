using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class StageDataManager : SingleTonBase<StageDataManager>
{
	private Dictionary<string, StageObjectClass> stageJsonDict = new Dictionary<string, StageObjectClass>();
	public List<StageObjectClass> stageJsonList = new List<StageObjectClass>();
	private int stageArrayIndex;
	public int StageArrayIndex { get { return stageArrayIndex; } set { stageArrayIndex = value; } }

	private string buddyName { get; set; }
	public string BuddyName { get { return buddyName; } set { buddyName = value;} }

	private List<bool> stageOpenCheck;
	public List<bool> StageOpenCheck { get { return stageOpenCheck; } }

	public void OnInit()
	{
		Init();
	}
	private void Init()
	{
		TextAsset jsonFile = Resources.Load<TextAsset>(ResourcesDirectory.Json +"StageTable");

		if (jsonFile != null)
		{
			stageJsonDict = JsonConvert.DeserializeObject<Dictionary<string, StageObjectClass>>(jsonFile.text);
			foreach (string key in stageJsonDict.Keys)
			{
				StageObjectClass data = new StageObjectClass();
				{
					/*
					 StageJson �ȿ� monster1 ~ monster4 �Ӽ� �߿� null ���� �־� string ������ �޾�����
					 Stage���� �����͸� �� ��ġ�� �Ѹ� �� null ���� �Ѿ�� string���� �� ���� ���� int�� 
					 �Ľ� ��Ų �� ����ϼ���.
					 */
					data = stageJsonDict[key];
					stageJsonList.Add(data);
				}
			}
		}

		stageOpenCheck = new List<bool>();
		for (int i = 0; i < stageJsonList.Count; i++)
		{
			stageOpenCheck.Add(false);
		}
		stageOpenCheck[0] = true;
		buddyName = "";
	}


	/// <summary>
	/// ����
	/// StageObjectClass stageData = null;
	/// GetStageData("1-1", out stageData);
	/// 
	/// ����
	/// ��𼭵� �������� ������ �޾ƿ��� ����
	/// 
	/// ���ó
	/// BattleScene�� ���۵��� �� �������� ������ �ʿ��ϸ� BattleScene Start() �Լ����� ���� ����
	/// 
	/// </summary>
	/// <param name="_stage">���������� [n-n] ������ �ؽ�Ʈ</param>
	/// <param name="_stageData">�޾ư� ������</param>
	public void GetStageData(string _stageLabel, out StageObjectClass _stageData)
	{
		_stageData = null;

		foreach (var item in stageJsonList)
		{
			if (item.dungeonName == _stageLabel)
			{
				_stageData = new StageObjectClass();
				_stageData.Init(item);      //���� ����
				return;
			}
		}

		// bool�� �Լ������� �ٲ����� ���� �޼����� ���Ⱑ ����
	}

	public void GetStageData(int _stageNumber, out StageObjectClass _stageData)
	{
		_stageData = null;
		//Debug.Log(_stageNumber + "\t" + stageJsonList.Count);
		if (_stageNumber < 0 || stageJsonList.Count <= _stageNumber) return;

		_stageData = new StageObjectClass();
		_stageData.Init(stageJsonList[_stageNumber]);      //���� ����

		// bool�� �Լ������� �ٲ����� ���� �޼����� ���Ⱑ ����
	}

	public void GetStageData(out StageObjectClass _stageData)
	{
		_stageData = new StageObjectClass();
		_stageData.Init(stageJsonList[stageArrayIndex]);
	}
}