using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDaTA
{
    public string questName; // ����Ʈ�̸�
    public int[] npcId;      // ����Ʈ�� ������ npc id

    public QuestDaTA(string name,int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
