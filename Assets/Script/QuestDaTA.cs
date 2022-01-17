using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string questName; // 퀘스트이름
    public int[] npcId;      // 퀘스트와 관련된 npc id

    public QuestData() { }

    public QuestData(string name,int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
