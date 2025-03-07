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
	public Text textName; // ĳ���� �̸�
	public Text textContent; // ĳ���� ���

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

	// Awake ���� - 

	
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
				// ������ �ó����� json�� �̿��� �ó����� ������ List �������� ��ȯ�ϴ� �ڵ�
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
					// S000 / S00 Ư�� ���� �����ϱ� ���� ���Խ�
					string pattern = "S000|S00";
					// choice �� choice next scene üũ�ϴ� ���ǹ���
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

					// default next scene üũ�ϴ� ���ǹ�
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

					// event_trigger üũ�ϴ� ���ǹ�
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



	#region ��ȭ �ѱ��
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
		// �������� ���� �� �ٽ� Ÿ���� ȿ�� �ȳ�����
		if (isChoice) return;
		// Ÿ���� ȿ�� �����߿� ��ȭâ �Է��ϸ� ���� �ϼ��Ǵ� ���
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
		// �������� ������ ��
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
				// �ó������� ����Ǵ� �߰��� �������� ������ �� �ó������� �з��� ����Ǵ� ���װ� �־�
				// ���� �ó����� �������� �ִ� ���� üũ ����.
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

    #region ������ ��ȭ �ѱ��
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
        // �������� ���� �� �ٽ� Ÿ���� ȿ�� �ȳ�����
        if (isChoice) return;
        // Ÿ���� ȿ�� �����߿� ��ȭâ �Է��ϸ� ���� �ϼ��Ǵ� ���
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

        // �������� ������ ��
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
                // �ó������� ����Ǵ� �߰��� �������� ������ �� �ó������� �з��� ����Ǵ� ���װ� �־�
                // ���� �ó����� �������� �ִ� ���� üũ ����.
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

    #region ������ ����
    public void isConditionPerform()
	{
		DestroyChoice();
		List<string> conditionList = shopList[index].getCondition();
		for (int i = 0; i < conditionList.Count; i++)
		{
			int idx = i;
			// GridLayout �����ϱ�
			// �׳� ��ư�� �־��� �� �������� ���װ� �־� Update�� �ȵǾ��ִ� ��� �ٽ� �ʱ�ȭ ���ֱ� ���� Grid/Size Filter �缳��.
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

	#region ������ ����
	public void DestroyChoice()
	{
		// choiceBox�� �����ϴ� ��ư�� �μӼ����� �����ϱ� ������ GameObject List�� �޾Ƽ� ��ü �� ���� ��ü���� ������. 
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

	#region ������ ����
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


	#region ��ȭ �÷���
	public void PlayText()
	{
		// ù�� ° �ó����� ����.
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
		// Ÿ���� ������ üũ�ϴ� �÷��� ����
		isTyping = true;
		textContent.text = string.Empty;
		foreach (var letter in sentence)
		{
			textContent.text += letter;
			yield return new WaitForSeconds(0.03f);
		}
		// Ÿ���� �Ϸ����� �� Ÿ���� ȿ�� �����ٴ� ���� �˸�.
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