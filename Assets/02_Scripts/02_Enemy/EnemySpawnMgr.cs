using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnMgr : MonoBehaviour
{

    public GameObject[] spawnMonsters;
    public Transform[] spawnLocate;

    void Start()
    {
        //몹 스폰 위치 잡기
        int spawnPointCount = 10; // 총 스폰 포인트 수
        spawnLocate = new Transform[spawnPointCount];
        for (int i = 0; i < spawnPointCount; i++)
        {
            string pointName = "SpawnPoint (" + (i) + ")"; // 이름: SpawnPoint1 ~ SpawnPoint20
            GameObject pointObj = GameObject.Find(pointName);
            if (pointObj != null)
            {
                spawnLocate[i] = pointObj.transform;
            }
        }



        //Enemy폴더에서 전체 불러오기
        GameObject[] loadAllMonster;
        loadAllMonster = Resources.LoadAll<GameObject>("Prefebs/Enemy");
        spawnMonsters = loadAllMonster;


        // stageClass.monster1~4를 정수로 변환하여 몬스터 선택
        int monsterIndex1 = StageDataManager.Instance.monster1;
        int monsterIndex2 = StageDataManager.Instance.monster2;
        int monsterIndex3 = StageDataManager.Instance.monster3;
        int monsterIndex4 = StageDataManager.Instance.monster4;

        // spawnLocate 인덱스 랜덤 선택 (중복 방지)
        List<int> availableIndices = Enumerable.Range(0, spawnLocate.Length).ToList();
        System.Random rnd = new System.Random();

        // 4개의 랜덤 위치에 몬스터 소환
        for (int i = 0; i < 4; i++)
        {
            int randIdx = rnd.Next(availableIndices.Count);
            int spawnIdx = availableIndices[randIdx];
            availableIndices.RemoveAt(randIdx); // 중복 방지

            int monsterIndex = 0;
            switch (i)
            {
                case 0: monsterIndex = monsterIndex1; break;
                case 1: monsterIndex = monsterIndex2; break;
                case 2: monsterIndex = monsterIndex3; break;
                case 3: monsterIndex = monsterIndex4; break;
            }

            Instantiate(spawnMonsters[monsterIndex], spawnLocate[spawnIdx].position, Quaternion.identity);
        }
    }


}
