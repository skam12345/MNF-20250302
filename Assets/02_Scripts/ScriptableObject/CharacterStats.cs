using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Game/CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public string characterName;
    public int maxLv = 50;
    public int element;
    // holy1, dark 2, fire 3, ice 4, earth 5, nature 6

    public int baseExp = 100;// 기본경험치
    public float growthRate = 1.5f;// 증가율

    public float baseHp;
    public float baseMp;
    public int baseAtk;

    public float baseCriChance = 5f;
    public float baseCriDamage = 110f;


    // 필요 경험치 계산 (공식 적용) 레벨업 시 사용
    public int GetExpRequirement(int level)
    {
        return Mathf.RoundToInt(baseExp * Mathf.Pow(growthRate, level - 1));
    }
}