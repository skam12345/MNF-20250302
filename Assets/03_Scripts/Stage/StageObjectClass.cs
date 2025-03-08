[System.Serializable]
// Serializabling for object from json (JSON으로 부터의 직렬화 하기 위한 객체)
public class StageObjectClass
{
    // Property of Json Instance Section - Serializabling for variable from json (JSON 인스턴스 속성 영역 - JSON으로부터의 직렬화 하기 위한 변수)
    public int stageNum;
    public int subNum;
    public string dungeonName;
    public int rewardExp;
    public int rewardGold;
    public string difficulty;
    public string monster1;
    public string monster2;
    public string monster3;
    public string monster4;
    public int bossidx;
    public string description;

    // Setter Section [It setting to inner data in the each for property] (Setter 영역 [각 부속 속성에 내부값을 셋팅함])
    public void setStageNum(int stageNum) { this.stageNum = stageNum; }
    public void setSubNum(int subNum) { this.subNum = subNum; }
    public void setDungeonName(string dungeonName) { this.dungeonName = dungeonName; }
    public void setRewardExp(int rewardExp) { this.rewardExp = rewardExp; }
    public void setRewardGold(int rewardGold) { this.rewardGold = rewardGold; }
    public void setDifficulty(string difficulty) { this.difficulty = difficulty; }
    public void setMonster1(string monster1) { this.monster1 = monster1; }
    public void setMonster2(string monster2) { this.monster2 = monster2; }
    public void setMonster3(string monster3) { this.monster3 = monster3; }
    public void setMonster4(string monster4) { this.monster4 = monster4; }
    public void setBossidx(int bossidx) { this.bossidx = bossidx; }
    public void setDescription(string description) { this.description = description; }

    // Getter Section [When it prove the each of property by self , get the inner data] (Getter 영역 [각 속성 자체임을 증명할 때 내부 데이터를 불러옴]
    public int getStageNum() { return stageNum; }
    public int getSubNum() { return subNum; }
    public string getDungeonName() { return dungeonName; }
    public int getRewardExp() { return rewardExp; }
    public int getRewardGold() { return rewardGold; }
    public string getDifficulty() { return difficulty; }
    public string getMonster1() { return monster1; }
    public string getMonster2() { return monster2; }
    public string getMonster3() { return monster3; }
    public string getMonster4() { return monster4; }
    public int getBossidx() { return bossidx; }
    public string getDescription() { return description; }
 }
