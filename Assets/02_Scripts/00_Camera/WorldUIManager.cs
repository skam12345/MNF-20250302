using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AddressableAssets.HostingServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using UnityEngine.TextCore.Text;
using UnityEditor.Localization.Plugins.XLIFF.V12;


public class WorldUIManager : MonoBehaviour
{
    // 필드씬에서 던전씬으로 이동할때 UI표기 및 스테이지 불러오기
    // 이 스크립트는 던전 인튜로듀스에서 가지고 있음

    public CinemachineVirtualCamera cam;



    //닿으면 열리는 창 - 일반 팝업 이미지(띄우기) 
    public GameObject dungeonPopup;
    public Transform targetDungeon;


    //버튼누르면 나오는 창 - 디테일 확장 ui 가져오기
    public GameObject dungeonIntroduce;
    UnityEngine.TextAsset txtFile; //Jsonfile
    public string dungeonName;
    public string dungeonDescription;
    public Image dungeonBGImage;
    public GameObject stageBtnBundle;
    public GameObject centerCharacter;

    //버튼 세트 가져와야함
    //여기서는 ui를 켜주는 역할만함. 그리고 btn의 인자를 받으면 거기에 맞는 json을 불러오는 역할을 한다.

    private void Awake()
    {
        dungeonPopup = GameObject.Find("DungeonPopup");
        dungeonIntroduce = GameObject.Find("DungeonIntroduce");
        stageBtnBundle = GameObject.Find("StageBtnBundle");
        dungeonIntroduce.SetActive(false);
        centerCharacter = GameObject.Find("CenterCharacter");

        cam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        //1. 콜라이더에 닿으면(PlayerWorldMove)
        //2. 이 스크립트에서 인스턴스로 스테이지 제이슨을 당겨옴
        //2. 이 스크립트에서 당겨와서 준트윈으로 애니메이션 재생
        //3. 그리고 json파일 받아오고 이름 이미지 등록

        {
            var jsonitemFIle = Resources.Load<UnityEngine.TextAsset>("Jsons/StageTable");
            txtFile = jsonitemFIle;
        }

    }

    //화면에 작은 팝업 키기  + json불러오기
    public void OnDungeonPopup() //
    {
        
        //일단 데려와 여기서만씀   심플제이슨 쓰기 기본임
        int _stageMainNum = StageDataManager.Instance.stageMainNum;
        string json = txtFile.text;
        var jsonData = JSON.Parse(json);
        int idx = _stageMainNum; // 매개변수

        dungeonPopup.transform.position = targetDungeon.transform.position;
        Animator animator = dungeonPopup.GetComponent<Animator>();
        animator.Play("StageUIOn");


        //계산식 ### : 제이슨의 첫번째 인수를 받음. 그걸 1+(5 x n-1)으로 해서 리턴하면 버튼의 매개변수는 678910 / 1112131415가된다. 그러면  m+(5 x idx-1)
        // 필요하면 jsondata앞에 (int)로 강제형변환하면댐

        //버튼 글씨 변경해줌
        stageBtnBundle.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][0 +(5 * (idx-1))]["dungeonName"]);
        stageBtnBundle.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][1 +(5 * (idx-1))]["dungeonName"]);
        stageBtnBundle.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][2 +(5 * (idx-1))]["dungeonName"]);
        stageBtnBundle.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][3 +(5 * (idx-1))]["dungeonName"]);
        stageBtnBundle.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][4 +(5 * (idx-1))]["dungeonName"]);

    }

    //화면에 작은 팝업 끄기
    public void OffDungeonPopup()
    {
        Animator animator = dungeonPopup.GetComponent<Animator>();
        animator.Play("StageUIOff");
    }




    public void OnDetailUI()
    {
        //이건 ㄹㅇ 트윈이 들어가야함
        Animator[] Playeranimators = centerCharacter.GetComponentsInChildren<Animator>();
        foreach (Animator animator in Playeranimators)
        {
            animator.Play("idle");
        }
            dungeonIntroduce.SetActive(true);
        //Jun_TweenRuntime[] gameObjects = battlesceneui.GetComponents<Jun_TweenRuntime>();
        //gameObjects[0].Play();
    }
    public void OffDetailUI()
    {
        dungeonIntroduce.SetActive(false);
    }



    //이건 서브스테이지용 내부 노란 긴 버튼임
    public void StageSubBtn(int _stageBtn)
    {
        string json = txtFile.text;
        var jsonData = JSON.Parse(json);
        int mainNum = StageDataManager.Instance.stageMainNum;
        int subNum = StageDataManager.Instance.stageSubNum;
        

        subNum = _stageBtn;

        Debug.Log($"현재 던전은 {mainNum}-{subNum} 스테이지입니다.");
        Debug.Log($"그래서 씬이 넘어가면 Stage{(mainNum)}-{(subNum)}을 불러오도록 하겠습니다.");

        StageDataManager.Instance.monster1 = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][subNum-1 + (5 * (mainNum - 1))]["monster1"]);
        StageDataManager.Instance.monster2 = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][subNum-1 + (5 * (mainNum - 1))]["monster2"]);
        StageDataManager.Instance.monster3 = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][subNum-1 + (5 * (mainNum - 1))]["monster3"]);
        StageDataManager.Instance.monster4 = (jsonData[$"DungeonList{StageDataManager.Instance.stageDungeonType}"][subNum-1 + (5 * (mainNum - 1))]["monster4"]);
        Debug.Log($"몬스터 1번은 {StageDataManager.Instance.monster1} 번 몬스터입니다.");
        Debug.Log($"몬스터 2번은 {StageDataManager.Instance.monster2} 번 몬스터입니다.");
        Debug.Log($"몬스터 3번은 {StageDataManager.Instance.monster3} 번 몬스터입니다.");
        Debug.Log($"몬스터 4번은 {StageDataManager.Instance.monster4} 번 몬스터입니다.");


    }





    private void GobackTown()
    {
        // 1.마을 가는 연출
        // 준트윈 재생
        // 2.마을씬으로 이동함
        SceneManager.LoadScene("03_TownScene");
    }
}
