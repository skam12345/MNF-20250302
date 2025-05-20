using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class Sample_Discription : MonoBehaviour
{

    public GameObject onOff;
    public GameObject auraEffect;
    public PlayableDirector director;

    public bool flag_timeline = true;

    private void Start()
    {
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
        if (director != null)
        {
            flag_timeline = false;
            director.Play(); // 현재 위치에서 시작
        }
        Debug.Log("재생함");
    }
}
