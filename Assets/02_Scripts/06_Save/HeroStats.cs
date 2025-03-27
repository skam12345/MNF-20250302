using UnityEngine;

public class HeroStats : MonoBehaviour
{
    public CharacterStats stats;  // ScriptableObject 연결

    public int lv;

    public int curExp;
    public int maxExp;
    public float maxhp;
    public float hp;
    public float maxmp;
    public int atk;
    [Space(10)]
    [Range(0, 100)]
    public float criChance; //in percentage
    public float criDamage;

    void Start()
    {
        LoadCharacterData();  // 게임 실행 시 저장된 데이터 불러오기 (선택)
    }

    // 🔹 캐릭터 초기화 (기본값 적용)
    void InitializeCharacter()
    {
        maxhp = stats.baseHp;
        maxmp = stats.baseMp;
        atk = stats.baseAtk;
    }

    // 🔹 경험치 획득 함수
    public void GainExperience(int amount)
    {
        if (lv >= stats.maxLv) return;

        curExp += amount;
        CheckLevelUp();
    }

    // 🔹 레벨업 체크
    void CheckLevelUp()
    {
        while (lv < stats.maxLv && curExp >= stats.GetExpRequirement(lv))
        {
            curExp -= stats.GetExpRequirement(lv);
            lv++;
            LevelUp();
        }
    }

    // 🔹 레벨업 시 스탯 증가
    void LevelUp()
    {
        //여기서 스위치나 해서 캐릭터의 속성에 따라 나눠야함
        hp += 10;
        atk += 2;
        criChance += 0.5f;
        criDamage += 2;

        Debug.Log($"{stats.characterName} 레벨업! 현재 레벨: {lv}");
    }




    // 🔹 게임을 종료해도 상태 유지하려면 저장 필요
    void SaveCharacterData()
    {
        PlayerPrefs.SetInt(gameObject.name + "_Level", lv);
        PlayerPrefs.SetInt(gameObject.name + "_Exp", curExp);
        PlayerPrefs.SetFloat(gameObject.name + "_HP", hp);
        PlayerPrefs.Save();
    }

    void LoadCharacterData()
    {
        lv = PlayerPrefs.GetInt(gameObject.name + "_Level", 1);
        curExp = PlayerPrefs.GetInt(gameObject.name + "_Exp", 0);
        hp = PlayerPrefs.GetFloat(gameObject.name + "_HP", stats.baseHp);
    }
}
