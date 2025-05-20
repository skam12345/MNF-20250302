using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Sample_Discription : MonoBehaviour
{

    public GameObject onOff;
    public GameObject auraEffect;
    public PlayableDirector director;
    public UITextBox uITextBox;

    public bool flag_timeline = true;

    private void Start()
    {
        uITextBox = GameObject.Find("Conversation").GetComponent<UITextBox>();
        director = gameObject.GetComponent<PlayableDirector>();
        director.extrapolationMode = DirectorWrapMode.Hold;
    }


    //타임라인 일시정지
    public void PauseTimeline()
    {
        if (director != null)
        {
            flag_timeline = true;
            director.Pause(); // 현재 위치에서 정지
        }
    }

    //버튼에 사용할 재생,TODO: 이거 누르면서 다음 문장 재생되게!!
    public void PlayTimeline()
    {
        if (director != null && flag_timeline)
        {
            flag_timeline = false;
            uITextBox.Next_CoroutineSet();
            director.Play(); // 현재 위치에서 시작
        }
        Debug.Log("재생함");
    }

    public void GetLobby()
    {
        SceneManager.LoadScene("02_LobbyScene");
    }
}
