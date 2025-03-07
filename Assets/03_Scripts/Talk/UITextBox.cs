using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITextBox : MonoBehaviour
{
	public Text textName; // 캐릭터 이름
	public Text textContent; // 캐릭터 대사

	public Image faceLocation;
	public GameObject choiceBox;
	public GameObject choiceButton;
	public GameObject copyButton;
	public GameObject choiceView;
	public GameObject choiceScroll;
	public GameObject talkService;
	public GameObject singleService;

	[SerializeField]
	private UIStage uIStage;
	private Dictionary<string, ShopConversationData> shopDataDict = new Dictionary<string, ShopConversationData>();
	private int index = 0;

	private List<TalkData> shopList = new List<TalkData>();
	private bool isTyping = false;
	private bool isChoice = false;
	private int defaultScene = 0;

	// Awake 삭제 - 

	
	public void OnInit(string _str)
	{
		Init(_str);
	}

	private void Init(string _fileName)
	{
		TextAsset jsonFile = Resources.Load<TextAsset>("Jsons/"+_fileName);
		//Debug.Log((jsonFile == null) + jsonFile.name);

		if (jsonFile != null)
		{
			shopDataDict.Clear();
			shopList.Clear();

			shopDataDict = JsonConvert.DeserializeObject<Dictionary<string, ShopConversationData>>(jsonFile.text);
			foreach (string key in shopDataDict.Keys)
			{
				// 가져온 시나리오 json을 이용해 시나리오 진행할 List 형식으로 변환하는 코드
				if (shopDataDict.ContainsKey(key))
				{
					TalkData data = new TalkData();
					string faceImage = shopDataDict[key].FaceImage;
					string character = shopDataDict[key].Character;
					string dialogue = shopDataDict[key].Dialogue;
					data.setFaceImage(faceImage);
					data.setCharacter(character);
					data.setDialogue(dialogue);
					//string event_trigger = shopDataDict[key].Event_Trigger;
					int defaultScene = 0;
					List<string> condition = new List<string>();
					List<int> nextScene = new List<int>();
					// S000 / S00 특정 문자 제거하기 위한 정규식
					string pattern = "S000|S00";
					// choice 와 choice next scene 체크하는 조건문들
					if (shopDataDict[key].Choice_1 != null)
					{
						condition.Add(shopDataDict[key].Choice_1);
						nextScene.Add(int.Parse(Regex.Replace(shopDataDict[key].Choice_1_Next_Scene, pattern, "", RegexOptions.IgnoreCase).Trim()));
					}
					if (shopDataDict[key].Choice_2 != null)
					{
						condition.Add(shopDataDict[key].Choice_2);
						nextScene.Add(int.Parse(Regex.Replace(shopDataDict[key].Choice_2_Next_Scene, pattern, "", RegexOptions.IgnoreCase).Trim()));
					}
					if (shopDataDict[key].Choice_3 != null)
					{
						condition.Add(shopDataDict[key].Choice_3);
						nextScene.Add(int.Parse(Regex.Replace(shopDataDict[key].Choice_3_Next_Scene, pattern, "", RegexOptions.IgnoreCase).Trim()));
					}

					// default next scene 체크하는 조건문
					if (shopDataDict[key].Default_Next_Scene != null)
					{
						defaultScene = int.Parse(Regex.Replace(shopDataDict[key].Default_Next_Scene, pattern, "", RegexOptions.IgnoreCase).Trim());
						data.setDefaultScene(defaultScene);
					}
					if (condition.Count != 0)
					{
						data.setCondition(condition);
						data.setNextScene(nextScene);
					}

					// event_trigger 체크하는 조건문
					//if (event_trigger != null)
					//{
					//    string[] trigger = event_trigger.Split('/');
					//    foreach(var item in trigger)
					//    {


					//    }
					//}

					shopList.Add(data);
				}
			}
		}
	}



	#region 대화 넘기기
	public void Next()
	{
		foreach (TalkData data in shopList)
		{
			if (data.getDefaultScene() != 0)
			{
				defaultScene = data.getDefaultScene();
				break;
			}
		}
		// 선택지가 떴을 때 다시 타이핑 효과 안나오게
		if (isChoice) return;
		// 타이핑 효과 진행중에 대화창 입력하면 문장 완성되는 기능
		if (isTyping)
		{
			isTyping = false;
			StopAllCoroutines();
			TypingCompleteSentence(shopList[index].getDialogue());
			if (shopList[index].getCondition() == null)
			{
				return;
			}
		}
		if (index == 0)
		{
			index = defaultScene - 1;
		}
		// 선택지가 존재할 때
		if (shopList[index].getCondition() != null)
		{
			isConditionPerform();
		}
		else
		{
			if (shopList[index].getDefaultScene() != 0)
			{
				index = shopList[index].getDefaultScene() - 1;
				talkService.SetActive(false);
				return;
			}
			index++;
			if (index < shopList.Count - 1 && shopList[index + 1].getCondition() != null)
			{
				// 시나리오가 진행되는 중간에 선택지가 있으면 전 시나리오가 밀려서 실행되는 버그가 있어
				// 다음 시나리오 선택지가 있는 것을 체크 해줌.
				index++;
				isConditionPerform();
			}
		}
		Debug.Log(shopList.Count - 1 + " : " + index);
		if (index <= shopList.Count - 1)
		{
			StartCoroutine(CallSpriteImage(shopList[index].getFaceImage()));
			StartCoroutine(TypeName(shopList[index].getCharacter()));
			StartCoroutine(TypingSentence(shopList[index].getDialogue()));
		}
	}
    #endregion

    #region 선택지 대화 넘기기
    public void StageSelectNext()
	{
        foreach (TalkData data in shopList)
        {
            if (data.getDefaultScene() != 0)
            {
                defaultScene = data.getDefaultScene();
                break;
            }
        }
        // 선택지가 떴을 때 다시 타이핑 효과 안나오게
        if (isChoice) return;
        // 타이핑 효과 진행중에 대화창 입력하면 문장 완성되는 기능
        if (isTyping)
        {
            isTyping = false;
            StopAllCoroutines();
            TypingCompleteSentence(shopList[index].getDialogue());
            if (shopList[index].getCondition() == null)
            {
                return;
            }
        }
        if (index == 0)
        {
			index++;
        }

        // 선택지가 존재할 때
        if (shopList[index].getCondition() != null)
        {
            isConditionPerform();
        }
        else
        {
            if (shopList[index].getDefaultScene() != 0)
            {
                index = shopList[index].getDefaultScene() - 1;
                talkService.SetActive(false);
				SceneManager.LoadScene(1);
                return;
            }
            index++;
            if (index < shopList.Count - 1 && shopList[index + 1].getCondition() != null)
            {
                // 시나리오가 진행되는 중간에 선택지가 있으면 전 시나리오가 밀려서 실행되는 버그가 있어
                // 다음 시나리오 선택지가 있는 것을 체크 해줌.
                index++;
                isConditionPerform();
            }
        }
        Debug.Log(shopList.Count - 1 + " : " + index);
        if (index <= shopList.Count - 1)
        {
            StartCoroutine(CallSpriteImage(shopList[index].getFaceImage()));
            StartCoroutine(TypeName(shopList[index].getCharacter()));
            StartCoroutine(TypingSentence(shopList[index].getDialogue()));
        }
    }
    #endregion

    public void StageStartNextBtn()
	{
        foreach (TalkData data in shopList)
        {
            if (data.getDefaultScene() != 0)
            {
                defaultScene = data.getDefaultScene();
                break;
            }
        }
        if (index <= defaultScene)
        {
            if (isTyping)
            {
                isTyping = false;
                StopAllCoroutines();
                TypingCompleteSentence(shopList[index].getDialogue());
                return;
            }
            if (index == 0)
            {
                index++;
            }
            if (shopList[index].getDefaultScene() != 0)
            {
                if (textContent.text == shopList[index].getDialogue())
                {
                    talkService.SetActive(false);
                    return;
                }
            }
            if (index <= shopList.Count - 1)
            {
                StartCoroutine(CallSpriteImage(shopList[index].getFaceImage()));
                StartCoroutine(TypeName(shopList[index].getCharacter()));
                StartCoroutine(TypingSentence(shopList[index].getDialogue()));
            }
            if (shopList[index].getDefaultScene() == 0)
            {
                index++;
            }
        }
    }

    #region 선택지 생성
    public void isConditionPerform()
	{
		DestroyChoice();
		List<string> conditionList = shopList[index].getCondition();
		for (int i = 0; i < conditionList.Count; i++)
		{
			int idx = i;
			// GridLayout 설정하기
			// 그냥 버튼을 넣었을 때 엇나가는 버그가 있어 Update가 안되어있는 경우 다시 초기화 해주기 위해 Grid/Size Filter 재설정.
			choiceButton = Resources.Load<GameObject>("Prefebs/TextBox/PrefebButton");
			GridLayoutGroup choiceBoxGrid = choiceBox.GetComponent<GridLayoutGroup>();
			ContentSizeFitter choiceBoxSizeFilter = choiceBox.GetComponent<ContentSizeFitter>();
			choiceView.GetComponent<RectTransform>().sizeDelta = new Vector2(320, (60 * conditionList.Count + 5));
			choiceScroll.GetComponent<RectTransform>().localPosition = new Vector3(592.9999f, (60 * conditionList.Count + 100), 0);
			choiceBoxGrid.cellSize = new Vector2(300, 50);
			choiceBoxGrid.spacing = new Vector2(0, 5);
			choiceBoxGrid.startAxis = GridLayoutGroup.Axis.Vertical;
			choiceBoxGrid.childAlignment = TextAnchor.UpperCenter;
			choiceBoxGrid.constraint = GridLayoutGroup.Constraint.FixedRowCount;
			choiceBoxGrid.constraintCount = conditionList.Count;
			choiceBoxSizeFilter.verticalFit = ContentSizeFitter.FitMode.MinSize;
			if (choiceButton != null)
			{
				copyButton = Instantiate(choiceButton, choiceBox.transform);
				choiceBox.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() => SelectChocie(idx));
				copyButton.GetComponentInChildren<Text>().text = conditionList[i];
				copyButton.GetComponentInChildren<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				copyButton.GetComponentInChildren<Text>().fontSize = 20;
			}
			isChoice = true;
		}
	}
	#endregion

	#region 선택지 비우기
	public void DestroyChoice()
	{
		// choiceBox에 존재하는 버튼의 부속성들이 존재하기 때문에 GameObject List로 받아서 객체 내 서브 객체들을 삭제함. 
		List<GameObject> children = new List<GameObject>();

		foreach (Transform child in choiceBox.transform)
		{
			children.Add(child.gameObject);
		}

		foreach (GameObject child in children)
		{
			Destroy(child);
		}
	}
	#endregion

	#region 선택지 선택
	void SelectChocie(int index01)
	{
		isChoice = false;
		DestroyChoice();
		index = shopList[index].getNextScene()[index01] - 1;
		StartCoroutine(CallSpriteImage(shopList[index].getFaceImage()));
		StartCoroutine(TypeName(shopList[index].getCharacter()));
		StartCoroutine(TypingSentence(shopList[index].getDialogue()));
	}
	#endregion


	#region 대화 플레이
	public void PlayText()
	{
		// 첫번 째 시나리오 실행.
		StopAllCoroutines();
		StartCoroutine(CallSpriteImage(shopList[index].getFaceImage()));
		StartCoroutine(TypeName(shopList[index].getCharacter()));
		StartCoroutine(TypingSentence(shopList[index].getDialogue()));
	}


	IEnumerator CallSpriteImage(string imageName)
	{
		Sprite sprite = null;

		if (imageName == "loan")
		{
			sprite = Resources.Load<Sprite>($"Sprites/TalkFace/{imageName}");
		}
		else
		{
			sprite = Resources.Load<Sprite>($"Sprites/TalkFace/{imageName}");
		}


		if (sprite != null)
		{
			faceLocation.sprite = sprite;
		}

		yield return null;
	}

	IEnumerator TypeName(string name)
	{
		textName.text = name;
		yield return null;
	}

	IEnumerator TypingSentence(string sentence)
	{
		// 타이핑 중인지 체크하는 플래그 변수
		isTyping = true;
		textContent.text = string.Empty;
		foreach (var letter in sentence)
		{
			textContent.text += letter;
			yield return new WaitForSeconds(0.03f);
		}
		// 타이핑 완료했을 때 타이핑 효과 끝났다는 것을 알림.
		if (textContent.text.Length == sentence.Length)
		{
			isTyping = false;
		}
	}

	public void TypingCompleteSentence(string sentence)
	{
		textContent.text = sentence;
	}
	#endregion
}