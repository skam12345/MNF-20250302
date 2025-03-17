using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public static BgmManager Instance { get; private set; } // 싱글톤 인스턴스
    //TODO:  ★★ BgmManager.Instance.PlayBGM(0); 같은 방식으로 어디서든 접근 가능

    private AudioSource bgmsound; // 오디오 소스
    [SerializeField]
    private AudioClip[] bgmClips; // 배경음 리스트

    void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        { Instance = this; DontDestroyOnLoad(gameObject); }// 씬이 바뀌어도 유지}
        else
        { Destroy(gameObject); return; }

        bgmsound = GetComponent<AudioSource>();
        LoadBGM();
        PlayBGM(0);
    }

    void LoadBGM()
    {
        // Resources/BGM 폴더 안의 모든 오디오 클립 로드
        bgmClips = Resources.LoadAll<AudioClip>("BGM");

        if (bgmClips.Length > 0)
        {
            Debug.Log("BGM 파일 로드 완료: " + bgmClips.Length + "개");
        }
        else
        {
            Debug.LogError("BGM 파일을 찾을 수 없습니다.");
        }
    }


    // 매개변수 받아서 번호에 맞는 BGM 재생
    public void PlayBGM(int index)
    {
        if (index >= 0 && index < bgmClips.Length)
        {
            bgmsound.clip = bgmClips[index];
            bgmsound.Play();
        }
        else
        {
            Debug.LogError("잘못된 BGM 인덱스입니다.");
        }
    }
}