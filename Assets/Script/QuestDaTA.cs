using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public string questName; // ����Ʈ�̸�
    public int[] npcId;      // ����Ʈ�� ���õ� npc id

    public QuestData() { }

    public QuestData(string name,int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
