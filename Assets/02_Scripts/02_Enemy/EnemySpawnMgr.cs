using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnMgr : MonoBehaviour
{

    StageClass stageClass = new StageClass();
    public GameObject[] spawnMonsters;


    void Start()
    {
        Debug.Log(stageClass.stageNum);
        Debug.Log(stageClass.subNum);
        Debug.Log(stageClass.monster1);
        Debug.Log(stageClass.monster2);
        Debug.Log(stageClass.monster3);
        Debug.Log(stageClass.monster4);
        Debug.Log(stageClass.bossidx);

        //spawnMonsters[0] = spawnMonsters[int.Parse(stageClass.monster1)];
    }


}
