using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string questName; // ����Ʈ Ÿ��Ʋ
    public int[] npcId;      // ����Ʈ�� ���õ� npc id�� �����ϴ� ������ �迭

    public QuestData() { }

    public QuestData(string name,int[] npc)//������
    {
        questName = name;
        npcId = npc;
    }
}
