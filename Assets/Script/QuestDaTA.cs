using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string questName; // 퀘스트 타이틀
    public int[] npcId;      // 퀘스트와 관련된 npc id를 저장하는 정수형 배열

    public QuestData() { }

    public QuestData(string name,int[] npc)//생성자
    {
        questName = name;
        npcId = npc;
    }
}
