using JetBrains.Annotations;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine.AI;

[System.Serializable]
public class StageObjectClass
{
    // Instance
    public int idx;
    public int stageNum;
    public int subNum;
    public string dungeonName;
    public int rewardExp;
    public int rewardGold;
    public string difficulty;
    public int timer;
    public int monster1;
    public int monster2;
    public int monster3;
    public int monster4;
    public int bossidx;
    public string description;

    //Setter Section
    public void setIdx(int idx) { this.idx = idx; }
    public void setStageNum(int stageNum) { this.stageNum = stageNum; }
    public void setSubNum(int subNum) { this.subNum = subNum;  }
    public void setDungeonName(string dungeonName) { this.dungeonName = dungeonName; }
    public void setRewardExp(int rewardExp) { this.rewardExp = rewardExp;  }
    public void setRewardGold(int rewardGold) { this.rewardGold = rewardGold; }
    public void setDifficulty(string difficulty) { this.difficulty = difficulty; }
    public void setTimer(int timer) { this.timer = timer; }
    public void setMonster1(int monster1) { this.monster1 = monster1; }
    public void setMonster2(int monster2) { this.monster2 = monster2; }
    public void setMonster3(int monster3) { this.monster3 = monster3; }
    public void setMonster4(int monster4) { this.monster4 = monster4; }
    public void setBossidx(int bossidx) { this.bossidx = bossidx; }
    public void setDescription(string description) { this.description = description; }

    // Getter Section
    public int getIdx() { return idx; }
    public int getStageNum() { return stageNum; }
    public int getSubNum() { return subNum; }
    public string getDungeonName() { return dungeonName; }
    public int getRewardExp() { return rewardExp; }
    public int getRewardGold() { return rewardGold; }
    public string getDifficulty() { return difficulty; }
    public int getTimer() { return timer; }
    public int getMonster1() { return monster1; }
    public int getMonster2() { return monster2; }
    public int getMonster3() { return monster3; }
    public int getMonster4() { return monster4; }
    public int getBossidx() { return bossidx; }
    public string getDescription() { return description; }
}
