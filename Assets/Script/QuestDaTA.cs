using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDaTA
{
    public string questName; // 퀘스트이름
    public int[] npcId;      // 퀘스트와 연결할 npc id

    public QuestDaTA(string name,int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
